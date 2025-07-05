import atexit
import json
import unittest
from pathlib import Path

from pact import Consumer, Like, Provider

from models.stock.stock_service_response import FilmStock, StockServiceResponse
from service.developer_service import DeveloperService


class EmulsiveFactoryStockContractTest(unittest.TestCase):
    def setUp(self):
        self.pact = Consumer("DeveloperService-Python").has_pact_with(
            Provider('EmulsiveFactory-StockApi'),
            pact_dir = Path(f"{Path().cwd().parents[0]}/SharedPactContracts/ConsumerDriven").__str__()
        )

        self.pact.start_service()
        self.FILM_STOCK_MOCK_RESPONSE = (
            {
                "httpStatusCode": 200,
                "result": {
                    "film": {
                        "name": "CT800",
                        "filmType": 0,
                        "id": Like("91ed96c5-9672-4988-aee8-34ec14eb89a6"),
                        "manufacturer": {
                            "name": "Cinestill",
                            "location": "Germany"
                        },
                        "contacts": [
                            {
                                "name": Like("Andy-bob"),
                                "email": Like("Andy@test.com"),
                                "location": Like("Italy")
                            },
                            {
                                "name": Like("Jane"),
                                "email": Like("Jane@test.com"),
                                "location": Like("Dortmand")
                            }
                        ],
                        "tags": [
                            {
                                "name": "Neon"
                            },
                            {
                                "name": "Night"
                            }
                        ]
                    },
                    "stock": {
                        "inStock": Like(607),
                        "onOrder": Like(9)
                    }
                }
            }
        )

        atexit.register(self.pact.stop_service)
        
    def test_stock_service_consumer_contract(self):

        # Arrange
        (self.pact
            .upon_receiving("A request for a film from the developer service")
            .given("the Emulsive Factory Stock has film")
            .with_request('GET', '/Stock/CT800')
            .will_respond_with(
                status=200,
                headers= {"Content-Type": "application/json; charset=utf-8"},
                body=self.FILM_STOCK_MOCK_RESPONSE
            ))

        expected_response = {
            "httpStatusCode": 200,
            "result": {
                "film": {
                    "name": "CT800",
                    "filmType": 0,
                    "id": "91ed96c5-9672-4988-aee8-34ec14eb89a6",
                    "manufacturer": {
                        "name": "Cinestill",
                        "location": "Germany"
                    },
                    "contacts": [
                        {
                            "name": "Andy-bob",
                            "email": "Andy@test.com",
                            "location": "Italy"
                        },
                        {
                            "name": "Jane",
                            "email": "Jane@test.com",
                            "location": "Dortmand"
                        }
                    ],
                    "tags": [
                        {
                            "name": "Neon"
                        },
                        {
                            "name": "Night"
                        }
                    ]
                },
                "stock": {
                    "inStock": 607,
                    "onOrder": 9
                }
            }
        }

        # Act
        with self.pact:
            developer_service = DeveloperService(self.pact.uri)
            actual_response = developer_service.get_film("CT800")

        # Assert
            self.assertEqual(actual_response.httpStatusCode, 200)

            expected_response = StockServiceResponse[FilmStock].model_validate_json(json.dumps(expected_response))
            self.assertEqual(expected_response, actual_response)


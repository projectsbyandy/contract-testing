import json
import unittest
from pathlib import Path

from pact import Pact, match

from models.stock.stock_service_response import FilmStock, StockServiceResponse
from service.developer_service import DeveloperService

class EmulsiveFactoryStockContractTest(unittest.TestCase):
    def setUp(self):
        self.pact = Pact("DeveloperService-Python", "EmulsiveFactory-StockApi").with_specification("V4")

        self.pact_dir = Path(f"{Path().cwd().parents[0]}/SharedPactContracts/ConsumerDriven").__str__()

        self.FILM_STOCK_MOCK_RESPONSE = {
            "httpStatusCode": 200,
            "result": {
                "film": {
                    "name": "CT800",
                    "filmType": 0,
                    "id": match.uuid("91ed96c5-9672-4988-aee8-34ec14eb89a6"),
                    "manufacturer": {
                        "name": "Cinestill",
                        "location": "Germany"
                    },
                    "contacts": [
                        {
                            "name": match.str("Andy-bob"),
                            "email": match.regex("Andy@test.com", regex=r".+@.+\..+"),
                            "location": match.str("Italy")
                        },
                        {
                            "name": match.str("Jane"),
                            "email": match.regex("Jane@test.com", regex=r".+@.+\..+"),
                            "location": match.str("Dortmand")
                        }
                    ],
                    "tags": [
                        {"name": "Neon"},
                        {"name": "Night"}
                    ]
                },
                "stock": {
                    "inStock": match.int(607),
                    "onOrder": match.int(9)
                }
            }
        }

    def test_stock_service_consumer_contract(self):
        (
            self.pact
            .upon_receiving("A request for a film from the developer service")
            .given("the Emulsive Factory Stock has film")
            .with_request("GET", "/Stock/CT800")
            .will_respond_with(200)
            .with_header("Content-Type", "application/json; charset=utf-8")
            .with_body(self.FILM_STOCK_MOCK_RESPONSE, content_type="application/json")
        )

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
                        {"name": "Andy-bob", "email": "Andy@test.com", "location": "Italy"},
                        {"name": "Jane", "email": "Jane@test.com", "location": "Dortmand"}
                    ],
                    "tags": [
                        {"name": "Neon"},
                        {"name": "Night"}
                    ]
                },
                "stock": {"inStock": 607, "onOrder": 9}
            }
        }

        with self.pact.serve() as mock_server:
            developer_service = DeveloperService(str(mock_server.url))
            actual_response = developer_service.get_film("CT800")

            self.assertEqual(actual_response.httpStatusCode, 200)

            expected = StockServiceResponse[FilmStock].model_validate_json(json.dumps(expected_response))
            self.assertEqual(expected, actual_response)

        self.pact.write_file(self.pact_dir)
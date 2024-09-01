import path from "path";
import { PactV3, MatchersV3, SpecificationVersion, } from "@pact-foundation/pact";
import { StockService } from '../../stockservice';
const { eachLike, like } = MatchersV3;

const provider = new PactV3({
    consumer: "StockService",
    provider: "EmulsiveFactory",
    logLevel: "info",
    dir: path.resolve(process.cwd(), "pacts"),
    spec: SpecificationVersion.SPECIFICATION_VERSION_V3,
    port: 1234
});


const EMULSIVE_FILM_RESPONSE = {
    "httpStatusCode": 200,
    "filmStock": {
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
                    "name": "Andy",
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
};

describe('Stock service test', () => {
    test("Get details of CT800 film ", async () => {
        provider.addInteraction({
            states: [{ description: 'CT800 film exists' }],
            uponReceiving: 'a request for CT800 film details',
            withRequest: {
                method: 'GET',
                path: '/Stock/CT800',
            },
            willRespondWith: {
                status: 200,
                headers: { 'Content-Type': 'application/json' },
                body: EMULSIVE_FILM_RESPONSE,
            },
        });

        await provider.executeTest(async (mockserver) => {
            let stockService = new StockService(mockserver.url);
            let stock = await stockService.getStock("CT800");
            expect(stock).toStrictEqual(EMULSIVE_FILM_RESPONSE);
        });
    });
});
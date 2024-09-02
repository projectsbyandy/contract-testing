import path from "path";
import { PactV3, MatchersV3, SpecificationVersion } from "@pact-foundation/pact";
import { StockService } from '../../stockservice';
const { eachLike, like } = MatchersV3;

const provider = new PactV3({
    consumer: "StockServiceApiJs",
    provider: "EmulsiveFactoryApi",
    logLevel: "info",
    dir: path.resolve(process.cwd(), "../SharedPactContracts/ConsumerDriven"),
    spec: SpecificationVersion.SPECIFICATION_VERSION_V3,
    port: 1234
});


const EMULSIVE_FILM_RESPONSE = {
    "httpStatusCode": 200,
    "filmStock": {
        "film": {
            "name": "CT800",
            "filmType": 0,
            "id": MatchersV3.like("91ed96c5-9672-4988-aee8-34ec14eb89a6"),
            "manufacturer": {
                "name": "Cinestill",
                "location": "Germany"
            },
            "contacts": [
                {
                    "name": MatchersV3.like("Andy-bob"),
                    "email": MatchersV3.like("Andy@test.com"),
                    "location": MatchersV3.like("Italy")
                },
                {
                    "name": MatchersV3.like("Jane"),
                    "email": MatchersV3.like("Jane@test.com"),
                    "location": MatchersV3.like("Dortmand")
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
            "inStock": MatchersV3.like(607),
            "onOrder": MatchersV3.like(9)
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
            expect(stock.httpStatusCode).toBe(200);
            expect(stock.filmStock.film.name).toBe(EMULSIVE_FILM_RESPONSE.filmStock.film.name);
            expect(stock.filmStock.film.filmType).toBe(EMULSIVE_FILM_RESPONSE.filmStock.film.filmType);
            expect(stock.filmStock.stock.inStock).toBe(607);
            expect(stock.filmStock.stock.onOrder).toBe(9);
            expect(stock.filmStock.film.manufacturer).toStrictEqual(EMULSIVE_FILM_RESPONSE.filmStock.film.manufacturer);
            expect(stock.filmStock.film.tags).toStrictEqual(EMULSIVE_FILM_RESPONSE.filmStock.film.tags);
        })
    })
});
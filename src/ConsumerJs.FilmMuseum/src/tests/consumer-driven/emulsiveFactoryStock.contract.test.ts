import path from "path";
import { PactV4, MatchersV3 } from "@pact-foundation/pact";
import {expect, test} from '@jest/globals';
import { IStockService, StockService } from "../../service";

const EMULSIVE_FILM_RESPONSE = {
    "httpStatusCode": 200,
    "result": {
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

describe('Stock service contract test', () => {
    let provider: PactV4

    beforeAll(() => {
        process.env.PACT_DO_NOT_TRACK = "1";
        
        provider = new PactV4({
            consumer: "FilmMuseum-StockServiceApi-Js",
            provider: "EmulsiveFactory-StockApi",
            logLevel: "info",
            dir: path.resolve(process.cwd(), "../SharedPactContracts/ConsumerDriven"),
            port: 1234
        });
    });

    test("Get details of CT800 film", async () => {
        // Arrange
        await provider
            .addInteraction()
            .given('CT800 film exists')
            .uponReceiving('a request for CT800 film details')
            .withRequest('GET', '/Stock/CT800')
            .willRespondWith(200, (builder) =>
                builder
                .headers({ 'Content-Type': 'application/json' })
                .jsonBody(EMULSIVE_FILM_RESPONSE))
            .executeTest(async (mockserver) => {
                // Act
                let stockService: IStockService = new StockService(mockserver.url);
                let stock = await stockService.getStockForFilm("CT800");
                
                // Assert
                expect(stock.httpStatusCode).toBe(200);
                expect(stock.result.film.name).toBe(EMULSIVE_FILM_RESPONSE.result.film.name);
                expect(stock.result.film.filmType).toBe(EMULSIVE_FILM_RESPONSE.result.film.filmType);
                expect(stock.result.stock.inStock).toBe(607);
                expect(stock.result.stock.onOrder).toBe(9);
                expect(stock.result.film.manufacturer).toStrictEqual(EMULSIVE_FILM_RESPONSE.result.film.manufacturer);
                expect(stock.result.film.tags).toStrictEqual(EMULSIVE_FILM_RESPONSE.result.film.tags);
        });
    });
});
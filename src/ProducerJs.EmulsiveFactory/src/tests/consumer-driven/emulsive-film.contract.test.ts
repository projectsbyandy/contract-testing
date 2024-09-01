import { Pact } from '@pact-foundation/pact';
import { StockService } from '../../stockservice';

const provider = new Pact({
  consumer: 'StockService',
  provider: 'EnulsiveFactory',
  port: 1234,
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
        "Contacts": [
          {
            "name": "Andy",
            "email": "Andy@test.com",
            "location": "Munich"
          },
          {
            "name": "Jane",
            "email": "Jane@test.com",
            "location": "Dortmand"
          }
        ],
        "Tags": [
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

describe('Pact with EmulsiveFilm', () => {
  beforeAll(() => provider.setup());
  afterAll(() => provider.finalize());

  describe('when a request for a user is made', () => {
    beforeAll(() =>
      provider.addInteraction({
        state: 'CT800 film exists',
        uponReceiving: 'a request for a user',
        withRequest: {
          method: 'GET',
          path: '/Stock/CT800',
          headers: { Accept: 'application/json' },
        },
        willRespondWith: {
          status: 200,
          headers: { 'Content-Type': 'application/json' },
          body: EMULSIVE_FILM_RESPONSE,
        },
      })
    );

    it('will receive the user details', async () => {
      let stockService = new StockService("https://localhost:7194/");
      let stock = await stockService.getStock("CT800");
      expect(stock.httpStatusCode).toBe(200);
    });
  });
});
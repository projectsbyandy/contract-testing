import { StockService } from "../service/stockservice";
import { expect, beforeAll } from '@jest/globals';


let stockService: StockService;

describe.skip('Stock Service Tests', () => {  
    describe('Check Get Stock endpoint', () => {
      beforeAll(async () => {
        stockService = new StockService("https://localhost:7194")
        await stockService.isEndPointRunning();
      });
  
      it('will return data for a valid film', async () => {
        const stock = await stockService.getStockForFilm("CT800");
        expect(stock.httpStatusCode).toBe(200);
        expect(stock.result.film.name).toBe("CT800")
      });
    });
});
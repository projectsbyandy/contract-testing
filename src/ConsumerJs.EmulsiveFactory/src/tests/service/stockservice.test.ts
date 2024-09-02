import { StockService } from "../../stockservice";

let stockService: StockService;

describe('Stock Service Tests', () => {  
    describe('Check Get Stock endpoint', () => {
      beforeAll(async () => {
        stockService = new StockService("https://localhost:7194")
        await stockService.isEndPointRunning();
      });
  
      it('will return data for a valid film', async () => {
        const stock = await stockService.getStock("CT800");
        expect(stock.httpStatusCode).toBe(200);
        expect(stock.filmStock.film.name).toBe("CT800")
      });
    });
});
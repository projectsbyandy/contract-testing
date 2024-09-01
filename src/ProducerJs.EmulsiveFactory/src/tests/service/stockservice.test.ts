import { StockService } from "../../stockservice";

describe('Stock Service Tests', () => {  
    describe('Check Get Stock endpoint', () => {
      let stockService: StockService;
      
      beforeAll(() =>
        stockService = new StockService("https://localhost:7194")
      );
  
      it('will return data for a valid film', async () => {
        const stock = await stockService.getStock("CT800");
        expect(stock.httpStatusCode).toBe(200);
        expect(stock.filmStock.film.name).toBe("CT800")
      });
    })
});
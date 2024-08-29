import { StockService } from "../../stockservice";

describe('Stock Service Tests', () => {  
    describe('Check Get Stock endpoint', () => {
      let stockService: StockService;
      
      beforeAll(() =>
        stockService = new StockService("https://localhost:7194/")
      );
  
      it('will return data', async () => {
        const stock = await stockService.getStock("CT800");
      });
    })
});
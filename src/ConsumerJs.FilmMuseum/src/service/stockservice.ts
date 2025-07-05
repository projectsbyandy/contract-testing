import { FilmStock, StockServiceResponse } from "../models";
import https from 'https';
import axios from 'axios'
import { IStockService } from ".";

// For testing, generate certificate for prod use
const agent = new https.Agent({
  rejectUnauthorized: false,
});

export class StockService implements IStockService {
    private baseUrl: string;

    constructor(baseUrl: string) {
        this.baseUrl = baseUrl;
    }

    async isEndPointRunning(): Promise<void> {
      try {
        await axios.get(`${this.baseUrl}/swagger/index.html`, { httpsAgent: agent });
      } catch (error) {
        if (axios.isAxiosError(error) && error.code == 'ECONNREFUSED') {
            throw Error('Emulsive Service not running');
        }

        throw Error(`Unable call Emulsive Service ${error}`);
      }
    }

    async getStockForFilm(filmName: string): Promise<StockServiceResponse<FilmStock>> {
        try {
          const response = await axios.get<StockServiceResponse<FilmStock>>(`${this.baseUrl}/Stock/${filmName}`, { httpsAgent: agent });
          const stockServiceResponse = response.data;

          console.log(stockServiceResponse);
          return stockServiceResponse;
        } catch (error) {
          if (axios.isAxiosError(error)) {
            console.error('Error message: ', error.message);
          } else {
            console.error('Unexpected error: ', error);
          }
          throw error;
        }
    }
}
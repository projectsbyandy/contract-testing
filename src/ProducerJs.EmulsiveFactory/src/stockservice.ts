import { StockServiceResponse } from "./models/stockServiceResponse";
import axios from 'axios'

export class StockService {
    private baseUrl: string;

    constructor(baseUrl: string) {
        this.baseUrl = baseUrl;
    }

    // public get<T>(url: string, config?: AxiosRequestConfig): Promise<T> {
    //     return this.axiosInstance.get<T>(url, config).then((response) => response.data);
    //   }

    async getStock(filmName: string): Promise<StockServiceResponse> {
        try {
          const response = await axios.get<StockServiceResponse>(`${this.baseUrl}/Stock/${filmName}`);
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
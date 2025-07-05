import { StockServiceResponse, FilmStock } from "../models";

export interface IStockService {
  isEndPointRunning(): Promise<void>;
  getStockForFilm(filmName: string): Promise<StockServiceResponse<FilmStock>>;
}
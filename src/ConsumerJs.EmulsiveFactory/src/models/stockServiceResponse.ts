import { Film } from "./film";

export interface StockServiceResponse {
    httpStatusCode: number,
    filmStock: FilmStock,
}

export interface Stock {
    inStock : number,
    onOrder: number
}

export interface FilmStock {
    film: Film,
    stock: Stock
}
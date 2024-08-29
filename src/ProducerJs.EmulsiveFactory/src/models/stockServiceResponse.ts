import { Film } from "./film";

export interface StockServiceResponse {
    httpStatusCode: number,
    filmStock: FilmStock,
}

export interface Stock {
    InStock : number,
    OnOrder: number
}

export interface FilmStock {
    film: Film,
    stock: Stock
}
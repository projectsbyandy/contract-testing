import { Film } from "./film";

export interface StockServiceResponse<Type> {
    httpStatusCode: number,
    result: Type,
}

export interface Stock {
    inStock : number,
    onOrder: number
}

export interface FilmStock {
    film: Film,
    stock: Stock
}
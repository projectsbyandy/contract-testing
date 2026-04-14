import { Film } from "./Film";

export type StockServiceResponse<TResponseBody> = {
    httpStatusCode: number,
    result: TResponseBody,
}

export type Stock = {
    inStock : number,
    onOrder: number
}

export type FilmStock = {
    film: Film,
    stock: Stock
}
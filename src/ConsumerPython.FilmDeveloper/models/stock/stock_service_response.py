from typing import Generic, List, TypeVar
from pydantic import BaseModel

from models.stock.film_type import FilmType

DataT = TypeVar('DataT')

class StockServiceResponse(BaseModel, Generic[DataT]):
     httpStatusCode: int
     result: DataT

class Manufacturer(BaseModel):
     name: str
     location: str

class Person(BaseModel):
    name: str
    email: str
    location: str

class Tag(BaseModel):
     name: str

class Film(BaseModel):
     name: str
     filmType: FilmType
     id: str
     manufacturer: Manufacturer
     contacts: List[Person]
     tags: List[Tag]

class Stock(BaseModel):
     inStock: int
     onOrder: int

class FilmStock(BaseModel):
     film: Film
     stock: Stock
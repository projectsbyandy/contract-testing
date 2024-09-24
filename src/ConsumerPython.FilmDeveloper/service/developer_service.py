import requests
from pydantic import ValidationError

from models.stock.stock_service_response import FilmStock, StockServiceResponse


class DeveloperService:
    def __init__(self, base_url: str):
        self.base_url = base_url

    def get_film(self, film: str):
        response = requests.get(self.base_url + '/Stock/' + film)
        stock_service_response = StockServiceResponse

        try:
            stock_service_response = StockServiceResponse[FilmStock].model_validate_json(response.content)

        except ValidationError as e:
            print(e)
        
        return stock_service_response
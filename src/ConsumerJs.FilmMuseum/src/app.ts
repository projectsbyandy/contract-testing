import express from 'express';
import { Film } from './models/Film';
import { FilmType } from './models/FilmType';

const app = express();
const port = 5001;

var films : Film[] = [
  {id:"6ad24164-e021-4cb2-93d6-fe681820f643", name: "Portra400", filmType: FilmType.ThirtyFive, manufacturer: {name: "Kodak", location: "Germany"}},
  {id:"58eb57f9-22b8-417d-987d-e082a31d3bf3", name: "Portra800", filmType: FilmType.ThirtyFive, manufacturer: {name: "Kodak", location: "Germany"}},
  {id:"7d7e7a8a-f6d8-4630-b31b-e9ff4a1c87a9", name: "CineStill800", filmType: FilmType.Medium, manufacturer: {name: "CineStill", location: "US"}}

]

app.get('/EmulsiveFilms', (req, res) => {
  res.send(films);
});

app.get('/EmulsiveFilm/{manufacturer}/{filmType}', (req, res) => {
  res.send('Hey bob');
});

app.get('/EmulsiveFilm', (req, res) => {
  const filmType = req.query.filmType as any as FilmType;
  console.log(`film type ${filmType}`);

  res.send(films.filter(film => film.filmType == filmType));
});

app.listen(port, () => {
  console.log(`Server is running on port ${port}`);
});
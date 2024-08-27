import express from 'express';
import { Film } from './models/film';
import { FilmType } from './models/filmType';

const app = express();
const port = 5001;

var films : Film[] = [
  {id:"6ad24164-e021-4cb2-93d6-fe681820f643", name: "Porta400", filmType: FilmType.ThirtyFive, manufacturer: {name: "Kodak", location: "Germany"}},
  {id:"58eb57f9-22b8-417d-987d-e082a31d3bf3", name: "Porta800", filmType: FilmType.ThirtyFive, manufacturer: {name: "Kodak", location: "Germany"}}
]

app.get('/EmulsiveFilm', (req, res) => {
  res.send(films);
});

app.get('/EmulsiveFilm/{manufacturer}/{filmType}', (req, res) => {
  res.send('Hey bob');
});

app.get('/EmulsiveFilm/{filmType}', (req, res) => {
  res.send('Get bob by filmtype');
});

app.listen(port, () => {
  console.log(`Server is running on port ${port}`);
});
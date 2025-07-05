import { FilmType } from "./FilmType";
import { Manufacturer } from "./Manufacturer";
import { Person } from "./Person";
import { Tag } from "./Tag";

export type Film = {
    name: string,
    filmType: FilmType,
    id: string,
    manufacturer: Manufacturer,
    contacts?: Person[],
    tags?: Tag[]
}

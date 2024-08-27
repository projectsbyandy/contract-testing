import { FilmType } from "./filmType";
import { Manufacturer } from "./manufacturer";
import { Person } from "./person";
import { Tag } from "./tag";

export type Film = {
    name: string,
    filmType: FilmType,
    id: string,
    manufacturer: Manufacturer,
    contacts?: Person[],
    tags?: Tag[]
}

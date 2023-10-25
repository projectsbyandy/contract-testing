using Producer_EmulsiveFilm.Models;

namespace Producer_EmulsiveFilm.Repository;

public interface IFilmStore
{
    public List<Film> GetAll();

}
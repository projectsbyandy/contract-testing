using Producer_EmulsiveFilm.Models.EmulsiveFilm.Response;

namespace Producer_EmulsiveFilm.Repository;

public interface IFilmStore
{
    public List<Film> GetAll();
}
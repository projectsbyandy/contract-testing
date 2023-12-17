using Producer_EmulsiveFilm.Models;
using Producer_EmulsiveFilm.Models.Response;

namespace Producer_EmulsiveFilm.Repository;

public interface IFilmStore
{
    public List<Film> GetAll();
}
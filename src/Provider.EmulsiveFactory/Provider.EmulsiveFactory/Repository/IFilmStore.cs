using Provider.EmulsiveFactory.Models.EmulsiveFactory.Response;

namespace Provider.EmulsiveFactory.Repository;

public interface IFilmStore
{
    public List<Film> GetAll();
}
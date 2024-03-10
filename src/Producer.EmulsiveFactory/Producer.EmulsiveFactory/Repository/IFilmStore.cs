using Producer.EmulsiveFactory.Models.EmulsiveFactory.Response;

namespace Producer.EmulsiveFactory.Repository;

public interface IFilmStore
{
    public List<Film> GetAll();
}
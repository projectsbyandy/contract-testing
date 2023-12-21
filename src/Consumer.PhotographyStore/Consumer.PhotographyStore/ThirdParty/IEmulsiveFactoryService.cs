using Consumer.PhotographyStore.ThirdParty.Models.EmulsiveFactory;

namespace Consumer.PhotographyStore.ThirdParty;

public interface IEmulsiveFactoryService
{
    public Task<IEnumerable<Film>> GetAllFilmAsync();
}
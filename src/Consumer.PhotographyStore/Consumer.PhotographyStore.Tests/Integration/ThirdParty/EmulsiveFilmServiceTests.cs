using Consumer.PhotographyStore.ThirdParty.Services.Internal;
using FluentAssertions;

namespace Consumer.PhotographyStore.Tests.Integration.ThirdParty;

// NOTE - Requires Provider to be running
public class EmulsiveFilmServiceTests
{
    [Test]
    public async Task Verify_All_Films_Can_Be_Retrieved()
    {
        // Given
        var emulsiveFilmService = new EmulsiveFactoryService(new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:7194")
        });
        
        // When
        var allFilm = await emulsiveFilmService.GetAllFilmAsync();
        
        // Then
        var films = allFilm.ToList();
        films.Should().HaveCountGreaterThan(0);
        films.FirstOrDefault()?.Name.Should().NotBeEmpty();
    }
}
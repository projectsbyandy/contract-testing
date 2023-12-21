using Consumer.PhotographyStore.ThirdParty.Internal;
using FluentAssertions;

namespace Consumer.PhotographyStore.Tests.Integration.ThirdParty;

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
        var films = await emulsiveFilmService.GetAllFilmAsync();
        
        // Then
        films.Should().HaveCountGreaterThan(0);
    }
}
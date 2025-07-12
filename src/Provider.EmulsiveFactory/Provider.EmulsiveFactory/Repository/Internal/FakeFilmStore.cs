using Provider.EmulsiveFactory.Models;
using Provider.EmulsiveFactory.Models.EmulsiveFactory.Response;

namespace Provider.EmulsiveFactory.Repository.Internal;

public class FakeFilmStore : IFilmStore
{
    public List<Film> GetAll()
    {
        return new()
        {
            new Film()
            {
                Name = "Portra800",
                Id = Guid.Parse("d4c835a7-93ea-43aa-895b-5c48eec5be2e"),
                FilmType = FilmType.Large,
                ProcessingType = "C41",
                Iso = 800,
                isActive = true,
                Manufacturer = new Manufacturer()
                {
                    Name = "Kodak",
                    Location = "USA",
                    Date = DateOnly.FromDateTime(DateTime.Today - TimeSpan.FromDays(10))
                },
                Contacts = new List<Person>()
                {
                    new()
                    {
                        Name = "Peter",
                        Location = "USA",
                        Email = "Peter@scots.com"
                    },
                    new()
                    {
                        Name = "Mandy",
                        Location = "New York",
                        Email = "Mandy@scots.com"
                    }
                },
                Tags = new List<Tag>()
                {
                    new()
                    {
                        Name = "New"
                    },
                    new()
                    {
                        Name = "Mega Grain"
                    }
                }
            },
            new Film()
            {
                Name = "CT800",
                Id = Guid.Parse("91ed96c5-9672-4988-aee8-34ec14eb89a6"),
                FilmType = FilmType.Medium,
                ProcessingType = "C41",
                Iso = 800,
                isActive = true,
                Manufacturer = new Manufacturer()
                {
                    Name = "Cinestill",
                    Location = "Germany",
                    Date = DateOnly.FromDateTime(DateTime.Today - TimeSpan.FromDays(5))
                },
                Contacts = new List<Person>()
                {
                    new()
                    {
                        Name = "Andy",
                        Location = "Munich", 
                        Email = "Andy@test.com"
                    },
                    new()
                    {
                        Name = "Jane",
                        Location = "Dortmand",
                        Email = "Jane@test.com"

                    }
                },
                Tags = new List<Tag>()
                {
                    new()
                    {
                        Name = "Neon"
                    },
                    new()
                    {
                        Name = "Night"
                    }
                }
            },
            new Film()
            {
                Name = "Portra400",
                Id = Guid.Parse("a9877e6b-a75a-4c9b-a841-4ce8d01745df"),
                FilmType = FilmType.Large,
                ProcessingType = "C41",
                Iso = 400,
                isActive = true,
                Manufacturer = new Manufacturer()
                {
                    Name = "Kodak",
                    Location = "USA"
                },
                Contacts = new List<Person>()
                {
                    new()
                    {
                        Name = "David",
                        Location = "Oregan",
                        Email = "David@lucky.com"

                    },
                    new()
                    {
                        Name = "Linda",
                        Location = "Las Vegas",
                        Email = "linda@lucky.com"

                    }
                },
                Tags = new List<Tag>()
                {
                    new()
                    {
                        Name = "New"
                    },
                    new()
                    {
                        Name = "Small Grain"
                    },
                    new()
                    {
                        Name = "Vintage"
                    }
                }
            },
            new Film()
            {
                Name = "Pro400",
                Id = Guid.Parse("00c84d10-c681-4add-aff5-bcdb8adfd4b6"),
                FilmType = FilmType.ThirtyFive,
                ProcessingType = "E6",
                Iso = 400,
                isActive = true,
                Manufacturer = new Manufacturer()
                {
                    Name = "Fuji",
                    Location = "Japan",
                    Date = DateOnly.FromDateTime(DateTime.Today - TimeSpan.FromDays(2))
                },
                Contacts = new List<Person>()
                {
                    new()
                    {
                        Name = "Stan",
                        Location = "Tokyo",
                        Email = "Stan@Lee.com"

                    },
                    new()
                    {
                        Name = "Koyo",
                        Location = "Osaka",
                        Email = "Koyo@Yam.com"

                    }
                },
                Tags = new List<Tag>()
                {
                    new()
                    {
                        Name = "Cool"
                    },
                    new()
                    {
                        Name = "Colour"
                    },
                    new()
                    {
                        Name = "Modern"
                    }
                }
            },
        };
    }
}
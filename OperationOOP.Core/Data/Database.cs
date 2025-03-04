namespace OperationOOP.Core.Data;

public class Database : IDatabase
{
    public List<Instrument> Instruments { get; set; }
    
    public Database(bool mockedData = true)
    {   
        if (mockedData)
            Instruments = GetMockedData();
    }

    // Sprinkle in some polymorphism, altho composition > inheritance :)
    private List<Instrument> GetMockedData()
    {
        return
        [
            new Guitar
            {   
                Id = 0,
                Type = MostCommonType.Guitar,
                Model = "Stratocaster",
                IsAcoustic = false,
                LastOwner = "Jimi Hendrix",
                Brand = "Fender",
                YearMade = 1969,
                Price = 2990000,
                Condition = Condition.Used,
            },
            new Drum
            {
                Id = 1,
                Type = MostCommonType.Drum,
                Size = 22,
                LastOwner = "John Bonham",
                Brand = "Ludwig",
                YearMade = 1970,
                Price = 290000,
                Condition = Condition.Used,
            },
            new Piano
            {
                Id = 2,
                Type = MostCommonType.Piano,
                NumOfKeys = 88,
                LastOwner = "Ludwig van Beethoven",
                Brand = "Steinway & Sons",
                YearMade = 1867,
                Price = 10000001,
                Condition = Condition.Refurbished,
            },
            new Instrument
            {   
                Id = 3,
                Type = MostCommonType.Other,
                TypeName = "Violin",
                LastOwner = "Unknown",
                Brand = "Joseph Curtin",
                YearMade = 2005,
                Price = 15,
                Condition = Condition.New,
            },
            new Instrument
            {
                Id = 4,
                Type = MostCommonType.Other,
                TypeName = "Trumpet",
                LastOwner = "Miles Davis",
                Brand = "Martin Committee",
                YearMade = 1947,
                Price = 599000,
                Condition = Condition.Used
            },
            new Instrument
            {
                Id = 5,
                Type = MostCommonType.Other,
                TypeName = "Saxophone",
                LastOwner = "Charlie Parker",
                Brand = "Selmer",
                YearMade = 1950,
                Price = 450000,
                Condition = Condition.Used
            },
            new Instrument
            {
                Id = 6,
                Type = MostCommonType.Other,
                TypeName = "Flute",
                LastOwner = "Jean-Pierre Rampal",
                Brand = "Muramatsu",
                YearMade = 1975,
                Price = 120000,
                Condition = Condition.Used
            }
        ];
    }
}

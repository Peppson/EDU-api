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
                Model = "Stratocaster",
                IsAcoustic = false,
                LastOwner = "Jimi Hendrix",
                Brand = "Fender",
                YearMade = 1969,
                Price = 2990000,
                Condition = Condition.Used,
                Type = InstrumentType.Stringed
            },
            new Drum
            {
                Id = 1,
                Size = 22,
                LastOwner = "John Bonham",
                Brand = "Ludwig",
                YearMade = 1970,
                Price = 1000000,
                Condition = Condition.Used,
                Type = InstrumentType.Percussion
            },
            new Piano
            {
                Id = 2,
                NumOfKeys = 88,
                LastOwner = "Ludwig van Beethoven",
                Brand = "Steinway & Sons",
                YearMade = 1867,
                Price = 10000000,
                Condition = Condition.Refurbished,
                Type = InstrumentType.Keyboard
            },
            new Instrument
            {   
                Id = 3,
                TypeName = "Violin",
                LastOwner = "Unknown",
                Brand = "Joseph Curtin",
                YearMade = 2005,
                Price = 1337,
                Condition = Condition.New,
                Type = InstrumentType.Stringed
            },
            new Instrument
            {
                Id = 4,
                TypeName = "Trumpet",
                LastOwner = "Miles Davis",
                Brand = "Martin Committee",
                YearMade = 1947,
                Price = 500000,
                Condition = Condition.Used,
                Type = InstrumentType.Other
            }
        ];
    }
}

namespace OperationOOP.Core.Models;

public class Instrument : IInstrument
{   
    public int Id { get; set; }
    public MostCommonType Type  { get; set; }
    public string? TypeName { get; set; }
    public string? LastOwner { get; set; }
    public string Brand { get; set; }
    public int YearMade { get; set; }
    public int Price { get; set; }
    public Condition Condition { get; set; }
}

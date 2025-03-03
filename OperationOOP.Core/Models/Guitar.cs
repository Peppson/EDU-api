namespace OperationOOP.Core.Models;

// Valde arv då jag nästan alltid annars använder komposition
public class Guitar : Instrument 
{
    public string Model { get; set; } = string.Empty;
    public bool IsAcoustic { get; set; }
}

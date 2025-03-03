namespace OperationOOP.Api.Models;

public record InstrumentResponse(
    int Id,
    string? TypeName,
    string? LastOwner,
    string Brand,
    int YearMade,
    int Price,
    Condition Condition,
    MostCommonType Type,
    int? Size,          // Drum
    string? Model,      // Guitar
    bool? IsAcoustic,   // Guitar
    int? NumOfKeys      // Piano
);

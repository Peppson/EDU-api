namespace OperationOOP.Api.Endpoints;

public partial class GetInstrumentById : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/api/instruments/{id}", Handle)
        .WithSummary("Get an instrument by id");

    private static IResult Handle(IDatabase db, int id)
    {   
        if (db.Instruments == null || db.Instruments.Count == 0)
            return Results.NotFound("No instrument found");

        var instrument = db.Instruments.FirstOrDefault(i => i.Id == id);

        if (instrument == null)
            return Results.NotFound($"Instrument with ID {id} not found");

        var response = new InstrumentResponse(
            Id: instrument.Id,
            TypeName: Helper.GetInstrumentTypeName(instrument),
            LastOwner: instrument.LastOwner,
            Brand: instrument.Brand,
            YearMade: instrument.YearMade,
            Price: instrument.Price,
            Condition: instrument.Condition,
            Type: instrument.Type,
            Size: (instrument as Drum)?.Size,
            Model: (instrument as Guitar)?.Model,
            IsAcoustic: (instrument as Guitar)?.IsAcoustic,
            NumOfKeys: (instrument as Piano)?.NumOfKeys
        );

        return Results.Ok(response);
    }
}

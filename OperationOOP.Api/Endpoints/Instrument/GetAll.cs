namespace OperationOOP.Api.Endpoints;

public class GetAllInstruments : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/api/instruments", Handle)
        .WithSummary("Get all instruments");

    private static IResult Handle(IDatabase db)
    {   
        if (db.Instruments == null || db.Instruments.Count == 0)
            return Results.NotFound("No instruments found");

        var response = db.Instruments
            .Select(i => new InstrumentResponse(
                Id: i.Id,
                TypeName: Helper.GetInstrumentTypeName(i),
                LastOwner: i.LastOwner,
                Brand: i.Brand,
                YearMade: i.YearMade,
                Price: i.Price,
                Condition: i.Condition,
                Type: i.Type,
                Size: (i as Drum)?.Size,
                Model: (i as Guitar)?.Model,
                IsAcoustic: (i as Guitar)?.IsAcoustic,
                NumOfKeys: (i as Piano)?.NumOfKeys
            )).ToList();

        return Results.Ok(response);
    }
}

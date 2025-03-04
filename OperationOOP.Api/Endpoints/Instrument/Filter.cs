namespace OperationOOP.Api.Endpoints;

public class GetInstrumentFilter : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/api/instruments/filter/{condition}", Handle)
        .WithSummary("Get all instruments by condition");

    private static IResult Handle(IDatabase db, Condition condition)
    {   
        if (db.Instruments == null || db.Instruments.Count == 0)
            return Results.NotFound("No instrument found");

        // Filter via LINQ :)
        var instrument = db.Instruments.Where(i => i.Condition == condition).ToList();

        if (instrument.Count < 1)
            return Results.NotFound($"No instrument with \"{condition}\" found!");

        return Results.Ok(instrument);
    }
}

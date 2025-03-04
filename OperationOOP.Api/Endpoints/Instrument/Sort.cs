namespace OperationOOP.Api.Endpoints;

public class GetInstrumentSort : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/api/instruments/sortprice/{ascending}", Handle)
        .WithSummary("Sort all instruments by price");

    private static IResult Handle(IDatabase db, bool ascending = true)
    {   
        if (db.Instruments == null || db.Instruments.Count == 0)
            return Results.NotFound("No instrument found");

        // Sort price via LINQ :)
        var sortedInstruments = (ascending) ? 
            db.Instruments.OrderBy(i => i.Price).ToList() : 
            db.Instruments.OrderByDescending(i => i.Price).ToList();

        return Results.Ok(sortedInstruments);
    }
}

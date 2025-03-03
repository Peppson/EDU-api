namespace OperationOOP.Api.Endpoints;

public class RemoveInstrumentById : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapDelete("/api/instruments/{id}", Handle)
        .WithSummary("Remove a instrument by id");

    private static IResult Handle(IDatabase db, int id)
    {   
        if (db.Instruments == null || db.Instruments.Count == 0)
            return Results.NotFound("No instruments found");

        var instrument = db.Instruments.FirstOrDefault(i => i.Id == id);

        if (instrument == null)
            return Results.NotFound($"Instrument with ID {id} not found");

        db.Instruments.Remove(instrument);

        return Results.Ok($"Instrument with id: {id} removed!");
    }
}

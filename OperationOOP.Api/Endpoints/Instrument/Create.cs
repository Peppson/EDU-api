using Swashbuckle.AspNetCore.Annotations;

namespace OperationOOP.Api.Endpoints;

public class AddInstrument : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/instruments/{type}", Handle)
        .WithMetadata(new SwaggerParameterAttribute
        {
            Description = "The type of instrument to add (Guitar, Drum, Piano)",
            //Enum = new[] { "Guitar", "Drum", "Piano" }
        });
        //.WithSummary("Add an instrument"); // Då mina klasser heter ca samma som summary tog jag bort den

    private static IResult Handle(InstrumentResponse request, IDatabase db)
    {
        var instrument = new Instrument();

        if (db.Instruments.Count == 0)
            instrument.Id = 0;
        else
            instrument.Id = db.Instruments.Count; // Starting @ id 0


        instrument.TypeName = request.TypeName;
        instrument.LastOwner = request.LastOwner;


        db.Instruments.Add(instrument);

        return Results.Ok($"Added with id: {instrument.Id}");
    }
}








/*
namespace OperationOOP.Api.Endpoints;

public class CreateBonsai : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/bonsais", Handle)
        .WithSummary("Bonsai trees");

    public record Request(
        string Name,
        string Species,
        int AgeYears,
        DateTime LastWatered,
        DateTime LastPruned,
        BonsaiStyle Style,
        CareLevel CareLevel
    );
    public record Response(int id);

    private static Ok<Response> Handle(Request request, IDatabase db)
    {
        

        var bonsai = new Bonsai();

        bonsai.Id = db.Bonsais.Any()
            ? db.Bonsais.Max(bonsai => bonsai.Id) + 1
            : 1;
        bonsai.Name = request.Name;
        bonsai.Species = request.Species;
        bonsai.AgeYears = request.AgeYears;
        bonsai.LastWatered = request.LastWatered;
        bonsai.LastPruned = request.LastPruned;
        bonsai.Style = request.Style;
        bonsai.CareLevel = request.CareLevel;

        db.Bonsais.Add(bonsai);

        return TypedResults.Ok(new Response(bonsai.Id));
    }
}


*/

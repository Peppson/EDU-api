namespace OperationOOP.Api.Endpoints;

public class AddInstrument : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/instruments/{type}/{condition}", Handle)
        .WithSummary("Add an instrument");

    private static IResult Handle(InstrumentRequest request, MostCommonType type, Condition condition, IDatabase db)
    {
        var instrument = Helper.GetInstrumentType(type, request);        
        instrument.Id = db.Instruments.Max(e => e.Id) + 1;
        instrument.Type = type;
        instrument.TypeName = Helper.GetInstrumentTypeName(instrument);
        instrument.LastOwner = request.LastOwner;
        instrument.Brand = request.Brand;
        instrument.YearMade = request.YearMade;
        instrument.Price = request.Price;
        instrument.Condition = request.Condition;

        // Validation
        var val = new InstrumentResponseValidator();
        var result = val.Validate(instrument);
        if (!result.IsValid)
        {
            return Results.BadRequest(result.Errors.Select(x => new
            {
                Field = x.PropertyName,
                Message = x.ErrorMessage
            }));
        }
        db.Instruments.Add(instrument);

        return Results.Ok($"Added with id: {instrument.Id}");
    }
}

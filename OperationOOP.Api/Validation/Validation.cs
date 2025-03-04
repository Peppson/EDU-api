namespace OperationOOP.Api.Validation;

public class InstrumentResponseValidator : AbstractValidator<Instrument>
{
    public InstrumentResponseValidator()
    {   
        // Base instrument
        RuleFor(i => i.Brand)
            .NotNull()
            .NotEmpty();

        RuleFor(i => i.YearMade)
            .LessThan(DateTime.Now.Year)
            .NotNull();

        RuleFor(i => i.Price)
            .GreaterThan(-1)
            .NotNull();

        RuleFor(i => i.Condition)
            .IsInEnum();

        RuleFor(i => i.Type)
            .IsInEnum();
    }
}

namespace OperationOOP.Api.Helpers;

public static class Helper
{
    public static string GetInstrumentTypeName(Instrument instrument)
    {
        return string.IsNullOrEmpty(instrument?.TypeName) ? instrument!.GetType().Name : instrument.TypeName;
    }
}

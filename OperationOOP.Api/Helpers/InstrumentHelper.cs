namespace OperationOOP.Api.Helpers;

public static class Helper
{
    public static string GetInstrumentTypeName(Instrument instrument)
    {
        return string.IsNullOrEmpty(instrument.TypeName) ? instrument!.GetType().Name : instrument.TypeName;
    }

    public static Instrument GetInstrumentType(MostCommonType type, InstrumentResponse request)
    {
        switch (type)
        {   
            case MostCommonType.Drum:
                return new Drum()
                {
                    Size = request.Size ?? 0
                };
            case MostCommonType.Guitar:
                return new Guitar()
                {
                    Model = request.Model ?? string.Empty,
                    IsAcoustic = request.IsAcoustic ?? false
                };
            case MostCommonType.Piano:
                return new Piano()
                {
                    NumOfKeys = request.NumOfKeys ?? 0
                };  
            default:
                return new Instrument();
        }
    }
}

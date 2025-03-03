namespace OperationOOP.Core.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum InstrumentType
{
    Stringed,
    Percussion,
    Keyboard,
    Other
}

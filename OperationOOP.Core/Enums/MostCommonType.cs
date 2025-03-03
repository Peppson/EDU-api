namespace OperationOOP.Core.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MostCommonType
{
    Guitar,
    Drum,
    Piano,
    Other
}

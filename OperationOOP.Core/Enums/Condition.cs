namespace OperationOOP.Core.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Condition
{
    New,
    Used,
    Refurbished,
    ForParts
}

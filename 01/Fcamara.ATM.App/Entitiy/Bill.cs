namespace Fcamara.ATM.App;

public record Bill
{
    public required string Serie { get; set; }
    public required BillValueType Value { get; set; }
}
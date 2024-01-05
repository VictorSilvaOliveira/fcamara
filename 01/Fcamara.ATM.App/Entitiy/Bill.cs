namespace Fcamara.ATM.App;

public record Bill
{
    public required string Serie { get; set; }
    public required double Value { get; set; }
}
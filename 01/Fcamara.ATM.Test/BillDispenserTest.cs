using Fcamara.ATM.App;
using Xunit;

namespace Fcamara.ATM.Test;

public class BillDispenserTest
{
    [Fact]
    public void BillDispenser_30_Withdraw_Success()
    {
        var billDispenser = new BillDispenser();

        var bills = billDispenser.MakeWithdrawOf(30);

        Assert.True(bills.Count() == 2, "Total of bills don't match");
        Assert.True(bills.Count(b => b.Value == 20.00) == 1, "Total of 20 bill don't match");
        Assert.True(bills.Count(b => b.Value == 10.00) == 1, "Total of 10 bill don't match");
    }
    
    [Fact]
    public void BillDispenser_60_Withdraw_Success()
    {
        var billDispenser = new BillDispenser();

        var bills = billDispenser.MakeWithdrawOf(60);

        
        Assert.True(bills.Count() == 2, "Total of bill don't match");
        Assert.True(bills.Count(b => b.Value == 50.00) == 1, "Total of 50 bill don't match");
        Assert.True(bills.Count(b => b.Value == 10.00) == 1, "Total of 10 bill don't match");
    }

    [Fact]
    public void BillDispenser_80_Withdraw_Success()
    {
        var billDispenser = new BillDispenser();

        var bills = billDispenser.MakeWithdrawOf(80);
        
        Assert.True(bills.Count() == 3, "Total of bill don't match");
        Assert.True(bills.Count(b => b.Value == 50.00) == 1, "Total of 50 bill don't match");
        Assert.True(bills.Count(b => b.Value == 20.00) == 1, "Total of 20 bill don't match");
        Assert.True(bills.Count(b => b.Value == 10.00) == 1, "Total of 10 bill don't match");
    }
}
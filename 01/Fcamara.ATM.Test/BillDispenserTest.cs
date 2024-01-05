using Fcamara.ATM.App;
namespace Fcamara.ATM.Test;

public class BillDispenserTest
{
    [Fact]
    public void BillDispenser_30_Withdraw_Success()
    {
        var billsReservations = new List<Bill>(10)
        {
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.HUNDRED },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.FIFTY },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TWENTY },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
        };

        var billDispenser = new BillDispenser(billsReservations);

        Assert.True(billDispenser.TotalBills == 10, "Total of bill on dispenser don't match");

        var billsWithTenty = billDispenser.MakeWithdrawOf(30);

        Assert.True(billsWithTenty.Count() == 2, "Total of bills don't match");
        Assert.True(billsWithTenty.Count(b => b.Value == BillValueType.TWENTY) == 1, "Total of 20 bill don't match");
        Assert.True(billsWithTenty.Count(b => b.Value == BillValueType.TEN) == 1, "Total of 10 bill don't match");

        Assert.True(billDispenser.TotalBills == 8, "Total of bill on dispenser don't match");

        var billsOnlyTens = billDispenser.MakeWithdrawOf(30);

        Assert.True(billsOnlyTens.Count() == 3, "Total of bills don't match");
        Assert.True(billsOnlyTens.Count(b => b.Value == BillValueType.TEN) == 3, "Total of 10 bill don't match");

        Assert.True(billDispenser.TotalBills == 5, "Total of bill on dispenser don't match");
    }

    [Fact]
    public void BillDispenser_60_Withdraw_Success()
    {
        var billsReservations = new List<Bill>(15)
        {
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.FIFTY },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },

            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TWENTY },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TWENTY },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TWENTY }
            ,
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TWENTY },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TWENTY },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },

            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
        };

        var billDispenser = new BillDispenser(billsReservations);

        Assert.True(billDispenser.TotalBills == 15, "Total of bill on dispenser don't match");

        var billsWithFifty = billDispenser.MakeWithdrawOf(60);

        Assert.True(billsWithFifty.Count() == 2, "Total of bill don't match");
        Assert.True(billsWithFifty.Count(b => b.Value == BillValueType.FIFTY) == 1, "Total of 50 bill don't match");
        Assert.True(billsWithFifty.Count(b => b.Value == BillValueType.TEN) == 1, "Total of 10 bill don't match");
        Assert.True(billDispenser.TotalBills == 13, "Total of bill on dispenser don't match");

        var billsOnlyTenty = billDispenser.MakeWithdrawOf(60);

        Assert.True(billsOnlyTenty.Count() == 3, "Total of bill don't match");
        Assert.True(billsOnlyTenty.Count(b => b.Value == BillValueType.TWENTY) == 3, "Total of 20 bill don't match");
      
        Assert.True(billDispenser.TotalBills == 10, "Total of bill on dispenser don't match");

        var billsTentyTen = billDispenser.MakeWithdrawOf(60);

        Assert.True(billsTentyTen.Count() == 4, "Total of bill don't match");
        Assert.True(billsTentyTen.Count(b => b.Value == BillValueType.TWENTY) == 2, "Total of 20 bill don't match");
        Assert.True(billsTentyTen.Count(b => b.Value == BillValueType.TEN) == 2, "Total of 10 bill don't match");
      
        Assert.True(billDispenser.TotalBills == 6, "Total of bill on dispenser don't match");

        var billsOnlyTen = billDispenser.MakeWithdrawOf(60);

        Assert.True(billsOnlyTen.Count() == 6, "Total of bill don't match");
        Assert.True(billsOnlyTen.Count(b => b.Value == BillValueType.TEN) == 6, "Total of 10 bill don't match");
       
        Assert.True(billDispenser.TotalBills == 0, "Total of 1ill on dispenser don't match");
    }

    [Fact]
    public void BillDispenser_80_Withdraw_WithFifty_Success()
    {
        var billsReservations = new List<Bill>(9)
        {
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.HUNDRED },

            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.FIFTY },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TWENTY },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },

            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.HUNDRED },

            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.FIFTY },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
        };

        var billDispenser = new BillDispenser(billsReservations);

        Assert.True(billDispenser.TotalBills == 9, "Total of bill on dispenser don't match");

        var bills = billDispenser.MakeWithdrawOf(80);

        Assert.True(bills.Count() == 3, "Total of bill don't match");
        Assert.True(bills.Count(b => b.Value == BillValueType.FIFTY) == 1, "Total of 50 bill don't match");
        Assert.True(bills.Count(b => b.Value == BillValueType.TWENTY) == 1, "Total of 20 bill don't match");
        Assert.True(bills.Count(b => b.Value == BillValueType.TEN) == 1, "Total of 10 bill don't match");

        
        Assert.True(billDispenser.TotalBills == 6, "Total of bill on dispenser don't match");

        var billsFitfyTen = billDispenser.MakeWithdrawOf(80);

        Assert.True(billsFitfyTen.Count() == 4, "Total of bill don't match");
        Assert.True(billsFitfyTen.Count(b => b.Value == BillValueType.FIFTY) == 1, "Total of 50 bill don't match");
        Assert.True(billsFitfyTen.Count(b => b.Value == BillValueType.TEN) == 3, "Total of 10 bill don't match");
        
        Assert.True(billDispenser.TotalBills == 2, "Total of bill on dispenser don't match");

    }

    [Fact]
    public void BillDispenser_80_Withdraw_WithoutFifty_Success()
    {

        var billsReservations = new List<Bill>(4)
        {
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.HUNDRED },

            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TWENTY },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TWENTY },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TWENTY },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TWENTY },

            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.HUNDRED },

            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TWENTY },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TWENTY },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TWENTY },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },

            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.HUNDRED },

            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
        
        };

        var billDispenser = new BillDispenser(billsReservations);

        Assert.True(billDispenser.TotalBills == 22, "Total of bill on dispenser don't match");

        var billsOnlyTwenty = billDispenser.MakeWithdrawOf(80);

        Assert.True(billsOnlyTwenty.Count() == 4, "Total of bill don't match");
        Assert.True(billsOnlyTwenty.Count(b => b.Value == BillValueType.TWENTY) == 4, "Total of 20 bill don't match");

        
        Assert.True(billDispenser.TotalBills == 18, "Total of bill on dispenser don't match");

        var billsTwentyTen = billDispenser.MakeWithdrawOf(80);

        Assert.True(billsTwentyTen.Count() == 5, "Total of bill don't match");
        Assert.True(billsTwentyTen.Count(b => b.Value == BillValueType.TWENTY) == 3, "Total of 20 bill don't match");
        Assert.True(billsTwentyTen.Count(b => b.Value == BillValueType.TEN) == 2, "Total of 10 bill don't match");

        Assert.True(billDispenser.TotalBills == 13, "Total of bill on dispenser don't match");

        var billsOnlyTen = billDispenser.MakeWithdrawOf(80);

        Assert.True(billsOnlyTen.Count() == 8, "Total of bill don't match");
        Assert.True(billsOnlyTen.Count(b => b.Value == BillValueType.TEN) == 8, "Total of 10 bill don't match");

        Assert.True(billDispenser.TotalBills == 5, "Total of bill on dispenser don't match");
    }

    [Fact]
    public void BillDispenser_InsuficienteBill_Withdraw_Exception()
    {
        var billsReservations = new List<Bill>(4)
        {
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.HUNDRED },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.FIFTY },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TWENTY },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN }
        };

        var billDispenser = new BillDispenser(billsReservations);

        Assert.Throws<InsuficienteBillsToWithdrawnException>(() => billDispenser.MakeWithdrawOf(190));

    }

    [Fact]
    public void BillDispenser_ValueBillMismatch_Withdraw_Exception()
    {
        var billsReservations = new List<Bill>()
        {
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.HUNDRED },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.FIFTY },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.FIFTY },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.FIFTY },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TWENTY },
            
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TWENTY },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TWENTY },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TWENTY },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TWENTY },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TWENTY },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TWENTY },

            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
            new Bill(){ Serie = Guid.NewGuid().ToString(), Value = BillValueType.TEN },
        };

        var billDispenser = new BillDispenser(billsReservations);

        Assert.Throws<ValueBillMismatchException>(() => billDispenser.MakeWithdrawOf(135));

        Assert.True(billDispenser.TotalBills == billsReservations.Count, "Total of bill on dispenser don't match");

    }
}
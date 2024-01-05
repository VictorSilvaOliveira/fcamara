namespace Fcamara.ATM.App;

public class BillDispenser
{
    public int TotalBills => 0;

    public BillDispenser(ICollection<Bill> bills)
    {
         
    }

    public ICollection<Bill> MakeWithdrawOf(int amount)
    {
        return new List<Bill>(0);
    }
}
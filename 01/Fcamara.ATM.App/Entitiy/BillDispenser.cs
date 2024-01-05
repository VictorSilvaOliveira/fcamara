using System.Collections;

namespace Fcamara.ATM.App;

public class BillDispenser
{
    public ICollection<Bill> MakeWithdrawOf(double amount)
    {
        return new List<Bill>(0);
    }
}

namespace Fcamara.ATM.App;

public class BillDispenser
{
    private BillDispenserState _billDispenserState;

    public BillDispenser(ICollection<Bill> bills)
    {
        _billDispenserState = new BillDispenserState(bills);
    }

    public int TotalBills { get => _billDispenserState.TotalBills; }

    public ICollection<Bill> MakeWithdrawOf(int amount)
    {
        var currentState = _billDispenserState.Clone();
        var partialAmount = amount;
        var withdraw = new List<Bill>();
        var billIndex = 0;
                
        currentState.CheckBalance(amount);

        while (partialAmount > 0)
        {
            var bill = currentState.GetNextBill(billIndex);

            if ((int)bill.Value > partialAmount)
            {
                billIndex++;
                continue;
            }
            withdraw.Add(bill);
            currentState.DrawBill(bill);
            partialAmount -= (int)bill.Value;
            
            currentState.CheckBillMatch(partialAmount);
        }
        
        _billDispenserState = currentState;

        return withdraw;
    }
}
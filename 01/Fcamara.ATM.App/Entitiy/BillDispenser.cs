
using System.Diagnostics;

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
        var highestBillSkipIndex = 0;
                
        if (!currentState.CheckBalance(amount))
        {
            throw new InsuficienteBillsToWithdrawnException();
        }

        while (partialAmount > 0)
        {
            var bill = currentState.GetNextBill(partialAmount, highestBillSkipIndex);

            if (bill == null)
            {
                throw new ValueBillMismatchException(); 
            }

            withdraw.Add(bill);
            currentState.DrawBill(bill);
            partialAmount -= (int)bill.Value;

            if (!currentState.CheckBillMatch(partialAmount, highestBillSkipIndex))
            {
                currentState = _billDispenserState.Clone();
                highestBillSkipIndex = currentState.GetNextBillIndex(withdraw.Max(b => (int)b.Value));
                withdraw = new List<Bill>();
                partialAmount = amount;
            }
        }
        
        _billDispenserState = currentState;

        return withdraw;
    }
}
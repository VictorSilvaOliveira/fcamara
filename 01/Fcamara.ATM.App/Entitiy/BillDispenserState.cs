
namespace Fcamara.ATM.App;

internal class BillDispenserState
{

    internal BillDispenserState(ICollection<Bill> bills)
    {
        foreach( var bill in bills)
        {
            if (!_billsInfo.ContainsKey(bill.Value))
            {
                _billsInfo[bill.Value] = 0;
            }
            _billsInfo[bill.Value] += 1;
            _bills.Add(bill);
        }
    }
    private SortedSet<Bill> _bills = new SortedSet<Bill>(new BillValueReverseSort());
    IDictionary<BillValueType, int> _billsInfo = new SortedDictionary<BillValueType, int>(new BillValueTypeReverseSort());

    internal int TotalBills => _bills.Count;

    internal BillDispenserState Clone()
    {
        return new BillDispenserState(new List<Bill>(_bills));
    }

    internal Bill? GetNextBill(int amount, int billIndex)
    {
        return _bills.Skip(billIndex).FirstOrDefault(b => (int)b.Value <= amount);
    }

    internal void DrawBill(Bill bill)
    {
        _billsInfo[bill.Value] -= 1;
        if (_billsInfo[bill.Value] == 0)
        {
            _billsInfo.Remove(bill.Value);
        }
        _bills.Remove(bill);
    }

    internal bool CheckBalance(int amount)
    {
        return _bills.Sum(b => (int)b.Value) >= amount;
    }

    internal bool CheckBillMatch(int partialAmount, int billIndex)
    {
        return partialAmount == 0 || _bills.Skip(billIndex).Min(b => (int)b.Value) <= partialAmount;
    }

    internal int GetNextBillIndex(int minBill)
    {
        return _bills.Count(b=> (int)b.Value >= minBill);
    }
}
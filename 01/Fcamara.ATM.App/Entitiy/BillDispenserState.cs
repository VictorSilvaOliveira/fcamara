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
            _totalValue += (int)bill.Value;
            _minBill = Math.Min(_minBill, (int)bill.Value);
        }
    }
    private SortedSet<Bill> _bills = new SortedSet<Bill>(new BillValueReverseSort());
    private int _totalValue = 0;
    private int _minBill = Int32.MaxValue;
    IDictionary<BillValueType, int> _billsInfo = new SortedDictionary<BillValueType, int>(new BillValueTypeReverseSort());

    internal int TotalBills => _bills.Count;

    internal BillDispenserState Clone()
    {
        return new BillDispenserState(new List<Bill>(_bills));
    }

    internal Bill GetNextBill(int billIndex)
    {
        return _bills.Skip(billIndex).First();
    }

    internal void DrawBill(Bill bill)
    {
        _totalValue -= (int)bill.Value;
        _billsInfo[bill.Value] -= 1;
        if (_billsInfo[bill.Value] == 0)
        {
            _billsInfo.Remove(bill.Value);
        }
        _bills.Remove(bill);
    }

    internal void CheckBalance(int amount)
    {
        if (_totalValue < amount)
        {
            throw new InsuficienteBillsToWithdrawnException();
        }
    }

    internal void CheckBillMatch(int partialAmount)
    {
        if (partialAmount > 0 && _minBill > partialAmount)
        {
            throw new ValueBillMismatchException();
        }
    }
}
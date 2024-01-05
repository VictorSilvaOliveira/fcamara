namespace Fcamara.ATM.App;

internal class BillValueReverseSort : IComparer<Bill>
{
    public int Compare(Bill? x, Bill? y)
    {
        if (x == null)
        {
            if (y == null)
                return 1;
            else 
                return 0;
        }
        if (y == null)
        {
            return -1;
        }
        if (x.Value > y.Value)
            return -1;
        if (x.Value < y.Value)
            return 1;
        else
            return x.Serie.CompareTo(y.Serie);
    }
}
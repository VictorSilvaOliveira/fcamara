namespace Fcamara.ATM.App;

internal class BillValueTypeReverseSort : IComparer<BillValueType>
{
    public int Compare(BillValueType x, BillValueType y)
    {
        if (x > y)
            return -1;
        if (x < y)
            return 1;
        else
            return 0;
    }

}
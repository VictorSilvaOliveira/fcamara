using System.Runtime.Serialization;

[Serializable]
public class ValueBillMismatchException : Exception
{
    public ValueBillMismatchException()
    {
    }

    public ValueBillMismatchException(string? message) : base(message)
    {
    }

    public ValueBillMismatchException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected ValueBillMismatchException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
using System.Runtime.Serialization;

[Serializable]
public class InsuficienteBillsToWithdrawnException : Exception
{
    public InsuficienteBillsToWithdrawnException()
    {
    }

    public InsuficienteBillsToWithdrawnException(string? message) : base(message)
    {
    }

    public InsuficienteBillsToWithdrawnException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected InsuficienteBillsToWithdrawnException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
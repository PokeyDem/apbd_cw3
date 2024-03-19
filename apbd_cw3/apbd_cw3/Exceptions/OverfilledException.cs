namespace apbd_cw3.Exceptions;

public class OverfilledException : Exception
{
    public OverfilledException()
    {
    }

    public OverfilledException(string? message) : base(message)
    {
    }

    public OverfilledException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
namespace _02Tsymbal.CustomException;

public class FutureDateException : Exception
{
    public FutureDateException() : base("This date is in future")
    {
    }
}
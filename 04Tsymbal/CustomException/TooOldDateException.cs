namespace _02Tsymbal.CustomException;

public class TooOldDateException : Exception
{
    public TooOldDateException() : base("This date is too old")
    {
    }
}
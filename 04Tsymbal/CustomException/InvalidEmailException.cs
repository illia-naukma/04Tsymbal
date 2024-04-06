namespace _02Tsymbal.CustomException;

using System;

public class InvalidEmailException : Exception
{
    public InvalidEmailException() : base("Invalid email!")
    {
    }
}

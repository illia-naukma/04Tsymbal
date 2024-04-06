using _02Tsymbal.CustomException;

namespace _04Tsymbal;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class Person
{
    private string _name;
    private string _surname;
    private string _emailAddress;
    private DateTime _dateOfBirth;
    private bool _isAdult;
    private string _sunSign;
    private string _chineseSign;
    private bool _isBirthday;

    public string Name => _name;
    public string Surname => _surname;
    public string EmailAddress => _emailAddress;
    public DateTime DateOfBirth => _dateOfBirth;

    public bool IsAdult => _isAdult;
    public string SunSign => _sunSign;
    public string ChineseSign => _chineseSign;
    public bool IsBirthday => _isBirthday;

    [JsonConstructor]
    public Person(string name, string surname, string emailAddress, DateTime dateOfBirth)
    {
        _name = name;
        _surname = surname;
        _emailAddress = emailAddress;
        _dateOfBirth = dateOfBirth;
        InitializeAsync();
    }

    public Person(string name, string surname, string emailAddress) : this(name, surname, emailAddress,
        DateTime.MinValue)
    {
    }

    public Person(string name, string surname, DateTime dateOfBirth) : this(name, surname, null, dateOfBirth)
    {
    }

    public async void InitializeAsync()
    {
        await Task.Run(() =>
        {
            _isAdult = ComputeIsAdult();
            _sunSign = ComputeSunSign();
            _chineseSign = ComputeChineseSign();
            _isBirthday = ComputeIsBirthday();
        });
    }

    private bool ComputeIsAdult()
    {
        int age = DateTime.Now.Year - _dateOfBirth.Year;
        if (DateTime.Now.DayOfYear < _dateOfBirth.DayOfYear)
            age -= 1;
        return age >= 18;
    }

    private string ComputeSunSign()
    {
        int month = DateOfBirth.Month;
        int day = DateOfBirth.Day;

        if ((month == 3 && day >= 21) || (month == 4 && day <= 19))
        {
            return "ARIES";
        }
        else if ((month == 4 && day >= 20) || (month == 5 && day <= 20))
        {
            return "TAURUS";
        }
        else if ((month == 5 && day >= 21) || (month == 6 && day <= 20))
        {
            return "GEMINI";
        }
        else if ((month == 6 && day >= 21) || (month == 7 && day <= 22))
        {
            return "CANCER";
        }
        else if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
        {
            return "LEO";
        }
        else if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
        {
            return "VIRGO";
        }
        else if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
        {
            return "LIBRA";
        }
        else if ((month == 10 && day >= 23) || (month == 11 && day <= 21))
        {
            return "SCORPIUS";
        }
        else if ((month == 11 && day >= 22) || (month == 12 && day <= 21))
        {
            return "SAGITTARIUS";
        }
        else if ((month == 12 && day >= 22) || (month == 1 && day <= 19))
        {
            return "CAPRICORN";
        }
        else if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
        {
            return "AQUARIUS";
        }
        else if ((month == 2 && day >= 19) || (month == 3 && day <= 20))
        {
            return "PISCES";
        }
        else
        {
            return "Impossible date";
        }
    }

    private string ComputeChineseSign()
    {
        int chineseHoroscopeIndex = (DateOfBirth.Year - 4) % 12;

        switch (chineseHoroscopeIndex)
        {
            case 0:
                return "Rat";
            case 1:
                return "Ox";
            case 2:
                return "Tiger";
            case 3:
                return "Rabbit";
            case 4:
                return "Dragon";
            case 5:
                return "Snake";
            case 6:
                return "Horse";
            case 7:
                return "Goat";
            case 8:
                return "Monkey";
            case 9:
                return "Rooster";
            case 10:
                return "Dog";
            case 11:
                return "Pig";
            default:
                return "Impossible date";
        }
    }


    private bool ComputeIsBirthday()
    {
        return DateTime.Now.Month == _dateOfBirth.Month && DateTime.Now.Day == _dateOfBirth.Day;
    }

    internal static bool IsValidEmail(string text)
    {
        if (string.IsNullOrWhiteSpace(text) || !text.Contains("@") || !text.Contains(".") ||
            text.IndexOf("@") > text.LastIndexOf("."))
            throw new InvalidEmailException();
        return true;
    }
}
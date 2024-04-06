using _02Tsymbal.CustomException;

namespace _04Tsymbal;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Collections;
using System.ComponentModel;
using System.Windows.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

public class ViewModel
{
    public static List<Person> Persons = new List<Person>();

    private static ListSortDirection? sortDirection = null;

    public static bool CalculateAge(DateTime? birthDate)
    {
        if (birthDate != null)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Value.Year;
            if (birthDate > today.AddYears(-age)) age--;
            if (age > 135)
            {
                throw new TooOldDateException();
            }
            else if (age < 0)
            {
                throw new FutureDateException();
            }
            else
            {
                if (birthDate.Value.Month == today.Month && birthDate.Value.Day == today.Day)
                    MessageBox.Show("Happy B-day!");
                return true;
            }
        }

        return false;
    }

    public static void SaveData()
    {
        string json = JsonConvert.SerializeObject(Persons);
        string filePath = "people.json";
        File.WriteAllText(filePath, json);
    }

    public static void LoadData()
    {
        string filePath = "people.json";
        if (!File.Exists(filePath))
        {
            return;
        }

        string jsonFromFile = File.ReadAllText(filePath);
        List<Person> deserializedPeople = JsonConvert.DeserializeObject<List<Person>>(jsonFromFile);
        Persons = deserializedPeople;
    }

    internal static void GenerateData()
    {
        List<Person> p = new List<Person>
        {
            new Person("John", "Doe", "john.doe@example.com", new DateTime(1990, 5, 15)),
            new Person("Jane", "Smith", "jane.smith@example.com", new DateTime(1985, 8, 10)),
            new Person("Michael", "Johnson", "michael.johnson@example.com", new DateTime(1982, 12, 3)),
            new Person("Emily", "Brown", "emily.brown@example.com", new DateTime(1995, 4, 25)),
            new Person("David", "Williams", "david.williams@example.com", new DateTime(1987, 9, 17)),
            new Person("Sarah", "Miller", "sarah.miller@example.com", new DateTime(1993, 7, 8)),
            new Person("James", "Anderson", "james.anderson@example.com", new DateTime(1980, 2, 12)),
            new Person("Olivia", "Jones", "olivia.jones@example.com", new DateTime(1998, 1, 30)),
            new Person("Daniel", "Wilson", "daniel.wilson@example.com", new DateTime(1984, 6, 5)),
            new Person("Ava", "Martinez", "ava.martinez@example.com", new DateTime(1996, 10, 19)),
            new Person("William", "Garcia", "william.garcia@example.com", new DateTime(1989, 3, 28)),
            new Person("Sophia", "Hernandez", "sophia.hernandez@example.com", new DateTime(1992, 11, 7)),
            new Person("Alexander", "Lopez", "alexander.lopez@example.com", new DateTime(1986, 8, 14)),
            new Person("Mia", "Gonzalez", "mia.gonzalez@example.com", new DateTime(1994, 6, 22)),
            new Person("Ethan", "Perez", "ethan.perez@example.com", new DateTime(1983, 4, 10)),
            new Person("Isabella", "Smith", "isabella.smith@example.com", new DateTime(1997, 2, 3)),
            new Person("Henry", "Lee", "henry.lee@example.com", new DateTime(1981, 9, 9)),
            new Person("Amelia", "Nguyen", "amelia.nguyen@example.com", new DateTime(1990, 7, 18)),
            new Person("Benjamin", "Chen", "benjamin.chen@example.com", new DateTime(1988, 5, 27)),
            new Person("Evelyn", "Wang", "evelyn.wang@example.com", new DateTime(1999, 12, 14)),
            new Person("Sebastian", "Wu", "sebastian.wu@example.com", new DateTime(1985, 3, 2)),
            new Person("Charlotte", "Kim", "charlotte.kim@example.com", new DateTime(1991, 1, 5)),
            new Person("Jack", "Tran", "jack.tran@example.com", new DateTime(1984, 10, 29)),
            new Person("Liam", "Liu", "liam.liu@example.com", new DateTime(1993, 6, 9)),
            new Person("Avery", "Gomez", "avery.gomez@example.com", new DateTime(1982, 4, 23)),
            new Person("Luna", "Huang", "luna.huang@example.com", new DateTime(1998, 8, 12)),
            new Person("Mason", "Zhang", "mason.zhang@example.com", new DateTime(1987, 11, 17)),
            new Person("Harper", "Ng", "harper.ng@example.com", new DateTime(1995, 9, 21)),
            new Person("Elijah", "Wang", "elijah.wang@example.com", new DateTime(1986, 5, 7)),
            new Person("Ella", "Chen", "ella.chen@example.com", new DateTime(1992, 3, 18)),
            new Person("Carter", "Wu", "carter.wu@example.com", new DateTime(1989, 2, 1)),
            new Person("Grace", "Tran", "grace.tran@example.com", new DateTime(1994, 12, 5)),
            new Person("Lucas", "Liu", "lucas.liu@example.com", new DateTime(1981, 6, 14)),
            new Person("Layla", "Gomez", "layla.gomez@example.com", new DateTime(1997, 4, 26)),
            new Person("Zoe", "Huang", "zoe.huang@example.com", new DateTime(1980, 10, 8)),
            new Person("Isaac", "Zhang", "isaac.zhang@example.com", new DateTime(1996, 7, 11)),
            new Person("Julian", "Ng", "julian.ng@example.com", new DateTime(1983, 9, 13)),
            new Person("Nora", "Wang", "nora.wang@example.com", new DateTime(1991, 11, 3)),
            new Person("Gabriel", "Chen", "gabriel.chen@example.com", new DateTime(1988, 4, 7)),
            new Person("Hazel", "Tran", "hazel.tran@example.com", new DateTime(1990, 8, 22)),
            new Person("Mateo", "Liu", "mateo.liu@example.com", new DateTime(1982, 12, 30)),
            new Person("Lily", "Gomez", "lily.gomez@example.com", new DateTime(1998, 6, 16)),
            new Person("Logan", "Huang", "logan.huang@example.com", new DateTime(1985, 1, 20)),
            new Person("Mia", "Zhang", "mia.zhang@example.com", new DateTime(1994, 10, 2)),
            new Person("Mason", "Ng", "mason.ng@example.com", new DateTime(1989, 8, 4)),
            new Person("Sophia", "Wang", "sophia.wang@example.com", new DateTime(1992, 4, 13)),
            new Person("Elijah", "Tran", "elijah.tran@example.com", new DateTime(1986, 11, 15)),
            new Person("Avery", "Liu", "avery.liu@example.com", new DateTime(1996, 3, 28)),
            new Person("Olivia", "Chen", "olivia.chen@example.com", new DateTime(1981, 7, 9)),
            new Person("James", "Zhang", "james.zhang@example.com", new DateTime(1997, 5, 18)),
            new Person("Lucas", "Ng", "lucas.ng@example.com", new DateTime(1980, 3, 7))
        };

        Persons = p;
    }

    internal static void SortHandler(object sender, DataGridSortingEventArgs e)
    {
        var data = (IEnumerable<Person>)((DataGrid)sender).ItemsSource;
        var sortMemberPath = e.Column.SortMemberPath;

        if (sortDirection == null)
        {
            sortDirection = ListSortDirection.Ascending;
        }
        else
        {
            sortDirection = sortDirection == ListSortDirection.Ascending
                ? ListSortDirection.Descending
                : ListSortDirection.Ascending;
        }

        var sortedData = sortDirection == ListSortDirection.Ascending
            ? data.OrderBy(x => x.GetType().GetProperty(sortMemberPath).GetValue(x, null))
            : data.OrderByDescending(x => x.GetType().GetProperty(sortMemberPath).GetValue(x, null));

        e.Handled = true;

        ((DataGrid)sender).ItemsSource = sortedData;
    }

    internal static void AddPerson(Person person)
    {
        Persons.Add(person);
    }

    internal static void RemovePerson(Person person)
    {
        Persons.RemoveAll(x =>
            x.Name == person.Name && x.Surname == person.Surname && x.DateOfBirth == person.DateOfBirth &&
            x.EmailAddress == person.EmailAddress);
    }

    internal static void UpdatePerson(Person person)
    {
        var index = Persons.FindIndex(x => x.Name == person.Name && x.Surname == person.Surname);
        if (index >= 0 && index < Persons.Count)
        {
            Persons[index] = person;
        }
    }
}
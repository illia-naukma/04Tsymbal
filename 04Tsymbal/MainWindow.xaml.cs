using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _04Tsymbal;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        ViewModel.LoadData();
        if (ViewModel.Persons.Count == 0)
            ViewModel.GenerateData();
        PersonList.ItemsSource = ViewModel.Persons;
        PersonList.Sorting += new DataGridSortingEventHandler(ViewModel.SortHandler);
    }

    private void DateChanged(object sender, SelectionChangedEventArgs e)
    {
        if (FirstName.Text.Length > 0 && LastName.Text.Length > 0 && Email.Text.Length > 0 &&
            DatePicker.SelectedDate != null)
        {
            EnableButtons();
        }
        else
        {
            DisableButtons();
        }
    }

    private void ProceedButton_Click(object sender, RoutedEventArgs e)
    {
        try {
            if (!ViewModel.CalculateAge(DatePicker.SelectedDate) || !Person.IsValidEmail(Email.Text))
            {
                return;
            }

            Person person = new Person(FirstName.Text, LastName.Text, Email.Text, DatePicker.SelectedDate.Value);
            person.InitializeAsync();
            ViewModel.AddPerson(person);
            PersonList.ItemsSource = ViewModel.Persons;
            PersonList.Items.Refresh();
            ViewModel.SaveData();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void FirstName_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (FirstName.Text.Length > 0 && LastName.Text.Length > 0 && Email.Text.Length > 0 &&
            DatePicker.SelectedDate != null)
        {
            EnableButtons();
        }
        else
        {
            DisableButtons();
        }
    }

    private void DisableButtons()
    {
        ProceedButton.IsEnabled = false;
        UpdateButton.IsEnabled = false;
        DeleteButton.IsEnabled = false;
    }

    private void EnableButtons()
    {
        ProceedButton.IsEnabled = true;
        UpdateButton.IsEnabled = true;
        DeleteButton.IsEnabled = true;
    }

    private void LastName_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (FirstName.Text.Length > 0 && LastName.Text.Length > 0 && Email.Text.Length > 0 &&
            DatePicker.SelectedDate != null)
        {
            EnableButtons();
        }
        else
        {
            DisableButtons();
        }
    }

    private void Email_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (FirstName.Text.Length > 0 && LastName.Text.Length > 0 && Email.Text.Length > 0 &&
            DatePicker.SelectedDate != null)
        {
            EnableButtons();
        }
        else
        {
            DisableButtons();
        }
    }

    private void UpdateButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (!ViewModel.CalculateAge(DatePicker.SelectedDate) || !Person.IsValidEmail(Email.Text))
            {
                return;
            }

            Person person = new Person(FirstName.Text, LastName.Text, Email.Text, DatePicker.SelectedDate.Value);
            person.InitializeAsync();
            ViewModel.UpdatePerson(person);
            PersonList.ItemsSource = ViewModel.Persons;
            PersonList.Items.Refresh();
            ViewModel.SaveData();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Person person = new Person(FirstName.Text, LastName.Text, Email.Text, DatePicker.SelectedDate.Value);
            ViewModel.RemovePerson(person);
            //update personlist
            PersonList.ItemsSource = ViewModel.Persons;
            PersonList.Items.Refresh();
            ViewModel.SaveData();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void PersonList_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
    {
        if (PersonList.SelectedItem != null)
        {
            Person person = (Person)PersonList.SelectedItem;
            FirstName.Text = person.Name;
            LastName.Text = person.Surname;
            Email.Text = person.EmailAddress;
            DatePicker.SelectedDate = person.DateOfBirth;
        }
    }
}
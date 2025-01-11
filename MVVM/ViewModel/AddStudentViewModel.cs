using Domain.Entities;
using PropertyChanged;
using SMSApp;
using System;
using System.Windows.Input;

[AddINotifyPropertyChangedInterface]
public class AddStudentViewModel
{
    public string Name { get; set; } = String.Empty;

    public int Age { get; set; }

    public double Grade { get; set; }

    public Guid StudentId { get; set; } = Guid.NewGuid();

    public ICommand GenerateStudentIdCommand { get; }

    public ICommand ShowStudentsListCommand { get; }

    public ICommand AddStudentToDbCommand { get; }

    public ICommand CalculateAverageGradeCommand { get; }

    public AddStudentViewModel()
    {
        GenerateStudentIdCommand = new Command(() =>
        {
            StudentId = Guid.NewGuid();
        });

        ShowStudentsListCommand = new Command(async () =>
        {
            await Shell.Current.GoToAsync("StudentsListViewModel");
        });

        AddStudentToDbCommand = new Command(async () =>
        { 
            if (!await Validate())
            {
                return;
            }

            Student student = new(StudentId, Name, Age, Grade);

            try
            {
                App._studentsManager.AddStudent(student);

                ResetProperties();
                await App.Current.MainPage.DisplayAlert("Sukces", "Student został pomyślnie dodany!", "OK");
            }
            catch (Exception ex) 
            {
                await App.Current.MainPage.DisplayAlert("Błąd", $"Błąd podczas operacji na bazie danych: {ex?.Message}", "OK");
            }
        });

        CalculateAverageGradeCommand = new Command(async () =>
        {
            try
            {
                var average = App._studentsManager.CalculateAverageGrade();
                var count = App._studentsManager.DisplaytAllStudents().Count;
                await App.Current.MainPage.DisplayAlert("Srednia ocena", $"Średnia ocena wynosi: {average} dla {count} uczniów.", "OK");
            }
            catch (Exception ex) 
            {
                await App.Current.MainPage.DisplayAlert("Błąd", $"Błąd podczas operacji na bazie danych: {ex?.Message}", "OK");
            }
        });
    }


    private async Task<bool> Validate()
    {
        bool valid = true;

        if (string.IsNullOrEmpty(Name) || Name.Length <= 0)
        {
            await App.Current.MainPage.DisplayAlert("Błąd", "Imię nie może być puste.", "OK");
            valid = false;
            return valid;
        }

        if (Age <= 0)
        {
            await App.Current.MainPage.DisplayAlert("Błąd", "Wiek musi być dodatni", "OK");
            valid = false;
            return valid;
        }

        if (Grade < 0 || Grade > 100)
        {
            await App.Current.MainPage.DisplayAlert("Błąd", "Ocena musi być w przedziale od 0 do 100.", "OK");
            valid = false;
            return valid;
        }

        return valid;
    }

    private void ResetProperties()
    {
        Name = string.Empty;
        Age = 0;
        Grade = 0.0;
        StudentId = Guid.NewGuid();
    }
}

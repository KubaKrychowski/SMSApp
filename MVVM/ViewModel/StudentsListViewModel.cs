using Domain.Entities;
using PropertyChanged;
using SMSApp.MVVM.View;
using System.Windows.Input;

namespace SMSApp.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class StudentsListViewModel
    {
        public List<Student> Students { get; set; }

        public ICommand DeleteStudentCommand { get; }

        public ICommand UpdateStudentCommand { get; }

        public ICommand ShowStudentGradeCommand { get; }

        public StudentsListViewModel(INavigation navigation)
        {
            try
            {
                Students = App._studentsManager.DisplaytAllStudents();
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Błąd", $"Błąd podczas wykonywania operacji na bazie danych: {ex?.Message}", "OK");
            }

            DeleteStudentCommand = new Command<Guid>(async (studentId) =>
            {
                try
                {
                    App._studentsManager.RemoveStudent(studentId);
                    Students = App._studentsManager.DisplaytAllStudents();
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Błąd", $"Błąd podczas kasowania studenta: {ex?.Message}", "OK");
                }
            });

            UpdateStudentCommand = new Command<Guid>(async (studentId) =>
            {
                await navigation.PushAsync(new UpdateStudentDataView(studentId));
            });

            ShowStudentGradeCommand = new Command<Guid>(async (studentId) =>
            {
                try
                {
                    var student = App._studentsManager.GetStudentById(studentId);
                    await App.Current.MainPage.DisplayAlert($"Student: {student.Name}", student.DisplayInfo(), "OK");
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Błąd", $"Błąd podczas wykonywania operacji na bazie danych: {ex?.Message}", "OK");
                }
            });

        }
    }
}

using Domain.Entities;
using PropertyChanged;
using SMSApp.Domain.Exceptions;
using System.Windows.Input;

namespace SMSApp.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class UpdateStudentDataViewModel
    {
        public Student Student { get; set; }

        public ICommand SaveChangesCommand { get; }

        public UpdateStudentDataViewModel(Guid studentId, INavigation navigation)
        {
            try
            {
                Student = App._studentsManager.GetStudentById(studentId);
            }
            catch (NotFoundException ex)
            {
                App.Current.MainPage
                    .DisplayAlert("Nie znaleziono", $"{ex?.Message}", "OK")
                    .GetAwaiter()
                    .GetResult();
            }
            catch (Exception ex) 
            {
                App.Current.MainPage
                    .DisplayAlert("Błąd", $"Błąd podczas wykonywania operacji na bazie danych: {ex?.Message}", "OK")
                    .GetAwaiter()
                    .GetResult();
            }
            
            SaveChangesCommand = new Command(async () =>
            {
                try
                {
                    App._studentsManager.UpdateStudent(Student);
                    await navigation.PopAsync();
                }
                catch (Exception ex) 
                {
                   await App.Current.MainPage.DisplayAlert("Błąd", $"Błąd podczas wykonywania operacji na bazie danych: {ex?.Message}", "OK");
                }
            });
        }
    }
}

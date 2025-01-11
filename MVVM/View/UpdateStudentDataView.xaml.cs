using SMSApp.MVVM.ViewModel;

namespace SMSApp.MVVM.View;

[QueryProperty("StudentId","StudentId")]
public partial class UpdateStudentDataView : ContentPage
{
    string studentId;
    public string StudentId
    {
        get => studentId;
        set
        {
            studentId = value;
            OnPropertyChanged();
        }
    }
    public UpdateStudentDataView(Guid studentId)
    {
        InitializeComponent();
        BindingContext = new UpdateStudentDataViewModel(studentId, Navigation);
    }
}

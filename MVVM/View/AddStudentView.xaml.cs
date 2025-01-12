namespace SMSApp.MVVM.View;

public partial class AddStudentView : ContentPage
{
    public AddStudentView()
	{
		InitializeComponent();
		BindingContext = new AddStudentViewModel();
	}
}
using SMSApp.MVVM.ViewModel;

namespace SMSApp.MVVM.View;

public partial class StudentsListView : ContentPage
{
	public StudentsListView()
	{
		InitializeComponent();
		BindingContext = new StudentsListViewModel(Navigation);
	}
}
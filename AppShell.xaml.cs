using SMSApp.MVVM.View;

namespace SMSApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            Routing.RegisterRoute("StudentsListViewModel", typeof(StudentsListView));
            Routing.RegisterRoute("AddStudentViewModel", typeof(AddStudentView));
            Routing.RegisterRoute("UpdateStudentDataViewModel", typeof(UpdateStudentDataView));
            InitializeComponent();
        }
    }
}

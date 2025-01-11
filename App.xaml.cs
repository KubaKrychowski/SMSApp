using SMSApp.Application.Managers;
using SMSApp.Domain.DataContext;
using System.Diagnostics;

namespace SMSApp
{
    public partial class App : Microsoft.Maui.Controls.Application
    {
        public static StudentsManager _studentsManager { get; set; }
        public App(DataContext dataContext, StudentsManager studentsManager)
        {
            InitializeComponent();
            dataContext.InitializeDb();
            _studentsManager = studentsManager;
            MainPage = new AppShell();
            //throw new NotImplementedException();
        }
    }

}

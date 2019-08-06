using Xamarin.Essentials;
using Xamarin.Forms;

using TeachingApp.Helpers;
using TeachingApp.Pages;

namespace TeachingApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if(string.IsNullOrEmpty(Preferences.Get(Constants.Access_Token, string.Empty)))
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new MasterPage();
            }
        }
    }
}

using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TeachingApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();
        }

        private void TapHome_OnTapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new HomePage());
            IsPresented = false;
        }

        private void TapChangePassword_OnTapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ChangePasswordPage());
            IsPresented = false;
        }

        private void TapInstructor_OnTapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new BecomeInstructorPage());
            IsPresented = false;
        }

        private void TapFAQ_OnTapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new FAQPage());
            IsPresented = false;
        }

        private void TapLogout_OnTapped(object sender, EventArgs e)
        {

        }
    }
}

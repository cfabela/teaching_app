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

        private void BtnHome_OnClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new HomePage());
            IsPresented = false;
        }

        private void BtnChangePassword_OnClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ChangePasswordPage());
            IsPresented = false;
        }
    }
}

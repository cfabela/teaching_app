using System;
using System.Collections.Generic;
using TeachingApp.Servies;
using Xamarin.Forms;

namespace TeachingApp.Pages
{
    public partial class ChangePasswordPage : ContentPage
    {
        private IAccountServiceInterface serviceApi;

        public ChangePasswordPage()
        {
            InitializeComponent();
        }

        private async void BtnChangePassword_OnClicked(object sender, EventArgs e)
        {
            serviceApi = serviceApi ?? new MockupService();
            var response = await serviceApi.ChangePassword(EntOldPassword.Text, EntNewPassword.Text,
                EntConfirmPassword.Text);

            if (response)
            {
                await DisplayAlert("Password Changed", "Kindly login with the new password", "Alright");
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                await DisplayAlert("Oops", "Something wrong", "Cancel");
            }

        }
    }
}

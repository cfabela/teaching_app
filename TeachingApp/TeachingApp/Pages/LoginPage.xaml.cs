using System;
using TeachingApp.Helpers;
using TeachingApp.Servies;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TeachingApp.Pages
{
    public partial class LoginPage : ContentPage
    {
        private IAccountServiceInterface apiService;
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            apiService = apiService ?? new MockupService();

            var response = await apiService.GetToken(EntEmail.Text, EntPassword.Text);

            if(string.IsNullOrEmpty(response.AccessToken))
            {
                await DisplayAlert("Error", "Something wrong", "Alright");
            }
            else
            {
                Preferences.Set(Constants.Access_Token, response.AccessToken);
                Preferences.Set(Constants.Password, EntPassword.Text);
                Preferences.Set(Constants.Email, EntEmail.Text);
                Application.Current.MainPage = new MasterPage();
            }
        }

        private void Signup_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage());
        }

        private void TapForgotPassword_OnTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgotPasswordPage());
        }
    }
}
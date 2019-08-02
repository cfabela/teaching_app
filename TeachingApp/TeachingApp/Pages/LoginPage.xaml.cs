using System;
using System.Collections.Generic;
using TeachingApp.Servies;
using Xamarin.Forms;

namespace TeachingApp.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            var apiService = new AccountService();
            var response = await apiService.GetToken(EntEmail.Text, EntPassword.Text);
            if(string.IsNullOrEmpty(response.AccessToken))
            {
                await DisplayAlert("Error", "Something wrong", "Alright");
            }
            else
            {
                Application.Current.MainPage = new MasterPage();
            }
        }

        private void Signup_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage());
        }
    }
}

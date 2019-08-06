using System;
using System.Collections.Generic;
using TeachingApp.Servies;
using Xamarin.Forms;

namespace TeachingApp.Pages
{
    public partial class ForgotPasswordPage : ContentPage
    {

        private IAccountServiceInterface apiService;

        public ForgotPasswordPage()
        {
            InitializeComponent();
        }

        private async void BtnSend_OnClicked(object sender, EventArgs e)
        {
            apiService = apiService ?? new MockupService();
            var response = await apiService.PasswordRecovery(EntEmail.Text);
            if (response)
            {
                await DisplayAlert("Hi", "A new password has been sent to your email. Kindly type new password", "Alright");
                await Navigation.PopToRootAsync();
            }
            else
            {
                await DisplayAlert("Ooops", "Something wrong", "Cancel");
            }
        }
    }
}

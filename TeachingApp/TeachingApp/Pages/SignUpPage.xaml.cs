using TeachingApp.Servies;

using Xamarin.Forms;

namespace TeachingApp.Pages
{
    public partial class SignUpPage :ContentPage
    {
        private IAccountServiceInterface apiService;

        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void BtnSignup_Clicked(object sender, System.EventArgs e)
        {
            apiService = apiService ?? new MockupService();
            var response = apiService.RegisetUser(EntEmail.Text, EntPassword.Text, EntConfirmPassword.Text).Result;
            
            if (!response)
            {
                await DisplayAlert("Oops", "Something wrong", "Cancel");
            }
            else
            {
                await DisplayAlert("Hi", "Your account has been created", "OK");
                await Navigation.PopToRootAsync();
            }
        }
    }
}

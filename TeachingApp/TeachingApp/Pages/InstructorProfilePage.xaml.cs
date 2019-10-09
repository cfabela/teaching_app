using System;

using Xamarin.Forms;
using Xamarin.Essentials;

using TeachingApp.Servies;

namespace TeachingApp.Pages
{
    public partial class InstructorProfilePage : ContentPage
    {
        private IAccountServiceInterface apiService;
        private string number;
        private string email;

        public InstructorProfilePage(int instructorId)
        {
            InitializeComponent();
            GetInstructor(instructorId);
        }

        private async void GetInstructor(int instructorId)
        {
            apiService = apiService ?? new MockupService();
            var instructor =  await apiService.GetInstructor(instructorId);
            ImgProfile.Source = instructor.ImageLogo;
            LblCity.Text = instructor.City;
            LblLanguage.Text = instructor.Language;
            LblNationality.Text = instructor.Nationality;
            LblSpecialization.Text = instructor.CourseDomain;
            LblExperience.Text = instructor.Experience;
            LblName.Text = instructor.Name;
            LblOnelineDescription.Text = instructor.OneLineTitle;
            LblHourlyRate.Text = instructor.HourlyRate;
            LblDescription.Text = instructor.Description;
            number = instructor.Phone;
            email = instructor.Email;
        }

        private void BtnCall_OnClicked(object sender, EventArgs e)
        {
            PhoneDialer.Open(number);
        }

        private void BtnSms_OnClicked(object sender, EventArgs e)
        {
            var message = new SmsMessage("", number);
            Sms.ComposeAsync(message);
        }

        private void BtnEmail_OnClicked(object sender, EventArgs e)
        {
            var message = new EmailMessage("", "", email);
            Email.ComposeAsync(message);
        }
    }
}

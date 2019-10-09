using System;

using Xamarin.Forms;

using TeachingApp.Servies;

namespace TeachingApp.Pages
{
    public partial class InstructorProfilePage : ContentPage
    {
        private IAccountServiceInterface apiService;

        public InstructorProfilePage(int instructorId)
        {
            InitializeComponent();
            GetInstructor(instructorId);
        }


        private async void GetInstructor(int instructorId)
        {

        }

        private void BtnCall_OnClicked(object sender, EventArgs e)
        {

        }

        private void BtnSms_OnClicked(object sender, EventArgs e)
        {

        }

        private void BtnEmail_OnClicked(object sender, EventArgs e)
        {

        }
    }
}

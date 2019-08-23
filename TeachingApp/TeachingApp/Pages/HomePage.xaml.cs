using System;
using System.Collections.ObjectModel;

using TeachingApp.Models;
using TeachingApp.Servies;

using Xamarin.Forms;

namespace TeachingApp.Pages
{
    public partial class HomePage : ContentPage
    {
        private ObservableCollection<InstructorModel> Instructors;
        private IAccountServiceInterface apiService;

        private bool FirstAppearing = true;
        public HomePage()
        {
            InitializeComponent();
            Instructors = new ObservableCollection<InstructorModel>();   
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (FirstAppearing)
            {
                apiService = apiService ?? new MockupService();
                var instructors = await apiService.GetInstructors();
                foreach (var instructor in instructors)
                {
                    Instructors.Add(instructor);
                }

                LvInstructors.ItemsSource = Instructors;
            }

            FirstAppearing = false;
        }

        private void LvInstructors_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedInstructor = e.SelectedItem as InstructorModel;
            Navigation.PushAsync(new InstructorProfilePage(selectedInstructor.Id));
        }
    }
}
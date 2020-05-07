using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TeachingApp.Models;
using TeachingApp.Servies;
using Xamarin.Forms;

namespace TeachingApp.Pages
{
    public partial class SearchInstructorPage : ContentPage
    {

        private ObservableCollection<InstructorModel> Instructors;
        private IAccountServiceInterface apiService;

        private string _course;
        private string _city;
        private string _gender;

        private bool FirstAppearing = true;
        public SearchInstructorPage(string course, string city, string gender)
        {
            InitializeComponent();
            Instructors = new ObservableCollection<InstructorModel>();

            _course = course;
            _city = city;
            _gender = gender;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (FirstAppearing)
            {
                apiService = apiService ?? new MockupService();
                var instructors = await apiService.SearchInstructors(_course, _city, _gender);
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

        private void TbSearch_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FindInstructorPage());
        }
    }
}
using System.Collections.ObjectModel;

using TeachingApp.Models;
using TeachingApp.Servies;
using Xamarin.Forms;

namespace TeachingApp.Pages
{
    public partial class FindInstructorPage : ContentPage
    {
        private ObservableCollection<CourseModel> Courses;
        private ObservableCollection<CityModel> Cities;

        private IAccountServiceInterface apiService;

        public FindInstructorPage()
        {
            InitializeComponent();

            apiService = new AccountService();

            Courses = new ObservableCollection<CourseModel>();
            Cities = new ObservableCollection<CityModel>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadCourses();
            LoadCities();
        }

        private async void LoadCourses()
        {
            var courses = await apiService.GetCourses();
            foreach(var course in courses)
            {
                Courses.Add(course);
            }

            PickerCourse.ItemsSource = Courses;
        }

        private async void LoadCities()
        {
            var cities = await apiService.GetCities();
            foreach(var city in cities)
            {
                Cities.Add(city);
            }

            PickerCity.ItemsSource = Cities;
        }

        private void BtnSearchInstructor_Clicked(System.Object sender, System.EventArgs e)
        {
            if( PickerCourse.SelectedIndex < 0 ||
                PickerCity.SelectedIndex < 0 ||
                PickerGender.SelectedIndex < 0)
            {
                DisplayAlert("Oops", "Please select all the options", "Cancel");
            }
            else
            {
                var course = PickerCourse.Items[PickerCourse.SelectedIndex].Trim();
                var city = PickerCourse.Items[PickerCity.SelectedIndex].Trim();
                var gender = PickerGender.Items[PickerGender.SelectedIndex].Trim();

                Navigation.PushAsync(new SearchInstructorPage(course, city, gender));
            }
        }
    }
}

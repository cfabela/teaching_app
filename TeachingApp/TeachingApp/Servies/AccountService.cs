﻿
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Xamarin.Essentials;

using TeachingApp.Helpers;
using TeachingApp.Models;
using Xamarin.Essentials;

namespace TeachingApp.Servies
{
    public class AccountService : IAccountServiceInterface
    {
        public async Task<bool> RegisetUser(string email, string password, string confirmPassword)
        {
            var registerModel = new RegisterModel()
            {
                Email = email, Password = password, ConfirmPassword = confirmPassword
            };

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(registerModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://teachify.azurewebsites.net/api/Account/Register", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<TokenResponseModel> GetToken(string email, string password)
        {
            var httpClient = new HttpClient();
            var content = new StringContent($"grant_type=password&username={email}&password={password}", Encoding.UTF8);
            var response = await httpClient.PostAsync("https://teachify.azurewebsites.net//Token", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TokenResponseModel>(jsonResult);
                return result;
            }

            return new TokenResponseModel()
            {
                AccessToken = string.Empty,

            };
        }

        public async Task<bool> PasswordRecovery(string email)
        {
            var httpClient = new HttpClient();
            var recoverPasswordModel = new PasswordRecoveryModel()
            {
                Email = email
            };

            var json = JsonConvert.SerializeObject(recoverPasswordModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://teachify.azurewebsites.net/api/Users/PasswordRecovery", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ChangePassword(string oldPassword, string newPassword, string confirmPassword)
        {
            var httpClient = new HttpClient();
            var changePasswordModel = new ChangePasswordModel()
            {
                OldPassword = oldPassword,
                NewPassword = newPassword,
                ConfirmPassword = confirmPassword
            };

            var json = JsonConvert.SerializeObject(changePasswordModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get(Constants.Access_Token, string.Empty));
            var response = await httpClient.PostAsync("https://teachigy.azurewebsites.net/api/Account/ChangePassword", content);
            
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> BecomeAnInstructor(InstructorModel instructor)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(instructor);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get(Constants.Access_Token, string.Empty));
            var response = await httpClient.PostAsync("https://teachify.azurewebsites.net/api/instructors", content);
            return response.StatusCode == HttpStatusCode.Created;
        }

        public async Task<List<InstructorModel>> GetInstructors()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get(Constants.Access_Token, string.Empty));
            var response = await httpClient.GetStringAsync("https://teachify.azurewebsites.net/api/instructors");
            return JsonConvert.DeserializeObject<List<InstructorModel>>(response);
        }

        public async Task<InstructorModel> GetInstructor(int id)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get(Constants.Access_Token, string.Empty));
            var response = await httpClient.GetStringAsync("https://teachify.azurewebsites.net/api/instructors/" + id);
            return JsonConvert.DeserializeObject<InstructorModel>(response);
        }

        public async Task<List<InstructorModel>> SearchInstructors(string subject, string gender, string city)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get(Constants.Access_Token, string.Empty));
            var response = await httpClient.GetStringAsync("https://teachify.azurewebsites.net/api/instructors?subject="+subject +
                "&gender="+gender+"&city="+city);
            return JsonConvert.DeserializeObject<List<InstructorModel>>(response);
        }

        public async Task<List<CityModel>> GetCities()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://teachify.azurewebsites.net/api/cities");
            return JsonConvert.DeserializeObject<List<CityModel>>(response);
        }

        public async Task<List<CourseModel>> GetCourses()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://teachify.azurewebsites.net/api/courses");
            return JsonConvert.DeserializeObject<List<CourseModel>>(response);
        }
    }
}

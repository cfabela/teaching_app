using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TeachingApp.Models;

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
    }
}

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

        public async Task<TokenResponseModel> GetToken(string email, string password)
        {
            var httpClient = new HttpClient();
            var content = new StringContent($"grant_type=password&username={email}&password={password}", Encoding.UTF8);
            var response = await httpClient.PostAsync("http://teachify.azurewebsites.net//Token", content);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TokenResponseModel>(jsonResult);

            return result;
        }
    }
}

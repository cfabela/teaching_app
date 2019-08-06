using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeachingApp.Models;

namespace TeachingApp.Servies
{
    public class MockupService : IAccountServiceInterface
    {
        public Task<bool> BecomeAnInstructor(InstructorModel instructor)
        {
            return Task.FromResult(true);
        }

        public Task<bool> ChangePassword(string oldPassword, string newPassword, string confirmPassword)
        {
            return Task.FromResult(true);
        }

        public Task<List<CityModel>> GetCities()
        {
            return new Task<List<CityModel>>(() => new List<CityModel>());
        }

        public Task<List<CourseModel>> GetCourses()
        {
            return new Task<List<CourseModel>>(() => new List<CourseModel>());
        }

        public Task<InstructorModel> GetInstructor(int id)
        {
            return new Task<InstructorModel>(() => new InstructorModel());
        }

        public Task<List<InstructorModel>> GetInstructors()
        {
            throw new NotImplementedException();
        }

        public Task<TokenResponseModel> GetToken(string email, string password)
        {
            var resultToken = new TokenResponseModel
            {
                AccessToken = $"special_token{email}_{password}",
                TokenType = "password",
                ExpiresIn = 1024,
                UserName = email,
                Issued = "true",
                Expires = "2014 05, 01"
            };

            return Task.FromResult(resultToken);
        }

        public Task<bool> PasswordRecovery(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisetUser(string email, string password, string confirmPassword)
        {
            return Task.FromResult(true);
        }

        public Task<List<InstructorModel>> SearchInstructors(string subject, string gender, string city)
        {
            throw new NotImplementedException();
        }
    }
}

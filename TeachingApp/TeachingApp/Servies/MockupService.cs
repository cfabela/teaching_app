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
            var instructors = new List<InstructorModel>();
            instructors.Add(new InstructorModel
            {
                Id = 1,
                Name = "Robert",
                Language = "English",
                City = "Amsterdam",
                Experience = "2 Yeras",
                HourlyRate = "$20/h",
                Nationality = "English",
                Gender = "Male",
                CourseDomain = "Computer Science",
                ImageLogo = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4f/Csharp_Logo.png/245px-Csharp_Logo.png"
            });

            instructors.Add(new InstructorModel
            {
                Id = 2,
                Name = "Denise",
                Language = "Spanish",
                City = "Cuban",
                Experience = "5 Yeras",
                HourlyRate = "$30/h",
                Nationality = "Cuban",
                Gender = "Male",
                CourseDomain = "History",
                ImageLogo = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4f/Csharp_Logo.png/245px-Csharp_Logo.png"
            });

            instructors.Add(new InstructorModel
            {
                Id = 3,
                Name = "Ambar",
                Language = "Spanish",
                City = "Mexican",
                Experience = "3 Yeras",
                HourlyRate = "$15/h",
                Nationality = "Mexican",
                Gender = "Female",
                CourseDomain = "Design",
                ImageLogo = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4f/Csharp_Logo.png/245px-Csharp_Logo.png"
            });

            instructors.Add(new InstructorModel
            {
                Id = 4,
                Name = "Cindy",
                Language = "Danish",
                City = "Japan",
                Experience = "10 Yeras",
                HourlyRate = "$30/h",
                Nationality = "Japanese",
                Gender = "Female",
                CourseDomain = "Economics",
                ImageLogo = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4f/Csharp_Logo.png/245px-Csharp_Logo.png"
            });

            return Task.FromResult(instructors);
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
            return Task.FromResult(true);
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

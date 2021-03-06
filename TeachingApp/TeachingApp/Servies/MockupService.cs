﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeachingApp.Models;

namespace TeachingApp.Servies
{
    public class MockupService : IAccountServiceInterface
    {
        private List<InstructorModel> instructors;

        public MockupService()
        {
            instructors = CreateInstructors();
        }

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
            return new Task<List<CourseModel>>(() => CreateCourses());
        }

        public Task<InstructorModel> GetInstructor(int id)
        {
            if (id < instructors.Count) return Task.FromResult(instructors[id]);
            throw new Exception("Not element found!");
        }

        public Task<List<InstructorModel>> GetInstructors()
        {
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
            return Task.FromResult(instructors.Take(3).ToList());
        }

        private List<InstructorModel> CreateInstructors()
        {
            var returnList = new List<InstructorModel>();
            returnList.Add(new InstructorModel
            {
                Id = 0,
                Name = "Robert Webber",
                Language = "English",
                Phone = "4511854121",
                Email = "educator@gmail.com",
                City = "Amsterdam",
                Experience = "2 Yeras",
                HourlyRate = "$20/h",
                Nationality = "English",
                OneLineTitle = "asdasdasd323434 asdasd",
                Gender = "Male",
                CourseDomain = "Computer Science",
                Description = "Lorem Ipsum is simply dummy text of " +
                       "the printing and typesetting industry.Lorem " +
                       "Ipsum has been the industry's standard dummy text " +
                       "ever since the 1500s, when an unknown printer took " +
                       "a galley of type and scrambled it ",
                ImageLogo = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4f/Csharp_Logo.png/245px-Csharp_Logo.png"
            });

            returnList.Add(new InstructorModel
            {
                Id = 1,
                Name = "Denise",
                Language = "Spanish",
                Email = "educator@gmail.com",
                Phone = "4511854121",
                City = "Cuban",
                OneLineTitle = "asdasdasd323434 asdasd",
                Experience = "5 Yeras",
                HourlyRate = "$30/h",
                Nationality = "Cuban",
                Gender = "Male",
                CourseDomain = "History",
                Description = "Lorem Ipsum is simply dummy text of " +
                       "the printing and typesetting industry.Lorem " +
                       "Ipsum has been the industry's standard dummy text " +
                       "ever since the 1500s, when an unknown printer took " +
                       "a galley of type and scrambled it ",
                ImageLogo = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4f/Csharp_Logo.png/245px-Csharp_Logo.png"
            });

            returnList.Add(new InstructorModel
            {
                Id = 2,
                Name = "Ambar",
                Phone = "4511854121",
                Email = "educator@gmail.com",
                OneLineTitle = "asdasdasd323434 asdasd",
                Language = "Spanish",
                City = "Mexican",
                Experience = "3 Yeras",
                HourlyRate = "$15/h",
                Nationality = "Mexican",
                Gender = "Female",
                CourseDomain = "Design",
                Description = "Lorem Ipsum is simply dummy text of " +
                       "the printing and typesetting industry.Lorem " +
                       "Ipsum has been the industry's standard dummy text " +
                       "ever since the 1500s, when an unknown printer took " +
                       "a galley of type and scrambled it ",
                ImageLogo = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4f/Csharp_Logo.png/245px-Csharp_Logo.png"
            });

            returnList.Add(new InstructorModel
            {
                Id = 3,
                Name = "Cindy",
                Phone = "4511854121",
                Email = "educator@gmail.com",
                OneLineTitle = "asdasdasd323434 asdasd",
                Language = "Danish",
                City = "Japan",
                Experience = "10 Yeras",
                HourlyRate = "$30/h",
                Nationality = "Japanese",
                Gender = "Female",
                CourseDomain = "Economics",
                Description = "Lorem Ipsum is simply dummy text of " +
                       "the printing and typesetting industry.Lorem " +
                       "Ipsum has been the industry's standard dummy text " +
                       "ever since the 1500s, when an unknown printer took " +
                       "a galley of type and scrambled it ",
                ImageLogo = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4f/Csharp_Logo.png/245px-Csharp_Logo.png"
            });

            return returnList;
        }

        private List<CourseModel> CreateCourses()
        {
            var returnList = new List<CourseModel>();

            returnList.Add(new CourseModel
            {
                Name = "Accounting"
            });

            returnList.Add(new CourseModel
            {
                Name = "Arts"
            });

            returnList.Add(new CourseModel
            {
                Name = "Biological Science"
            });

            returnList.Add(new CourseModel
            {
                Name = "Chemestry"
            });

            returnList.Add(new CourseModel
            {
                Name = "Computer Science"
            });

            returnList.Add(new CourseModel
            {
                Name = "Dentistry"
            });

            returnList.Add(new CourseModel
            {
                Name = "Forensic Science"
            });

            returnList.Add(new CourseModel
            {
                Name = "Medicine"
            });

            returnList.Add(new CourseModel
            {
                Name = "Philosophy"
            });

            return returnList;
        }
    }
}

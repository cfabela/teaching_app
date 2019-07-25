using System;
using System.Threading.Tasks;
using TeachingApp.Models;

namespace TeachingApp.Servies
{
    public interface IAccountServiceInterface
    {
        Task<bool> RegisetUser(string email, string password, string confirmPassword);
        Task<TokenResponseModel> GetToken(string email, string password);
        Task<bool> PasswordRecovery(string email);
        Task<bool> ChangePassword(string oldPassword, string newPassword, string confirmPassword);
        Task<bool> BecomeAnInstructor(InstructorModel instructor);
        Task<List<InstructorModel>> GetInstructors();
    }
}

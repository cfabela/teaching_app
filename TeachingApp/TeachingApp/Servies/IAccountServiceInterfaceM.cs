using System;
using System.Threading.Tasks;

namespace TeachingApp.Servies
{
    public interface IAccountServiceInterface
    {
        Task<bool> RegisetUser(string email, string password, string confirmPassword);
    }
}

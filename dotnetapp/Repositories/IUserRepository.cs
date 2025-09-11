using System.Threading.Tasks;
using dotnetapp.Models;

namespace dotnetapp.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
        // Add other user-related data operations as needed
    }
}

using Book_Store.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Book_Store.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
    }
}
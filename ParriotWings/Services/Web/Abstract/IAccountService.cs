using System;
using System.Threading.Tasks;
using ParriotWings.Entities;
using ParriotWings.Helpers;

namespace ParriotWings.Services.Web.Abstract
{
    public interface IAccountService
    {
        Task<Result<AuthorizedUser>> SignIn(string email, string password);
        Task<Result<AuthorizedUser>> SignUp(string email, string username, string password);
        Task<Result<UserInfoToken>> GetAccountProfile(string accessToken);
    }
}

using System;
using System.Threading.Tasks;
using ParriotWings.Entities;
using ParriotWings.Helpers;

namespace ParriotWings.Managers.Abstract
{
    public interface IAccountManager
    {
        bool IsAuthorized();
        void Logout();

        Task<Result<AuthorizedUser>> SignIn(string email, string password);
        Task<Result<AuthorizedUser>> SignUp(string email, string username, string password);
        Task<Result<UserInfoToken>> GetAccountProfile();
    }
}

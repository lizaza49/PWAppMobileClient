using System;
using System.Threading.Tasks;
using ParriotWings.Entities;
using ParriotWings.Helpers;
using ParriotWings.Managers.Abstract;
using ParriotWings.Services.Storage;
using ParriotWings.Services.Web.Abstract;

namespace ParriotWings.Managers
{
    public class AccountManager : IAccountManager
    {
        private readonly IAccountService accountService;
        private readonly ILocalStorage localStorage;

        public string AccessToken => localStorage.GetStringValue("AccessToken");

        public AccountManager(IAccountService accountService, ILocalStorage localStorage)
        {
            this.accountService = accountService;
            this.localStorage = localStorage;
        }

        public async Task<Result<UserInfoToken>> GetAccountProfile()
        {
            return await accountService.GetAccountProfile(AccessToken);
        }

        public bool IsAuthorized()
        {
            return !String.IsNullOrEmpty(AccessToken);
        }

        public async Task<Result<AuthorizedUser>> SignIn(string email, string password)
        {
            var response = await accountService.SignIn(email, password);
            if (response.IsSuccessful)
            {
                if (!string.IsNullOrEmpty(response.Instance?.Token)) localStorage.SetStringValue("AccessToken", response.Instance?.Token);
            }
            return response;
        }

        public async Task<Result<AuthorizedUser>> SignUp(string email, string username, string password)
        {
            var response = await accountService.SignUp(email, username, password);
            if (response.IsSuccessful)
            {
                if (!string.IsNullOrEmpty(response.Instance?.Token)) localStorage.SetStringValue("AccessToken", response.Instance?.Token);
            }
            return response;
        }

        public void Logout()
        {
            localStorage.SetStringValue("AccessToken", string.Empty);
        }
    }
}

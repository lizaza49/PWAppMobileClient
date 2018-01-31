using System;
using System.Threading.Tasks;
using ParriotWings.Entities;
using ParriotWings.Helpers;
using ParriotWings.Services.Web.Abstract;
using ParriotWings.Services.Web.Requests;

namespace ParriotWings.Services.Web
{
    public class AccountService : IAccountService
    {
        private readonly IRequestHelper requestHelper;

        public AccountService(IRequestHelper requestHelper)
        {
            this.requestHelper = requestHelper;
        }

        public async Task<Result<UserInfoToken>> GetAccountProfile(string accessToken)
        {
            return await requestHelper.SendRequest<UserInfoToken>(new GetAccountRequest(accessToken));
        }

        public async Task<Result<AuthorizedUser>> SignIn(string email, string password)
        {
            return await requestHelper.SendRequest<AuthorizedUser>(new SignInRequest(email, password));
        }

        public async Task<Result<AuthorizedUser>> SignUp(string email, string username, string password)
        {
            return await requestHelper.SendRequest<AuthorizedUser>(new SignUpRequest(email, username, password));
        }
    }
}

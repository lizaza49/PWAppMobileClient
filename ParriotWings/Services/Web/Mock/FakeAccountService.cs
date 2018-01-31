using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ParriotWings.Entities;
using ParriotWings.Helpers;
using ParriotWings.Services.Web.Abstract;

namespace ParriotWings.Services.Web.Mock
{
    public class FakeAccountService : IAccountService
    {
        public Dictionary<String, AccountProfile> users = new Dictionary<string, AccountProfile>();
        private Dictionary<String, String> passwords = new Dictionary<string, string>();

        private string currentUserToken;
        private string currentUsername;

        public AccountProfile currentUser => users[currentUsername];
        int lastId = 1002;

        public FakeAccountService()
        {
            users.Add("test1", new AccountProfile()
            {
                Id = 1000,
                Name = "test1",
                Email = "test1@test.com",
                Balance = 500
            });
            passwords.Add("test1@test.com", "12345");

            users.Add("test2", new AccountProfile()
            {
                Id = 1001,
                Name = "test2",
                Email = "test2@test.com",
                Balance = 500
            });
            passwords.Add("test2@test.com", "qwerty");

            users.Add("test3", new AccountProfile()
            {
                Id = 1002,
                Name = "test3",
                Email = "test3@test.com",
                Balance = 500
            });
            passwords.Add("test3@test.com", "test");
        }

        public async Task<Result<UserInfoToken>> GetAccountProfile(string accessToken)
        {
            await Task.Delay(1000);
            if (currentUserToken == accessToken)
            {
                return new SuccessResult<UserInfoToken>(new UserInfoToken()
                {
                    UserInfo = currentUser
                });
            }
            return new ErrorResult<UserInfoToken>(new Error()
            {
                Code = Error.CodeUnauthorizedError,
                Message = LocalizedStrings.UnauthorizedError
            });
        }

        public async Task<Result<AuthorizedUser>> SignIn(string email, string password)
        {
            await Task.Delay(1000);
            foreach (var user in users)
            {
                if (user.Value.Email == email)
                {
                    if (passwords[email] == password)
                    {
                        currentUsername = user.Value.Name;
                        currentUserToken = email + password;
                        return new SuccessResult<AuthorizedUser>(new AuthorizedUser()
                        {
                            Token = currentUserToken
                        });
                    }
                    else 
                    {
                        return new ErrorResult<AuthorizedUser>(new Error()
                        {
                            Code = Error.CodeInvalidEmailOrPassword,
                            Message = LocalizedStrings.InvalidEmailOrPassword
                        });
                    }
                }
            }
            return new ErrorResult<AuthorizedUser>(new Error()
            {
                Code = Error.CodeUserNotFound,
                Message = LocalizedStrings.UserNotFound
            });
        }

        public async Task<Result<AuthorizedUser>> SignUp(string email, string username, string password)
        {
            await Task.Delay(1000);
            if (users.ContainsKey(username))
            {
                return new ErrorResult<AuthorizedUser>(new Error()
                {
                    Code = Error.CodeUserExists,
                    Message = LocalizedStrings.UserExists
                });
            }

            lastId += 1;
            var newUser = new AccountProfile()
            {
                Id = lastId,
                Name = username,
                Email = email,
                Balance = 500
            };
            currentUserToken = email + password;
            currentUsername = username;
            users.Add(username, newUser);
            passwords.Add(email, password);

            return new SuccessResult<AuthorizedUser>(new AuthorizedUser()
            {
                Token = currentUserToken
            });
        }
    }
}

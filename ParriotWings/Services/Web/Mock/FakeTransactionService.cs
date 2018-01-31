using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ParriotWings.Entities;
using ParriotWings.Helpers;
using ParriotWings.Services.Web.Abstract;

namespace ParriotWings.Services.Web.Mock
{
    public class FakeTransactionService: ITransactionService
    {
        private readonly IAccountService accountService;
        Dictionary<String, List<Transaction>> transactions = new Dictionary<string, List<Transaction>>();

        int lastTransactionId = 0;

        public FakeTransactionService(IAccountService accountService)
        {
            this.accountService = accountService;
            var fakeAccService = accountService as FakeAccountService;

            foreach (var user in fakeAccService.users)
            {
                transactions.Add(user.Key, new List<Transaction>()); 
            }
        }

        public async Task<Result<TransactionToken>> CreateTransaction(string name, int amount, string accessToken)
        {
            await Task.Delay(1000);
            var fakeAccService = accountService as FakeAccountService;
            if (fakeAccService.currentUser.Balance - amount < 0)
            {
                return new ErrorResult<TransactionToken>(new Error()
                {
                    Code = Error.CodeBalanceExceeded,
                    Message = LocalizedStrings.BalanceExceeded
                });
            }
            fakeAccService.currentUser.Balance -= amount;
            fakeAccService.users[name].Balance += amount;

            lastTransactionId += 1;
            var newTransaction = new Transaction()
            {
                Id = lastTransactionId,
                Date = DateTime.UtcNow.ToString(),
                Name = name,
                Amount = -amount,
                Balance = fakeAccService.currentUser.Balance
            };

            transactions[fakeAccService.currentUser.Name].Add(newTransaction);

            lastTransactionId += 1;
            transactions[fakeAccService.users[name].Name].Add(new Transaction()
            {
                Id = lastTransactionId,
                Date = DateTime.UtcNow.ToString(),
                Name = fakeAccService.currentUser.Name,
                Amount = amount,
                Balance = fakeAccService.users[name].Balance
            });
            return new SuccessResult<TransactionToken>(new TransactionToken()
            {
                transaction = newTransaction
            });
        }

        public async Task<Result<TransactionsList>> GetTransactionsList(string accessToken)
        {
            await Task.Delay(1000);
            var fakeAccService = accountService as FakeAccountService;
            var transList = new TransactionsList()
            {
                tokenList = transactions[fakeAccService.currentUser.Name]
            };
            return new SuccessResult<TransactionsList>(transList);
        }

        public async Task<Result<List<PWUser>>> GetUsersList(string searchString, string accessToken)
        {
            await Task.Delay(1000);
            var fakeAccService = accountService as FakeAccountService;
            if (string.IsNullOrEmpty(searchString))
            {
                return new ErrorResult<List<PWUser>>(new Error()
                {
                    Code = Error.CodeEmptySearchString,
                    Message = LocalizedStrings.EmptySearchString
                });
            }
            var pwUsersResult = new List<PWUser>();
            foreach (var user in fakeAccService.users)
            {
                if (user.Value.Name.StartsWith(searchString)) pwUsersResult.Add(new PWUser()
                {
                    Name = user.Value.Name,
                    Id = user.Value.Id
                });
            }
            return new SuccessResult<List<PWUser>>(pwUsersResult);
        }
    }
}

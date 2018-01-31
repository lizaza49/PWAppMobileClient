using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ParriotWings.Entities;
using ParriotWings.Helpers;
using ParriotWings.Managers.Abstract;
using ParriotWings.Services.Storage;
using ParriotWings.Services.Web.Abstract;

namespace ParriotWings.Managers
{
    public class TransactionManager : ITransactionManager
    {
        private readonly ILocalStorage localStorage;
        private readonly ITransactionService transactionService;

        public string AccessToken => localStorage.GetStringValue("AccessToken");

        public TransactionManager(ILocalStorage localStorage, ITransactionService transactionService)
        {
            this.transactionService = transactionService;
            this.localStorage = localStorage;
        }

        public async Task<Result<TransactionToken>> CreateTransaction(string name, int amount)
        {
            return await transactionService.CreateTransaction(name, amount, AccessToken);
        }

        public async Task<Result<TransactionsList>> GetTransactionsList()
        {
            return await transactionService.GetTransactionsList(AccessToken);
        }

        public async Task<Result<List<PWUser>>> GetUsersList(string searchString)
        {
            return await transactionService.GetUsersList(searchString, AccessToken);

        }
    }
}

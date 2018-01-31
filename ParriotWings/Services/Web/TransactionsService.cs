using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ParriotWings.Entities;
using ParriotWings.Helpers;
using ParriotWings.Services.Web.Abstract;
using ParriotWings.Services.Web.Requests;

namespace ParriotWings.Services.Web
{
    public class TransactionsService : ITransactionService
    {
        private readonly IRequestHelper requestHelper;

        public TransactionsService(IRequestHelper requestHelper)
        {
            this.requestHelper = requestHelper;
        }

        public async Task<Result<TransactionToken>> CreateTransaction(string name, int amount, string accessToken)
        {
            return await requestHelper.SendRequest<TransactionToken>(new CreateTransactionRequest(name, amount, accessToken));
        }

        public async Task<Result<TransactionsList>> GetTransactionsList(string accessToken)
        {
            return await requestHelper.SendRequest<TransactionsList>(new GetTransactionsList(accessToken));
        }

        public async Task<Result<List<PWUser>>> GetUsersList(string searchString, string accessToken)
        {
            return await requestHelper.SendRequest<List<PWUser>>(new GetPWUsersList(searchString, accessToken));
        }
    }
}

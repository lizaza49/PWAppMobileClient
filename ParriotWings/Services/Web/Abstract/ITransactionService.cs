using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ParriotWings.Entities;
using ParriotWings.Helpers;

namespace ParriotWings.Services.Web.Abstract
{
    public interface ITransactionService
    {
        Task<Result<List<PWUser>>> GetUsersList(string searchString, string accessToken);
        Task<Result<TransactionsList>> GetTransactionsList(string accessToken);
        Task<Result<TransactionToken>> CreateTransaction(string name, int amount, string accessToken);

    }
}

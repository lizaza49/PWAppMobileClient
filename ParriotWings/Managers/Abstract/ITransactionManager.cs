using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ParriotWings.Entities;
using ParriotWings.Helpers;

namespace ParriotWings.Managers.Abstract
{
    public interface ITransactionManager
    {
        Task<Result<List<PWUser>>> GetUsersList(string searchString);
        Task<Result<TransactionsList>> GetTransactionsList();
        Task<Result<TransactionToken>> CreateTransaction(string name, int amount);
    }
}

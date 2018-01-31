using System;
using System.Threading.Tasks;
using ParriotWings.Helpers;
using ParriotWings.Services.Web.Base;

namespace ParriotWings.Services.Web.Abstract
{
    public interface IRequestHelper
    {
        Task<Result<TResponce>> SendRequest<TResponce>(Request request) where TResponce : class;
    }
}

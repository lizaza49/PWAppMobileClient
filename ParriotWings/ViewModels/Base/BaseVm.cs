using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using ParriotWings.Helpers;
using ParriotWings.Managers.Abstract;
using ParriotWings.Navigation;
using Plugin.Connectivity;

namespace ParriotWings.ViewModels
{
    public class BaseVm : ViewModelBase
    {
        public BaseVm()
        {
        }

        public bool IsErrorProcessed { get; set; }
        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            protected set
            {
                IsErrorProcessed = value == null;
                errorMessage = value;
                RaisePropertyChanged();
            }
        }

        protected virtual async Task ProcessRequest<T>(Func<Task<Result<T>>> requestFunc, Action<T> successProcessor, Action<Result<T>> failProcessor = null)
            where T : class
        {
            Exception error = null;
            var dialogService = ServiceLocator.Current.GetInstance<IDialogService>();

            try
            {
                var result = await requestFunc.Invoke();
                if (result?.IsSuccessful == true)
                {
                    ErrorMessage = null;
                    successProcessor?.Invoke(result.Instance);
                }
                else
                {
                    ErrorMessage = result.Error.Message;
                    await ErrorProcessor(result.Error);
                    failProcessor?.Invoke(result);
                }
            }
            catch (Exception ex)
            {
                error = ex;
            }

            if (error != null)
            {
#if DEBUG
                ErrorMessage = error.ToString();
                if (!IsErrorProcessed && dialogService != null) await dialogService.ShowError(error, LocalizedStrings.Error, "OK", null);
#else
                ErrorMessage = GlobalStrings.ServerUnavalibleError;
                if(!IsErrorProcessed && dialogService!=null) await dialogService.ShowError(GlobalStrings.ServerUnavalibleError, GlobalStrings.Error, "OK", null);
#endif
            }
        }

        protected virtual async Task ErrorProcessor(Error error)
        {
            string message = ErrorMessage;
            var dialogService = ServiceLocator.Current.GetInstance<IDialogService>();
            if (!IsErrorProcessed) await dialogService?.ShowMessage(message, LocalizedStrings.Error, "OK", null);
            if (error.Code == Error.CodeUnauthorizedError)
            {
                var navigationService = ServiceLocator.Current.GetInstance<IExtendedNavigationService>();
                var accountManager = ServiceLocator.Current.GetInstance<IAccountManager>();
                accountManager?.Logout();
                navigationService?.NavigateTo(Page.SignInPage);
            }

        }
    }
}

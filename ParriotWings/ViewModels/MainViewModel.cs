using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using ParriotWings.Entities;
using ParriotWings.Helpers;
using ParriotWings.Managers.Abstract;
using ParriotWings.Navigation;

namespace ParriotWings.ViewModels
{
    public class MainViewModel : BaseVm
    {
        private readonly IAccountManager accountManager;
        private readonly IExtendedNavigationService navigationService;
        private readonly ILocaleManager localeManager;

        private readonly IDialogService dialogService;

        public ICommand OnLoadCommand { get; private set; }
        public ICommand LogoutCommand { get; private set; }
        public ICommand ShowTransactionsCommand { get; private set; }
        public ICommand NewTransactionCommand { get; private set; }



        public bool IsAuthorized => accountManager.IsAuthorized();
        public string CurrentLocale => localeManager.GetCurrentLocale();

        private string userName;
        public string UserName
        {
            get
            {
                return userName;
            }
            private set
            {
                Set(() => UserName, ref userName, value);
            }
        }

        private string userEmail;
        public string UserEmail
        {
            get
            {
                return userEmail;
            }
            set
            {
                Set(() => UserEmail, ref userEmail, value);
            }
        }

        private string balance;
        public string Balance
        {
            get
            {
                return balance;
            }
            set
            {
                Set(() => Balance, ref balance, value);
            }
        }

        private bool isLoading;
        public bool IsLoading
        {
            get
            {
                return isLoading;
            }
            private set
            {
                Set(() => IsLoading, ref isLoading, value);
            }
        }

        public MainViewModel(IAccountManager accountManager,
                             IExtendedNavigationService navigationService,
                             ILocaleManager localeManager,
                             IDialogService dialogService)
        {
            this.accountManager = accountManager;
            this.navigationService = navigationService;
            this.localeManager = localeManager;
            this.dialogService = dialogService;

            OnLoadCommand = new RelayCommand(OnLoadCommandProcessor);
            LogoutCommand = new RelayCommand(LogoutCommandProcessor);
            ShowTransactionsCommand = new RelayCommand(ShowTransactionsCommandProcessor);
            NewTransactionCommand = new RelayCommand(NewTransactionCommandProcessor);
        }

        private void OnLoadCommandProcessor()
        {
            IsLoading = true;
            InitAsync().ContinueWith((res) =>
            {
                IsLoading = false;
            });
        }

        public async Task InitAsync()
        {
            if (IsAuthorized)
                await LoadAsync();
            else
                ClearUserCreditionals();
        }

        private async Task LoadAsync()
        {
            await ProcessRequest<UserInfoToken>(() => accountManager.GetAccountProfile(),
                                                (result) =>
                                                 {
                                                     UserName = result.UserInfo.Name;
                                                     UserEmail = result.UserInfo.Email;
                                                     Balance = result.UserInfo.Balance.ToString();
                                                 },
                                                 (error) =>
                                                {
                                                    dialogService.ShowError(error.Error.Message, LocalizedStrings.Error, "OK", null);
                                                    ClearUserCreditionals();
                                                }
                                                );
        }

        private void LogoutCommandProcessor()
        {
            accountManager.Logout();
            ClearUserCreditionals();
        }

        private void ShowTransactionsCommandProcessor()
        {
            navigationService.NavigateTo(Page.TransactionsPage);
        }

        private void NewTransactionCommandProcessor()
        {
            navigationService.NavigateTo(Page.NewTransactionPage);
        }

        private void ClearUserCreditionals()
        {
            UserName = string.Empty;
            UserEmail = string.Empty;
            Balance = string.Empty;
            navigationService.NavigateTo(Page.SignInPage);
        }

        public void InitLocale()
        {
            localeManager.InitLocale();
        }

        public void SetLocale(string locale)
        {
            localeManager.SetLocale(locale);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ParriotWings.Entities;
using ParriotWings.Helpers;
using ParriotWings.Managers.Abstract;
using ParriotWings.Navigation;

namespace ParriotWings.ViewModels
{
    public class NewTransactionViewModel : BaseVm
    {
        private readonly IExtendedNavigationService navigationService;
        private readonly ITransactionManager transactionsManager;

        public ICommand SelectUsernameCommand { get; private set; }
        public ICommand SendTransactionCommand { get; private set; }
        public ICommand GetUserListCommand { get; private set; }
        public ICommand SetUsernameCommand { get; private set; }
        public ICommand CleanUserListCommand { get; private set; }


        public ObservableRangeCollection<PWUser> FoundUsers = new ObservableRangeCollection<PWUser>();

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

        private string searchQuiry;
        public string SearchQuiry
        {
            get
            {
                return searchQuiry;
            }
            set
            {
                Set(() => SearchQuiry, ref searchQuiry, value);
            }
        }

        private string amount;
        public string Amount
        {
            get
            {
                return amount;
            }
            private set
            {
                Set(() => Amount, ref amount, value);
            }
        }

        public NewTransactionViewModel(IExtendedNavigationService navigationService,
                                     ITransactionManager transactionsManager)
        {
            this.transactionsManager = transactionsManager;
            this.navigationService = navigationService;

            SendTransactionCommand = new RelayCommand(SendTransactionCommandCommandProcessor);
            SelectUsernameCommand = new RelayCommand(SelectUsernameCommandProcessor);
            GetUserListCommand = new RelayCommand(GetUserListCommandProcessor);
            SetUsernameCommand = new RelayCommand<String>(SetUsernameCommandProcessor);
            CleanUserListCommand = new RelayCommand(CleanCommandProcessor);
        }

        private void SendTransactionCommandCommandProcessor()
        {
            IsLoading = true;
            SendTransactionAsync().ContinueWith((res) =>
            {
                IsLoading = false;
            });
        }

        private async Task SendTransactionAsync()
        {
            if (Int32.TryParse(Amount, out int amount))
            {
                await ProcessRequest<TransactionToken>(() => transactionsManager.CreateTransaction(UserName, amount),
                                                (result) =>
                                                {
                                                    navigationService.GoBack();
                                                    UserName = String.Empty;
                                                });
            };
        }

        private void SelectUsernameCommandProcessor()
        {
            navigationService.NavigateTo(Page.SelectUser);
        }

        private void GetUserListCommandProcessor()
        {
            IsLoading = true;
            GetUsersAsync().ContinueWith((res) =>
            {
                IsLoading = false;
            });
        }

        private async Task GetUsersAsync()
        {
            await ProcessRequest<List<PWUser>>(() => transactionsManager.GetUsersList(SearchQuiry),
                                                (result) =>
                                                {
                                                    FoundUsers.Clear();
                                                    FoundUsers.AddRange(result);
                                                });
        }

        private void SetUsernameCommandProcessor(String username)
        {
            UserName = username;
            navigationService.GoBack();
        }

        protected virtual void CleanCommandProcessor()
        {
            FoundUsers.Clear();
        }
    }
}

using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using ParriotWings.Entities;
using ParriotWings.Helpers;
using ParriotWings.Managers.Abstract;
using ParriotWings.Navigation;

namespace ParriotWings.ViewModels
{
    public class TransactionsViewModel : BaseVm
    {
        public ObservableRangeCollection<Transaction> Transactions = new ObservableRangeCollection<Transaction>();

        private readonly IExtendedNavigationService navigationService;
        private readonly ITransactionManager transactionsManager;

        public ICommand OnLoadCommand { get; private set; }

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

        public TransactionsViewModel(IExtendedNavigationService navigationService,
                                     ITransactionManager transactionsManager)
        {
            this.transactionsManager = transactionsManager;
            this.navigationService = navigationService;

            OnLoadCommand = new RelayCommand(OnLoadCommandProcessor);

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
            await LoadAsync();
        }

        private async Task LoadAsync()
        {
            await ProcessRequest<TransactionsList>(() => transactionsManager.GetTransactionsList(),
                                                (result) =>
                                                {
                                                    Transactions.Clear();
                                                    Transactions.AddRange(result.tokenList);
                                                });
        }
    }
}

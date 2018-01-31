using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using ParriotWings.Entities;
using ParriotWings.Helpers;
using ParriotWings.Managers.Abstract;
using ParriotWings.Navigation;

namespace ParriotWings.ViewModels
{
    public class SignInViewModel : BaseVm
    {
        private readonly IAccountManager accountManager;
        private readonly IExtendedNavigationService navigationService;
        private readonly IDialogService dialogService;

        private string email;
        private string password;
        private RelayCommand signInCommand;
        private RelayCommand signUpCommand;
        private bool isLoading;
        private bool emailValidationError;
        private bool passwordValidationError;


        public SignInViewModel(IAccountManager accountManager,
                               IExtendedNavigationService navigationService,
                               IDialogService dialogService)
        {
            this.accountManager = accountManager;
            this.navigationService = navigationService;
            this.dialogService = dialogService;
        }

        public string Email
        {
            get { return email; }
            set
            {
                Set(() => Email, ref email, value);
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                Set(() => Password, ref password, value);
            }
        }

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

        public bool EmailValidationError
        {
            get
            {
                return emailValidationError;
            }
            private set
            {
                Set(() => EmailValidationError, ref emailValidationError, value);
            }
        }

        public bool PasswordValidationError
        {
            get
            {
                return passwordValidationError;
            }
            private set
            {
                Set(() => PasswordValidationError, ref passwordValidationError, value);
            }
        }

        public RelayCommand SignInCommand => signInCommand ?? (signInCommand = new RelayCommand(SignInCommandProcessor,
                    () => !isLoading));

        private void SignInCommandProcessor()
        {
            IsLoading = true;
            SignInAsync(Email, Password).ContinueWith(res =>
            {
                IsLoading = false;
                if (res.Result)
                {
                    navigationService.NavigateTo(Page.MainPage);
                }
            });
        }

        public RelayCommand SignUpCommand => signUpCommand ?? (signUpCommand = new RelayCommand(SignUpCommandProcessor,
                    () => !isLoading));

        private void SignUpCommandProcessor()
        {
            navigationService.NavigateTo(Page.SignUpPage);
        }

        private async Task<bool> SignInAsync(string email, string password)
        {
            ClearFlags();
            // Client-side validation
            if (!ClientSideValidation())
                return false;

            bool result = false;
            await ProcessRequest<AuthorizedUser>(() => accountManager.SignIn(email, password),
                                                 (res) =>
                                                 {
                                                     result = true;
                                                 });
            return result;
        }

        private bool ClientSideValidation()
        {
            // return true on success

            // Email
            EmailValidationError |= string.IsNullOrEmpty(Email);
            EmailValidationError |= !Email.IsValidEmail();

            // Password
            PasswordValidationError |= string.IsNullOrEmpty(Password);

            return !(EmailValidationError | PasswordValidationError);
        }

        private void ClearFlags()
        {
            EmailValidationError = false;
            PasswordValidationError = false;
        }
    }
}

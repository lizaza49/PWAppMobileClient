using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using ParriotWings.Helpers;
using ParriotWings.Managers.Abstract;
using ParriotWings.Navigation;

namespace ParriotWings.ViewModels
{
    public class SignUpViewModel : BaseVm
    {
        private readonly IAccountManager accountManager;
        private readonly IDialogService dialogService;
        private readonly IExtendedNavigationService navigationService;

        private bool isLoading;
        private string email;
        private string password;
        private string userName;
        private string errorMessage;
        private RelayCommand signUpCommand;
        private RelayCommand signInCommand;
        private bool emailValidationError;
        private bool passwordValidationError;
        private bool userNameValidationError;

        public SignUpViewModel(IAccountManager accountManager,
                               IDialogService dialogService,
                               IExtendedNavigationService navigationService)
        {
            this.accountManager = accountManager;
            this.dialogService = dialogService;
            this.navigationService = navigationService;
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

        public bool UserNameValidationError
        {
            get
            {
                return userNameValidationError;
            }
            private set
            {
                Set(() => UserNameValidationError, ref userNameValidationError, value);
            }
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

        public string UserName
        {
            get { return userName; }
            set
            {
                Set(() => UserName, ref userName, value);
            }
        }

        public RelayCommand SignUpCommand => signUpCommand
        ?? (signUpCommand = new RelayCommand(SignUpCommandProcessor, () => !isLoading));

        private void SignUpCommandProcessor()
        {
            IsLoading = true;
            SignUpAsync(Email, UserName, Password).ContinueWith((res) =>
            {
                IsLoading = false;
                if (res.Result)
                {
                    navigationService.NavigateTo(Page.MainPage);
                }

            });
        }

        public RelayCommand SignInCommand => signInCommand
                    ?? (signInCommand = new RelayCommand(SingInCommandProcessor, () => !isLoading));
        private void SingInCommandProcessor()
        {
            navigationService.NavigateTo(Page.SignInPage);
        }

        private async Task<bool> SignUpAsync(string email, string userName, string password)
        {
            ClearFlags();

            // Client-side validation
            if (!ClientSideValidation())
                return false;
            var result = false;
            await ProcessRequest(() => accountManager.SignUp(email, userName, password), (res) =>
            {
                result = true;
            });
            return result;
        }

        private bool ClientSideValidation()
        {
            // return true on success

            // Email
            EmailValidationError |= string.IsNullOrWhiteSpace(Email);
            EmailValidationError |= !Email.IsValidEmail();

            // Password
            PasswordValidationError |= string.IsNullOrWhiteSpace(Password);

            // FirstName
            UserNameValidationError |= string.IsNullOrWhiteSpace(UserName);

            return !(EmailValidationError | PasswordValidationError |
                     UserNameValidationError);
        }

        private void ClearFlags()
        {
            EmailValidationError = false;
            PasswordValidationError = false;
            UserNameValidationError = false;
        }
    }
}

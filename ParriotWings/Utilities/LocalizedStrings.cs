using System;
using I18NPortable;

namespace ParriotWings.Helpers
{
    public static class LocalizedStrings
    {
        public static string Error => nameof(Error).Translate();
        public static string UserNotFound => nameof(UserNotFound).Translate();
        public static string UserExists => nameof(UserExists).Translate();
        public static string BalanceExceeded => nameof(BalanceExceeded).Translate();
        public static string EmptyUsernameOrPassword => nameof(EmptyUsernameOrPassword).Translate();
        public static string EmptyEmailOrPassword => nameof(EmptyEmailOrPassword).Translate();
        public static string InvalidEmailOrPassword => nameof(InvalidEmailOrPassword).Translate();
        public static string UnauthorizedError => nameof(UnauthorizedError).Translate();
        public static string InvalidUser => nameof(InvalidUser).Translate();
        public static string EmptySearchString => nameof(EmptySearchString).Translate();
        public static string ConnectionError => nameof(ConnectionError).Translate();
        public static string Email => nameof(Email).Translate();
        public static string Password => nameof(Password).Translate();
        public static string SignIn => nameof(SignIn).Translate();
        public static string SignUp => nameof(SignUp).Translate();
        public static string Name => nameof(Name).Translate();
        public static string Exit => nameof(Exit).Translate();
        public static string Balance => nameof(Balance).Translate();
        public static string ShowTransactions => nameof(ShowTransactions).Translate();
        public static string NewTransaction => nameof(NewTransaction).Translate();
        public static string Id => nameof(Id).Translate();
        public static string Date => nameof(Date).Translate();
        public static string Amount => nameof(Amount).Translate();
        public static string Transactions => nameof(Transactions).Translate();
        public static string SelectUser => nameof(SelectUser).Translate();
        public static string SetAmount => nameof(SetAmount).Translate();
        public static string Send => nameof(Send).Translate();


    }
}

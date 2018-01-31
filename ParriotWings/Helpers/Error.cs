using System;
namespace ParriotWings.Helpers
{
    public class Error
    {
        public static string CodeUserExists = "user-exists";
        public static string CodeUserNotFound = "user-not-found";
        public static string CodeBalanceExceeded = "balance-exceeded";
        public static string CodeEmptyUsernameOrPassword = "empty-username-or-password";
        public static string CodeEmptyEmailOrPassword = "empty-email-or-password";
        public static string CodeInvalidEmailOrPassword = "invalid-email-or-password";
        public static string CodeUnauthorizedError = "unauthorized-error";
        public static string CodeInvalidUser = "invalid-user";
        public static string CodeEmptySearchString = "empty-search-string";
        public static string CodeServerUnknown = "server-unknown";

        public string Code { get; set; }

        public string Message { get; set; }
    }
}

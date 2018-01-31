using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;

namespace ParriotWings.iOS.Utilities
{
    public class IOSDialogService : IDialogService
    {
        DialogService dialogService;

        public IOSDialogService()
        {
            dialogService = new DialogService();
        }

        public Task ShowError(Exception error, string title, string buttonText, Action afterHideCallback)
        {
            Task result = null;
            AppDelegate.Instance.InvokeOnMainThread(() =>
            {
                result = dialogService.ShowError(error, title, buttonText, afterHideCallback);
            });
            return result;
        }

        public Task ShowError(string message, string title, string buttonText, Action afterHideCallback)
        {
            Task result = null;
            AppDelegate.Instance.InvokeOnMainThread(() =>
            {
                result = dialogService.ShowError(message, title, buttonText, afterHideCallback);
            });
            return result;
        }

        public Task ShowMessage(string message, string title)
        {
            Task result = null;
            AppDelegate.Instance.InvokeOnMainThread(() =>
            {
                result = dialogService.ShowMessage(message, title);
            });
            return result;
        }

        public Task ShowMessage(string message, string title, string buttonText, Action afterHideCallback)
        {
            Task result = null;
            AppDelegate.Instance.InvokeOnMainThread(() =>
            {
                result = dialogService.ShowMessage(message, title, buttonText, afterHideCallback);
            });
            return result;
        }

        public Task<bool> ShowMessage(string message, string title, string buttonConfirmText, string buttonCancelText, Action<bool> afterHideCallback)
        {
            Task<bool> result = null;
            AppDelegate.Instance.InvokeOnMainThread(() =>
            {
                result = dialogService.ShowMessage(message, title, buttonConfirmText, buttonCancelText, afterHideCallback);
            });
            return result;
        }

        public Task ShowMessageBox(string message, string title)
        {
            Task result = null;
            AppDelegate.Instance.InvokeOnMainThread(() =>
            {
                result = dialogService.ShowMessageBox(message, title);
            });
            return result;
        }
    }
}

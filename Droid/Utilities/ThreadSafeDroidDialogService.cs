using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;
using Plugin.CurrentActivity;

namespace ParriotWings.Droid.Utilities
{
    public class ThreadSafeDroidDialogService : IDialogService
    {
        private IDialogService unsafeService;

        public ThreadSafeDroidDialogService()
        {
            unsafeService = new DroidDialogService();
        }

        public Task ShowError(string message, string title, string buttonText, Action afterHideCallback)
        {
            Task task = null;
            CrossCurrentActivity.Current.Activity.RunOnUiThread(() =>
            {
                task = unsafeService.ShowError(message, title, buttonText, afterHideCallback);
            });
            return task;
        }

        public Task ShowError(Exception error, string title, string buttonText, Action afterHideCallback)
        {
            Task task = null;
            CrossCurrentActivity.Current.Activity.RunOnUiThread(() =>
            {
                task = unsafeService.ShowError(error, title, buttonText, afterHideCallback);
            });
            return task;
        }

        public Task ShowMessage(string message, string title)
        {
            Task task = null;
            CrossCurrentActivity.Current.Activity.RunOnUiThread(() =>
            {
                task = unsafeService.ShowMessage(message, title);
            });
            return task;
        }

        public Task ShowMessage(string message, string title, string buttonText, Action afterHideCallback)
        {
            Task task = null;
            CrossCurrentActivity.Current.Activity.RunOnUiThread(() =>
            {
                task = unsafeService.ShowMessage(message, title, buttonText, afterHideCallback);
            });
            return task;
        }

        public Task<bool> ShowMessage(string message, string title, string buttonConfirmText, string buttonCancelText, Action<bool> afterHideCallback)
        {
            Task<bool> task = null;
            CrossCurrentActivity.Current.Activity.RunOnUiThread(() =>
            {
                task = unsafeService.ShowMessage(message, title, buttonConfirmText, buttonCancelText, afterHideCallback);
            });
            return task;
        }

        public Task ShowMessageBox(string message, string title)
        {
            Task task = null;
            CrossCurrentActivity.Current.Activity.RunOnUiThread(() =>
            {
                task = unsafeService.ShowMessageBox(message, title);
            });
            return task;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading;
using CoreAnimation;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using ParriotWings.Helpers;
using ParriotWings.iOS.ViewControllers;
using ParriotWings.Managers.Abstract;
using ParriotWings.Navigation;
using Plugin.Connectivity;
using UIKit;

namespace ParriotWings.iOS.Utilities
{
    public class IOSNavigationService : IExtendedNavigationService
    {
        private readonly Dictionary<Page, PageConfiguration> pagesByKey = new Dictionary<Page, PageConfiguration>();

        public UINavigationController NavigationController { get; private set; }
        public int BackStackCount => NavigationController.ViewControllers.Length;

        public Page? CurrentPage { get; private set; }

        public void Configure(PageConfiguration pageEntity)
        {
            lock (pagesByKey)
            {
                if (pagesByKey.ContainsKey(pageEntity.Page))
                {
                    pagesByKey[pageEntity.Page] = pageEntity;
                }
                else
                {
                    pagesByKey.Add(pageEntity.Page, pageEntity);
                }
            }
        }

        public void Initialize(UINavigationController navigation)
        {
            this.NavigationController = navigation;

            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                if (args.IsConnected)
                {
                    NavigateTo(Page.MainPage);
                }
            };
        }

        public void GoBack()
        {
            CurrentPage = null; //need to imlement stack for full functionality
            NavigationController.InvokeOnMainThread(() =>
            {
                NavigationController.PopViewController(true);
            });
        }

        public void NavigateTo(Page page)
        {
            CurrentPage = page;
            NavigateTo(page, null);
        }

        public void NavigateTo(Page page, object parameter)
        {
            CurrentPage = page;

            System.Diagnostics.Debug.WriteLine($"Navigate to  {page.ToString()} in thread {Thread.CurrentThread.ManagedThreadId.ToString()}");
            if (Thread.CurrentThread.ManagedThreadId == 1)
            {
                NavigateToUnsafe(page, parameter);
            }
            else
                NavigationController.InvokeOnMainThread(() =>
                {
                    NavigateToUnsafe(page, parameter);
                });
        }

        public void NavigateToUnsafe(Page page, object parameter)
        {
            System.Diagnostics.Debug.WriteLine($"Navigate to  {page.ToString()} in thread {Thread.CurrentThread.ManagedThreadId.ToString()}");

            lock (pagesByKey)
            {
                Type type;
                if (pagesByKey.ContainsKey(page))
                {
                    type = pagesByKey[page].Type;
                }
                else
                {
                    throw new InvalidOperationException($"Unable to navigate: page {page.ToString()} not found");
                }

                if (!CrossConnectivity.Current.IsConnected)
                {
                    var dialogService = ServiceLocator.Current.GetInstance<IDialogService>();
                    dialogService.ShowMessage(LocalizedStrings.ConnectionError, LocalizedStrings.Error);
                    return;
                }

                if (pagesByKey[page].RequireAuth)
                {
                    var accountManager = ServiceLocator.Current.GetInstance<IAccountManager>();
                    if (!accountManager.IsAuthorized())
                    {
                        NavigateTo(Page.SignInPage);
                        return;
                    }
                }

                UIViewController uIViewController;

                uIViewController = CreateController(page, parameter);

                if (pagesByKey[page].IsRoot)
                {
                    UIView snapShot = AppDelegate.Instance.Window.SnapshotView(false);
                    AppDelegate.Instance.Window.RootViewController = new TransparentNavigationController(uIViewController);

                    if (snapShot != null)
                    {
                        uIViewController.View.AddSubview(snapShot);

                        UIView.AnimateNotify(0.3f, () =>
                        {
                            snapShot.Layer.Opacity = 0;
                            snapShot.Layer.Transform = CATransform3D.MakeScale(1.5f, 1.5f, 1.5f);
                        }, (finished) => snapShot.RemoveFromSuperview());
                    }

                }
                else if (NavigationController.TopViewController == null || !NavigationController.Contains(uIViewController))
                {
                    this.NavigationController.PushViewController(uIViewController, true);
                }

            }
        }

        public UIViewController CreateController(Page page, object parameter)
        {
            object[] parameters = parameter != null ? new[] { parameter } : null;
            var controller = Activator.CreateInstance(pagesByKey[page].Type, parameters) as UIViewController;
            return controller;
        }
    }
}

using System;
using System.Collections.Generic;
using Android.Support.V4.App;
using Android.Support.V7.App;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using ParriotWings.Helpers;
using ParriotWings.Managers.Abstract;
using ParriotWings.Navigation;
using Plugin.Connectivity;

namespace ParriotWings.Droid.Utilities
{
    public class DroidNavigationService: IExtendedNavigationService
    {
        private readonly Dictionary<Page, PageConfiguration> pagesByKey = new Dictionary<Page, PageConfiguration>();
        private Stack<Page> pageStack = new Stack<Page>();

        private AppCompatActivity mainActivity;
        private int container;
        private FragmentManager fragmentManager;

        public void Init(AppCompatActivity activity, int container)
        {
            mainActivity = activity;
            this.container = container;
            fragmentManager = activity.SupportFragmentManager;
            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                if (args.IsConnected)
                {
                    NavigateTo(Page.MainPage);
                }
            };
        }

        public int BackStackCount => pageStack.Count;

        public Page? CurrentPage
        {
            get
            {
                if (pageStack.Count == 0) return null;
                return pageStack.Peek();
            }
        }

        public void Configure(PageConfiguration config)
        {
            lock (pagesByKey)
            {
                if (pagesByKey.ContainsKey(config.Page))
                {
                    pagesByKey[config.Page] = config;
                }
                else
                {
                    pagesByKey.Add(config.Page, config);
                }
            }
        }

        public void GoBack()
        {
            pageStack.Pop();
            mainActivity.RunOnUiThread(() =>
            {
                try
                {
                    fragmentManager.PopBackStack();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"failed to backstack {ex.Message}");
                }
            });
        }

        public void NavigateTo(Page page)
        {
            NavigateTo(page, null);
        }

        public void NavigateTo(Page page, object parameter)
        {
            mainActivity.RunOnUiThread(() =>
            {
                if (page == CurrentPage && parameter == null) return;

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

                lock (pagesByKey)
                {
                    if (!pagesByKey.ContainsKey(page))
                        throw new ArgumentException($"No such page: {page.ToString()}. Did you forget to call NavigationService.Configure?");

                    var fragment = CreateFragment(page, parameter);

                    var transaction = fragmentManager
                        .BeginTransaction()
                        .SetCustomAnimations(Resource.Animation.anim_slide_in_right, Resource.Animation.anim_slide_out_right)
                        .Replace(container, fragment, page.ToString());

                    if (!pagesByKey[page].IsRoot)
                    {
                        transaction.AddToBackStack(page.ToString());
                    }
                    else if (pageStack.Count > 0)
                    {
                        pageStack.Clear();
                        fragmentManager.PopBackStackImmediate(null, FragmentManager.PopBackStackInclusive);
                    }

                    transaction.CommitAllowingStateLoss();
                    pageStack.Push(page);
                }

            });
        }

        private Fragment CreateFragment(Page page, object parameter)
        {
            object[] parameters = parameter != null ? new[] { parameter } : null;
            var fragment = Activator.CreateInstance(pagesByKey[page].Type, parameters) as Fragment;
            return fragment;
        }
    }
}

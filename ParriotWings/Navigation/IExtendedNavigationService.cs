using System;
namespace ParriotWings.Navigation
{
    public interface IExtendedNavigationService
    {
        void NavigateTo(Page page, object parameter);
        void NavigateTo(Page page);
        void GoBack();
        int BackStackCount { get; }
        Page? CurrentPage { get; }

        void Configure(PageConfiguration pageEntity);
    }
}

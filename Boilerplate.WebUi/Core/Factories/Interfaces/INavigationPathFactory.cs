using Boilerplate.WebUi.ViewModels.Components;

namespace Boilerplate.WebUi.Core.Factories.Interfaces
{
    public interface INavigationPathFactory
    {
        Task<NavigationPathViewModel> PrepareNavigationPathViewModel();
    }
}
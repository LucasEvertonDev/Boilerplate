using Boilerplate.WebUi.ViewModels.Components;

namespace Boilerplate.WebUi.Core.Factories.Interfaces
{
    public interface ISaveButtonsModelFactory
    {
        Task<SaveButtonsViewModel> PrepareSaveButtonsViewModel();
    }
}
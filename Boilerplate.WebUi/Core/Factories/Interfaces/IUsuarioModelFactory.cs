using Boilerplate.WebUi.ViewModels.Account;

namespace Boilerplate.WebUi.Core.Factories.Interfaces
{
    public interface IUsuarioModelFactory
    {
        Task<EditProfileViewModel> PrepareEditProfileModel(int userId);
        Task<RegisterViewModel> PrepareRegisterViewModel();
    }
}

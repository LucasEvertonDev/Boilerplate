using Boilerplate.WebUi.ViewModels.Base;

namespace Boilerplate.WebUi.ViewModels.Components
{
    public class LayoutNavBarViewModel : BaseViewModel
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool Enabled { get; set; }
    }
}

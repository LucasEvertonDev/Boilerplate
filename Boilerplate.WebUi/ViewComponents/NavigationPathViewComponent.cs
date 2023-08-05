using Boilerplate.WebUi.Core.Factories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.WebUi.ViewComponents
{
    [ViewComponent(Name = "NavigationPathViewComponent")]
    public class NavigationPathViewComponent : ViewComponent
    {
        private readonly INavigationPathFactory _navigationPathFactory;

        public NavigationPathViewComponent(INavigationPathFactory navigationPathFactory)
        {
            _navigationPathFactory = navigationPathFactory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("../Shared/_NavigationPath.cshtml", await _navigationPathFactory.PrepareNavigationPathViewModel());
        }
    }
}

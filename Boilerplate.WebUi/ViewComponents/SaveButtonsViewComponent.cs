using Boilerplate.WebUi.Core.Factories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.WebUi.ViewComponents
{
    [ViewComponent(Name = "SaveButtonsViewComponent")]
    public class SaveButtonsViewComponent : ViewComponent
    {
        private readonly ISaveButtonsModelFactory _SaveButtonsModelFactory;

        public SaveButtonsViewComponent(ISaveButtonsModelFactory SaveButtonsModelFactory)
        {
            _SaveButtonsModelFactory = SaveButtonsModelFactory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("../Shared/_SaveButtons.cshtml", await _SaveButtonsModelFactory.PrepareSaveButtonsViewModel());
        }
    }
}

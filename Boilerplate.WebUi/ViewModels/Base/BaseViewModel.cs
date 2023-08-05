namespace Boilerplate.WebUi.ViewModels.Base
{
    public class BaseViewModel
    {
        public int? Id { get; set; }

        public BaseViewModel()
        {
            Controller = string.Empty;
            Action = string.Empty;
        }

        public BaseViewModel(string controllerName, string actionName)
        {
            Controller = controllerName;
            Action = actionName;
        }

        /// <summary>
        /// Controller associado ao view model.
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        /// Action associada ao view model.
        /// </summary>
        public string Action { get; set; }

        // Indica a página a ser exibida
        /// </summary>
        public int? Page { get; set; }
    }
}

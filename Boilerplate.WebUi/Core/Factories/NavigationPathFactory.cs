using Boilerplate.WebUi.Core.Factories.Interfaces;
using Boilerplate.WebUi.ViewModels.Components;

namespace Boilerplate.WebUi.Core.Factories
{
    public class NavigationPathFactory : INavigationPathFactory
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NavigationPathFactory(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<NavigationPathViewModel> PrepareNavigationPathViewModel()
        {
            string controller = _httpContextAccessor.HttpContext.GetRouteValue("controller").ToString();
            string action = _httpContextAccessor.HttpContext.GetRouteValue("action").ToString();

            return Task.FromResult(new NavigationPathViewModel
            {
                CurrentController = controller.ToLower(),
                ApelidoRotaAtual = GetApelidoByAcao(action),
                ApelidoRotaAnterior = GetApelidoByController(controller),
                AcaoAtual = action,
                AcaoAnterior = "index"
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetApelidoByController(string controller)
        {
            /// TODO
            if ("clients".Equals(controller.ToLower()))
            {
                return "Clientes";
            }
            return controller; // O nome do controller já está ok
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="acao"></param>
        /// <returns></returns>
        private string GetApelidoByAcao(string action)
        {
            if ("create".Equals(action.ToLower()))
            {
                return $"Cadastro";
            }
            if ("index".Equals(action.ToLower()))
            {
                return $"Consulta";
            }
            if ("edit".Equals(action.ToLower()))
            {
                return $"Edição";
            }
            return action;
        }
    }
}

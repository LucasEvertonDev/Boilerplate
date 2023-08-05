using Boilerplate.Core.Models.Constants;
using Boilerplate.WebUi.Infra.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Boilerplate.WebUi.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        [HttpGet, SessionExpire, Authorize(Roles = Roles.Admin)]
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { });
            }
            return View();
        }
    }
}

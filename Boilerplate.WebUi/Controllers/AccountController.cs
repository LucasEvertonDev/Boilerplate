using Boilerplate.Core.IContracts.Services.User;
using Boilerplate.Core.Models.Models.User;
using Boilerplate.Infra.Plugins.Identity;
using Boilerplate.WebUi.Infra.Extensions;
using Boilerplate.WebUi.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.WebUi.Controllers;

public class AccountController : BaseController
{
    private readonly ILoginService _loginService;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(ILoginService loginService,
        SignInManager<ApplicationUser> signInManager)
    {
        this._loginService = loginService;
        this._signInManager = signInManager;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet, AllowAnonymous]
    public IActionResult Login(string returnUrl)
    {
        var remember = GetCookie("RememberMe");
        var loginViewModel = new LoginViewModel()
        {
            RememberMe = "True".Equals(remember),
            ReturnUrl = returnUrl
        };

        return View(loginViewModel);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="loginViewModel"></param>
    /// <returns></returns>
    [HttpPost, AllowAnonymous]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var user = await _loginService.ExecuteAsync(new LoginModel
                { 
                    Login = loginViewModel.Username,
                    Password = loginViewModel.Password
                });

                if (user != null && !string.IsNullOrEmpty(user.Id))
                {
                    var result = await _signInManager.PasswordSignInAsync(
                       loginViewModel.Username,
                       loginViewModel.Password,
                       loginViewModel.RememberMe,
                       lockoutOnFailure: false);

                    HttpContext.Session.Set("UserId", user.Id);
                    UpdateCookie("RememberMe", loginViewModel.RememberMe.ToString());

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            TratarException(ex);
        }
        loginViewModel.RememberMe = false;
        return View(loginViewModel);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "Account");
    }
}

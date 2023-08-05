using Boilerplate.Infra.Utils.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Boilerplate.WebUi.Controllers
{
    public class BaseController : Controller
    {
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireTime"></param>
        public void AddCookie(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();
            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddDays(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddDays(7);

            Response.Cookies.Append(key, value, option);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireTime"></param>
        public void UpdateCookie(string key, string value, int? expireTime = null)
        {
            var cookie = GetCookie(key);
            if (!string.IsNullOrEmpty(cookie))
            {
                RemoveCookie(key);
            }
            AddCookie(key, value, expireTime);
        }

        /// <summary>  
        /// Delete the key  
        /// </summary>  
        /// <param name="key">Key</param>  
        public void RemoveCookie(string key)
        {
            Response.Cookies.Delete(key);
        }

        /// <summary>  
        /// Get the cookie  
        /// </summary>  
        /// <param name="key">Key </param>  
        /// <returns>string value</returns>  
        public string GetCookie(string key)
        {
            return Request.Cookies[key];
        }

        /// <summary>
        /// 
        /// </summary>
        public void TratarException(Exception ex)
        {
            if (ex.GetType() == typeof(BusinessException))
            {
                AddWarning(ex.Message);
            }
            else
            {
                AddError(JsonConvert.SerializeObject(ex));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddError(string error)
        {
            TempData["success"] = null;
            TempData["warning"] = null;
            TempData["error"] = error;
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddSuccess(string sucess)
        {
            TempData["success"] = sucess;
            TempData["warning"] = null;
            TempData["error"] = null;
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddWarning(string warning)
        {
            TempData["success"] = null;
            TempData["warning"] = warning;
            TempData["error"] = null;
        }
    }
}


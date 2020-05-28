using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web;
using System.Web.Security;
/*********************************
 * 类名：UserLoginManager
 * 功能描述：提供用户身份验证业务逻辑
 * ******************************/
namespace HotelManager.BLL
{
    public  class UserLoginManager:Page
    {
        /// <summary>
        /// 添加用户身份到Cookie中，并加密
        /// </summary>
        /// <param name="username"></param>
        public  void AuthenticationUsers(string username)
        {
            FormsAuthenticationTicket tichet = new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddHours(24), true, "");
            string hashTicket = FormsAuthentication.Encrypt(tichet);
            HttpCookie userCookie = new HttpCookie(FormsAuthentication.FormsCookieName);
            userCookie.Value  = hashTicket;
            userCookie.Expires = tichet.Expiration;
            userCookie.Domain = FormsAuthentication.CookieDomain;
            HttpContext.Current.Response.Cookies.Add(userCookie);
        }
    }
}

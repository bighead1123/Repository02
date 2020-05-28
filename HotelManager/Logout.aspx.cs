using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
/*********************************
 * 类名：Logout
 * 功能描述：提供身份注销页面
 * ******************************/
public partial class Logout : System.Web.UI.Page
{
    #region "Event Handlers"
    /// <summary>
    /// 执行页面加载事件
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //根据配置文件中设置的Cookie名称,实例化Cookie对象
            HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if(cookie!=null)
            {
                //调用系统提供注销方法
                FormsAuthentication.SignOut();
            }
            //清除Cookies
            Request.Cookies.Clear();
            HttpContext.Current.Response.Cookies[FormsAuthentication.FormsCookieName].Value = null;
            HttpContext.Current.Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddYears(-100);
            HttpContext.Current.Session.Abandon();

        }
    }
    #endregion
}

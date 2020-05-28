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
using HotelManager.BLL;
using HotelManager.Models;
/*********************************
 * 类名：Login
 * 功能描述：提供系统登录页面
 * ******************************/
public partial class Login : System.Web.UI.Page
{
    #region Private Members
    //实例化身份验证对象
    UserLoginManager userLigon = new UserLoginManager();
    //定义重定向路径,并保存视图状态
    private string ReturnUrl
    {
        get { return Convert.ToString(ViewState["returnUrl"]); }
        set { ViewState["returnUrl"] = value; }
    }
    #endregion

    #region Event Handlers
    //在页面加载时,获取重定向路径
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReturnUrl = Request.QueryString["ReturnUrl"];
        }
    }
    /// <summary>
    /// 执行登录事件
    /// </summary>
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //根据用户名得到用户密码
        string validatePwd = UserManager.GetUserPasswordByUserName(this.txtPassword.Text.Trim());
        //加密密码
        string inputPwd = CryptogramManager.EncryptPassword(this.txtPassword.Text.Trim());
        //通过对比密码,验证登录信息是否正确
        if (inputPwd.Trim() == validatePwd.Trim())
        {
            //保存用户身份
            userLigon.AuthenticationUsers(this.txtUserName.Text.Trim());
            if (!string.IsNullOrEmpty(ReturnUrl))
                Response.Redirect(ReturnUrl);
            else
                Response.Redirect("Default.aspx");
        }
        else
            this.lblResult.Text = "您输入的用户名或密码不正确！";
    }
    #endregion
}

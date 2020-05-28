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
 * 类名：ViewRoomType
 * 功能描述：提供客房类型信息预览页面
 * ******************************/
public partial class ViewRoomType : System.Web.UI.Page
{
    #region "Event Handlers"
    /// <summary>
    /// 在页面加载时,绑定类型信息
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRoomType();
        }
    }
    /// <summary>
    /// 执行GridView数据行绑定事件
    /// </summary>
    protected void gvRoomType_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //设置行颜色   
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#ff9900'");
            //添加自定义属性，当鼠标移走时还原该行的背景色   
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
            //添加删除确认
            ImageButton imgbtn = (ImageButton)e.Row.FindControl("imgbtnDelete");
            imgbtn.Attributes.Add("onclick", "return confirm('您确认要删除吗?');");
        }
    }
    /// <summary>
    /// 执行GridView数据行按钮事件
    /// </summary>
    protected void gvRoomType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //获取按钮命令名称
        string cmd = e.CommandName;
        int typeId = Convert.ToInt32(e.CommandArgument);//获取命令参数
        if (cmd == "De")
        {
            //根据类型ID删除类型信息
            RoomTypeManager.DeleteRoomTypeByTypeId(typeId);
        }
        else if (cmd == "Ed")
        {
            //转向类型信息编辑页 
            Page.Server.Transfer("EditRoomType.aspx?typeId=" + Convert.ToString(typeId));
        }
        BindRoomType();
    }
    /// <summary>
    /// 执行分页事件
    /// </summary>
    protected void gvRoomType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRoomType.PageIndex = e.NewPageIndex;
        BindRoomType();
    }
    #endregion

    #region "Public Methods"
    /// <summary>
    /// 绑定客房类型信息
    /// </summary>
    public void BindRoomType()
    {
        this.gvRoomType.DataSource = RoomTypeManager.GetAllRoomTypes();
        this.gvRoomType.DataBind();
    }
    #endregion
}

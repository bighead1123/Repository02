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
 * 类名：ViewRoom
 * 功能描述：提供客房信息预览页面
 * ******************************/
public partial class ViewRoom : System.Web.UI.Page
{
    #region "Event Handlers"
    /// <summary>
    /// 在页面加载时,绑定客房信息
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRoom();
        }
    }
    /// <summary>
    /// 执行GridView数据行绑定事件
    /// </summary>
    protected void gvRoom_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void gvRoom_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //获取命令名称
        string cmd = e.CommandName;
        int roomId = Convert.ToInt32(e.CommandArgument);//获取命令参数
        if (cmd == "De")
        {
            //根据客房ID删除客房信息
            RoomManager.DeleteRoomByRoomId(roomId);
        }
        else if (cmd == "Ed")
        {
            //跳转到客房信息编辑页
            Page.Server.Transfer("EditRoom.aspx?roomid=" +roomId.ToString());
        }
        BindRoom();
    }
    /// <summary>
    /// 执行分页事件
    /// </summary>
    protected void gvRoom_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRoom.PageIndex = e.NewPageIndex;
        BindRoom();
    }
    #endregion

    #region "Public Methods"
    /// <summary>
    /// 绑定客房信息
    /// </summary>
    protected void BindRoom()
    {
        this.gvRoom.DataSource = RoomManager.GetAllRooms();
        this.gvRoom.DataBind();

    }
    /// <summary>
    /// 绑定客房状态
    /// </summary>
    /// <param name="state">状态</param>
    /// <returns></returns>
    public string GetRoomState(string state)
    {
        string ViewState = string.Empty;
        if (state == "housing")
            ViewState = "入住";
        else if (state == "modify")
            ViewState = "维修";
        else if (state == "arrive")
            ViewState = "将到";
        else if (state == "leave")
            ViewState = "将离";
        else if (state == "empty")
            ViewState = "空闲";
        else
            ViewState = "自用";
        return ViewState;
    }
    /// <summary>
    /// 根据类型ID得到类型名称
    /// </summary>
    public string GetRoomType(string typeID)
    {
        return RoomTypeManager.GetTypeNameByTypeID(Convert.ToInt32(typeID));
    }
    /// <summary>
    /// 确保客房描述信息最大长度不能超过20个字符
    /// </summary>
    public string SubStringDescription(string description)
    {
        if (description.Length > 20)
            description = description.Substring(0, 20)+"............";
        return description;
    }
    #endregion
}

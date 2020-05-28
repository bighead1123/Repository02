using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HotelManager.Models;
using HotelManager.BLL;
/*********************************
 * 类名：_Default
 * 功能描述：提供系统默认页面
 * ******************************/
public partial class _Default : System.Web.UI.Page
{
    #region "Event Handler"
    /// <summary>
    /// 在页面载入时,首先判断用户是否通过身份验证;
    /// 如果用户通过身份绑定房间状态,客房类型信息;
    /// 如果没有通过身份验证转向登录页
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty(User.Identity.Name))
                Response.Redirect("Login.aspx");
            else
            {
                BindRoomState();
                BindRoomType();
            }
        }
    }
    /// <summary>
    /// 将选中的房间状态回绑到房间状态编辑区
    /// </summary>
    protected void dlRoomState_SelectedIndexChanged(object sender, DataListCommandEventArgs e)
    {
        int n = e.Item.ItemIndex;
        dlRoomState.Items[n].BackColor = System.Drawing.Color.Red;
        int key =Convert.ToInt32( this.dlRoomState.DataKeys[n]);
        Session["key"] = key;
        Room room = new Room();
        room = RoomManager.GetRoomByRoomId(key);
        if (room.State == "housing")
            this.rblRoomState.SelectedValue = "housing";
        else if (room.State == "modify")
            this.rblRoomState.SelectedValue = "modify";
        else if (room.State == "arrive")
            this.rblRoomState.SelectedValue = "arrive";
        else if (room.State == "leave")
            this.rblRoomState.SelectedValue = "leave";
        else if (room.State == "empty")
            this.rblRoomState.SelectedValue = "empty";
        else
            this.rblRoomState.SelectedValue = "helpOneself";

    }
    /// <summary>
    /// 修改房间状态
    /// </summary>
    protected void btnModifyRoomState_Click(object sender, EventArgs e)
    {
        string state = string.Empty;
        state = this.rblRoomState.SelectedValue;
        RoomManager.ModifyRoomState(Convert.ToInt32(Session["key"]),state);
        //回绑房间状态
        BindRoomState();
    }
    /// <summary>
    /// 在选择客房类型时,根据客房类型检索该类型对应的房间,并展示该房间的状态
    /// </summary>
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        int typeid = Convert.ToInt32(this.ddlType.SelectedValue);
        if (typeid == -1)
            typeid = 0;
        this.dlRoomState.DataSource = RoomManager.GetAllRoomsByTypeId(typeid);
        this.dlRoomState.DataBind();
    }
    #endregion

    #region  "Public Methods"
    /// <summary>
    /// 根据房间状态得到状态对应的表示图
    /// </summary>
    /// <param name="state">状态</param>
    /// <returns></returns>
    public string GetRoomStateImageUrlByState(string state)
    {
        string imageUrl = string.Empty;
        if (state == "housing")
            imageUrl = "images/RoomState/housing.jpg";
        else if (state == "modify")
            imageUrl = "images/RoomState/modify.jpg";
        else if (state == "arrive")
            imageUrl = "images/RoomState/arrive.jpg";
        else if (state == "leave")
            imageUrl = "images/RoomState/leave.jpg";
        else if (state == "empty")
            imageUrl = "images/RoomState/empty.jpg";
        else
            imageUrl = "images/RoomState/helpOneself.jpg";
        return imageUrl;
    }
    /// <summary>
    /// 绑定房间状态
    /// </summary>
    public void BindRoomState()
    {
        this.dlRoomState.DataSource = RoomManager.GetAllRoomsByTypeId(0);
        this.dlRoomState.DataBind();
    }
    /// <summary>
    /// 绑定客房类型
    /// </summary>
    public void BindRoomType()
    {    
        ddlType.DataSource = RoomTypeManager.GetAllRoomTypes();
        ddlType.DataTextField = "TypeName";
        ddlType.DataValueField = "TypeId";
        ddlType.DataBind();
        ListItem item = new ListItem();
        item.Text = "--选择--";
        item.Value = "-1";
        ddlType.Items.Insert(0,item);
    }
    #endregion
}
   

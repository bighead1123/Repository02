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
 * 类名：EditRoom
 * 功能描述：提供客房信息编辑页面
 * ******************************/
public partial class EditRoom : System.Web.UI.Page
{
    #region "Private Members"
    //定义客房ID,并保存试图状态
    private int RoomID
    {
        get { return (int)ViewState["RoomID"]; }
        set { ViewState["RoomID"] = value; } 
    }
    //实例化客房实体对象
    Room room = new Room();
    #endregion 

    #region "Event Handlers"
    /// <summary>
    /// 在页面加载时,绑定客房类型信息,同时获取客房ID并绑定客房信息
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRoomType();
            if (!string.IsNullOrEmpty(Request.QueryString["roomId"].ToString()))
            {
                RoomID = Convert.ToInt32(Request.QueryString["roomId"]);
                BindRoom();
            }     
        }
    }
    /// <summary>
    /// 提交客房信息
    /// </summary>
    protected void tbnSave_Click(object sender, EventArgs e)
    {
        room.RoomId = RoomID;
        room.Number = this.lblRoomNO.Text.Trim();
        room.TypeID =Convert.ToInt32(this.ddlRoomType.SelectedValue);
        room.State = this.ddlRoomState.SelectedValue;
        room.BedNumber = Convert.ToInt32(this.txtBedNumber.Text.Trim());
        room.GuestNumber = Convert.ToInt32(this.txtGuestNumber.Text.Trim());
        room.Description = this.txtDescription.Text.Trim();
        //修改客房信息
        RoomManager.ModifyRoom(room);
        //转向客房信息预览页
        Page.Server.Transfer("ViewRoom.aspx",true);
    }
    #endregion 

    #region "Public Methods"
    /// <summary>
    /// 绑定客房类型信息
    /// </summary>
    public void BindRoomType()
    {
        this.ddlRoomType.DataSource = RoomTypeManager.GetAllRoomTypes();
        this.ddlRoomType.DataTextField = "TypeName";
        this.ddlRoomType.DataValueField = "TypeID";
        this.DataBind();
    }
    /// <summary>
    /// 绑定客房信息
    /// </summary>
    private void BindRoom()
    {
       room =RoomManager.GetRoomByRoomId(RoomID);
       this.lblRoomNO.Text = room.Number;
       this.ddlRoomType.SelectedValue = room.TypeID.ToString();
       this.ddlRoomState.SelectedValue = room.State;
       this.txtBedNumber.Text = room.BedNumber.ToString();
       this.txtGuestNumber.Text = room.GuestNumber.ToString();
       this.txtDescription.Text = room.Description;
    }
    #endregion
}

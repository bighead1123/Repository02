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
using HotelManager.Models;
using HotelManager.BLL;
/*********************************
 * 类名：AddRoom
 * 功能描述：提供新增客房信息页面
 * ******************************/
public partial class AddRoom : System.Web.UI.Page
{
    #region "Private Members"
    //实例化客房实体对象
    Room room = new Room();
    #endregion

    #region "Event Handlers"
    /// <summary>
    /// 在页面加载时绑定客房类型
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRoomType();
        }
    }
    /// <summary>
    /// 提交客房信息
    /// </summary>
    protected void tbnSave_Click(object sender, EventArgs e)
    {
        //根据房间号得到客房ID
        int roomId = RoomManager.GetRoomIdByRoomNo(this.txtRoomNO.Text.Trim());
        if(roomId>0)
            this.lblResult.Text="此房间已存在！";
        else
        {
            room.Number = this.txtRoomNO.Text.Trim();
            room.TypeID =Convert.ToInt32( this.ddlRoomType.SelectedValue);
            room.State = this.ddlRoomState.SelectedValue;
            room.BedNumber = Convert.ToInt32(this.txtBedNumber.Text.Trim());
            room.GuestNumber = Convert.ToInt32(this.txtGuestNumber.Text.Trim());
            room.Description = this.txtDescription.Text.Trim();
            roomId = RoomManager.AddRoom(room);
            if (roomId > 0)
                Page.Server.Transfer("ViewRoom.aspx");
            else
                this.lblResult.Text = "房间创建失败！";
        }

    }
    #endregion

    #region "Public Methodes"
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
    #endregion
}

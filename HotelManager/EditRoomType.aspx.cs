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
 * 类名：EditRoomType
 * 功能描述：提供客房类型信息编辑页面
 * ******************************/
public partial class EditRoomType : System.Web.UI.Page
{
    #region "Private Members"
    //定义类型ID,并保存视图状态
    private int TypeID
    {
        get { return (int)ViewState["TypeID"]; }
        set { ViewState["TypeID"] = value; }
    }
    //实例化类型实体对象
    RoomType roomType = new RoomType();
    #endregion

    #region "Event Handlers"
    /// <summary>
    /// 页面加载时,获取从信息预览页传来的类型ID,并绑定类型信息.
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["typeId"].ToString()))
            {
                TypeID = Convert.ToInt32(Request.QueryString["typeId"]);
                BindRoomType();
            }
        }
    }
    /// <summary>
    /// 提交类型信息
    /// </summary>
    protected void tbnSave_Click(object sender, EventArgs e)
    {
        roomType.TypeId = TypeID;
        roomType.TypeName = this.lblTypeName.Text.Trim();
        roomType.TypePrice = Convert.ToDecimal(this.txtTypePrice.Text.Trim());
        roomType.IsAddBed = this.rdolstIsAddBed.SelectedValue;
        if (roomType.IsAddBed.Trim() == "否")
            roomType.AddBedPrice = 0;
        else
            roomType.AddBedPrice = Convert.ToDecimal(this.txtAddBedPrice.Text.Trim());   
        roomType.Remark = this.txtRemark.Text.Trim();
        //修改类型信息
        RoomTypeManager.ModifyRoomType(roomType);
        //转向类型信息预览页
        Page.Server.Transfer("ViewRoomType.aspx");
    }
    #endregion 

    #region "Public Methods"
    /// <summary>
    /// 绑定类型信息
    /// </summary>
    public void BindRoomType()
    {
        roomType =RoomTypeManager.GetRoomTypeByTypeID(TypeID);
        this.lblTypeName.Text = roomType.TypeName;
        this.txtTypePrice.Text = Convert.ToString(roomType.TypePrice);
        this.txtAddBedPrice.Text = Convert.ToString(roomType.AddBedPrice);
        this.rdolstIsAddBed.SelectedValue = roomType.IsAddBed.Trim();
        this.txtRemark.Text = roomType.Remark;
    }
    #endregion
}

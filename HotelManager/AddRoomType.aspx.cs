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
 * 类名：AddRoomType
 * 功能描述：提供新增客房类型信息页面
 * ******************************/
public partial class AddRoomType : System.Web.UI.Page
{
    #region "Private Members"
    //实例化客房类型实体对象
    RoomType roomType = new RoomType();
    #endregion

    #region "Event Handlers"
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 提交客房类型信息
    /// </summary>
    protected void tbnSave_Click(object sender, EventArgs e)
    {
        //根据类型名称得到类型ID
        int typeId = RoomTypeManager.GetTypeIdTypeName(this.txtTypeName.Text.Trim());
        if (typeId > 0)
            this.lblResult.Text = "此客房类型已存在！";
        else
        {
            roomType.TypeName = this.txtTypeName.Text.Trim();
            roomType.TypePrice = Convert.ToDecimal(this.txtTypePrice.Text.Trim());
            roomType.IsAddBed = this.rdolstIsAddBed.SelectedValue;
            if (roomType.IsAddBed.Trim() == "否")
                roomType.AddBedPrice = 0;
            else
                roomType.AddBedPrice = Convert.ToDecimal(this.txtAddBedPrice.Text.Trim());
            roomType.Remark = this.txtRemark.Text.Trim();
            typeId = RoomTypeManager.AddRoomType(roomType);
            if (typeId > 0)
                Page.Server.Transfer("ViewRoomType.aspx");
            else
                this.lblResult.Text = "客房类型创建失败！";
            
        }
    }
    #endregion
}

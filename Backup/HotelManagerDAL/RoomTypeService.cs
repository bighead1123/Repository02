using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using HotelManager.Models;
/*********************************
 * 类名：RoomTypeService
 * 功能描述：提供客房类型信息数据访问
 * ******************************/
namespace HotelManager.DAL
{
   public static class RoomTypeService
   {
       #region Private Members
       static string sql = string.Empty;
       #endregion

       #region "Public Methods"
       /// <summary>
       /// 得到客房类型信息集合
       /// </summary>
       /// <returns></returns>
       public static IList<RoomType> GetAllRoomTypes()
       {
           IList<RoomType> roomTypes = new List<RoomType>();
           sql = "select * from RoomType";
           using (SqlDataReader dataReader = DBHelper.GetReader(sql))
           {
               while (dataReader.Read())
               {
                   RoomType roomType = new RoomType();
                   roomType.TypeId = Convert.ToInt32(dataReader["TypeId"]);
                   roomType.TypeName = Convert.ToString(dataReader["TypeName"]);
                   roomType.TypePrice = Convert.ToDecimal(dataReader["TypePrice"]);
                   roomType.AddBedPrice = Convert.ToDecimal(dataReader["AddBedPrice"]);
                   roomType.Remark = Convert.ToString(dataReader["Remark"]);
                   roomType.IsAddBed = Convert.ToString(dataReader["IsAddBed"]);
                   roomTypes.Add(roomType);
               }
           }
           return roomTypes;
       }
       /// <summary>
       /// 根据类型ID得到类型名称
       /// </summary>
       /// <param name="typeID">类型ID</param>
       /// <returns></returns>
       public static string GetTypeNameByTypeID(int typeID)
       {
           string typeName = string.Empty;
           sql = "select TypeName from RoomType where TypeID ="+"'"+typeID+"'";
           using (SqlDataReader dataReader = DBHelper.GetReader(sql))
           {
               if (dataReader.Read())
               {
                   typeName = Convert.ToString(dataReader["TypeName"]);
               }
           }
           return typeName;
       }
       /// <summary>
       /// 根据类型ID得到类型实体对象
       /// </summary>
       /// <param name="typeId">类型ID</param>
       /// <returns></returns>
       public static RoomType GetRoomTypeByTypeID(int typeId)
       {                  
           RoomType roomType = new RoomType();
           sql = "select * from RoomType where TypeID =" + "'" + typeId + "'";
           using (SqlDataReader dataReader = DBHelper.GetReader(sql))
           {
               if (dataReader.Read())
               {
                   roomType.TypeName = Convert.ToString(dataReader["TypeName"]);
                   roomType.TypePrice = Convert.ToDecimal(dataReader["TypePrice"]);
                   roomType.AddBedPrice = Convert.ToDecimal(dataReader["AddBedPrice"]);
                   roomType.Remark = Convert.ToString(dataReader["Remark"]);
                   roomType.IsAddBed = Convert.ToString(dataReader["IsAddBed"]);
               }
           }
           return roomType;
       }
       /// <summary>
       /// 修改客房类型信息
       /// </summary>
       /// <param name="roomType">类型实体对象</param>
       public static void ModifyRoomType(RoomType roomType)
       {
           StringBuilder updateString = new StringBuilder();
           updateString.Append("update RoomType set ");
           updateString.Append("TypeName=" + "'" + roomType.TypeName + "'");
           updateString.Append(",TypePrice=" + "'"+roomType.TypePrice+"'");
           updateString.Append(",AddBedPrice=" +"'"+ roomType.AddBedPrice+"'");
           updateString.Append(",IsAddBed=" +"'"+ roomType.IsAddBed+"'");
           updateString.Append(",Remark=" + "'" + roomType.Remark + "'");
           updateString.Append(" where TypeId=" + roomType.TypeId);

           sql = updateString.ToString();
           DBHelper.ExecuteCommand(sql);
       }
       /// <summary>
       /// 根据类型ID删除类型信息
       /// </summary>
       /// <param name="typeId">类型ID</param>
       public static void DeleteRoomTypeByTypeId(int typeId)
       {
           sql = "delete from RoomType where TypeID=" + Convert.ToString(typeId);
           DBHelper.ExecuteCommand(sql);
       }
       /// <summary>
       /// 新增类型信息
       /// </summary>
       /// <param name="roomType">类型实体对象</param>
       /// <returns>类型ID</returns>
       public static int AddRoomType(RoomType roomType)
       {
           int typeId = 0;
           StringBuilder addString = new StringBuilder();
           addString.Append("insert into RoomType ( TypeName,TypePrice,AddBedPrice,IsAddBed,Remark) values(");
           addString.Append(" '" + roomType.TypeName + "'");
           addString.Append(",'" + roomType.TypePrice+"'");
           addString.Append(",'" + roomType.AddBedPrice+"'");
           addString.Append(",'" + roomType.IsAddBed+"'");
           addString.Append(",'" + roomType.Remark + "') select @@IDENTITY");
           sql = addString.ToString();
           typeId = DBHelper.GetScalar(sql);
           return typeId;
       }
       /// <summary>
       /// 根据类型名称得到类型ID
       /// </summary>
       /// <param name="typeName">类型名称</param>
       /// <returns></returns>
       public static int GetTypeIdByTypeName(string typeName)
       {
           int typeId =0;
           sql = "select TypeID from RoomType where TypeName='" + typeName+"'";
           using (SqlDataReader dataReader = DBHelper.GetReader(sql))
           {
               if(dataReader.Read())
               {
                   typeId = Convert.ToInt32(dataReader["TypeID"]);
               }
           }
          return typeId;
       }
       #endregion
   }
}

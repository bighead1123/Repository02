using System;
using System.Collections.Generic;
using System.Text;
using HotelManager.Models;
using HotelManager.DAL;
/*********************************
 * 类名：RoomTypeManager
 * 功能描述：提供客房类型信息业务逻辑
 * ******************************/
namespace HotelManager.BLL
{
   public static class RoomTypeManager
   {
       #region "Public Methods"
       /// <summary>
       /// 得到客房类型信息集合
       /// </summary>
       /// <returns></returns>
       public static IList<RoomType> GetAllRoomTypes()
        {
            try
            {
             return   RoomTypeService.GetAllRoomTypes();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
       /// <summary>
       /// 根据类型ID得到类型名称
       /// </summary>
       /// <param name="typeID">类型ID</param>
       /// <returns></returns>
       public static string GetTypeNameByTypeID(int typeID)
       {
           try
           {
               return RoomTypeService.GetTypeNameByTypeID(typeID);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.ToString());
           }
       }
       /// <summary>
       /// 根据类型ID得到类型实体对象
       /// </summary>
       /// <param name="typeId">类型ID</param>
       /// <returns></returns>
       public static RoomType GetRoomTypeByTypeID(int typeId)
       {
           try
           {
               return RoomTypeService.GetRoomTypeByTypeID(typeId);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.ToString());
           }
       }
       /// <summary>
       /// 修改客房类型信息
       /// </summary>
       /// <param name="roomType">类型实体对象</param>
       public static void ModifyRoomType(RoomType roomType)
       {
           try
           {
               RoomTypeService.ModifyRoomType(roomType);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.ToString());
           }

       }
       /// <summary>
       /// 根据类型ID删除类型信息
       /// </summary>
       /// <param name="typeId"></param>
       public static void DeleteRoomTypeByTypeId(int typeId)
       {
           try
           {
               RoomTypeService.DeleteRoomTypeByTypeId(typeId);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.ToString());
           }
       }
       /// <summary>
       /// 新增类型信息
       /// </summary>
       /// <param name="roomType">类型实体对象集合</param>
       /// <returns></returns>
       public static int AddRoomType(RoomType roomType)
       {
           try
           {
             return  RoomTypeService.AddRoomType(roomType);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.ToString());
           }
       }
       /// <summary>
       /// 根据类型名称得到类型ID
       /// </summary>
       /// <param name="typeName">类型名称</param>
       /// <returns></returns>
       public static int GetTypeIdTypeName(string typeName)
       {
           try
           {
               return RoomTypeService.GetTypeIdByTypeName(typeName);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.ToString());
           }
       }
       #endregion
    }
}

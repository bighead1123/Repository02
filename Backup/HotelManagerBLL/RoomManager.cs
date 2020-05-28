using System;
using System.Collections.Generic;
using System.Text;
using HotelManager.Models;
using HotelManager.DAL;
/*********************************
 * 类名：RoomManager
 * 功能描述：提供客房信息业务逻辑
 * ******************************/
namespace HotelManager.BLL
{
   public static class RoomManager
   {
       #region "Public Methods"
       /// <summary>
       /// 根据类型ID的客房信息集合
       /// </summary>
       public static IList<Room> GetAllRoomsByTypeId(int roomTypeId)
       {
           try
           {
               return RoomService.GetAllRoomsByTypeId(roomTypeId);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.ToString());
           }
       }
       /// <summary>
       /// 得到客房信息集合
       /// </summary>
       public static IList<Room> GetAllRooms()
       {
           try
           {
               return RoomService.GetAllRooms();
           }
           catch (Exception ex)
           {
               throw new Exception(ex.ToString());
           }
       }
       /// <summary>
       /// 根据客房ID得到客房信息实体对象
       /// </summary>
       public static Room GetRoomByRoomId(int roomId)
       {
           try
           {
               return RoomService.GetRoomByRoomId(roomId);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.ToString());
           }
       }
       /// <summary>
       /// 修改房间状态
       /// </summary>
       /// <param name="roomId">客房ID</param>
       /// <param name="state">房间状态</param>
       public static void ModifyRoomState(int roomId, string state)
       {
           try
           {
               RoomService.ModifyRoomState(roomId, state);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.ToString());
           }
       }
       /// <summary>
       /// 删除客房信息
       /// </summary>
       /// <param name="roomId">客房ID</param>
       public static void DeleteRoomByRoomId(int roomId)
       {
           try
           {
               RoomService.DeleteRoomByRoomId(roomId);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.ToString());
           }
       }
       /// <summary>
       /// 修改客房信息
       /// </summary>
       /// <param name="room">客房实体对象</param>
       public static void ModifyRoom(Room room)
       {
           try
           {
               RoomService.ModifyRoom(room);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.ToString());
           }
       }
       /// <summary>
       /// 根据房间号得到客房ID
       /// </summary>
       /// <param name="roomNo">房间号</param>
       /// <returns></returns>
       public static int GetRoomIdByRoomNo(string roomNo)
       {
           int roomId;
           try
           {
               roomId =RoomService.GetRoomIdByRoomNo(roomNo);
  
           }
           catch (Exception ex)
           {
               throw new Exception(ex.ToString());
           }
           return roomId;
       }
       /// <summary>
       /// 新增客房信息
       /// </summary>
       /// <param name="room">客房实体对象</param>
       /// <returns></returns>
       public static int AddRoom(Room room)
       {
           try
           {
             return  RoomService.AddRoom(room);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.ToString());
           }
       }
       #endregion
   }
}

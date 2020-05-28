using System;
using System.Collections.Generic;
using System.Text;
using HotelManager.Models;
using HotelManager.DAL;
/*********************************
 * ������RoomManager
 * �����������ṩ�ͷ���Ϣҵ���߼�
 * ******************************/
namespace HotelManager.BLL
{
   public static class RoomManager
   {
       #region "Public Methods"
       /// <summary>
       /// ��������ID�Ŀͷ���Ϣ����
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
       /// �õ��ͷ���Ϣ����
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
       /// ���ݿͷ�ID�õ��ͷ���Ϣʵ�����
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
       /// �޸ķ���״̬
       /// </summary>
       /// <param name="roomId">�ͷ�ID</param>
       /// <param name="state">����״̬</param>
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
       /// ɾ���ͷ���Ϣ
       /// </summary>
       /// <param name="roomId">�ͷ�ID</param>
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
       /// �޸Ŀͷ���Ϣ
       /// </summary>
       /// <param name="room">�ͷ�ʵ�����</param>
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
       /// ���ݷ���ŵõ��ͷ�ID
       /// </summary>
       /// <param name="roomNo">�����</param>
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
       /// �����ͷ���Ϣ
       /// </summary>
       /// <param name="room">�ͷ�ʵ�����</param>
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

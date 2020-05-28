using System;
using System.Collections.Generic;
using System.Text;
using HotelManager.Models;
using HotelManager.DAL;
/*********************************
 * ������RoomTypeManager
 * �����������ṩ�ͷ�������Ϣҵ���߼�
 * ******************************/
namespace HotelManager.BLL
{
   public static class RoomTypeManager
   {
       #region "Public Methods"
       /// <summary>
       /// �õ��ͷ�������Ϣ����
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
       /// ��������ID�õ���������
       /// </summary>
       /// <param name="typeID">����ID</param>
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
       /// ��������ID�õ�����ʵ�����
       /// </summary>
       /// <param name="typeId">����ID</param>
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
       /// �޸Ŀͷ�������Ϣ
       /// </summary>
       /// <param name="roomType">����ʵ�����</param>
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
       /// ��������IDɾ��������Ϣ
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
       /// ����������Ϣ
       /// </summary>
       /// <param name="roomType">����ʵ����󼯺�</param>
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
       /// �����������Ƶõ�����ID
       /// </summary>
       /// <param name="typeName">��������</param>
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using HotelManager.Models;
/*********************************
 * ������RoomService
 * �����������ṩ�ͷ���Ϣ���ݷ���
 * ******************************/
namespace HotelManager.DAL
{
    public static class RoomService
    {
        #region Private Members
        static string sql = string.Empty;
        #endregion

        #region Public Methods
        /// <summary>
        /// ��������ID�õ��ͷ���Ϣ����
        /// </summary>
        /// <param name="roomTypeId">����ID </param>
        /// <returns></returns>
        public static IList<Room> GetAllRoomsByTypeId(int roomTypeId)
        {
            IList<Room> rooms = new List<Room>();
            sql = "select * from Room ";
            if (roomTypeId.ToString()!="0")
                sql += " where TypeID = " + roomTypeId.ToString();
            using (SqlDataReader dataReader = DBHelper.GetReader(sql))
            {
                while (dataReader.Read())
                {
                    Room room = new Room();
                    room.RoomId = Convert.ToInt32(dataReader["RoomId"]);
                    room.Number = Convert.ToString(dataReader["Number"]);
                    room.State = Convert.ToString(dataReader["State"]);
                    room.Description = Convert.ToString(dataReader["Description"]);
                    room.BedNumber = Convert.ToInt32(dataReader["BedNumber"]);
                    room.GuestNumber = Convert.ToInt32(dataReader["GuestNumber"]);
                    rooms.Add(room);
                }
            }
            return rooms ;
        }
        /// <summary>
        /// �õ��ͷ���Ϣ����
        /// </summary>
        /// <returns></returns>
        public static IList<Room> GetAllRooms()
        {
            IList<Room> rooms = new List<Room>();
            sql = "select * from Room";
            using (SqlDataReader dataReader = DBHelper.GetReader(sql))
            {
                while (dataReader.Read())
                {
                    Room room = new Room();
                    room.RoomId = Convert.ToInt32(dataReader["RoomId"]);
                    room.TypeID = Convert.ToInt32(dataReader["TypeID"]);
                    room.Number = Convert.ToString(dataReader["Number"]);
                    room.State = Convert.ToString(dataReader["State"]);
                    room.Description = Convert.ToString(dataReader["Description"]);
                    room.BedNumber = Convert.ToInt32(dataReader["BedNumber"]);
                    room.GuestNumber = Convert.ToInt32(dataReader["GuestNumber"]);
                    rooms.Add(room);
                }
            }
            return rooms;
        }
        /// <summary>
        /// ���ݿͷ�ID�õ��ͷ�ʵ�����
        /// </summary>
        /// <param name="roomId">�ͷ�ID </param>
        /// <returns></returns>
        public static Room GetRoomByRoomId(int roomId)
        {               
            Room room = new Room();
            sql = "select * from Room where RoomId ="+ roomId.ToString();
            using (SqlDataReader dataReader = DBHelper.GetReader(sql))
            {
                if (dataReader.Read())
                {
                    room.Number = Convert.ToString(dataReader["Number"]);
                    room.TypeID = Convert.ToInt32(dataReader["TypeID"]);
                    room.State = Convert.ToString(dataReader["State"]);
                    room.Description = Convert.ToString(dataReader["Description"]);
                    room.BedNumber = Convert.ToInt32(dataReader["BedNumber"]);
                    room.GuestNumber = Convert.ToInt32(dataReader["GuestNumber"]);
                }
            }
            return room;
        }
        /// <summary>
        /// �޸ķ���״̬
        /// </summary>
        /// <param name="roomId">����ID</param>
        /// <param name="state">״̬</param>
        public static void ModifyRoomState(int roomId,string state)
        {
            sql = "update Room set State =" + "'" + state + "'" + " where RoomId =" + "'" + roomId + "'";
            DBHelper.ExecuteCommand(sql);
        }
        /// <summary>
        /// ���ݿͷ�IDɾ���ͷ���Ϣ
        /// </summary>
        /// <param name="roomId">�ͷ��ɣ�</param>
        public static void DeleteRoomByRoomId(int roomId)
        {
            sql = "delete from Room where RoomID=" + Convert.ToString(roomId);
            DBHelper.ExecuteCommand(sql);
        }
        /// <summary>
        /// �޸Ŀͷ���Ϣ
        /// </summary>
        /// <param name="room">�ͷ�ʵ�����</param>
        public static void ModifyRoom(Room room)
        {
            StringBuilder updateString = new StringBuilder();
            updateString.Append("update Room set ");
            updateString.Append("Number="+"'"+room.Number+"'");
            updateString.Append(",TypeID=" + room.TypeID);
            updateString.Append(",BedNumber=" + room.BedNumber);
            updateString.Append(",GuestNumber=" + room.GuestNumber);
            updateString.Append(",State=" + "'" + room.State + "'");
            updateString.Append(",Description=" + "'" + room.Description + "'");
            updateString.Append(" where RoomId=" + room.RoomId );

            sql = updateString.ToString();
            DBHelper.ExecuteCommand(sql);
        }
        /// <summary>
        /// ���ݷ���ŵõ��ͷ�ID
        /// </summary>
        /// <param name="roomNo">�����</param>
        /// <returns></returns>
        public static int GetRoomIdByRoomNo(string roomNo)
        {
            int roomId=0;
            sql = "select RoomID from Room where Number=" + "'" + roomNo + "'";
            using (SqlDataReader dataReader = DBHelper.GetReader(sql))
            {
                if (dataReader.Read())
                {
                    roomId = Convert.ToInt32(dataReader["RoomID"]);
                }
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
            int roomId = 0;
            StringBuilder addString = new StringBuilder();
            addString.Append("insert into Room ( Number,TypeID,BedNumber,GuestNumber,State,Description) values(");
            addString.Append(" '" + room.Number + "'");
            addString.Append("," + room.TypeID);
            addString.Append("," + room.BedNumber);
            addString.Append("," + room.GuestNumber);
            addString.Append(",'" + room.State + "'");
            addString.Append(",'" + room.Description + "') select @@IDENTITY");
            sql = addString.ToString();
            roomId =DBHelper.GetScalar(sql);
            return roomId;
        }
        #endregion
    }
}

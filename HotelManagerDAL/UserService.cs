using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
/*********************************
 * ������UserManager
 * �����������ṩ�û���Ϣ���ݷ���
 * ******************************/
namespace HotelManager.DAL
{
   public static class UserService
   {
       #region Private Members
       static string sql = string.Empty;
       #endregion

       #region Public Methods
       /// <summary>
       /// �����û����õ��û�����
       /// </summary>
       /// <param name="userName">�û���</param>
       /// <returns>����</returns>
       public static string GetUserPasswordByUserName(string userName)
       {
           string pwd = string.Empty;
           sql = "select Password from HotelUser where userName =" + "'" + userName + "'";
           using (SqlDataReader dataReader = DBHelper.GetReader(sql))
           {
               if (dataReader.Read())
               {
                   pwd = Convert.ToString(dataReader["Password"]);
               }
           }
           return pwd;
       }
       #endregion
   }
}

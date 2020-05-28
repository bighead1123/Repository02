using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
/*********************************
 * 类名：UserManager
 * 功能描述：提供用户信息数据访问
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
       /// 根据用户名得到用户密码
       /// </summary>
       /// <param name="userName">用户名</param>
       /// <returns>密码</returns>
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

using System;
using System.Collections.Generic;
using System.Text;
using HotelManager.DAL;
using HotelManager.Models;
/*********************************
 * 类名：UserManager
 * 功能描述：提供用户信息业务逻辑
 * ******************************/
namespace HotelManager.BLL
{
    public static class UserManager
    {
        /// <summary>
        /// 根据用户名得到用户密码
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>密码</returns>
        public static string GetUserPasswordByUserName(string userName)
        {
            string pwd = string.Empty;
            try
            {
                pwd =UserService.GetUserPasswordByUserName(userName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return pwd;
        }
    }
}

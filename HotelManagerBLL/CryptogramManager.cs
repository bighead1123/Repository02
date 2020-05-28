using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.Web.Security;
/*********************************
 * 类名：CryptogramManager
 * 功能描述：提供密码加密功能
 * ******************************/
namespace HotelManager.BLL
{
    public static class CryptogramManager
    {
        /// <summary>
        /// 将指定的密码用SHA1加密
        /// </summary>
        /// <param name="passwordString">明文</param>
        /// <returns>密文</returns>
        public static string EncryptPassword(string passwordString)
        {
            string password = string.Empty;
            if (!string.IsNullOrEmpty(passwordString))
            {
                password = FormsAuthentication.HashPasswordForStoringInConfigFile(passwordString, "SHA1");
            }
            return password;
        }
    }
}

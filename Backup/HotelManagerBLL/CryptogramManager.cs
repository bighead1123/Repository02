using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.Web.Security;
/*********************************
 * ������CryptogramManager
 * �����������ṩ������ܹ���
 * ******************************/
namespace HotelManager.BLL
{
    public static class CryptogramManager
    {
        /// <summary>
        /// ��ָ����������SHA1����
        /// </summary>
        /// <param name="passwordString">����</param>
        /// <returns>����</returns>
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

using System;
using System.Collections.Generic;
using System.Text;
using HotelManager.DAL;
using HotelManager.Models;
/*********************************
 * ������UserManager
 * �����������ṩ�û���Ϣҵ���߼�
 * ******************************/
namespace HotelManager.BLL
{
    public static class UserManager
    {
        /// <summary>
        /// �����û����õ��û�����
        /// </summary>
        /// <param name="userName">�û���</param>
        /// <returns>����</returns>
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

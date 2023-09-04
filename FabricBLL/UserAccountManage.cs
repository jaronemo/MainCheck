using FabricDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FabricModel;

using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace FabricBLL
{
    public class UserAccountManage
    {
        //根据给定字符串生成MD5.由于仅仅在用户相关用到，故没有封装到Common中
        public static string GetMD5(string originStr)
        {
            MD5 md5 = MD5.Create();
            byte[] byteOld = Encoding.UTF8.GetBytes(originStr);
            byte[] byteNew = md5.ComputeHash(byteOld);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in byteNew)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        //获取信息
        public UserAccount Get(string username, bool keepPassword = true, bool keepPermission = true)
        {
            return new UserAccountServices().Get(username, keepPassword, keepPermission);
        }

        //返回List<Model>
        public List<UserAccount> GetList(string condition = "", string find = "", bool keepPassword = false, bool keepPermission = false)
        {
            switch (condition)
            {
                case "帳號名稱":
                    condition = " U_LoginName ";
                    break;
                case "員工姓名":
                    condition = " U_Name ";
                    break;
                case "部門":
                    condition = " U_Department ";
                    break;
                case "不篩選":
                default:
                    condition = "";
                    break;
            }
            return new UserAccountServices().Get(condition, find, keepPassword, keepPermission);
        }

        //检查某人是否有某权限
        public bool IfGranted(UserAccount usr, char permission)
        {
            if (usr.Permission.IndexOf(permission) > -1) return true;
            else return false;
        }

        //更改密码
        public void ChangePassword(string username, string newPassword)
        {
            if (newPassword == string.Empty)
            {
                throw new Exception("請輸入新密碼!");
            }
            newPassword = GetMD5(newPassword);
            UserAccount usr = new UserAccount();
            usr.LoginName = username;
            usr.Password = newPassword;
            new UserAccountServices().ChangeInfo(usr);
        }

        //校验必要的参数
        private void ValidateInfo(string username, string name, string department, string phone)
        {
            if (username == string.Empty)
            {
                throw new Exception("帳號名稱不得為空！");
            }
            if (username.Length > 20)
            {
                throw new Exception("帳號名稱長度超過系統限制！");
            }
            if (name == string.Empty)
            {
                throw new Exception("員工姓名不能為空！");
            }
            if (name.Length > 10)
            {
                throw new Exception("姓名長度超過系統限制！");
            }
            if (department.Length > 20)
            {
                throw new Exception("部門的字數過長，請限制在20個字元內！");
            }
            if (phone.Length > 11)
            {
                throw new Exception("聯絡電話字數超過限制，請限制在11個字元內。");
            }
        }

        //生成UserModel
        private UserAccount GetModel(string username, string permission, string name, string sex, string department, string phone, DateTime birthday, DateTime entryDate, string password = null)
        {
            UserAccount newUsr = new UserAccount();
            newUsr.LoginName = username;
            newUsr.Name = name;
            newUsr.Password = password;
            newUsr.Sex = sex;
            newUsr.Department = department;
            newUsr.Phone = phone;
            newUsr.Birthday = birthday;
            newUsr.EntryDate = entryDate;
            newUsr.Permission = permission;
            return newUsr;
        }

        //更改信息
        public void ChangeInfo(string username, string permission, string name, string sex, string department, string phone, DateTime birthday, DateTime entryDate)
        {
            ValidateInfo(username, name, department, phone);
            if (username.ToLower() == "admin") throw new Exception("不允許修改管理員的資料！");
            new UserAccountServices().ChangeInfo(GetModel(username, permission, name, sex, department, phone, birthday, entryDate));

        }

        //新增用户
        public void Add(string username, string password, string permission, string name, string sex, string department, string phone, DateTime birthday, DateTime entryDate)
        {
            ValidateInfo(username, name, department, phone);
            if (username.ToLower() == "admin") throw new Exception("管理員已經存在！");
            if (password == string.Empty) throw new Exception("請輸入密碼！");
            //查找是否有同用户名账户
            try
            {
                new UserAccountServices().Get(username);
                // 如果能找到該用戶，則拋出異常說明該用戶名已經被使用
                throw new Exception("帳號已存在");
            }
            catch (Exception exp)
            {
                // 如果找不到該用戶，則繼續執行
                if (exp.Message != "帳號不存在")
                {
                    throw exp;
                }
            }
            new UserAccountServices().Add(GetModel(username, permission, name, sex, department, phone, birthday, entryDate, GetMD5(password)));
        }


        //删除用户
        public void Delete(string username)
        {
            new UserAccountServices().Delete(username);
        }
    }
}

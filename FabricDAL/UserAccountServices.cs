using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using static DevExpress.XtraEditors.Mask.MaskSettings;
using System.Data;
using FabricModel;

namespace FabricDAL
{
    public class UserAccountServices
    {
        private List<UserAccount> ToModel(DataTable dt, bool keepPassword = false, bool keepPermission = false)
        {
            List<UserAccount> usrList = new List<UserAccount>();
            UserAccount usr;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                usr = new UserAccount();
                usr.LoginName = dt.Rows[i]["U_LoginName"].ToString();
                if (keepPassword) usr.Password = dt.Rows[i]["U_Password"].ToString();
                if (keepPermission) usr.Permission = dt.Rows[i]["U_Permission"].ToString();
                usr.Name = dt.Rows[i]["U_Name"].ToString();
                usr.Sex = dt.Rows[i]["U_Sex"].ToString();
                usr.Department = dt.Rows[i]["U_Department"].ToString();
                usr.Phone = dt.Rows[i]["U_Phone"].ToString();
                usr.Birthday = (dt.Rows[i]["U_Birthday"] == DBNull.Value) ? default(DateTime) : (DateTime)dt.Rows[i]["U_Birthday"];
                usr.EntryDate = (dt.Rows[i]["U_EntryDate"] == DBNull.Value) ? default(DateTime) : (DateTime)dt.Rows[i]["U_EntryDate"];
                usrList.Add(usr);
            }
            return usrList;
        }

        //获取单人Model
        /* public User Get(string username, bool keepPassword = true, bool keepPermission = true)
         {
             string sqlStr = string.Format("SELECT * FROM tbl_User WHERE U_LoginName = '{0}'", username);
             DataSet ds = SqlHelper.Query(sqlStr);
             if (ds.Tables[0].Rows.Count == 0) throw new Exception("用戶不存在");
             return ToModel(ds.Tables[0], keepPassword, keepPermission)[0];
         }*/
        public UserAccount Get(string username, bool keepPassword = true, bool keepPermission = true)
        {
            string sqlStr = "SELECT * FROM tbl_User WHERE U_LoginName = @Username";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Username", username)
            };


            DataSet ds = SqlHelper.Query(sqlStr, parameters);
            if (ds.Tables[0].Rows.Count == 0) throw new Exception("帳號不存在");
            return ToModel(ds.Tables[0], keepPassword, keepPermission)[0];
        }


        //重载 获取列表的List<Model>
        public List<UserAccount> Get(string condition, string find, bool keepPassword = false, bool keepPermission = false)
        {
            string sqlStr = "SELECT * FROM tbl_User";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();
            if (!string.IsNullOrEmpty(condition) && !string.IsNullOrEmpty(find))
            {
                sqlStr += $" WHERE {condition} = @Find";
                parameters.Add(new NpgsqlParameter("@Find", find));
            }
            DataSet ds = SqlHelper.Query(sqlStr, parameters.ToArray());
            return ToModel(ds.Tables[0]);
        }


        //修改信息,注意:每一次只能修改密码或信息
        public void ChangeInfo(UserAccount usr)
        {
            string sqlStr = "UPDATE tbl_User SET ";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>();

            if (!string.IsNullOrEmpty(usr.Password))
            {
                sqlStr += "U_Password = @Password, ";
                parameters.Add(new NpgsqlParameter("@Password", usr.Password));
            }

            sqlStr += "U_Name = @Name, U_Sex = @Sex, U_Department = @Department, U_Phone = @Phone, U_Birthday = @Birthday, U_EntryDate = @EntryDate, U_Permission = @Permission WHERE U_LoginName = @LoginName";

            parameters.Add(new NpgsqlParameter("@Name", usr.Name));
            parameters.Add(new NpgsqlParameter("@Sex", usr.Sex));
            parameters.Add(new NpgsqlParameter("@Department", usr.Department));
            parameters.Add(new NpgsqlParameter("@Phone", usr.Phone));
            parameters.Add(new NpgsqlParameter("@Birthday", usr.Birthday));
            parameters.Add(new NpgsqlParameter("@EntryDate", usr.EntryDate));
            parameters.Add(new NpgsqlParameter("@Permission", usr.Permission));
            parameters.Add(new NpgsqlParameter("@LoginName", usr.LoginName));

            SqlHelper.Execute(sqlStr, parameters.ToArray());
        }

        /*public void ChangeInfo(User usr)
        {
            //先区分类型
            string sqlStr = String.Format("UPDATE tbl_User SET ");
            if (usr.Password != string.Empty && usr.Password != null)
            {
                //修改密码
                sqlStr += String.Format(" U_Password = '{0}' ", usr.Password);
            }
            else
            {
                //修改信息
                sqlStr += String.Format(" U_Name = '{0}', U_Sex = '{1}', U_Department = '{2}', U_Phone = '{3}', U_Birthday = '{4}', U_EntryDate = '{5}', U_Permission = '{6}' ",
                    usr.Name, usr.Sex, usr.Department, usr.Phone, usr.Birthday, usr.EntryDate, usr.Permission);
            }
            sqlStr += String.Format(" WHERE U_LoginName = '{0}' ", usr.LoginName);
            SqlHelper.Execute(sqlStr);
        }*/

        //添加用户
        public void Add(UserAccount usr)
        {
            string sqlStr = "INSERT INTO tbl_User (U_LoginName, U_Password, U_Permission, U_Name, U_Sex, U_Department, U_Phone, U_Birthday, U_EntryDate) VALUES (@LoginName, @Password, @Permission, @Name, @Sex, @Department, @Phone, @Birthday, @EntryDate)";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@LoginName", usr.LoginName),
                new NpgsqlParameter("@Password", usr.Password),
                new NpgsqlParameter("@Permission", usr.Permission),
                new NpgsqlParameter("@Name", usr.Name),
                new NpgsqlParameter("@Sex", usr.Sex),
                new NpgsqlParameter("@Department", usr.Department),
                new NpgsqlParameter("@Phone", usr.Phone),
                new NpgsqlParameter("@Birthday", usr.Birthday),
                new NpgsqlParameter("@EntryDate", usr.EntryDate)
            };
            SqlHelper.Execute(sqlStr, parameters);
        }

        //删除用户
        public void Delete(string username)
        {
            string sqlStr = "DELETE From tbl_user WHERE U_LoginName = @LoginName";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@LoginName", username)
            };
            SqlHelper.Execute(sqlStr, parameters);
        }
    }
}

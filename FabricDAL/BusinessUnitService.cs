using FabricModel;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricDAL
{
    public class BussinessUnitService
    {
        public List<BussinessUnit> ToModel(DataTable dt)
        {
            List<BussinessUnit> list = new List<BussinessUnit>();
            BussinessUnit bu;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bu = new BussinessUnit();
                bu.No = (int)dt.Rows[i]["BU_No"];
                bu.Name = dt.Rows[i]["BU_Name"].ToString();
                bu.Address = dt.Rows[i]["BU_Address"].ToString();
                bu.ContactName = dt.Rows[i]["BU_ContactName"].ToString();
                bu.Phone = dt.Rows[i]["BU_Phone"].ToString();
                bu.Email = dt.Rows[i]["BU_Email"].ToString();
                bu.Fax = dt.Rows[i]["BU_fax"].ToString();
                bu.Mobile = dt.Rows[i]["BU_mobile"].ToString();
                bu.ComapnyName = dt.Rows[i]["BU_company_name"].ToString();
                bu.Vat1 = dt.Rows[i]["BU_vat1"].ToString();
                bu.Vat2 = dt.Rows[i]["BU_vat2"].ToString();
                bu.ContractPhone = dt.Rows[i]["BU_contract_phone"].ToString();
                bu.ContractFax = dt.Rows[i]["BU_contract_fax"].ToString();
                bu.Sale1 = dt.Rows[i]["BU_sale1"].ToString();
                bu.Sale2 = dt.Rows[i]["BU_sale2"].ToString();
                bu.Level1 = dt.Rows[i]["BU_level1"].ToString();
                bu.Level2 = dt.Rows[i]["BU_level2"].ToString();
                bu.Note = dt.Rows[i]["BU_Note"].ToString();
                bu.EngCompanyName = dt.Rows[i]["BU_eng_company_name"].ToString();
                bu.Code = dt.Rows[i]["BU_Code"].ToString();
                bu.Principal = dt.Rows[i]["bu_principal"].ToString();
                if (dt.Rows[i]["bu_payment_id"] != DBNull.Value)
                {
                    bu.PaymentID = (int)dt.Rows[i]["bu_payment_id"];
                }
                else
                {
                    bu.PaymentID = null; // 或者設定為其他預設值，如 -1
                }

                list.Add(bu);
            }
            return list;
        }

        //获取单个
        /*public BussinessUnit Get(int no)
        {
            string sqlStr = "SELECT * FROM tbl_BussinessUnit WHERE BU_No = " + no;
            DataSet ds = SqlHelper.Query(sqlStr);
            if (ds.Tables[0].Rows.Count == 0) throw new Exception("往來單位不存在");
            return ToModel(ds.Tables[0])[0];
        }*/
        public BussinessUnit Get(int no)
        {
            string sqlStr = "SELECT * FROM tbl_BussinessUnit WHERE BU_No = @No";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@No", no)
            };
            DataSet ds = SqlHelper.Query(sqlStr, parameters);
            if (ds.Tables[0].Rows.Count == 0) throw new Exception("往來單位不存在");
            return ToModel(ds.Tables[0])[0];
        }


        /*public List<BussinessUnit> Get(string type, string condition, string find)
        {
            string sqlStr = "SELECT * FROM tbl_BussinessUnit WHERE BU_Type = @Type";
            if (condition != string.Empty)
            {
                sqlStr += String.Format(" AND {0} = '{1}' ", condition, find);
            }
            DataSet ds = SqlHelper.Query(sqlStr);
            return ToModel(ds.Tables[0]);
        }*/
        public List<BussinessUnit> Get(string condition, string find)
        {
            string sqlStr = "SELECT * FROM tbl_BussinessUnit";

            if (!string.IsNullOrEmpty(condition) && !string.IsNullOrEmpty(find))
            {
                sqlStr += $" WHERE {condition} LIKE '%{find}%'";
            }

            DataSet ds = SqlHelper.Query(sqlStr);
            return ToModel(ds.Tables[0]);
        }



        /*public void Add(BussinessUnit bu)
        {
            string sqlStr = string.Format("INSERT INTO tbl_BussinessUnit VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}') ",
                bu.Name, bu.Type, bu.Address, bu.ContactName, bu.Phone, bu.Email, bu.Fax, bu.Mobile, bu.ComapnyName);
            SqlHelper.Execute(sqlStr);
        }*/
        /*public void Add(BussinessUnit bu)
        {
            string sqlStr = string.Format("INSERT INTO tbl_BussinessUnit (bu_Name, bu_Type, bu_Address, bu_ContactName, bu_Phone, bu_Email, bu_Fax, bu_Mobile, bu_company_name) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}') ",
                bu.Name, bu.Type, bu.Address, bu.ContactName, bu.Phone, bu.Email, bu.Fax, bu.Mobile, bu.ComapnyName);
            SqlHelper.Execute(sqlStr);
        }*/
        public void Add(BussinessUnit bu)
        {
            string sqlStr = "INSERT INTO tbl_bussinessunit (bu_Name, bu_Address, bu_ContactName, bu_Phone, bu_Email, bu_Fax, bu_Mobile, bu_company_name, bu_code, bu_principal, bu_vat1, bu_vat2, bu_eng_company_name, bu_sale1, bu_sale2, BU_level1, BU_level2, bu_note, bu_contract_phone, bu_contract_fax, bu_payment_id) VALUES (@Name, @Address, @ContactName, @Phone, @Email, @Fax, @Mobile, @CompanyName, @Code, @Principal, @vat1, @vat2, @eng_company, @saleperson, @saleperson1, @level1, @level2, @note, @contract_phone, @contract_fax, @PaymentID)";
            /* name, address, contactName, phone, email, fax, mobile, company_name, eng_company_name,  code, principal, vat1, vat2, contract_phone, contract_fax, sale1, sale2, level1, level2, note*/
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Name", bu.Name),
                new NpgsqlParameter("@Address", bu.Address ??(object) DBNull.Value),
                new NpgsqlParameter("@ContactName", bu.ContactName ??(object) DBNull.Value),
                new NpgsqlParameter("@Phone", bu.Phone ??(object) DBNull.Value),
                new NpgsqlParameter("@Email", bu.Email ??(object) DBNull.Value),
                new NpgsqlParameter("@Fax", bu.Fax ??(object) DBNull.Value),
                new NpgsqlParameter("@Mobile", bu.Mobile ??(object) DBNull.Value),
                new NpgsqlParameter("@CompanyName", bu.ComapnyName ??(object) DBNull.Value),
                new NpgsqlParameter("@Code", bu.Code),
                new NpgsqlParameter("@Principal", bu.Principal ??(object) DBNull.Value),
                new NpgsqlParameter("@vat1", bu.Vat1 ??(object) DBNull.Value),
                new NpgsqlParameter("@vat2", bu.Vat2 ??(object) DBNull.Value),
                new NpgsqlParameter("@eng_company", bu.EngCompanyName),
                new NpgsqlParameter("@saleperson", bu.Sale1 ?? (object)DBNull.Value),
                new NpgsqlParameter("@saleperson1", bu.Sale2 ?? (object)DBNull.Value),
                new NpgsqlParameter("@level1", bu.Level1),
                new NpgsqlParameter("@level2", bu.Level2),
                new NpgsqlParameter("@note", bu.Note ?? (object)DBNull.Value),
                new NpgsqlParameter("@contract_phone", bu.ContractPhone ??(object) DBNull.Value),
                new NpgsqlParameter("@contract_fax", bu.ContractFax ??(object) DBNull.Value),
                new NpgsqlParameter("@PaymentID", bu.PaymentID.HasValue ? (object)bu.PaymentID.Value : DBNull.Value)
            };

            SqlHelper.Execute(sqlStr, parameters);
        }



        /* public void Delete(int no)
         {
             string sqlStr = String.Format("DELETE FROM tbl_BussinessUnit WHERE BU_No = {0}", no);
             SqlHelper.Execute(sqlStr);
         }*/
        public void Delete(int no)
        {
            string sqlStr = "DELETE FROM tbl_bussinessunit WHERE BU_No = @No";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
        new NpgsqlParameter("@No", no)
            };

            SqlHelper.Execute(sqlStr, parameters);
        }
        /*public void ChangeInfo(BussinessUnit bu)
        {
            //无需类别信息
            string sqlStr = String.Format("UPDATE tbl_BussinessUnit SET BU_Name = '{0}', BU_Address = '{1}', BU_ContactName = '{2}', BU_Phone = '{3}', BU_Email = '{4}', BU_Fax = '{5}', BU_Mobile = '{6}', BU_company_name = '{7}' WHERE BU_No = '{8}' ",
                bu.Name, bu.Address, bu.ContactName, bu.Phone, bu.Email, bu.Fax, bu.Mobile, bu.ComapnyName, bu.No);
            SqlHelper.Execute(sqlStr);
        }*/
        public void ChangeInfo(BussinessUnit bu)
        {
            string sqlStr = @"UPDATE tbl_bussinessunit 
                      SET BU_Name = @Name, 
                          BU_Address = @Address, 
                          BU_ContactName = @ContactName, 
                          BU_Phone = @Phone, 
                          BU_Email = @Email, 
                          BU_Fax = @Fax, 
                          BU_Mobile = @Mobile, 
                          BU_company_name = @CompanyName,
                          BU_eng_company_name = @EngCompanyName,
                          BU_Code = @Code,
                          BU_Principal = @Principal,
                          BU_Vat1 = @Vat1,
                          BU_Vat2 = @Vat2,
                          bu_contract_phone = @ContractPhone,
                          bu_contract_fax = @ContractFax,
                          BU_Sale1 = @Sale1,
                          BU_Sale2 = @Sale2,
                          BU_Level1 = @Level1,
                          BU_Level2 = @Level2,
                          BU_Note = @Note,
                          BU_Payment_ID = @PaymentID  
                      WHERE BU_No = @No";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
        new NpgsqlParameter("@Name", bu.Name),
        new NpgsqlParameter("@Address", bu.Address ??(object) DBNull.Value),
        new NpgsqlParameter("@ContactName", bu.ContactName ??(object) DBNull.Value),
        new NpgsqlParameter("@Phone", bu.Phone ??(object) DBNull.Value),
        new NpgsqlParameter("@Email", bu.Email ??(object) DBNull.Value),
        new NpgsqlParameter("@Fax", bu.Fax ??(object) DBNull.Value),
        new NpgsqlParameter("@Mobile", bu.Mobile ??(object) DBNull.Value),
        new NpgsqlParameter("@CompanyName", bu.ComapnyName ??(object) DBNull.Value),
        new NpgsqlParameter("@EngCompanyName", bu.EngCompanyName ??(object) DBNull.Value),
        new NpgsqlParameter("@Code", bu.Code),
        new NpgsqlParameter("@Principal", bu.Principal ??(object) DBNull.Value),
        new NpgsqlParameter("@Vat1", bu.Vat1 ??(object) DBNull.Value),
        new NpgsqlParameter("@Vat2", bu.Vat2 ??(object) DBNull.Value),
        new NpgsqlParameter("@ContractPhone", bu.ContractPhone ??(object) DBNull.Value),
        new NpgsqlParameter("@ContractFax", bu.ContractFax ??(object) DBNull.Value),
        new NpgsqlParameter("@Sale1", bu.Sale1 ?? (object)DBNull.Value),
        new NpgsqlParameter("@Sale2", bu.Sale2 ?? (object)DBNull.Value),
        new NpgsqlParameter("@Level1", bu.Level1),
        new NpgsqlParameter("@Level2", bu.Level2),
        new NpgsqlParameter("@Note", bu.Note ?? (object)DBNull.Value),
        new NpgsqlParameter("@PaymentID", bu.PaymentID.HasValue ? (object)bu.PaymentID.Value : DBNull.Value),
        new NpgsqlParameter("@No", bu.No)
            };

            SqlHelper.Execute(sqlStr, parameters);
        }

    }
}

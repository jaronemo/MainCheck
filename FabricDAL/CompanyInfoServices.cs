using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FabricModel;
using Npgsql;

namespace FabricDAL
{
    public class CompanyInfoServices
    {
        public CompanyInfo ToModel(DataRow row)
        {
            CompanyInfo company = new CompanyInfo()
            {
                Name = row["c_Name"].ToString(),
                Shortname = row["c_ShortName"].ToString(),
                Address = row["c_Address"].ToString(),
                Zipcode = row["c_Zipcode"].ToString(),
                Taxid = row["c_Taxid"].ToString(),
                Phone = row["c_Phone"].ToString(),
                Fax = row["c_Fax"].ToString(),
                Website = row["c_Website"].ToString(),
                Email = row["c_Email"].ToString(),
                Logo = (byte[])row["c_Logo"]
            };

            return company;
        }

        public CompanyInfo Get()
        {
            string sqlStr = "SELECT * FROM tbl_CompanyInfo";

            DataSet ds = SqlHelper.Query(sqlStr);
            if (ds.Tables[0].Rows.Count == 0)
            {
                // Return an empty CompanyInfo object when no data is found
                return null;
            }

            DataRow row = ds.Tables[0].Rows[0];
            CompanyInfo company = ToModel(row);

            return company;
        }

        public void ChangeInfo(CompanyInfo company)
        {
           
            string sqlStr = @"
INSERT INTO tbl_CompanyInfo (c_Name, c_Shortname, c_Address, c_Zipcode, c_Taxid,c_Phone, c_Fax, c_Website, c_email, c_Logo)
VALUES (@c_Name, @c_Shortname, @c_Address, @c_Zipcode, @c_Taxid, @c_Phone, @c_Fax, @c_Website, @c_email, @c_Logo)
ON CONFLICT (c_Name)
DO UPDATE SET 
    c_Shortname = EXCLUDED.c_Shortname, 
    c_Address = EXCLUDED.c_Address, 
    c_Zipcode = EXCLUDED.c_Zipcode, 
    c_Taxid = EXCLUDED.c_Taxid, 
    c_Phone = EXCLUDED.c_Phone, 
    c_Fax = EXCLUDED.c_Fax, 
    c_Website = EXCLUDED.c_Website, 
    c_email = EXCLUDED.c_email, 
    c_Logo = EXCLUDED.c_Logo;";


            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
        new NpgsqlParameter("c_name", company.Name),
        new NpgsqlParameter("c_shortname", company.Shortname),
        new NpgsqlParameter("c_address", company.Address),
        new NpgsqlParameter("c_zipcode", company.Zipcode),
        new NpgsqlParameter("c_taxid", company.Taxid),
        new NpgsqlParameter("c_phone", company.Phone),
        new NpgsqlParameter("c_fax", company.Fax),
        new NpgsqlParameter("c_website", company.Website),
        new NpgsqlParameter("c_email", company.Email),
        new NpgsqlParameter("c_logo", company.Logo)
            };

            SqlHelper.Query(sqlStr, parameters);
        }
    }
}

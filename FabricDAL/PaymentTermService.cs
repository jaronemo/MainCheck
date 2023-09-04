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
    public class PaymentTermService
    {
        public List<PaymentTermUnit> ToModel(DataTable dt)
        {
            List<PaymentTermUnit> list = new List<PaymentTermUnit>();
            PaymentTermUnit pt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                pt = new PaymentTermUnit
                {
                    Id = (int)dt.Rows[i]["ID"],
                    Name = dt.Rows[i]["Name"].ToString(),
                };
                list.Add(pt);
            }
            return list;
        }

        public List<PaymentTermUnit> GetList()
        {
            string sqlStr = "SELECT * FROM tbl_paymenttermunit";

            DataSet dt = SqlHelper.Query(sqlStr);

            return ToModel(dt.Tables[0]);
        }


        public void Add(PaymentTermUnit cu)
        {
            string sqlStr = "INSERT INTO tbl_paymenttermunit (Name) VALUES (@Name)";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Name", cu.Name),
            };

            SqlHelper.Execute(sqlStr, parameters);
        }

        public void ChangeInfo(PaymentTermUnit pt)
        {
            string sqlStr = "UPDATE tbl_paymenttermunit SET Name = @Name WHERE ID = @ID";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Name", pt.Name),
                new NpgsqlParameter("@ID", pt.Id)
            };

            SqlHelper.Execute(sqlStr, parameters);
        }

        public void Delete(int id)
        {
            string sqlStr = "DELETE FROM tbl_paymenttermunit WHERE ID = @ID";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
        new NpgsqlParameter("@ID", id)
            };

            SqlHelper.Execute(sqlStr, parameters);
        }
    }
}

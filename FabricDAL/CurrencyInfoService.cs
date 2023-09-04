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
    public class CurrencyInfoService
    {
        public List<CurrencyUnits> ToModel(DataTable dt)
        {
            List<CurrencyUnits> list = new List<CurrencyUnits>();
            CurrencyUnits cu;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cu = new CurrencyUnits
                {
                    Id = (int)dt.Rows[i]["ID"],
                    Name = dt.Rows[i]["Name"].ToString(),
                    Rate = float.Parse(dt.Rows[i]["Rate"].ToString())
                };
                list.Add(cu);
            }
            return list;
        }

        public List<CurrencyUnits> GetList()
        {
            string sqlStr = "SELECT * FROM tbl_currencyunit";

            DataSet dt = SqlHelper.Query(sqlStr);

            return ToModel(dt.Tables[0]);
        }


        public void Add(CurrencyUnits cu)
        {
            string sqlStr = "INSERT INTO tbl_currencyunit (Name, Rate) VALUES (@Name, @Rate)";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Name", cu.Name),
                new NpgsqlParameter("@Rate", cu.Rate),
            };

            SqlHelper.Execute(sqlStr, parameters);
        }

        public void ChangeInfo(CurrencyUnits cu)
        {
            string sqlStr = "UPDATE tbl_currencyunit SET Name = @Name,Rate = @Rate WHERE ID = @ID";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Name", cu.Name),
                new NpgsqlParameter("@Rate", cu.Rate),
                new NpgsqlParameter("@ID", cu.Id)
            };

            SqlHelper.Execute(sqlStr, parameters);
        }

        public void Delete(int id)
        {
            string sqlStr = "DELETE FROM tbl_currencyunit WHERE ID = @ID";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
        new NpgsqlParameter("@ID", id)
            };

            SqlHelper.Execute(sqlStr, parameters);
        }

    }
}

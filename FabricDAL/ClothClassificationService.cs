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
    public class ClothClassificationService
    {
        public List<ClothClassificationUnit> ToModel(DataTable dt)
        {
            List<ClothClassificationUnit> list = new List<ClothClassificationUnit>();
            ClothClassificationUnit cc;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cc = new ClothClassificationUnit
                {
                    Id = (int)dt.Rows[i]["ID"],
                    Name = dt.Rows[i]["Name"].ToString(),
                };
                list.Add(cc);
            }
            return list;
        }

        public List<ClothClassificationUnit> GetList()
        {
            string sqlStr = "SELECT * FROM tbl_cloth_classification";

            DataSet dt = SqlHelper.Query(sqlStr);

            return ToModel(dt.Tables[0]);
        }


        public void Add(ClothClassificationUnit cc)
        {
            string sqlStr = "INSERT INTO tbl_cloth_classification (Name) VALUES (@Name)";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Name", cc.Name),
            };

            SqlHelper.Execute(sqlStr, parameters);
        }

        public void ChangeInfo(ClothClassificationUnit cc)
        {
            string sqlStr = "UPDATE tbl_cloth_classification SET Name = @Name WHERE ID = @ID";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Name", cc.Name),
                new NpgsqlParameter("@ID", cc.Id)
            };

            SqlHelper.Execute(sqlStr, parameters);
        }

        public void Delete(int id)
        {
            string sqlStr = "DELETE FROM tbl_cloth_classification WHERE ID = @ID";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
        new NpgsqlParameter("@ID", id)
            };

            SqlHelper.Execute(sqlStr, parameters);
        }
    }
}

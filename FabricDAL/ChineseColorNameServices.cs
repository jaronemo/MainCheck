using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using FabricModel;
using Npgsql;

namespace FabricDAL
{
    public class ChineseColorNameServices
    {
        //由DataTable获取List
        public List<ChineseColorNameUnit> ToModel(DataTable dt)
        {
            List<ChineseColorNameUnit> list = new List<ChineseColorNameUnit>();
            ChineseColorNameUnit unit;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                unit = new ChineseColorNameUnit();
                unit.Id = (int)dt.Rows[i]["id"];
                unit.Code = dt.Rows[i]["code"].ToString();
                unit.Name = dt.Rows[i]["name"].ToString();
                unit.Description = dt.Rows[i]["description"].ToString();
                list.Add(unit);
            }
            return list;
        }

        public ChineseColorNameUnit Get(int id)
        {
            string sqlStr = "SELECT * FROM tbl_chinese_color_name WHERE id = @Id";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Id", id)
            };
            DataSet ds = SqlHelper.Query(sqlStr, parameters);
            if (ds.Tables[0].Rows.Count == 0) throw new Exception("資料不存在");
            return ToModel(ds.Tables[0])[0];
        }

        public List<ChineseColorNameUnit> GetList()
        {
            string sqlStr = "SELECT * FROM tbl_chinese_color_name";
            DataSet dt = SqlHelper.Query(sqlStr);
            return ToModel(dt.Tables[0]);
        }

        public void Add(ChineseColorNameUnit unit)
        {
            string sqlStr = "INSERT INTO tbl_chinese_color_name (code, name, description) VALUES (@Code, @Name, @Description)";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Code", unit.Code),
                new NpgsqlParameter("@Name", unit.Name),
                new NpgsqlParameter("@Description", unit.Description ??(object) DBNull.Value)
            };
            SqlHelper.Execute(sqlStr, parameters);
        }

        public void ChangeInfo(ChineseColorNameUnit unit)
        {
            string sqlStr = "UPDATE tbl_chinese_color_name SET code = @Code, name = @Name, description = @Description WHERE id = @Id";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Code", unit.Code),
                new NpgsqlParameter("@Name", unit.Name),
                new NpgsqlParameter("@Description", unit.Description ??(object) DBNull.Value),
                new NpgsqlParameter("@Id", unit.Id)
            };
            SqlHelper.Execute(sqlStr, parameters);
        }

        public void Delete(int id)
        {
            string sqlStr = "DELETE FROM tbl_chinese_color_name WHERE id = @Id";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Id", id)
            };
            SqlHelper.Execute(sqlStr, parameters);
        }

        public bool IsCodeExists(string code, int excludeId = 0)
        {
            string sqlStr = "SELECT COUNT(*) FROM tbl_chinese_color_name WHERE code = @Code AND id != @ExcludeId";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Code", code),
                new NpgsqlParameter("@ExcludeId", excludeId)
            };
            int count = Convert.ToInt32(SqlHelper.ExecuteScalar(sqlStr, parameters));
            return count > 0;
        }
    }
}

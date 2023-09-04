using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using FabricModel;

namespace FabricDAL
{
    public class TubeCategoryServices
    {
        // Convert DataTable to List<TubeCategoryUnit>
        public List<TubeCategoryUnit> ToModel(DataTable dt)
        {
            List<TubeCategoryUnit> list = new List<TubeCategoryUnit>();
            foreach (DataRow row in dt.Rows)
            {
                TubeCategoryUnit unit = new TubeCategoryUnit
                {
                    Id = Convert.ToInt32(row["id"]),
                    Code = row["code"].ToString(),
                    Description = row["description"].ToString(),
                    Tube_weight = Convert.ToSingle(row["tube_weight"]),
                    Tube_price = Convert.ToSingle(row["tube_price"])
                };
                list.Add(unit);
            }
            return list;
        }

        public TubeCategoryUnit Get(int id)
        {
            string sqlStr = "SELECT * FROM tbl_tube_category WHERE id = @Id";
            NpgsqlParameter[] parameters = { new NpgsqlParameter("@Id", id) };
            DataTable dt = SqlHelper.Query(sqlStr, parameters).Tables[0];
            if (dt.Rows.Count == 0) throw new Exception("Tube category does not exist");
            return ToModel(dt)[0];
        }

        public List<TubeCategoryUnit> GetList()
        {
            string sqlStr = "SELECT * FROM tbl_tube_category";
            DataTable dt = SqlHelper.Query(sqlStr).Tables[0];
            return ToModel(dt);
        }

        public void Add(TubeCategoryUnit unit)
        {
            string sqlStr = "INSERT INTO tbl_tube_category (code, description, tube_weight, tube_price) VALUES (@Code, @Description, @Tube_weight, @Tube_price)";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@Code", unit.Code),
                new NpgsqlParameter("@Description", unit.Description),
                new NpgsqlParameter("@Tube_weight", unit.Tube_weight),
                new NpgsqlParameter("@Tube_price", unit.Tube_price)
            };
            SqlHelper.Execute(sqlStr, parameters);
        }

        public void Update(TubeCategoryUnit unit)
        {
            string sqlStr = "UPDATE tbl_tube_category SET code = @Code, description = @Description, tube_weight = @Tube_weight, tube_price = @Tube_price WHERE id = @Id";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@Code", unit.Code),
                new NpgsqlParameter("@Description", unit.Description),
                new NpgsqlParameter("@Tube_weight", unit.Tube_weight),
                new NpgsqlParameter("@Tube_price", unit.Tube_price),
                new NpgsqlParameter("@Id", unit.Id)
            };
            SqlHelper.Execute(sqlStr, parameters);
        }

        public void Delete(int id)
        {
            string sqlStr = "DELETE FROM tbl_tube_category WHERE id = @Id";
            NpgsqlParameter[] parameters = { new NpgsqlParameter("@Id", id) };
            SqlHelper.Execute(sqlStr, parameters);
        }

        public bool IsCodeExists(string code, int excludeId = 0)
        {
            string sqlStr = "SELECT COUNT(*) FROM tbl_tube_category WHERE code = @Code AND id != @ExcludeId";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@Code", code),
                new NpgsqlParameter("@ExcludeId", excludeId)
            };
            int count = Convert.ToInt32(SqlHelper.ExecuteScalar(sqlStr, parameters));
            return count > 0;
        }
    }
}

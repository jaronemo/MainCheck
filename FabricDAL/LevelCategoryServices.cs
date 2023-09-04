using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using FabricModel;

namespace FabricDAL
{
    public class LevelCategoryServices
    {
        // Convert DataTable to List<LevelCategoryUnit>
        private List<LevelCategoryUnit> ToModel(DataTable dt)
        {
            List<LevelCategoryUnit> list = new List<LevelCategoryUnit>();
            foreach (DataRow row in dt.Rows)
            {
                LevelCategoryUnit unit = new LevelCategoryUnit
                {
                    Id = Convert.ToInt32(row["id"]),
                    Code = row["code"].ToString(),
                    Name = row["name"].ToString(),
                    B_level = row["b_level"] == DBNull.Value ? 0 : Convert.ToInt32(row["b_level"]),
                    C_level = row["c_level"] == DBNull.Value ? 0 : Convert.ToInt32(row["c_level"]),
                    Yard = row["yard"].ToString(),
                    DeductionStandard = row["deduction_standard"].ToString()
                };
                list.Add(unit);
            }
            return list;
        }

        public LevelCategoryUnit Get(int id)
        {
            string sqlStr = "SELECT * FROM tbl_level_category WHERE id = @Id";
            NpgsqlParameter[] parameters = { new NpgsqlParameter("@Id", id) };
            DataTable dt = SqlHelper.Query(sqlStr, parameters).Tables[0];
            if (dt.Rows.Count == 0) throw new Exception("Level category does not exist");
            return ToModel(dt)[0];
        }

        public List<LevelCategoryUnit> GetList()
        {
            string sqlStr = "SELECT * FROM tbl_level_category";
            DataTable dt = SqlHelper.Query(sqlStr).Tables[0];
            return ToModel(dt);
        }

        public void Add(LevelCategoryUnit unit)
        {
            string sqlStr = "INSERT INTO tbl_level_category (code, name, b_level, c_level, yard, deduction_standard) VALUES (@Code, @Name, @B_level, @C_level, @Yard, @DeductionStandard)";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@Code", unit.Code),
                new NpgsqlParameter("@Name", unit.Name),
                new NpgsqlParameter("@B_level", unit.B_level == 0 ? (object)DBNull.Value : unit.B_level),
                new NpgsqlParameter("@C_level", unit.C_level == 0 ? (object)DBNull.Value : unit.C_level),
                new NpgsqlParameter("@Yard", unit.Yard),
                new NpgsqlParameter("@DeductionStandard", unit.DeductionStandard)
            };
            SqlHelper.Execute(sqlStr, parameters);
        }

        public void Update(LevelCategoryUnit unit)
        {
            string sqlStr = "UPDATE tbl_level_category SET code = @Code, name = @Name, b_level = @B_level, c_level = @C_level, yard = @Yard, deduction_standard = @DeductionStandard WHERE id = @Id";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@Code", unit.Code),
                new NpgsqlParameter("@Name", unit.Name),
                new NpgsqlParameter("@B_level", unit.B_level == 0 ? (object)DBNull.Value : unit.B_level),
                new NpgsqlParameter("@C_level", unit.C_level == 0 ? (object)DBNull.Value : unit.C_level),
                new NpgsqlParameter("@Yard", unit.Yard),
                new NpgsqlParameter("@DeductionStandard", unit.DeductionStandard),
                new NpgsqlParameter("@Id", unit.Id)
            };
            SqlHelper.Execute(sqlStr, parameters);
        }

        public void Delete(int id)
        {
            string sqlStr = "DELETE FROM tbl_level_category WHERE id = @Id";
            NpgsqlParameter[] parameters = { new NpgsqlParameter("@Id", id) };
            SqlHelper.Execute(sqlStr, parameters);
        }

        public bool IsCodeExists(string code, int excludeId = 0)
        {
            string sqlStr = "SELECT COUNT(*) FROM tbl_level_category WHERE code = @Code AND id != @ExcludeId";
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

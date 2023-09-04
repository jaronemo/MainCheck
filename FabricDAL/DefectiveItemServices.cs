using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using FabricModel;

namespace FabricDAL
{
    public class DefectiveItemServices
    {
        public DefectiveItemUnit ToModel(DataRow row)
        {
            DefectiveItemUnit unit = new DefectiveItemUnit();
            unit.Id = (int)row["id"];
            unit.Name = row["name"].ToString();
            unit.Eng_name = row["eng_name"].ToString();
            unit.Type = row["type"].ToString();
            unit.Code = row["code"].ToString();
            return unit;
        }

        public List<DefectiveItemUnit> ToModel(DataTable dt)
        {
            List<DefectiveItemUnit> list = new List<DefectiveItemUnit>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(ToModel(row));
            }
            return list;
        }

        public DefectiveItemUnit Get(int id)
        {
            string sqlStr = "SELECT * FROM tbl_defective_item WHERE id = @Id";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Id", id)
            };
            DataSet ds = SqlHelper.Query(sqlStr, parameters);
            if (ds.Tables[0].Rows.Count == 0) throw new Exception("該項目不存在");
            return ToModel(ds.Tables[0].Rows[0]);
        }

        public List<DefectiveItemUnit> GetList()
        {
            string sqlStr = "SELECT * FROM tbl_defective_item";
            DataSet ds = SqlHelper.Query(sqlStr);
            return ToModel(ds.Tables[0]);
        }

        public void Add(DefectiveItemUnit unit)
        {
            string sqlStr = "INSERT INTO tbl_defective_item (name, eng_name, type, code) VALUES (@Name, @EngName, @Type, @Code)";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Name", unit.Name),
                new NpgsqlParameter("@EngName", unit.Eng_name),
                new NpgsqlParameter("@Type", unit.Type),
                new NpgsqlParameter("@Code", unit.Code)
            };
            SqlHelper.Execute(sqlStr, parameters);
        }

        public void ChangeInfo(DefectiveItemUnit unit)
        {
            string sqlStr = "UPDATE tbl_defective_item SET name = @Name, eng_name = @EngName, type = @Type, code = @Code WHERE id = @Id";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Name", unit.Name),
                new NpgsqlParameter("@EngName", unit.Eng_name),
                new NpgsqlParameter("@Type", unit.Type),
                new NpgsqlParameter("@Code", unit.Code),
                new NpgsqlParameter("@Id", unit.Id)
            };
            SqlHelper.Execute(sqlStr, parameters);
        }

        public void Delete(int id)
        {
            string sqlStr = "DELETE FROM tbl_defective_item WHERE id = @Id";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Id", id)
            };
            SqlHelper.Execute(sqlStr, parameters);
        }

        public bool IsNameExists(string name, int excludeId = 0)
        {
            string sqlStr = "SELECT COUNT(*) FROM tbl_defective_item WHERE name = @Name AND id != @ExcludeId";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Name", name),
                new NpgsqlParameter("@ExcludeId", excludeId)
            };
            int count = Convert.ToInt32(SqlHelper.ExecuteScalar(sqlStr, parameters));
            return count > 0;
        }

        public bool IsCodeExists(string code, int excludeId = 0)
        {
            string sqlStr = "SELECT COUNT(*) FROM tbl_defective_item WHERE code = @Code AND id != @ExcludeId";
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

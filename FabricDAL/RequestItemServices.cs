using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using FabricModel;

namespace FabricDAL
{
    public class RequestItemServices
    {
        public List<RequestItemUnit> ToModel(DataTable dt)
        {
            List<RequestItemUnit> list = new List<RequestItemUnit>();
            foreach (DataRow row in dt.Rows)
            {
                RequestItemUnit unit = new RequestItemUnit
                {
                    Id = Convert.ToInt32(row["id"]),
                    Code = row["code"].ToString(),
                    Name = row["name"].ToString(),
                    Color = row["color"].ToString(),
                    Merge = row["merge"].ToString()
                };
                list.Add(unit);
            }
            return list;
        }

        public RequestItemUnit Get(int id)
        {
            string sqlStr = "SELECT * FROM tbl_request_item WHERE id = @Id";
            NpgsqlParameter[] parameters = { new NpgsqlParameter("@Id", id) };
            DataTable dt = SqlHelper.Query(sqlStr, parameters).Tables[0];
            if (dt.Rows.Count == 0) throw new Exception("請求項目不存在");
            return ToModel(dt)[0];
        }

        public List<RequestItemUnit> GetList()
        {
            string sqlStr = "SELECT * FROM tbl_request_item";
            DataTable dt = SqlHelper.Query(sqlStr).Tables[0];
            return ToModel(dt);
        }

        public void Add(RequestItemUnit unit)
        {
            string sqlStr = "INSERT INTO tbl_request_item (code, name, merge, color) VALUES (@Code, @Name, @Merge, @Color)";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@Code", unit.Code),
                new NpgsqlParameter("@Name", unit.Name),
                new NpgsqlParameter("@Merge", unit.Merge),
                new NpgsqlParameter("@Color", unit.Color)
            };
            SqlHelper.Execute(sqlStr, parameters);
        }

        public void Update(RequestItemUnit unit)
        {
            string sqlStr = "UPDATE tbl_request_item SET code = @Code, name = @Name, merge = @Merge, color=@Color WHERE id = @Id";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@Code", unit.Code),
                new NpgsqlParameter("@Name", unit.Name),
                new NpgsqlParameter("@Merge", unit.Merge),
                new NpgsqlParameter("@Color", unit.Color),
                new NpgsqlParameter("@Id", unit.Id)
            };
            SqlHelper.Execute(sqlStr, parameters);
        }

        public void Delete(int id)
        {
            string sqlStr = "DELETE FROM tbl_request_item WHERE id = @Id";
            NpgsqlParameter[] parameters = { new NpgsqlParameter("@Id", id) };
            SqlHelper.Execute(sqlStr, parameters);
        }

        public bool IsCodeExists(string code, int excludeId = 0)
        {
            string sqlStr = "SELECT COUNT(*) FROM tbl_request_item WHERE code = @Code AND id != @ExcludeId";
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

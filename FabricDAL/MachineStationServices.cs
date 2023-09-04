using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using FabricModel;

namespace FabricDAL
{
    public class MachineStationServices
    {
        // Convert DataTable to List<MachineStationUnit>
        public List<MachineStationUnit> ToModel(DataTable dt)
        {
            List<MachineStationUnit> list = new List<MachineStationUnit>();
            foreach (DataRow row in dt.Rows)
            {
                MachineStationUnit unit = new MachineStationUnit
                {
                    Id = Convert.ToInt32(row["id"]),
                    Code = row["code"].ToString(),
                    Name = row["name"].ToString(),
                    Station = row["station"].ToString()
                };
                list.Add(unit);
            }
            return list;
        }

        public MachineStationUnit Get(int id)
        {
            string sqlStr = "SELECT * FROM tbl_machine_station WHERE id = @Id";
            NpgsqlParameter[] parameters = { new NpgsqlParameter("@Id", id) };
            DataTable dt = SqlHelper.Query(sqlStr, parameters).Tables[0];
            if (dt.Rows.Count == 0) throw new Exception("機台站別不存在");
            return ToModel(dt)[0];
        }

        public List<MachineStationUnit> GetList()
        {
            string sqlStr = "SELECT * FROM tbl_machine_station";
            DataTable dt = SqlHelper.Query(sqlStr).Tables[0];
            return ToModel(dt);
        }

        public void Add(MachineStationUnit unit)
        {
            string sqlStr = "INSERT INTO tbl_machine_station (code, name, station) VALUES (@Code, @Name, @Station)";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@Code", unit.Code),
                new NpgsqlParameter("@Name", unit.Name),
                new NpgsqlParameter("@Station", unit.Station ??(object) DBNull.Value)
            };
            SqlHelper.Execute(sqlStr, parameters);
        }

        public void Update(MachineStationUnit unit)
        {
            string sqlStr = "UPDATE tbl_machine_station SET code = @Code, name = @Name, station = @Station WHERE id = @Id";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@Code", unit.Code),
                new NpgsqlParameter("@Name", unit.Name),
                new NpgsqlParameter("@Station",  unit.Station ??(object) DBNull.Value),
                new NpgsqlParameter("@Id", unit.Id)
            };
            SqlHelper.Execute(sqlStr, parameters);
        }

        public void Delete(int id)
        {
            string sqlStr = "DELETE FROM tbl_machine_station WHERE id = @Id";
            NpgsqlParameter[] parameters = { new NpgsqlParameter("@Id", id) };
            SqlHelper.Execute(sqlStr, parameters);
        }

        public bool IsCodeExists(string code, int excludeId = 0)
        {
            string sqlStr = "SELECT COUNT(*) FROM tbl_machine_station WHERE code = @Code AND id != @ExcludeId";
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

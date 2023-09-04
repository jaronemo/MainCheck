using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using FabricModel;

namespace FabricDAL
{
    public class PickingLabelServices
    {
        /*public PickingLabelUnit ToModel(DataRow row)
        {
            PickingLabelUnit unit = new PickingLabelUnit();
            unit.Id = (int)row["id"];
            unit.Code = row["code"].ToString();
            unit.Name = row["name"].ToString();
            unit.Length_inch = (float)row["length_inch"];
            unit.Length_mm = (int)row["length_mm"];
            unit.Length_pix = (int)row["length_pix"];
            unit.Width_inch = (float)row["width_inch"];
            unit.Width_mm = (int)row["width_mm"];
            unit.Width_pix = (int)row["width_pix"];
            unit.Filename = row["filename"].ToString();
            unit.Backpicture = row["backpicture"].ToString();
            return unit;
        }*/
        public PickingLabelUnit ToModel(DataRow row)
        {
            PickingLabelUnit unit = new PickingLabelUnit();
            unit.Id = Convert.ToInt32(row["id"]);
            unit.Code = row["code"].ToString();
            unit.Name = row["name"].ToString();

            if (row["length_inch"] != DBNull.Value)
                unit.Length_inch = Convert.ToSingle(row["length_inch"]);
            else
                unit.Length_inch = null;

            if (row["length_mm"] != DBNull.Value)
                unit.Length_mm = Convert.ToInt32(row["length_mm"]);
            else
                unit.Length_mm = null;

            if (row["length_pix"] != DBNull.Value)
                unit.Length_pix = Convert.ToInt32(row["length_pix"]);
            else
                unit.Length_pix = null;

            if (row["width_inch"] != DBNull.Value)
                unit.Width_inch = Convert.ToSingle(row["width_inch"]);
            else
                unit.Width_inch = null;

            if (row["width_mm"] != DBNull.Value)
                unit.Width_mm = Convert.ToInt32(row["width_mm"]);
            else
                unit.Width_mm = null;

            if (row["width_pix"] != DBNull.Value)
                unit.Width_pix = Convert.ToInt32(row["width_pix"]);
            else
                unit.Width_pix = null;

            unit.Filename = row["filename"].ToString();
            unit.Backpicture = row["backpicture"].ToString();

            return unit;
        }

        public PickingLabelUnit Get(int id)
        {
            string sqlStr = "SELECT * FROM tbl_picking_label WHERE id = @Id";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Id", id)
            };
            DataSet ds = SqlHelper.Query(sqlStr, parameters);
            if (ds.Tables[0].Rows.Count == 0) throw new Exception("標籤不存在");
            return ToModel(ds.Tables[0].Rows[0]);
        }

        public List<PickingLabelUnit> GetList()
        {
            string sqlStr = "SELECT * FROM tbl_picking_label";
            DataSet ds = SqlHelper.Query(sqlStr);
            List<PickingLabelUnit> list = new List<PickingLabelUnit>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(ToModel(row));
            }
            return list;
        }
        private void EnsureNonNullValues(PickingLabelUnit unit)
        {
            unit.Length_inch = unit.Length_inch ?? 0;
            unit.Length_mm = unit.Length_mm ?? 0;
            unit.Length_pix = unit.Length_pix ?? 0;
            unit.Width_inch = unit.Width_inch ?? 0;
            unit.Width_mm = unit.Width_mm ?? 0;
            unit.Width_pix = unit.Width_pix ?? 0;
        }
        public void Add(PickingLabelUnit unit)
        {
            EnsureNonNullValues(unit);
            string sqlStr = "INSERT INTO tbl_picking_label (code, name, length_inch, length_mm, length_pix, width_inch, width_mm, width_pix, filename, backpicture) VALUES (@Code, @Name, @LengthInch, @LengthMM, @LengthPix, @WidthInch, @WidthMM, @WidthPix, @Filename, @Backpicture)";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Code", unit.Code),
                new NpgsqlParameter("@Name", unit.Name),
                new NpgsqlParameter("@LengthInch", unit.Length_inch),
                new NpgsqlParameter("@LengthMM", unit.Length_mm),
                new NpgsqlParameter("@LengthPix", unit.Length_pix),
                new NpgsqlParameter("@WidthInch", unit.Width_inch),
                new NpgsqlParameter("@WidthMM", unit.Width_mm),
                new NpgsqlParameter("@WidthPix", unit.Width_pix),
               new NpgsqlParameter("@Filename", string.IsNullOrEmpty(unit.Filename) ? (object)DBNull.Value : unit.Filename),
new NpgsqlParameter("@Backpicture", string.IsNullOrEmpty(unit.Backpicture) ? (object)DBNull.Value : unit.Backpicture)
            };
            SqlHelper.Execute(sqlStr, parameters);
        }

        public void ChangeInfo(PickingLabelUnit unit)
        {
            EnsureNonNullValues(unit);
            string sqlStr = "UPDATE tbl_picking_label SET code = @Code, name = @Name, length_inch = @LengthInch, length_mm = @LengthMM, length_pix = @LengthPix, width_inch = @WidthInch, width_mm = @WidthMM, width_pix = @WidthPix, filename = @Filename, backpicture = @Backpicture WHERE id = @Id";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Code", unit.Code),
                new NpgsqlParameter("@Name", unit.Name),
                new NpgsqlParameter("@LengthInch", unit.Length_inch),
                new NpgsqlParameter("@LengthMM", unit.Length_mm),
                new NpgsqlParameter("@LengthPix", unit.Length_pix),
                new NpgsqlParameter("@WidthInch", unit.Width_inch),
                new NpgsqlParameter("@WidthMM", unit.Width_mm),
                new NpgsqlParameter("@WidthPix", unit.Width_pix),
               new NpgsqlParameter("@Filename", string.IsNullOrEmpty(unit.Filename) ? (object)DBNull.Value : unit.Filename),
new NpgsqlParameter("@Backpicture", string.IsNullOrEmpty(unit.Backpicture) ? (object)DBNull.Value : unit.Backpicture),
                new NpgsqlParameter("@Id", unit.Id)
            };
            SqlHelper.Execute(sqlStr, parameters);
        }

        public void Delete(int id)
        {
            string sqlStr = "DELETE FROM tbl_picking_label WHERE id = @Id";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Id", id)
            };
            SqlHelper.Execute(sqlStr, parameters);
        }

        public bool IsCodeExists(string code, int excludeId = 0)
        {
            string sqlStr = "SELECT COUNT(*) FROM tbl_picking_label WHERE code = @Code AND id != @ExcludeId";
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

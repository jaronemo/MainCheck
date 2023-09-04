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
    public class ProductBasicInfoServices
    {
        //由DataTable获取List
        public List<ProductBasicInfoUnit> ToModel(DataTable dt)
        {
            List<ProductBasicInfoUnit> list = new List<ProductBasicInfoUnit>();
            ProductBasicInfoUnit pd;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                pd = new ProductBasicInfoUnit();
                pd.No = (int)dt.Rows[i]["p_no"];
                pd.Code = dt.Rows[i]["p_code"].ToString();
                pd.Name = dt.Rows[i]["p_name"].ToString();                
                if (dt.Rows[i]["p_cloth_id"] != DBNull.Value)
                {
                    pd.Cloth_id = (int)dt.Rows[i]["p_cloth_id"];
                }
                else
                {
                    pd.Cloth_id = null; // 或者設定為其他預設值，如 -1
                }
                list.Add(pd);
            }
            return list;
        }            

        public ProductBasicInfoUnit Get(int no)
        {
            string sqlStr = "SELECT * FROM tbl_product_basic_info WHERE p_no = @No";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@No", no)
            };
            DataSet ds = SqlHelper.Query(sqlStr, parameters);
            if (ds.Tables[0].Rows.Count == 0) throw new Exception("往來單位不存在");
            return ToModel(ds.Tables[0])[0];
        }

        public List<ProductBasicInfoUnit> GetList()
        {
            string sqlStr = "SELECT * FROM tbl_product_basic_info";

            DataSet dt = SqlHelper.Query(sqlStr);

            return ToModel(dt.Tables[0]);
        }


        public void Add(ProductBasicInfoUnit pd)
        {
            string sqlStr = "INSERT INTO tbl_product_basic_info ( p_code, p_name, p_cloth_id) VALUES (@Code, @Name, @Cloth)";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Code", pd.Code),
                new NpgsqlParameter("@Name", pd.Name),
                new NpgsqlParameter("@Cloth",  pd.Cloth_id.HasValue ? (object)pd.Cloth_id.Value : DBNull.Value),
            };

            SqlHelper.Execute(sqlStr, parameters);
        }

        public void ChangeInfo(ProductBasicInfoUnit pd)
        {
            string sqlStr = "UPDATE tbl_product_basic_info SET p_code = @Code, p_name= @Name, p_cloth_id = @Cloth WHERE p_no = @No";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Code", pd.Code),
                new NpgsqlParameter("@Name", pd.Name),
                new NpgsqlParameter("@Cloth", pd.Cloth_id.HasValue ? (object)pd.Cloth_id.Value : DBNull.Value),
                new NpgsqlParameter("@No", pd.No)
            };

            SqlHelper.Execute(sqlStr, parameters);
        }

        public void Delete(int No)
        {
            string sqlStr = "DELETE FROM tbl_product_basic_info WHERE p_no = @No";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
        new NpgsqlParameter("@No", No)
            };

            SqlHelper.Execute(sqlStr, parameters);
        }

        public bool IsCodeExists(string code, int excludeId = 0)
        {
            string sqlStr = "SELECT COUNT(*) FROM tbl_product_basic_info WHERE p_code = @Code AND p_no != @ExcludeId";
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

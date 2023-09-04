using FabricModel;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FabricDAL
{
    public class SaleOrderDetailServices
    {
        // 由DataTable获取List
        public List<SaleOrderDetailUnit> ToModel(DataTable dt)
        {
            List<SaleOrderDetailUnit> list = new List<SaleOrderDetailUnit>();
            SaleOrderDetailUnit saleOrderDetail;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    saleOrderDetail = new SaleOrderDetailUnit
                    {
                        NO = Convert.ToInt32(dt.Rows[i]["NO"]),
                        ProductID = Convert.ToInt32(dt.Rows[i]["ProductID"]),
                        Width = dt.Rows[i]["Width"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[i]["Width"]) : 0m,
                        Weight = dt.Rows[i]["Weight"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[i]["Weight"]) : 0m,
                        GSM = dt.Rows[i]["GSM"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[i]["GSM"]) : 0m,
                        OrderQuantity = dt.Rows[i]["OrderQuantity"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[i]["OrderQuantity"]) : 0m,
                        InputQuantity = dt.Rows[i]["InputQuantity"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[i]["InputQuantity"]) : 0m,
                        FinishedQuantity = dt.Rows[i]["FinishedQuantity"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[i]["FinishedQuantity"]) : 0m,
                        ShippedQuantity = dt.Rows[i]["ShippedQuantity"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[i]["ShippedQuantity"]) : 0m,
                        TransferQuantity = dt.Rows[i]["TransferQuantity"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[i]["TransferQuantity"]) : 0m,
                        ReturnedQuantity = dt.Rows[i]["ReturnedQuantity"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[i]["ReturnedQuantity"]) : 0m,
                        Inventory = dt.Rows[i]["Inventory"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[i]["Inventory"]) : 0m,
                        Grade = dt.Rows[i]["Grade"].ToString(),
                        SaleOrderID = Convert.ToInt32(dt.Rows[i]["SaleOrderID"]),
                    };
                    list.Add(saleOrderDetail);
                }
                catch (InvalidCastException ex)
                {
                    MessageBox.Show($"轉換異常在行{i}：{ex.Message}");
                }

            }
            return list;
        }

        public SaleOrderDetailUnit Get(int no)
        {
            string sqlStr = "SELECT * FROM tbl_sales_detail WHERE NO = @NO";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@NO", no)
            };
            DataSet ds = SqlHelper.Query(sqlStr, parameters);
            if (ds.Tables[0].Rows.Count == 0) throw new Exception("查無此銷售明細行");
            return ToModel(ds.Tables[0])[0];
        }

        public List<SaleOrderDetailUnit> GetList()
        {
            string sqlStr = "SELECT * FROM tbl_sales_detail";
            DataSet dt = SqlHelper.Query(sqlStr);
            return ToModel(dt.Tables[0]);
        }

        public void Add(SaleOrderDetailUnit saleOrderDetail)
        {
            string sqlStr = "INSERT INTO tbl_sales_detail (ProductID, Width, Weight, GSM, OrderQuantity, InputQuantity, FinishedQuantity, ShippedQuantity, TransferQuantity, ReturnedQuantity, Inventory, Grade, SaleOrderID) VALUES (@ProductID, @Width, @Weight, @GSM, @OrderQuantity, @InputQuantity, @FinishedQuantity, @ShippedQuantity, @TransferQuantity, @ReturnedQuantity, @Inventory, @Grade, @SaleOrderID)";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@ProductID", saleOrderDetail.ProductID),
                new NpgsqlParameter("@Width", saleOrderDetail.Width),
                new NpgsqlParameter("@Weight", saleOrderDetail.Weight),
                new NpgsqlParameter("@GSM", saleOrderDetail.GSM),
                new NpgsqlParameter("@OrderQuantity", saleOrderDetail.OrderQuantity),
                new NpgsqlParameter("@InputQuantity", saleOrderDetail.InputQuantity),
                new NpgsqlParameter("@FinishedQuantity", saleOrderDetail.FinishedQuantity),
                new NpgsqlParameter("@ShippedQuantity", saleOrderDetail.ShippedQuantity),
                new NpgsqlParameter("@TransferQuantity", saleOrderDetail.TransferQuantity),
                new NpgsqlParameter("@ReturnedQuantity", saleOrderDetail.ReturnedQuantity),
                new NpgsqlParameter("@Inventory", saleOrderDetail.Inventory),
                new NpgsqlParameter("@Grade", saleOrderDetail.Grade),
                new NpgsqlParameter("@SaleOrderID", saleOrderDetail.SaleOrderID)
            };

            SqlHelper.Execute(sqlStr, parameters);
        }

        public void ChangeInfo(SaleOrderDetailUnit saleOrderDetail)
        {
            string sqlStr = "UPDATE tbl_sales_detail SET ProductID = @ProductID, Width = @Width, Weight = @Weight, GSM = @GSM, OrderQuantity = @OrderQuantity, InputQuantity = @InputQuantity, FinishedQuantity = @FinishedQuantity, ShippedQuantity = @ShippedQuantity, TransferQuantity = @TransferQuantity, ReturnedQuantity = @ReturnedQuantity, Inventory = @Inventory, Grade = @Grade, SaleOrderID = @SaleOrderID WHERE NO = @NO";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@ProductID", saleOrderDetail.ProductID),
                new NpgsqlParameter("@Width", saleOrderDetail.Width),
                new NpgsqlParameter("@Weight", saleOrderDetail.Weight),
                new NpgsqlParameter("@GSM", saleOrderDetail.GSM),
                new NpgsqlParameter("@OrderQuantity", saleOrderDetail.OrderQuantity),
                new NpgsqlParameter("@InputQuantity", saleOrderDetail.InputQuantity),
                new NpgsqlParameter("@FinishedQuantity", saleOrderDetail.FinishedQuantity),
                new NpgsqlParameter("@ShippedQuantity", saleOrderDetail.ShippedQuantity),
                new NpgsqlParameter("@TransferQuantity", saleOrderDetail.TransferQuantity),
                new NpgsqlParameter("@ReturnedQuantity", saleOrderDetail.ReturnedQuantity),
                new NpgsqlParameter("@Inventory", saleOrderDetail.Inventory),
                new NpgsqlParameter("@Grade", saleOrderDetail.Grade),
                new NpgsqlParameter("@SaleOrderID", saleOrderDetail.SaleOrderID),
                new NpgsqlParameter("@NO", saleOrderDetail.NO)
            };

            SqlHelper.Execute(sqlStr, parameters);
        }

        public void Delete(int no)
        {
            string sqlStr = "DELETE FROM tbl_sales_detail WHERE NO = @NO";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@NO", no)
            };

            SqlHelper.Execute(sqlStr, parameters);
        }

        public List<SaleOrderDetailUnit> GetListByOrderId(int orderId)
        {
            string sqlStr = "SELECT * FROM tbl_sales_detail WHERE SaleOrderID = @OrderId";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
            new NpgsqlParameter("@OrderId", orderId)
            };
            DataSet ds = SqlHelper.Query(sqlStr, parameters);
            return ToModel(ds.Tables[0]);
        }
    }
}

using FabricModel;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace FabricDAL
{
    public class DetailLinesDataServices
    {
        private List<DetailLinesData> ToModel(DataTable dt)
        {
            List<DetailLinesData> list = new List<DetailLinesData>();
            foreach (DataRow row in dt.Rows)
            {
                DetailLinesData detail = new DetailLinesData
                {
                    DetailId = Convert.ToInt32(row["detail_id"]),
                    OrderId = Convert.ToInt32(row["order_id"]),
                    SaleDetailId = Convert.ToInt32(row["sale_detail_id"]),
                    ProductId = Convert.ToInt32(row["product_id"]),
                    ColorId = Convert.ToInt32(row["color_id"]),
                    ColorCode = row["color_code"].ToString(),
                    ColorName = row["color_name"].ToString(),
                    ColorDescription = row["color_description"].ToString(),
                    ColorNameEn = row["color_name_en"].ToString(),
                    ColorNumber = row["color_number"].ToString(),
                    OrderQuantity = Convert.ToDecimal(row["order_quantity"]),
                    Unit = row["unit"].ToString(),
                    ExportCount = Convert.ToDecimal(row["export_count"]),
                    UnitPrice = Convert.ToDecimal(row["unit_price"]),
                    IncomingQuantity = Convert.ToDecimal(row["incoming_quantity"]),
                    FinishedQuantity = Convert.ToDecimal(row["finished_quantity"]),
                    ShippedQuantity = Convert.ToDecimal(row["shipped_quantity"]),
                    TransferQuantity = Convert.ToDecimal(row["transfer_quantity"]),
                    ReturnedQuantity = Convert.ToDecimal(row["returned_quantity"])
                };
                list.Add(detail);
            }
            return list;
        }

        public DetailLinesData Get(int detailId)
        {
            string sqlStr = "SELECT * FROM tbl_detail_lines_data WHERE detail_id = @DetailId";
            NpgsqlParameter[] parameters = { new NpgsqlParameter("@DetailId", detailId) };
            DataSet ds = SqlHelper.Query(sqlStr, parameters);
            if (ds.Tables[0].Rows.Count == 0) throw new Exception("查無此明細行");
            return ToModel(ds.Tables[0])[0];
        }

        public List<DetailLinesData> GetList()
        {
            string sqlStr = "SELECT * FROM tbl_detail_lines_data";
            DataSet dt = SqlHelper.Query(sqlStr);
            return ToModel(dt.Tables[0]);
        }

        public List<DetailLinesData> GetListByOrderId(int orderId)
        {
            string sqlStr = "SELECT * FROM tbl_detail_lines_data WHERE order_id = @OrderId";
            NpgsqlParameter[] parameters = { new NpgsqlParameter("@OrderId", orderId) };
            DataSet ds = SqlHelper.Query(sqlStr, parameters);
            return ToModel(ds.Tables[0]);
        }

        public void Add(DetailLinesData detailLinesData)
        {
            string sqlStr = @"INSERT INTO tbl_detail_lines_data (order_id, sale_detail_id, product_id, color_id, color_code, color_name, color_description, color_name_en, color_number, order_quantity, unit, export_count, unit_price, incoming_quantity, finished_quantity, shipped_quantity, transfer_quantity, returned_quantity) 
                      VALUES (@OrderId, @SaleDetailId, @ProductId, @ColorId, @ColorCode, @ColorName, @ColorDescription, @ColorNameEn, @ColorNumber, @OrderQuantity, @Unit, @ExportCount, @UnitPrice, @IncomingQuantity, @FinishedQuantity, @ShippedQuantity, @TransferQuantity, @ReturnedQuantity)";
            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("@OrderId", detailLinesData.OrderId),
                new NpgsqlParameter("@SaleDetailId", detailLinesData.SaleDetailId),
                new NpgsqlParameter("@ProductId", detailLinesData.ProductId),
                new NpgsqlParameter("@ColorId", detailLinesData.ColorId),
                new NpgsqlParameter("@ColorCode", detailLinesData.ColorCode),
                new NpgsqlParameter("@ColorName", detailLinesData.ColorName),
                new NpgsqlParameter("@ColorDescription", detailLinesData.ColorDescription),
                new NpgsqlParameter("@ColorNameEn", detailLinesData.ColorNameEn),
                new NpgsqlParameter("@ColorNumber", detailLinesData.ColorNumber),
                new NpgsqlParameter("@OrderQuantity", detailLinesData.OrderQuantity),
                new NpgsqlParameter("@Unit", detailLinesData.Unit),
                new NpgsqlParameter("@ExportCount", detailLinesData.ExportCount),
                new NpgsqlParameter("@UnitPrice", detailLinesData.UnitPrice),
                new NpgsqlParameter("@IncomingQuantity", detailLinesData.IncomingQuantity),
                new NpgsqlParameter("@FinishedQuantity", detailLinesData.FinishedQuantity),
                new NpgsqlParameter("@ShippedQuantity", detailLinesData.ShippedQuantity),
                new NpgsqlParameter("@TransferQuantity", detailLinesData.TransferQuantity),
                new NpgsqlParameter("@ReturnedQuantity", detailLinesData.ReturnedQuantity)
            };

            SqlHelper.Execute(sqlStr, parameters);
        }

        public void Update(DetailLinesData detailLinesData)
        {
            string sqlStr = @"UPDATE tbl_detail_lines_data 
                      SET order_id = @OrderId, sale_detail_id = @SaleDetailId, product_id = @ProductId, color_id = @ColorId, color_code = @ColorCode, color_name = @ColorName, color_description = @ColorDescription, color_name_en = @ColorNameEn, color_number = @ColorNumber, order_quantity = @OrderQuantity, unit = @Unit, export_count = @ExportCount, unit_price = @UnitPrice, incoming_quantity = @IncomingQuantity, finished_quantity = @FinishedQuantity, shipped_quantity = @ShippedQuantity, transfer_quantity = @TransferQuantity, returned_quantity = @ReturnedQuantity 
                      WHERE detail_id = @DetailId";
            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("@OrderId", detailLinesData.OrderId),
                new NpgsqlParameter("@SaleDetailId", detailLinesData.SaleDetailId),
                new NpgsqlParameter("@ProductId", detailLinesData.ProductId),
                new NpgsqlParameter("@ColorId", detailLinesData.ColorId),
                new NpgsqlParameter("@ColorCode", detailLinesData.ColorCode),
                new NpgsqlParameter("@ColorName", detailLinesData.ColorName),
                new NpgsqlParameter("@ColorDescription", detailLinesData.ColorDescription),
                new NpgsqlParameter("@ColorNameEn", detailLinesData.ColorNameEn),
                new NpgsqlParameter("@ColorNumber", detailLinesData.ColorNumber),
                new NpgsqlParameter("@OrderQuantity", detailLinesData.OrderQuantity),
                new NpgsqlParameter("@Unit", detailLinesData.Unit),
                new NpgsqlParameter("@ExportCount", detailLinesData.ExportCount),
                new NpgsqlParameter("@UnitPrice", detailLinesData.UnitPrice),
                new NpgsqlParameter("@IncomingQuantity", detailLinesData.IncomingQuantity),
                new NpgsqlParameter("@FinishedQuantity", detailLinesData.FinishedQuantity),
                new NpgsqlParameter("@ShippedQuantity", detailLinesData.ShippedQuantity),
                new NpgsqlParameter("@TransferQuantity", detailLinesData.TransferQuantity),
                new NpgsqlParameter("@ReturnedQuantity", detailLinesData.ReturnedQuantity),
                new NpgsqlParameter("@DetailId", detailLinesData.DetailId)
            };

            SqlHelper.Execute(sqlStr, parameters);
        }


        public void Delete(int detailId)
        {
            string sqlStr = "DELETE FROM tbl_detail_lines_data WHERE detail_id = @DetailId";
            NpgsqlParameter[] parameters = { new NpgsqlParameter("@DetailId", detailId) };
            SqlHelper.Execute(sqlStr, parameters);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using FabricModel;

namespace FabricDAL
{
    public class SaleOrderServices
    {
        // Convert DataTable to SaleOrderUnit       
        public List<SaleOrderUnit> ToModel(DataTable dt)
        {
            List<SaleOrderUnit> list = new List<SaleOrderUnit>();
            SaleOrderUnit saleOrder;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                saleOrder = new SaleOrderUnit
                {
                    OrderId = (int)dt.Rows[i]["Order_ID"],
                    OrderDate = (DateTime)dt.Rows[i]["Order_Date"],
                    DeliveryDate = (DateTime)dt.Rows[i]["Delivery_Date"],
                    Season = dt.Rows[i]["Season"].ToString(),
                    CustomerId = (int)dt.Rows[i]["Customer_Id"],
                    DeliveryTo = dt.Rows[i]["Delivery_To"].ToString(),
                    DeliveryLocation = dt.Rows[i]["Delivery_Location"].ToString(),
                    OriginLocation = dt.Rows[i]["Origin_Location"].ToString(),
                    CustomerOrder = dt.Rows[i]["Customer_Order"].ToString(),
                    OrderBuyer = dt.Rows[i]["Order_Buyer"].ToString(),
                    PoNumber = dt.Rows[i]["Po_Number"].ToString(),
                    Inspection_id = dt.Rows[i]["Inspection_id"] != DBNull.Value ? (int)dt.Rows[i]["Inspection_id"] : default(int?),
                    Label_id = dt.Rows[i]["Label_id"] != DBNull.Value ? (int)dt.Rows[i]["Label_id"] : default(int?),
                    OrderName = dt.Rows[i]["Order_Name"].ToString()
                };
                list.Add(saleOrder);
            }
            return list;
        }


        public SaleOrderUnit Get(int orderId)
        {
            string sqlStr = "SELECT * FROM tbl_sale_order WHERE order_id = @OrderId";
            NpgsqlParameter[] parameters = { new NpgsqlParameter("@OrderId", orderId) };
            DataSet dt = SqlHelper.Query(sqlStr, parameters);
            if (dt.Tables[0].Rows.Count == 0) throw new Exception("查無此訂單");
            return ToModel(dt.Tables[0])[0];
        }

        public List<SaleOrderUnit> GetList()
        {
            string sqlStr = "SELECT * FROM tbl_sale_order";
            DataSet dt = SqlHelper.Query(sqlStr);
            return ToModel(dt.Tables[0]);
        }

        public int Add(SaleOrderUnit unit)
        {
            string sqlStr = @"INSERT INTO tbl_sale_order (order_name, order_date, delivery_date, season, customer_id, 
                              delivery_to, delivery_location, origin_location, customer_order, order_buyer, po_number, 
                              inspection_id, label_id) 
                              VALUES (@OrderName, @OrderDate, @DeliveryDate, @Season, @CustomerId, @DeliveryTo, 
                              @DeliveryLocation, @OriginLocation, @CustomerOrder, @OrderBuyer, @PoNumber, 
                              @InspectionItem, @Label) RETURNING order_id";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@OrderName", unit.OrderName),
                new NpgsqlParameter("@OrderDate", unit.OrderDate),
                new NpgsqlParameter("@DeliveryDate", unit.DeliveryDate),
                new NpgsqlParameter("@Season", unit.Season ?? (object)DBNull.Value),
                new NpgsqlParameter("@CustomerId", unit.CustomerId),
                new NpgsqlParameter("@DeliveryTo", unit.DeliveryTo ?? (object)DBNull.Value),
                new NpgsqlParameter("@DeliveryLocation", unit.DeliveryLocation ?? (object)DBNull.Value),
                new NpgsqlParameter("@OriginLocation", unit.OriginLocation ?? (object)DBNull.Value),
                new NpgsqlParameter("@CustomerOrder", unit.CustomerOrder ?? (object)DBNull.Value),
                new NpgsqlParameter("@OrderBuyer", unit.OrderBuyer ?? (object)DBNull.Value),
                new NpgsqlParameter("@PoNumber", unit.PoNumber ?? (object)DBNull.Value),
                new NpgsqlParameter("@InspectionItem", unit.Inspection_id > 0 ? (object)unit.Inspection_id : DBNull.Value),
                new NpgsqlParameter("@Label", unit.Label_id > 0 ? (object)unit.Label_id : DBNull.Value)
            };
            /*SqlHelper.Execute(sqlStr, parameters);*/
            object result = SqlHelper.ExecuteScalar(sqlStr, parameters);
            if (result != null && int.TryParse(result.ToString(), out int newOrderId))
            {
                return newOrderId;
            }
            else
            {
                throw new Exception("無法取得新訂單ID");
            }
        }

        public void Update(SaleOrderUnit unit)
        {
            string sqlStr = @"UPDATE tbl_sale_order SET order_name = @OrderName, order_date = @OrderDate, 
                              delivery_date = @DeliveryDate, season = @Season, Customer_Id = @CustomerId, 
                              delivery_to = @DeliveryTo, delivery_location = @DeliveryLocation, 
                              origin_location = @OriginLocation, customer_order = @CustomerOrder, 
                              order_buyer = @OrderBuyer, po_number = @PoNumber, inspection_id = @InspectionItem, 
                              label_id = @Label WHERE order_id = @OrderId";
            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@OrderId", unit.OrderId),
                new NpgsqlParameter("@OrderName", unit.OrderName),
                new NpgsqlParameter("@OrderDate", unit.OrderDate),
                new NpgsqlParameter("@DeliveryDate", unit.DeliveryDate),
                new NpgsqlParameter("@Season", unit.Season ?? (object)DBNull.Value),
                new NpgsqlParameter("@CustomerId", unit.CustomerId),
                new NpgsqlParameter("@DeliveryTo", unit.DeliveryTo ?? (object)DBNull.Value),
                new NpgsqlParameter("@DeliveryLocation", unit.DeliveryLocation ?? (object)DBNull.Value),
                new NpgsqlParameter("@OriginLocation", unit.OriginLocation ?? (object)DBNull.Value),
                new NpgsqlParameter("@CustomerOrder", unit.CustomerOrder ?? (object)DBNull.Value),
                new NpgsqlParameter("@OrderBuyer", unit.OrderBuyer ?? (object)DBNull.Value),
                new NpgsqlParameter("@PoNumber", unit.PoNumber ?? (object)DBNull.Value),
                new NpgsqlParameter("@InspectionItem", unit.Inspection_id > 0 ? (object)unit.Inspection_id : DBNull.Value),
                new NpgsqlParameter("@Label", unit.Label_id > 0 ? (object)unit.Label_id : DBNull.Value)
            };
            SqlHelper.Execute(sqlStr, parameters);
        }

        public void Delete(int orderId)
        {
            string sqlStr = "DELETE FROM tbl_sale_order WHERE order_id = @OrderId";
            NpgsqlParameter[] parameters = { new NpgsqlParameter("@OrderId", orderId) };
            SqlHelper.Execute(sqlStr, parameters);
        }
    }
}

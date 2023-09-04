using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricModel
{
    public class DetailLinesData
    {
        public int DetailId { get; set; }  // 明細行的ID
        public int OrderId { get; set; }   // 銷售訂單的ID
        public int SaleDetailId { get; set; }  // 銷售明細行的ID
        public int ProductId { get; set; } // 銷售明細行產品的ID
        public int ColorId { get; set; }   // 色名資料的ID
        public string ColorCode { get; set; }  // 色名資料代碼
        public string ColorName { get; set; }  // 色名資料的色簡稱
        public string ColorDescription { get; set; }  // 色名資料表的說明
        public string ColorNameEn { get; set; }  // 英文色名
        public string ColorNumber { get; set; }  // 色號
        public decimal OrderQuantity { get; set; }  // 訂單量
        public string Unit { get; set; }  // 單位
        public decimal ExportCount { get; set; }  // 出口碼數
        public decimal UnitPrice { get; set; }  // 單價
        public decimal IncomingQuantity { get; set; }  // 來胚量
        public decimal FinishedQuantity { get; set; }  // 成品量
        public decimal ShippedQuantity { get; set; }  // 出貨量
        public decimal TransferQuantity { get; set; }  // 轉單量
        public decimal ReturnedQuantity { get; set; }  // 退胚量
    }

}

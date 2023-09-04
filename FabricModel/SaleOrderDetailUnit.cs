using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricModel
{
    public class SaleOrderDetailUnit
    {
        public int NO { get; set; }
        public int ProductID { get; set; }
        public decimal Width { get; set; }
        public decimal Weight { get; set; }
        public decimal GSM { get; set; }
        public decimal OrderQuantity { get; set; }
        public decimal InputQuantity { get; set; }
        public decimal FinishedQuantity { get; set; }
        public decimal ShippedQuantity { get; set; }
        public decimal TransferQuantity { get; set; }
        public decimal ReturnedQuantity { get; set; }
        public decimal Inventory { get; set; }
        public string Grade { get; set; }
        public int SaleOrderID { get; set; }
    }
}

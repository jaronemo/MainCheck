using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricModel
{
    public class SaleOrderUnit
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Season { get; set; }
        public int CustomerId { get; set; }
        public string DeliveryTo { get; set; }
        public string DeliveryLocation { get; set; }
        public string OriginLocation { get; set; }
        public string CustomerOrder { get; set; }
        public string OrderBuyer { get; set; }
        public string PoNumber { get; set; }
        public int? Inspection_id { get; set; }
        public int? Label_id { get; set; }
    }
}

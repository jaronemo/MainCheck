using System;
using System.Collections.Generic;
using FabricDAL;
using FabricModel;

namespace FabricBLL
{
    public class SaleOrderManage
    {
        private SaleOrderServices services = new SaleOrderServices();

        public SaleOrderUnit Get(int orderId)
        {
            return services.Get(orderId);
        }

        public List<SaleOrderUnit> GetList()
        {
            return services.GetList();
        }

        public int Add(SaleOrderUnit unit)
        {
            if (unit.OrderDate == default(DateTime) || unit.DeliveryDate == default(DateTime) || unit.CustomerId <= 0)
            {
                throw new Exception("訂單日期、交貨日期和客戶ID是必填項");
            }
            if (unit.Inspection_id < 0)
            {
                throw new Exception("InspectionItem的值無效");
            }
            if (unit.Label_id < 0)
            {
                throw new Exception("Label的值無效");
            }
            return services.Add(unit);
        }

        public void Update(SaleOrderUnit unit)
        {
            if (unit.OrderDate == default(DateTime) || unit.DeliveryDate == default(DateTime) || unit.CustomerId <= 0)
            {
                throw new Exception("訂單日期、交貨日期和客戶是必填項");
            }
            if (unit.Inspection_id  < 0)
            {
                throw new Exception("InspectionItem的值無效");
            }
            if (unit.Label_id < 0)
            {
                throw new Exception("Label的值無效");
            }
            services.Update(unit);
        }

        public void Delete(int orderId)
        {
            services.Delete(orderId);
        }
    }
}

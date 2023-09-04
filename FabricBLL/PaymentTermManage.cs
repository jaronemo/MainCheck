using FabricDAL;
using FabricModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricBLL
{
    public class PaymentTermManage
    {
        private PaymentTermService pts = new PaymentTermService();

        public List<PaymentTermUnit> GetList()
        {
            return pts.GetList();
        }

        public void Add(PaymentTermUnit cu)
        {
            pts.Add(cu);
        }

        public void ChangeInfo(PaymentTermUnit cu)
        {
            pts.ChangeInfo(cu);
        }

        public void Delete(int id)
        {
            pts.Delete(id);
        }
    }
}

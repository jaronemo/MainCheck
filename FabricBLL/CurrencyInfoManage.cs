using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricBLL
{
    public class CurrencyInfoManage
    {
        private FabricDAL.CurrencyInfoService cis = new FabricDAL.CurrencyInfoService();

        public List<FabricModel.CurrencyUnits> GetList()
        {
            return cis.GetList();
        }

        public void Add(FabricModel.CurrencyUnits cu)
        {
            cis.Add(cu);
        }

        public void ChangeInfo(FabricModel.CurrencyUnits cu)
        {
            cis.ChangeInfo(cu);
        }

        public void Delete(int id)
        {
            cis.Delete(id);
        }
    }
}

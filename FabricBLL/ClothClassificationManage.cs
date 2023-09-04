using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraPrinting;
using FabricDAL;
using FabricModel;

namespace FabricBLL
{
    public class ClothClassificationManage
    {
        /*CURD Function */
        private ClothClassificationService ccs = new ClothClassificationService();

        public List<ClothClassificationUnit> GetList()
        {
            return ccs.GetList();
        }
        public
            void Add(ClothClassificationUnit cu)
        {
            ccs.Add(cu);
        }
        public void ChangeInfo(ClothClassificationUnit cu)
        {
            ccs.ChangeInfo(cu);
        }
        public void Delete(int id)
        {
            ccs.Delete(id);
        }
    }
}

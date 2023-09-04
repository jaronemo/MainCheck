using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FabricDAL;
using FabricModel;


namespace FabricBLL
{
    public class ProductBasicInfoManage
    {
        private ProductBasicInfoServices services = new ProductBasicInfoServices();
        public ProductBasicInfoUnit Get(string no)
        {
            int n;
            if (!Int32.TryParse(no, out n))
            {
                throw new Exception("編號不正確!");
            }
            return new ProductBasicInfoServices().Get(n);
        }
        public List<ProductBasicInfoUnit> GetList()
        {
            return new ProductBasicInfoServices().GetList();
        }
        private ProductBasicInfoUnit GetModel(int no, string code, string name, int? cloth_id)
        {
            ProductBasicInfoUnit pd = new ProductBasicInfoUnit();
            pd.No = no;
            pd.Code = code;
            pd.Name = name;
            pd.Cloth_id = cloth_id;
            return pd;
        }
        public void ChangeInfo(int no, string code, string name, int? cloth_id)
        {
            if (services.IsCodeExists(code, no))
            {
                throw new Exception("此代碼已存在！");
            }
            new ProductBasicInfoServices().ChangeInfo(GetModel(no, code, name, cloth_id));
        }

        public void Add(string code, string name, int? cloth_id)
        {
            if (services.IsCodeExists(code))
            {
                throw new Exception("此代碼已存在！");
            }
            new ProductBasicInfoServices().Add(GetModel(-1, code, name, cloth_id));
        }

        public void Delete(int No)
        {
            new ProductBasicInfoServices().Delete(No);
        }
    }
}

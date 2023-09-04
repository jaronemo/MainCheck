using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FabricDAL;
using FabricModel;

namespace FabricBLL
{
    public class ChineseColorNameManage
    {
        private ChineseColorNameServices services = new ChineseColorNameServices();

        public ChineseColorNameUnit Get(string id)
        {
            int n;
            if (!Int32.TryParse(id, out n))
            {
                throw new Exception("編號不正確!");
            }
            return services.Get(n);
        }

        public List<ChineseColorNameUnit> GetList()
        {
            return services.GetList();
        }

        private ChineseColorNameUnit GetModel(int id, string code, string name, string description)
        {
            ChineseColorNameUnit unit = new ChineseColorNameUnit();
            unit.Id = id;
            unit.Code = code;
            unit.Name = name;
            unit.Description = description;
            return unit;
        }

        public void ChangeInfo(int id, string code, string name, string description)
        {
            if (services.IsCodeExists(code, id))
            {
                throw new Exception("此代碼已存在！");
            }
            services.ChangeInfo(GetModel(id, code, name, description));
        }

        public void Add(string code, string name, string description)
        {
            if (services.IsCodeExists(code))
            {
                throw new Exception("此代碼已存在！");
            }
            services.Add(GetModel(-1, code, name, description));
        }

        public void Delete(int id)
        {
            services.Delete(id);
        }
    }
}

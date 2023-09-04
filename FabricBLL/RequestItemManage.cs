using System;
using System.Collections.Generic;
using FabricDAL;
using FabricModel;

namespace FabricBLL
{
    public class RequestItemManage
    {
        private RequestItemServices services = new RequestItemServices();

        public RequestItemUnit Get(int id)
        {
            return services.Get(id);
        }

        public List<RequestItemUnit> GetList()
        {
            return services.GetList();
        }

        private RequestItemUnit GetModel(int id, string code, string name, string merge, string color)
        {
            RequestItemUnit unit = new RequestItemUnit();
            unit.Id = id;
            unit.Code = code;
            unit.Name = name;
            unit.Merge = merge;
            unit.Color = color;
            return unit;
        }

        public void Add(string code, string name, string merge, string color)
        {
            if (services.IsCodeExists(code))
            {
                throw new Exception("此代碼已存在！");
            }
            RequestItemUnit unit = GetModel(-1, code, name, merge, color);
            services.Add(unit);
        }

        public void ChangeInfo(int id, string code, string name, string merge, string color)
        {
            if (services.IsCodeExists(code, id))
            {
                throw new Exception("此代碼已存在！");
            }
            RequestItemUnit unit = GetModel(id, code, name, merge, color);
            services.Update(unit);
        }

        public void Delete(int id)
        {
            services.Delete(id);
        }
    }
}

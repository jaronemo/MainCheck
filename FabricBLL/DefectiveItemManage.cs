using System;
using System.Collections.Generic;
using FabricDAL;
using FabricModel;

namespace FabricBLL
{
    public class DefectiveItemManage
    {
        private DefectiveItemServices services = new DefectiveItemServices();

        public DefectiveItemUnit Get(int id)
        {
            return services.Get(id);
        }

        public List<DefectiveItemUnit> GetList()
        {
            return services.GetList();
        }

        private DefectiveItemUnit GetModel(int id, string name, string eng_name, string type, string code)
        {
            DefectiveItemUnit unit = new DefectiveItemUnit();
            unit.Id = id;
            unit.Name = name;
            unit.Eng_name = eng_name;
            unit.Type = type;
            unit.Code = code;
            return unit;
        }
        private void ValidateUnit(DefectiveItemUnit unit)
        {
            if (string.IsNullOrEmpty(unit.Name))
                throw new ArgumentException("名稱不能為空。");

            if (string.IsNullOrEmpty(unit.Eng_name))
                throw new ArgumentException("英文名稱不能為空。");

            if (string.IsNullOrEmpty(unit.Type) || (unit.Type != "Y" && unit.Type != "N"))
                throw new ArgumentException("類型必須是Y或N。");

            if (string.IsNullOrEmpty(unit.Code))
                throw new ArgumentException("代碼不能為空。");
        }
        public void Add(string name, string eng_name, string type, string code)
        {
            if (services.IsNameExists(name)) throw new Exception("該名稱已存在");
            if (services.IsCodeExists(code)) throw new Exception("該代碼已存在");
            DefectiveItemUnit unit = GetModel(0, name, eng_name, type, code);
            ValidateUnit(unit);
            services.Add(unit);
        }

        public void ChangeInfo(int id, string name, string eng_name, string type, string code)
        {
            if (services.IsNameExists(name, id)) throw new Exception("該名稱已存在");
            if (services.IsCodeExists(code, id)) throw new Exception("該代碼已存在");
            DefectiveItemUnit unit = GetModel(id, name, eng_name, type, code);
            ValidateUnit(unit);
            services.ChangeInfo(unit);
        }

        public void Delete(int id)
        {
            services.Delete(id);
        }
    }
}

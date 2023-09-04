using System;
using System.Collections.Generic;
using FabricDAL;
using FabricModel;

namespace FabricBLL
{
    public class LevelCategoryManage
    {
        private LevelCategoryServices services = new LevelCategoryServices();

        public LevelCategoryUnit Get(int id)
        {
            return services.Get(id);
        }

        public List<LevelCategoryUnit> GetList()
        {
            return services.GetList();
        }

        private LevelCategoryUnit GetModel(int id, string code, string name, int? b_level, int? c_level, string yard, string deduction_standard)
        {
            LevelCategoryUnit unit = new LevelCategoryUnit();
            unit.Id = id;
            unit.Code = code;
            unit.Name = name;
            unit.B_level = b_level ?? 0;  // If b_level is null, set to 0
            unit.C_level = c_level ?? 0;  // If c_level is null, set to 0
            unit.Yard = yard ?? null;
            unit.DeductionStandard = deduction_standard ?? null;
            return unit;
        }

        public void Add(string code, string name, int? b_level, int? c_level, string yard, string deductionStandard)
        {
            ValidateCodeAndName(code, name);
            LevelCategoryUnit unit = GetModel(0, code, name, b_level, c_level, yard, deductionStandard);
            services.Add(unit);
        }

        public void ChangeInfo(int id, string code, string name, int? b_level, int? c_level, string yard, string deductionStandard)
        {
            ValidateCodeAndName(code, name, id);
            LevelCategoryUnit unit = GetModel(id, code, name, b_level, c_level, yard, deductionStandard);
            services.Update(unit);
        }
        private void ValidateCodeAndName(string code, string name, int id = 0)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new Exception("代碼必須填寫！");
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("名稱必須填寫！");
            if (services.IsCodeExists(code, id))
                throw new Exception("此代碼已存在！");
        }

        public void Delete(int id)
        {
            services.Delete(id);
        }
    }
}

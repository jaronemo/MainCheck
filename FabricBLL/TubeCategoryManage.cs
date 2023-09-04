using System;
using System.Collections.Generic;
using FabricDAL;
using FabricModel;

namespace FabricBLL
{
    public class TubeCategoryManage
    {
        private TubeCategoryServices services = new TubeCategoryServices();

        public TubeCategoryUnit Get(int id)
        {
            return services.Get(id);
        }

        public List<TubeCategoryUnit> GetList()
        {
            return services.GetList();
        }

        private TubeCategoryUnit GetModel(int id, string code, string description, float tube_weight, float tube_price)
        {
            TubeCategoryUnit unit = new TubeCategoryUnit();
            unit.Id = id;
            unit.Code = code;
            unit.Description = description;
            unit.Tube_weight = tube_weight;
            unit.Tube_price = tube_price;
            return unit;
        }

        public void Add(string code, string description, float? tube_weight, float? tube_price)
        {
            if (string.IsNullOrEmpty(code))
                throw new Exception("代碼是必填的！");
            if (string.IsNullOrEmpty(description))
                throw new Exception("描述是必填的！");

            if (!tube_weight.HasValue)
                tube_weight = 0;  // 或拋出異常：throw new Exception("Tube weight is required!");
            if (!tube_price.HasValue)
                tube_price = 0;  // 或拋出異常：throw new Exception("Tube price is required!");

            TubeCategoryUnit unit = new TubeCategoryUnit
            {
                Code = code,
                Description = description,
                Tube_weight = tube_weight.Value,
                Tube_price = tube_price.Value
            };

            services.Add(unit);
        }

        public void ChangeInfo(int id, string code, string description, float? tube_weight, float? tube_price)
        {
            if (string.IsNullOrEmpty(code))
                throw new Exception("代碼是必填的！");
            if (string.IsNullOrEmpty(description))
                throw new Exception("描述是必填的！");

            if (!tube_weight.HasValue)
                tube_weight = 0;  // 或拋出異常：throw new Exception("Tube weight is required!");
            if (!tube_price.HasValue)
                tube_price = 0;  // 或拋出異常：throw new Exception("Tube price is required!");

            TubeCategoryUnit unit = new TubeCategoryUnit
            {
                Id = id,
                Code = code,
                Description = description,
                Tube_weight = tube_weight.Value,
                Tube_price = tube_price.Value
            };

            services.Update(unit);
        }
        public void Delete(int id)
        {
            services.Delete(id);
        }
    }
}

using System;
using System.Collections.Generic;
using FabricDAL;
using FabricModel;

namespace FabricBLL
{
    public class PickingLabelManage
    {
        private PickingLabelServices services = new PickingLabelServices();

        public PickingLabelUnit Get(string id)
        {
            int n;
            if (!Int32.TryParse(id, out n))
            {
                throw new Exception("編號不正確!");
            }
            return services.Get(n);
        }

        public List<PickingLabelUnit> GetList()
        {
            return services.GetList();
        }

        private PickingLabelUnit GetModel(int id, string code, string name, float? length_inch, int? length_mm, int? length_pix, float? width_inch, int? width_mm, int? width_pix, string filename, string backpicture)
        {
            PickingLabelUnit unit = new PickingLabelUnit();
            unit.Id = id;
            unit.Code = code;
            unit.Name = name;
            unit.Length_inch = length_inch;
            unit.Length_mm = length_mm;
            unit.Length_pix = length_pix;
            unit.Width_inch = width_inch;
            unit.Width_mm = width_mm;
            unit.Width_pix = width_pix;
            unit.Filename = filename;
            unit.Backpicture = backpicture;
            return unit;
        }

        public void Add(string code, string name, float? length_inch, int? length_mm, int? length_pix, float? width_inch, int? width_mm, int? width_pix, string filename, string backpicture)
        {
            if (services.IsCodeExists(code))
            {
                throw new Exception("此代碼已存在！");
            }
            services.Add(GetModel(-1, code, name, length_inch, length_mm, length_pix, width_inch, width_mm, width_pix, filename, backpicture));
        }

        public void ChangeInfo(int id, string code, string name, float? length_inch, int? length_mm, int? length_pix, float? width_inch, int? width_mm, int? width_pix, string filename, string backpicture)
        {
            if (services.IsCodeExists(code, id))
            {
                throw new Exception("此代碼已存在！");
            }
            services.ChangeInfo(GetModel(id, code, name, length_inch, length_mm, length_pix, width_inch, width_mm, width_pix, filename, backpicture));
        }

        public void Delete(int id)
        {
            services.Delete(id);
        }
    }
}

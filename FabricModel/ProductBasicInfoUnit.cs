using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricModel
{
    public class ProductBasicInfoUnit
    {
        private int no;
        private string code;
        private string name;
        private int? cloth_id;

        public int No { get => no; set => no = value; }
        public string Name { get => name; set => name = value; }
        public string Code { get => code; set => code = value; }
        public int? Cloth_id { get => cloth_id; set => cloth_id = value; }
    }
}

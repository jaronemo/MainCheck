using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricModel
{
    public class LevelCategoryUnit
    {
        private int id;
        private string code;
        private string name;
        private int b_level;
        private int c_level;
        private string yard;
        private string deduction_standard;

        public int Id { get => id; set => id = value; }
        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public int B_level { get => b_level; set => b_level = value; }
        public int C_level { get => c_level; set => c_level = value; }
        public string Yard { get => yard; set => yard = value; }
        public string DeductionStandard { get => deduction_standard; set => deduction_standard = value; }
    }
}

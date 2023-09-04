using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricModel
{
    public class DefectiveItemUnit
    {
        private int id;
        private string name;
        private string eng_name;
        private string type;
        private string code;
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Eng_name { get => eng_name; set => eng_name = value; }
        public string Type { get => type; set => type = value; }
        public string Code { get => code; set => code = value; }
    }
}

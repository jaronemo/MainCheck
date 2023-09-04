using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricModel
{
    public class RequestItemUnit
    {
        private int id;
        private string code;
        private string name;
        private string color;
        private string merge;

        public int Id { get => id; set => id = value; }
        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string Color { get => color; set => color = value; }

        public string Merge { get => merge; set => merge = value; }
    }
}

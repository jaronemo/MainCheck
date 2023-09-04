using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricModel
{
    public class MachineStationUnit
    {
        private int id;
        private string code;
        private string name;
        private string station;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Code { get => code; set => code = value; }
        public string Station { get => station; set => station = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricModel
{
    public class CurrencyUnits
    {
        private int id;
        private string name;
        private float rate;


        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public float Rate { get => rate; set => rate = value; }
    }
}

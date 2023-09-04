using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricModel
{
    public class PickingLabelUnit
    {
        private int id;
        private string code;
        private string name;
     /*   private float? length_inch;
        private int? length_mm;
        private int? length_pix;
        private float? width_inch;
        private int? width_mm;
        private int? width_pix;*/
        private string filename;
        private string backpicture;

        public int Id { get => id; set => id = value; }
        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public float? Length_inch { get; set; }
        public int? Length_mm { get; set; }
        public int? Length_pix { get; set; }
        public float? Width_inch { get; set; }
        public int? Width_mm { get; set; }
        public int? Width_pix { get; set; }
        public string Filename { get => filename; set => filename = value; }
        public string Backpicture { get => backpicture; set => backpicture = value; }
    }
}

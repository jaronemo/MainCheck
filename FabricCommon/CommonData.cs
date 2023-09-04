using FabricModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace FabricCommon
{
    public class CommonData
    {
        public static UserAccount nowLoginUser;
        public static Tuple<string, string> buffer2str = new Tuple<string, string>("", "");
    }
}

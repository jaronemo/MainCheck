using System;
using System.Collections.Generic;
using FabricDAL;
using FabricModel;

namespace FabricBLL
{
    public class MachineStationManage
    {
        private MachineStationServices services = new MachineStationServices();

        public MachineStationUnit Get(int id)
        {
            return services.Get(id);
        }

        public List<MachineStationUnit> GetList()
        {
            return services.GetList();
        }

        private MachineStationUnit GetModel(int id, string code, string name, string station)
        {
            MachineStationUnit unit = new MachineStationUnit();
            unit.Id = id;
            unit.Code = code;
            unit.Name = name;
            unit.Station = station;
            return unit;
        }

        public void Add(string code, string name, string station)
        {
            if (services.IsCodeExists(code))
            {
                throw new Exception("此代碼已存在！");
            }
            MachineStationUnit unit = GetModel(-1, code, name, station);
            services.Add(unit);
        }

        public void ChangeInfo(int id, string code, string name, string station)
        {
            if (services.IsCodeExists(code, id))
            {
                throw new Exception("此代碼已存在！");
            }
            MachineStationUnit unit = GetModel(id, code, name, station);
            services.Update(unit);
        }

        public void Delete(int id)
        {
            services.Delete(id);
        }
    }
}

using FabricDAL;
using FabricModel;
using System;
using System.Collections.Generic;

namespace FabricBLL
{
    public class DetailLinesDataManage
    {
        public DetailLinesData Get(int detailId)
        {
            return new DetailLinesDataServices().Get(detailId);
        }

        public List<DetailLinesData> GetList()
        {
            return new DetailLinesDataServices().GetList();
        }

        public List<DetailLinesData> GetListByOrderId(int orderId)
        {
            return new DetailLinesDataServices().GetListByOrderId(orderId);
        }

        public void Add(DetailLinesData detailLinesData)
        {
            new DetailLinesDataServices().Add(detailLinesData);
        }

        public void Update(DetailLinesData detailLinesData)
        {
            new DetailLinesDataServices().Update(detailLinesData);
        }

        public void Delete(int detailId)
        {
            new DetailLinesDataServices().Delete(detailId);
        }
    }
}

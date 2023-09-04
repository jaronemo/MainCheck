using FabricDAL;
using FabricModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricBLL
{
    public class SaleOrderDetailManage
    {
        public SaleOrderDetailUnit Get(int no)
        {
            return new SaleOrderDetailServices().Get(no);
        }

        public List<SaleOrderDetailUnit> GetList()
        {
            return new SaleOrderDetailServices().GetList();
        }

        private SaleOrderDetailUnit GetModel(int no, int productId, decimal width, decimal weight, decimal gsm, decimal orderQuantity, decimal inputQuantity, decimal finishedQuantity, decimal shippedQuantity, decimal transferQuantity, decimal returnedQuantity, decimal inventory, string grade, int saleOrderId)
        {
            SaleOrderDetailUnit saleOrderDetail = new SaleOrderDetailUnit();
            saleOrderDetail.NO = no;
            saleOrderDetail.ProductID = productId;
            saleOrderDetail.Width = width;
            saleOrderDetail.Weight = weight;
            saleOrderDetail.GSM = gsm;
            saleOrderDetail.OrderQuantity = orderQuantity;
            saleOrderDetail.InputQuantity = inputQuantity;
            saleOrderDetail.FinishedQuantity = finishedQuantity;
            saleOrderDetail.ShippedQuantity = shippedQuantity;
            saleOrderDetail.TransferQuantity = transferQuantity;
            saleOrderDetail.ReturnedQuantity = returnedQuantity;
            saleOrderDetail.Inventory = inventory;
            saleOrderDetail.Grade = grade;
            saleOrderDetail.SaleOrderID = saleOrderId;
            return saleOrderDetail;
        }

        public List<SaleOrderDetailUnit> GetListByOrderId(int orderId)
        {
            // 调用SaleOrderDetailServices中的GetListByOrderId方法来获取指定订单ID的销售订单明细数据
            return new SaleOrderDetailServices().GetListByOrderId(orderId);
        }


        public void ChangeInfo(int no, int productId, decimal width, decimal weight, decimal gsm, decimal orderQuantity, decimal inputQuantity, decimal finishedQuantity, decimal shippedQuantity, decimal transferQuantity, decimal returnedQuantity, decimal inventory, string grade, int saleOrderId)
        {
            new SaleOrderDetailServices().ChangeInfo(GetModel(no, productId, width, weight, gsm, orderQuantity, inputQuantity, finishedQuantity, shippedQuantity, transferQuantity, returnedQuantity, inventory, grade, saleOrderId));
        }

        public void Add(int productId, decimal width, decimal weight, decimal gsm, decimal orderQuantity, decimal inputQuantity, decimal finishedQuantity, decimal shippedQuantity, decimal transferQuantity, decimal returnedQuantity, decimal inventory, string grade, int saleOrderId)
        {
            new SaleOrderDetailServices().Add(GetModel(-1, productId, width, weight, gsm, orderQuantity, inputQuantity, finishedQuantity, shippedQuantity, transferQuantity, returnedQuantity, inventory, grade, saleOrderId));
        }

        public void Add(SaleOrderDetailUnit saleOrderDetail)
        {
            new SaleOrderDetailServices().Add(saleOrderDetail);
        }

        public void Delete(int no)
        {
            new SaleOrderDetailServices().Delete(no);
        }
    }
}

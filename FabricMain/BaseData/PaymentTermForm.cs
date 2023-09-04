using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using FabricBLL;
using FabricCommon;
using FabricModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FabricMain.BaseData
{
    public partial class PaymentTermForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public PaymentTermForm()
        {
            InitializeComponent();
        }

        private void barDockingMenuItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void PaymentTerm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FabMain checkMain = this.MdiParent as FabMain;
            if (checkMain != null)
            {
                checkMain.ShowMenu();
            }
        }

        private void PaymentTerm_Load(object sender, EventArgs e)
        {
            ReloadByCondition();
        }

        private BindingList<PaymentTermUnit> bindingList;
        private void ReloadByCondition()
        {
            try
            {
                List<PaymentTermUnit> list = new PaymentTermManage().GetList();
                bindingList = new BindingList<PaymentTermUnit>(list);
            }
            catch (Exception exp)
            {
                MsgBox.ShowError(exp.Message);
                return;
            }

            gridControl.DataSource = bindingList;

            bsiRecordsCount.Caption = "記錄 : " + bindingList.Count;

            Dictionary<string, string> columnCaptions = new Dictionary<string, string>
            {
                { "Id", "Id" },
                { "Name", "付款條件" }
            };

            foreach (var column in columnCaptions)
            {
                if (gridView.Columns.ColumnByFieldName(column.Key) != null)
                {
                    gridView.Columns[column.Key].Caption = column.Value;
                }
            }
            gridView.Columns["Id"].Visible = false;
            /*gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;*/

        }

        private void AddNewRow(object sender, ItemClickEventArgs e)
        {
            /* gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top; // 或 NewItemRowPosition.Bottom*/
            bindingList.AddNew();
        }

        private void btnSave_Click(object sender, ItemClickEventArgs e)
        {
            // 1. 獲取當前的數據
            List<PaymentTermUnit> currentData = bindingList.ToList();

            // 2. 保存到數據庫
            try
            {
                PaymentTermManage manager = new PaymentTermManage();
                foreach (PaymentTermUnit unit in currentData)
                {
                    if (unit.Id == 0) // 假設Id為0表示是新數據
                    {
                        manager.Add(unit); // 新增數據
                    }
                    else
                    {
                        manager.ChangeInfo(unit); // 更新數據
                    }
                }
                MsgBox.ShowInfo("數據保存成功！");
            }
            catch (Exception exp)
            {
                MsgBox.ShowError("保存數據時出錯: " + exp.Message);
            }
        }

        private void btnDelete_Click(object sender, ItemClickEventArgs e)
        {
            // 獲取選中的行
            int selectedRowHandle = gridView.FocusedRowHandle;
            if (selectedRowHandle < 0)
            {
                MsgBox.ShowError("請選擇要刪除的資料行！");
                return;
            }

            PaymentTermUnit selectedUnit = gridView.GetRow(selectedRowHandle) as PaymentTermUnit;
            if (selectedUnit == null)
            {
                MsgBox.ShowError("選擇的資料行無效！");
                return;
            }

            if (MsgBox.ShowAsk("確定要刪除選中的資料嗎？"))
            {
                try
                {
                    PaymentTermManage manager = new PaymentTermManage();
                    manager.Delete(selectedUnit.Id);
                    MsgBox.ShowInfo("數據刪除成功！");
                    ReloadByCondition(); // 重新加載數據
                }
                catch (Exception exp)
                {
                    MsgBox.ShowError("刪除數據時出錯: " + exp.Message);
                }
            }
        }
    }
}
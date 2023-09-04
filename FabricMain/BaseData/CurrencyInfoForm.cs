using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class CurrencyInfoForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public CurrencyInfoForm()
        {
            InitializeComponent();
        }

        private void barDockingMenuItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void CurrencyInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FabMain checkMain = this.MdiParent as FabMain;
            if (checkMain != null)
            {
                checkMain.ShowMenu();
            }
        }

        private void CurrencyInfoForm_Load(object sender, EventArgs e)
        {
            ReloadByCondition();

        }
        private BindingList<CurrencyUnits> bindingList;
        private void ReloadByCondition()
        {
            try
            {
                List<CurrencyUnits> list = new CurrencyInfoManage().GetList();
                bindingList = new BindingList<CurrencyUnits>(list);
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
                { "Name", "幣別" },
                { "Rate", "匯率" }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. 獲取當前的數據
            List<CurrencyUnits> currentData = bindingList.ToList();

            // 2. 保存到數據庫
            try
            {
                CurrencyInfoManage manager = new CurrencyInfoManage();
                foreach (CurrencyUnits unit in currentData)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 獲取選中的行
            int selectedRowHandle = gridView.FocusedRowHandle;
            if (selectedRowHandle < 0)
            {
                MsgBox.ShowError("請選擇要刪除的資料行！");
                return;
            }

            CurrencyUnits selectedUnit = gridView.GetRow(selectedRowHandle) as CurrencyUnits;
            if (selectedUnit == null)
            {
                MsgBox.ShowError("選擇的資料行無效！");
                return;
            }

            if (MsgBox.ShowAsk("確定要刪除選中的資料嗎？"))
            {
                try
                {
                    CurrencyInfoManage manager = new CurrencyInfoManage();
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
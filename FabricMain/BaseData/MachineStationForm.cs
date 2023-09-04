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
    public partial class MachineStationForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private BindingList<MachineStationUnit> bindingList;
        public MachineStationForm()
        {
            InitializeComponent();
        }

        private void btnClose(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void MachineStationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FabMain checkMain = this.MdiParent as FabMain;
            if (checkMain != null)
            {
                checkMain.ShowMenu();
            }
        }

        private void MachineStationForm_Load(object sender, EventArgs e)
        {
            ReloadByCondition();
        }

        private void ReloadByCondition()
        {
            try
            {
                List<MachineStationUnit> list = new MachineStationManage().GetList();
                bindingList = new BindingList<MachineStationUnit>(list);
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
                { "Code", "機台代碼" },
                { "Name", "機台簡稱" },
                { "Station", "站別" }
            };

            foreach (var column in columnCaptions)
            {
                if (gridView.Columns.ColumnByFieldName(column.Key) != null)
                {
                    gridView.Columns[column.Key].Caption = column.Value;
                }
            }
            gridView.Columns["Code"].VisibleIndex = 0; // 第一個顯示的欄位
            gridView.Columns["Name"].VisibleIndex = 1; // 第二個顯示的欄位
            gridView.Columns["Station"].VisibleIndex = 2;
            gridView.Columns["Id"].Visible = false;

        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            bindingList.AddNew();
        }

        private void btnSave_Click(object sender, ItemClickEventArgs e)
        {
            gridView.CloseEditor();
            List<MachineStationUnit> currentData = bindingList.ToList();
            int currentRowHandle = gridView.FocusedRowHandle;

            try
            {
                MachineStationManage manager = new MachineStationManage();
                foreach (MachineStationUnit unit in currentData)
                {
                    if (unit.Id == 0)
                    {
                        manager.Add(unit.Code, unit.Name, unit.Station);
                    }
                    else
                    {
                        manager.ChangeInfo(unit.Id, unit.Code, unit.Name, unit.Station);
                    }
                }
                ReloadByCondition();
                gridView.FocusedRowHandle = currentRowHandle;
                MsgBox.ShowInfo("數據保存成功！");
            }
            catch (Exception exp)
            {
                MsgBox.ShowError("保存數據時出錯: " + exp.Message);
            }
        }

        private void btnDelete_Click(object sender, ItemClickEventArgs e)
        {
            int selectedRowHandle = gridView.FocusedRowHandle;
            if (selectedRowHandle < 0)
            {
                MsgBox.ShowError("請選擇要刪除的資料行！");
                return;
            }

            MachineStationUnit selectedUnit = gridView.GetRow(selectedRowHandle) as MachineStationUnit;
            if (selectedUnit == null)
            {
                MsgBox.ShowError("選擇的資料行無效！");
                return;
            }

            if (MsgBox.ShowAsk("確定要刪除選中的資料嗎？"))
            {
                try
                {
                    MachineStationManage manager = new MachineStationManage();
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
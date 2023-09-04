using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using FabricBLL;
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
    public partial class RequestItemForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private BindingList<RequestItemUnit> bindingList;
        public RequestItemForm()
        {
            InitializeComponent();
        }

        private void btnClose(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void RequestItemForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FabMain checkMain = this.MdiParent as FabMain;
            if (checkMain != null)
            {
                checkMain.ShowMenu();
            }
        }

        private void RequestItemForm_Load(object sender, EventArgs e)
        {
            ReloadByCondition();
        }
        private void ReloadByCondition()
        {
            try
            {
                List<RequestItemUnit> list = new RequestItemManage().GetList();
                bindingList = new BindingList<RequestItemUnit>(list);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            gridControl.DataSource = bindingList;

            bsiRecordsCount.Caption = "記錄 : " + bindingList.Count;

            Dictionary<string, string> columnCaptions = new Dictionary<string, string>
            {
                { "Id", "Id" },
                { "Code", "代碼" },
                { "Name", "簡稱" },
                { "Merge", "合併" },
                { "Color", "顏色"}
            };

            foreach (var column in columnCaptions)
            {
                if (gridView.Columns.ColumnByFieldName(column.Key) != null)
                {
                    gridView.Columns[column.Key].Caption = column.Value;
                }
            }

            gridView.Columns["Code"].VisibleIndex = 0;
            gridView.Columns["Name"].VisibleIndex = 1;
            gridView.Columns["Color"].VisibleIndex = 2;
            gridView.Columns["Merge"].VisibleIndex = 3;
            
            // 隱藏Id欄位
            gridView.Columns["Id"].Visible = false;

            // Set up the Merge column to be a dropdown with Y and N options
            RepositoryItemComboBox comboMerge = new RepositoryItemComboBox();
            comboMerge.Items.AddRange(new string[] { "Y", "N" });
            gridView.Columns["Merge"].ColumnEdit = comboMerge;
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            bindingList.AddNew();
        }

        private void btnSave_Click(object sender, ItemClickEventArgs e)
        {
            gridView.CloseEditor();
            List<RequestItemUnit> currentData = bindingList.ToList();
            int currentRowHandle = gridView.FocusedRowHandle;

            try
            {
                RequestItemManage manager = new RequestItemManage();
                foreach (RequestItemUnit unit in currentData)
                {
                    if (unit.Id == 0)
                    {
                        manager.Add(unit.Code, unit.Name, unit.Merge, unit.Color);
                    }
                    else
                    {
                        manager.ChangeInfo(unit.Id, unit.Code, unit.Name, unit.Merge, unit.Color);
                    }
                }
                ReloadByCondition();
                gridView.FocusedRowHandle = currentRowHandle;
                MessageBox.Show("數據保存成功！", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exp)
            {
                MessageBox.Show("保存數據時出錯: " + exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, ItemClickEventArgs e)
        {
            int selectedRowHandle = gridView.FocusedRowHandle;
            if (selectedRowHandle < 0)
            {
                MessageBox.Show("請選擇要刪除的資料行！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RequestItemUnit selectedUnit = gridView.GetRow(selectedRowHandle) as RequestItemUnit;
            if (selectedUnit == null)
            {
                MessageBox.Show("選擇的資料行無效！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("確定要刪除選中的資料嗎？", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    RequestItemManage manager = new RequestItemManage();
                    manager.Delete(selectedUnit.Id);
                    MessageBox.Show("數據刪除成功！", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReloadByCondition(); // 重新加載數據
                }
                catch (Exception exp)
                {
                    MessageBox.Show("刪除數據時出錯: " + exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
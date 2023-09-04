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
    public partial class DefectiveItemForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private BindingList<DefectiveItemUnit> bindingList;
        public DefectiveItemForm()
        {
            InitializeComponent();
        }

        private void btnClose(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
        private void DefectiveItemForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FabMain checkMain = this.MdiParent as FabMain;
            if (checkMain != null)
            {
                checkMain.ShowMenu();
            }
        }
        private void DefectiveItemForm_Load(object sender, EventArgs e)
        {
            ReloadByCondition();
        }

        private void ReloadByCondition()
        {
            try
            {
                List<DefectiveItemUnit> list = new DefectiveItemManage().GetList();
                bindingList = new BindingList<DefectiveItemUnit>(list);
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
                { "Name", "名稱" },
                { "Eng_name", "英文名稱" },
                { "Type", "類型" },
                { "Code", "順序" }
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
            gridView.Columns["Eng_name"].VisibleIndex = 2;
            gridView.Columns["Type"].VisibleIndex = 3;
            // 隱藏Id欄位
            gridView.Columns["Id"].Visible = false;

            // Set up the Type column to be a dropdown with Y and N options
            RepositoryItemComboBox comboType = new RepositoryItemComboBox();
            comboType.Items.AddRange(new string[] { "Y", "N" });
            gridView.Columns["Type"].ColumnEdit = comboType;
        }


        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            bindingList.AddNew();
        }

        private void btnSave_Click(object sender, ItemClickEventArgs e)
        {
            gridView.CloseEditor();
            List<DefectiveItemUnit> currentData = bindingList.ToList();
            int currentRowHandle = gridView.FocusedRowHandle;

            try
            {
                DefectiveItemManage manager = new DefectiveItemManage();
                foreach (DefectiveItemUnit unit in currentData)
                {
                    if (unit.Id == 0)
                    {
                        manager.Add(unit.Name, unit.Eng_name, unit.Type, unit.Code);
                    }
                    else
                    {
                        manager.ChangeInfo(unit.Id, unit.Name, unit.Eng_name, unit.Type, unit.Code);
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

            DefectiveItemUnit selectedUnit = gridView.GetRow(selectedRowHandle) as DefectiveItemUnit;
            if (selectedUnit == null)
            {
                MessageBox.Show("選擇的資料行無效！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("確定要刪除選中的資料嗎？", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DefectiveItemManage manager = new DefectiveItemManage();
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
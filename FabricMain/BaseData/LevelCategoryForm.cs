using DevExpress.XtraBars;
using DevExpress.XtraEditors;
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
    public partial class LevelCategoryForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private BindingList<LevelCategoryUnit> bindingList;
        public LevelCategoryForm()
        {
            InitializeComponent();
        }

        private void btnClose(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void LevelCategoryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FabMain checkMain = this.MdiParent as FabMain;
            if (checkMain != null)
            {
                checkMain.ShowMenu();
            }
        }

        private void LevelCategoryForm_Load(object sender, EventArgs e)
        {
            ReloadByCondition();
        }

        private void ReloadByCondition()
        {
            try
            {
                List<LevelCategoryUnit> list = new LevelCategoryManage().GetList();
                bindingList = new BindingList<LevelCategoryUnit>(list);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            gridControl.DataSource = bindingList;

            bsiRecordsCount.Caption = "Records: " + bindingList.Count;

            Dictionary<string, string> columnCaptions = new Dictionary<string, string>
            {
                { "Id", "Id" },
                { "Code", "類別" },
                { "Name", "說明" },
                { "B_level", "B 級" },
                { "C_level", "C 級" },
                { "Yard", "平方碼" },
                { "DeductionStandard", "扣分標准" }
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
            gridView.Columns["B_level"].VisibleIndex = 2;
            gridView.Columns["C_level"].VisibleIndex = 3;
            gridView.Columns["Yard"].VisibleIndex = 4;
            gridView.Columns["DeductionStandard"].VisibleIndex = 5;

            // Hide the Id column
            gridView.Columns["Id"].Visible = false;
        }
        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            bindingList.AddNew();
        }
        private void btnSave_Click(object sender, ItemClickEventArgs e)
        {
            gridView.CloseEditor();
            List<LevelCategoryUnit> currentData = bindingList.ToList();
            int currentRowHandle = gridView.FocusedRowHandle;

            try
            {
                LevelCategoryManage manager = new LevelCategoryManage();
                foreach (LevelCategoryUnit unit in currentData)
                {
                    if (unit.Id == 0)
                    {
                        manager.Add(unit.Code, unit.Name, unit.B_level, unit.C_level, unit.Yard, unit.DeductionStandard);
                    }
                    else
                    {
                        manager.ChangeInfo(unit.Id, unit.Code, unit.Name, unit.B_level, unit.C_level, unit.Yard, unit.DeductionStandard);
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

            LevelCategoryUnit selectedUnit = gridView.GetRow(selectedRowHandle) as LevelCategoryUnit;
            if (selectedUnit == null)
            {
                MessageBox.Show("選擇的資料行無效！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("確定要刪除選中的資料嗎？", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    LevelCategoryManage manager = new LevelCategoryManage();
                    manager.Delete(selectedUnit.Id);
                    MessageBox.Show("數據刪除成功！", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReloadByCondition(); // Reload data
                }
                catch (Exception exp)
                {
                    MessageBox.Show("刪除數據時出錯: " + exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
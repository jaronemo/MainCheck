using DevExpress.XtraBars;
using DevExpress.XtraEditors;
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
using FabricBLL;
using FabricModel;
using FabricCommon;

namespace FabricMain.BaseData
{
    public partial class TubeCategoryForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private BindingList<TubeCategoryUnit> bindingList;
        public TubeCategoryForm()
        {
            InitializeComponent();
        }

        private void btnClose(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void TubeCategoryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FabMain checkMain = this.MdiParent as FabMain;
            if (checkMain != null)
            {
                checkMain.ShowMenu();
            }
        }

        private void TubeCategoryForm_Load(object sender, EventArgs e)
        {
            ReloadByCondition();
        }
        private void ReloadByCondition()
        {
            try
            {
                List<TubeCategoryUnit> list = new TubeCategoryManage().GetList();
                bindingList = new BindingList<TubeCategoryUnit>(list);
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
                { "Description", "規格說明" },
                { "Tube_weight", "管重" },
                { "Tube_price", "單價" }
            };

            foreach (var column in columnCaptions)
            {
                if (gridView.Columns.ColumnByFieldName(column.Key) != null)
                {
                    gridView.Columns[column.Key].Caption = column.Value;
                }
            }

            gridView.Columns["Code"].VisibleIndex = 0;
            gridView.Columns["Description"].VisibleIndex = 1;
            gridView.Columns["Tube_weight"].VisibleIndex = 2;
            gridView.Columns["Tube_price"].VisibleIndex = 3;
            gridView.Columns["Id"].Visible = false;
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            bindingList.AddNew();
        }

        private void btnSave_Click(object sender, ItemClickEventArgs e)
        {
            gridView.CloseEditor();
            List<TubeCategoryUnit> currentData = bindingList.ToList();
            int currentRowHandle = gridView.FocusedRowHandle;

            try
            {
                TubeCategoryManage manager = new TubeCategoryManage();
                foreach (TubeCategoryUnit unit in currentData)
                {
                    if (unit.Id == 0)
                    {
                        manager.Add(unit.Code, unit.Description, unit.Tube_weight, unit.Tube_price);
                    }
                    else
                    {
                        manager.ChangeInfo(unit.Id, unit.Code, unit.Description, unit.Tube_weight, unit.Tube_price);
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

            TubeCategoryUnit selectedUnit = gridView.GetRow(selectedRowHandle) as TubeCategoryUnit;
            if (selectedUnit == null)
            {
                MessageBox.Show("選擇的資料行無效！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("確定要刪除選中的資料嗎？", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    TubeCategoryManage manager = new TubeCategoryManage();
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
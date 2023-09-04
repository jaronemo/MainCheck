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
    public partial class ClothClassificationForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public ClothClassificationForm()
        {
            InitializeComponent();
        }

        private void btnClose(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void ClothClassificationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FabMain checkMain = this.MdiParent as FabMain;
            if (checkMain != null)
            {
                checkMain.ShowMenu();
            }
        }

        private void ClothClassificationForm_Load(object sender, EventArgs e)
        {
            ReloadByCondition();
        }

        private BindingList<ClothClassificationUnit> bindingList;
        private void ReloadByCondition()
        {
            try
            {
                List<ClothClassificationUnit> list = new ClothClassificationManage().GetList();
                bindingList = new BindingList<ClothClassificationUnit>(list);
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
                { "Name", "布種類別名稱" }
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

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            bindingList.AddNew();
        }

        private void btnSave_Click(object sender, ItemClickEventArgs e)
        {
            // 1. 獲取當前的數據
            List<ClothClassificationUnit> currentData = bindingList.ToList();

            // 2. 保存到數據庫
            try
            {
                ClothClassificationManage manager = new ClothClassificationManage();
                foreach (ClothClassificationUnit unit in currentData)
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

            ClothClassificationUnit selectedUnit = gridView.GetRow(selectedRowHandle) as ClothClassificationUnit;
            if (selectedUnit == null)
            {
                MsgBox.ShowError("選擇的資料行無效！");
                return;
            }

            if (MsgBox.ShowAsk("確定要刪除選中的資料嗎？"))
            {
                try
                {
                    ClothClassificationManage manager = new ClothClassificationManage();
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
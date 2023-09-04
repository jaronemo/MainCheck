using DevExpress.Utils.Layout;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FabricMain.BaseData
{
    public partial class ProductBasicInfoForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public ProductBasicInfoForm()
        {
            InitializeComponent();
           
        }
        
        private void btnClose(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void ProductBasicInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FabMain checkMain = this.MdiParent as FabMain;
            if (checkMain != null)
            {
                checkMain.ShowMenu();
            }
        }

        private void ProductBasicInfoForm_Load(object sender, EventArgs e)
        {
            ReloadByCondition();
            this.BeginInvoke(new Action(() =>
            {
                LoadClothClassificationData();
            }));

        }

        private Dictionary<string, int> clothClassificationDict = new Dictionary<string, int>();
        private void LoadClothClassificationData()
        {
            List<ClothClassificationUnit> clothClassifications = new ClothClassificationManage().GetList();

            RepositoryItemLookUpEdit clothLookUpEdit = new RepositoryItemLookUpEdit();
            clothLookUpEdit.NullText = "";
            clothLookUpEdit.DataSource = clothClassifications;
            clothLookUpEdit.ValueMember = "Id"; // Assuming 'Id' is the property name for cloth ID
            clothLookUpEdit.DisplayMember = "Name"; // Assuming 'Name' is the property name for cloth name

            // Hide the header
            clothLookUpEdit.ShowHeader = false;

            // Only show the Name column
            LookUpColumnInfoCollection columns = clothLookUpEdit.Columns;
            columns.Clear();
            columns.Add(new LookUpColumnInfo("Name"));

            // Add the LookUpEdit editor to the grid's repository
            gridControl.RepositoryItems.Add(clothLookUpEdit);

            // Assign the LookUpEdit editor to the Cloth_id column
            gridView.Columns["Cloth_id"].ColumnEdit = clothLookUpEdit;

        }


        private BindingList<ProductBasicInfoUnit> bindingList;
        private void ReloadByCondition()
        {
            try
            {
                List<ProductBasicInfoUnit> list = new ProductBasicInfoManage().GetList();
                bindingList = new BindingList<ProductBasicInfoUnit>(list);
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
                { "No", "No" },
                { "Code", "品名代碼" },
                { "Name", "品名描述" },
                { "Cloth_id", "布種分類" }
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
            gridView.Columns["Cloth_id"].VisibleIndex = 2;
            gridView.Columns["No"].Visible = false;
            /* RepositoryItemComboBox riComboBox = new RepositoryItemComboBox();
             gridControl.RepositoryItems.Add(riComboBox);
             gridView.Columns["Cloth_id"].ColumnEdit = riComboBox;*/
            /*gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;*/

        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            bindingList.AddNew();
        }

        private void btnSave_Click(object sender, ItemClickEventArgs e)
        {
            // 確保所有的更改都已提交到綁定的數據源
            gridView.CloseEditor();
            // 1. 獲取當前的數據
            List<ProductBasicInfoUnit> currentData = bindingList.ToList();
            int currentRowHandle = gridView.FocusedRowHandle;

            // 2. 保存到數據庫
            try
            {
                ProductBasicInfoManage manager = new ProductBasicInfoManage();
                foreach (ProductBasicInfoUnit unit in currentData)
                {
                    if (unit.Cloth_id.HasValue && clothClassificationDict.ContainsValue(unit.Cloth_id.Value))
                    {
                        unit.Cloth_id = clothClassificationDict.FirstOrDefault(x => x.Value == unit.Cloth_id.Value).Value;
                    }


                    if (unit.No == 0) // 假設Id為0表示是新數據
                    {
                        manager.Add(unit.Code, unit.Name, unit.Cloth_id); // 新增數據
                    }
                    else
                    {
                        manager.ChangeInfo(unit.No, unit.Code, unit.Name, unit.Cloth_id); // 更新數據
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
            // 獲取選中的行
            int selectedRowHandle = gridView.FocusedRowHandle;
            if (selectedRowHandle < 0)
            {
                MsgBox.ShowError("請選擇要刪除的資料行！");
                return;
            }

            ProductBasicInfoUnit selectedUnit = gridView.GetRow(selectedRowHandle) as ProductBasicInfoUnit;
            if (selectedUnit == null)
            {
                MsgBox.ShowError("選擇的資料行無效！");
                return;
            }

            if (MsgBox.ShowAsk("確定要刪除選中的資料嗎？"))
            {
                try
                {
                    ProductBasicInfoManage manager = new ProductBasicInfoManage();
                    manager.Delete(selectedUnit.No);
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
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using FabricBLL;
using FabricCommon;
using FabricModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FabricMain.BaseData
{
    public partial class PickingLabelForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private BindingList<PickingLabelUnit> bindingList;
        public PickingLabelForm()
        {
            InitializeComponent();          
        }

        private void btnClose(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void PickingLabelForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FabMain checkMain = this.MdiParent as FabMain;
            if (checkMain != null)
            {
                checkMain.ShowMenu();
            }
        }

        private void PickingLabelForm_Load(object sender, EventArgs e)
        {
            ReloadByCondition();
        }
        private void ReloadByCondition()
        {
            try
            {
                List<PickingLabelUnit> list = new PickingLabelManage().GetList();
                bindingList = new BindingList<PickingLabelUnit>(list);
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
                { "Code", "代碼" },
                { "Name", "名稱" },
                { "Length_inch", "長度(英寸)" },
                { "Length_mm", "長度(mm)" },
                { "Length_pix", "長度(像素)" },
                { "Width_inch", "寬度(英寸)" },
                { "Width_mm", "寬度(mm)" },
                { "Width_pix", "寬度(像素)" },
                { "Filename", "檔案名稱" },
                { "Backpicture", "背景圖片" }
            };

            foreach (var column in columnCaptions)
            {
                if (gridView.Columns.ColumnByFieldName(column.Key) != null)
                {
                    gridView.Columns[column.Key].Caption = column.Value;
                }
            }
            // 定義檔案選擇編輯器
            RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit();
            buttonEdit.ButtonClick += repositoryItemButtonEdit1_ButtonClick;
            gridView.Columns["Filename"].ColumnEdit = buttonEdit;
            // 定義按鈕編輯器
            RepositoryItemButtonEdit pic_buttonEdit = new RepositoryItemButtonEdit();
            pic_buttonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor; // 隱藏文字，只顯示按鈕
            pic_buttonEdit.ButtonClick += ButtonEdit_ButtonClick; // 添加按鈕點擊事件

            // 定義圖片編輯器
            RepositoryItemImageEdit imageEdit = new RepositoryItemImageEdit();
            gridView.Columns["Backpicture"].ColumnEdit = imageEdit;

            gridView.Columns["Backpicture"].OptionsColumn.AllowEdit = true; // 允許編輯
            gridView.ShownEditor += GridView_ShownEditor; // 當單元格進入編輯模式時的事件
            // 隱藏Id列
            gridView.Columns["Id"].Visible = false;
        }
        // 在GridView的設計模式中，選擇您想要的列（例如Filename），然後設定其ColumnEdit屬性為一個新的RepositoryItemButtonEdit。
        // 接著，為該RepositoryItemButtonEdit的ButtonClick事件添加事件處理程序：

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fullPath = openFileDialog.FileName;
                string fileName = Path.GetFileName(fullPath); // 只獲取檔案名稱
                (sender as ButtonEdit).EditValue = fileName;
            }
        }
        private void ButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "圖片文件(*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp"; // 只允許選擇圖片文件
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                gridView.SetFocusedValue(imagePath); // 將圖片路徑保存到單元格中
            }
        }
        private void GridView_ShownEditor(object sender, EventArgs e)
        {
            if (gridView.FocusedColumn.FieldName == "Backpicture")
            {
                ButtonEdit editor = gridView.ActiveEditor as ButtonEdit;
                if (editor != null)
                {
                    editor.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                    editor.Properties.ButtonClick += ButtonEdit_ButtonClick;
                }
            }
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            bindingList.AddNew();
        }

        private void btnSave_Click(object sender, ItemClickEventArgs e)
        {
            gridView.CloseEditor();
            List<PickingLabelUnit> currentData = bindingList.ToList();
            int currentRowHandle = gridView.FocusedRowHandle;

            try
            {
                PickingLabelManage manager = new PickingLabelManage();
                foreach (PickingLabelUnit unit in currentData)
                {
                    if (unit.Id == 0)
                    {
                        manager.Add(unit.Code, unit.Name, unit.Length_inch, unit.Length_mm, unit.Length_pix, unit.Width_inch, unit.Width_mm, unit.Width_pix, unit.Filename, unit.Backpicture);
                    }
                    else
                    {
                        manager.ChangeInfo(unit.Id, unit.Code, unit.Name, unit.Length_inch, unit.Length_mm, unit.Length_pix, unit.Width_inch, unit.Width_mm, unit.Width_pix, unit.Filename, unit.Backpicture);
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

            PickingLabelUnit selectedUnit = gridView.GetRow(selectedRowHandle) as PickingLabelUnit;
            if (selectedUnit == null)
            {
                MsgBox.ShowError("選擇的資料行無效！");
                return;
            }

            if (MsgBox.ShowAsk("確定要刪除選中的資料嗎？"))
            {
                try
                {
                    PickingLabelManage manager = new PickingLabelManage();
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
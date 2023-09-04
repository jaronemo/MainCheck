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
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace FabricMain.BaseData
{
    public partial class EmployeeForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public EmployeeForm()
        {
            InitializeComponent();
         
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }
       
        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            ReloadByCondition();
        }

        private void ReloadByCondition(string condition = "", string find = "")
        {
            List<UserAccount> list;
            try
            {
                list = new UserAccountManage().GetList(condition, find);
            }
            catch (Exception exp)
            {
                MsgBox.ShowError(exp.Message);
                return;
            }
            //成功
            gridControl.DataSource = list;
            bsiRecordsCount.Caption = "記錄 : " + list.Count;
            Dictionary<string, string> columnCaptions = new Dictionary<string, string>
            {
                { "LoginName", "帳號" },
                { "Password", "密碼" },
                { "Permission", "權限" },
                { "Name", "員工姓名" },
                { "Sex", "性別" },
                { "Department", "部門" },
                { "Phone", "電話" },
                { "Birthday", "員工生日" },
                { "EntryDate", "到職日期" },             
            };

            foreach (var column in columnCaptions)
            {
                if (gridView.Columns.ColumnByFieldName(column.Key) != null)
                {
                    gridView.Columns[column.Key].Caption = column.Value;
                }
            }

            // 隱藏不需要的列
            gridView.Columns["Password"].Visible = false;
            gridView.Columns["Permission"].Visible = false;
        }

        private void EmployeeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FabMain checkMain = this.MdiParent as FabMain;
            if (checkMain != null)
            {
                checkMain.ShowMenu();
            }
        }
        /* 新增事件*/

        private void barDockingMenuItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            SingleEmployee p = new SingleEmployee();
            p.ifNew = true;
            p.ShowDialog();
            ReloadByCondition();
        }

        private void barDockingMenuItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            /* int i = gridView.CurrentRow.Index;
             string username = gridView.Rows[i].Cells[0].Value.ToString();
             if (username == string.Empty || username == null)
             {
                 MsgBox.ShowError("請選擇員工");
                 return;
             }
             SingleEmployee p = new SingleEmployee();
             p.OutterUsername = gridView.Rows[i].Cells[0].Value.ToString();
             p.ShowDialog();
             ReloadByCondition();*/
            int handle = gridView.FocusedRowHandle;
            if (handle < 0)
            {
                MsgBox.ShowError("請選擇員工");
                return;
            }
            // 獲取選中行的username值
            string username = gridView.GetRowCellValue(handle, "LoginName").ToString();
            if (string.IsNullOrEmpty(username))
            {
                MsgBox.ShowError("請選擇員工");
                return;
            }
            // 使用選中的行的資料初始化SingleEmployee視窗
            SingleEmployee p = new SingleEmployee();
            p.OutterUsername = username;
            p.ShowDialog();

            // 重新加載資料
            ReloadByCondition();
        }

        private void barDockingMenuItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            // 獲取當前選中的行的handle
            int handle = gridView.FocusedRowHandle;
            if (handle < 0)
            {
                MsgBox.ShowError("請選擇員工");
                return;
            }

            // 從選中的行中獲取username
            string username = gridView.GetRowCellValue(handle, "LoginName").ToString();
            if (string.IsNullOrEmpty(username))
            {
                MsgBox.ShowError("請選擇員工");
                return;
            }

            if (MsgBox.ShowAsk("真的要刪除現在選擇的員工資料嗎？"))
            {
                // 刪除
                try
                {
                    new UserAccountManage().Delete(username);
                    MsgBox.ShowInfo("刪除員工資料成功");
                }
                catch (Exception exp)
                {
                    MsgBox.ShowError("刪除員工資料失敗！原因：" + exp.Message);
                    return;
                }
            }
            ReloadByCondition();
        }

        private void barDockingMenuItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
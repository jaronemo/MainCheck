using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using FabricBLL;
using FabricCommon;
using FabricModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;

namespace FabricMain.BaseData
{
    public partial class PartnerInfoForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private int currentFocusedRowHandle = -1;
        public PartnerInfoForm()
        {
            InitializeComponent();
            gridView1.FocusedRowChanged += GridView1_FocusedRowChanged;
        }

        private void btn_Close(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void PartnerInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FabMain checkMain = this.MdiParent as FabMain;
            if (checkMain != null)
            {
                checkMain.ShowMenu();
            }
        }

        private void GridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0) // 確保選中的是有效的資料行
            {
                BussinessUnit unit = gridView1.GetRow(e.FocusedRowHandle) as BussinessUnit;
                if (unit != null)
                {
                    DisplayDataInTextBox(unit);
                }
            }
        }

        private void PartnerInfoForm_Load(object sender, EventArgs e)
        {            
            LoadPaymentTermsToComboBox();
            ReloadByCondition();
        }

        // 定義一個字典來存儲PaymentTerm的Id和Name
        private Dictionary<string, int> paymentTermDict = new Dictionary<string, int>();

        private void LoadPaymentTermsToComboBox()
        {
            PaymentTermManage manager = new PaymentTermManage();
            List<PaymentTermUnit> terms = manager.GetList();

            // 清空ComboBox和字典
            txtPayment.Properties.Items.Clear();
            paymentTermDict.Clear();

            foreach (var term in terms)
            {
                txtPayment.Properties.Items.Add(term.Name);
                paymentTermDict[term.Name] = term.Id;
            }
        }


        private BindingList<BussinessUnit> bindingList;
        private void ReloadByCondition()
        {
            // 保存當前焦點行的主鍵值
            int? savedNo = null;
            if (gridView1.FocusedRowHandle >= 0)
            {
                savedNo = (int?)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "No");
            }
            try
            {
                List<BussinessUnit> list = new BussinessUnitManage().GetList();
                bindingList = new BindingList<BussinessUnit>(list);
            }
            catch (Exception exp)
            {
                MsgBox.ShowError(exp.Message);
                return;
            }

            gridControl1.DataSource = bindingList;

            bsiRecordsCount.Caption = "記錄 : " + bindingList.Count;

            
            // 首先設置所有欄位為不可見
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridView1.Columns)
            {
                column.Visible = false;
            }

            // 然後設置您想要顯示的欄位為可見
            gridView1.Columns["Code"].Visible = true;
            gridView1.Columns["Name"].Visible = true;
            gridView1.Columns["ComapnyName"].Visible = true;
            gridView1.Columns["Phone"].Visible = true;
            // 設定欄位名稱
            gridView1.Columns["Code"].Caption = "代碼";
            gridView1.Columns["Name"].Caption = "簡稱";
            gridView1.Columns["ComapnyName"].Caption = "公司名稱";
            gridView1.Columns["Phone"].Caption = "電話";
            // 設定欄位顯順序
            gridView1.Columns["Code"].VisibleIndex = 0; // 第一個顯示的欄位
            gridView1.Columns["Name"].VisibleIndex = 1; // 第二個顯示的欄位
            gridView1.Columns["ComapnyName"].VisibleIndex = 2; // 第三個顯示的欄位
            gridView1.Columns["Phone"].VisibleIndex = 3; // 第四個顯示的欄位
            /*gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;*/

            SortGridViewByNo();
            if (savedNo.HasValue)
            {
                int rowHandle = gridView1.LocateByValue("No", savedNo.Value);
                if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                {
                    gridView1.FocusedRowHandle = rowHandle;
                }
            }
            else
            {
                gridView1.FocusedRowHandle = gridView1.RowCount - 1; // 如果是新增，則焦點設置到最後一行
            }

        }

        private void SortGridViewByNo()
        {
            gridView1.OptionsView.ShowGroupPanel = false; // 隱藏分組面板
            gridView1.ClearSorting();
            gridView1.Columns["No"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
        }

        private void DisplayDataInTextBox(BussinessUnit unit)
        {
            // 將BussinessUnit的資料填充到對應的TextEdit控件中
            bu_no_text.Text = unit.No.ToString();
            nameText.Text = unit.Name;
            PrincipalText.Text = unit.Principal;
            phoneText.Text = unit.Phone;
            faxText.Text = unit.Fax;
            vat1Text.Text = unit.Vat1;
            vat2Text.Text = unit.Vat2;
            companyText.Text = unit.ComapnyName;
            engCompanyText.Text = unit.EngCompanyName;
            addressTextBox.Text = unit.Address;
            mailText.Text = unit.Email;
            sale1Text.Text = unit.Sale1;
            contractText.Text = unit.ContactName;
            contractPhoneText.Text = unit.ContractPhone;
            contractFaxText.Text = unit.ContractFax;
            mobileText.Text = unit.Mobile;
            level1Text.Text = unit.Level1;
            level2Text.Text = unit.Level2;
            codeText.Text = unit.Code;
            bu_no_text.Visible = false;
            if (unit.PaymentID.HasValue)
            {
                // 根據PaymentID查找對應的Name
                var paymentName = paymentTermDict.FirstOrDefault(x => x.Value == unit.PaymentID.Value).Key;
                txtPayment.Text = paymentName;
            }
            else
            {
                txtPayment.EditValue = null;
            }

        }

        private void ClearAllTextEditControls(Control parentControl)
        {
            foreach (Control control in parentControl.Controls)
            {
                if (control is TextEdit)
                {
                    control.Text = string.Empty;
                }
                else if (control is ComboBoxEdit) // 檢查是否為 ComboBoxEdit
                {
                    ComboBoxEdit comboBox = control as ComboBoxEdit;
                    comboBox.EditValue = null; // 清空選擇值
                }
                else
                {
                    ClearAllTextEditControls(control);
                }
            }
        }

        private void btnAdd_Click(object sender, ItemClickEventArgs e)
        {
            /* // 清空所有TextEdit控件的內容
             foreach (Control control in this.Controls)
             {
                 if (control is TextEdit)
                 {
                     control.Text = string.Empty;
                 }
             }*/
            ClearAllTextEditControls(this);
        }

        private void btnSave_Click(object sender, ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(bu_no_text.Text))
            {
                // 新增操作
                currentFocusedRowHandle = gridView1.RowCount; // 新資料行的索引
            }
            else
            {
                // 修改操作
                currentFocusedRowHandle = gridView1.FocusedRowHandle;
            }
            int? selectedPaymentID = null;
            if (!string.IsNullOrEmpty(txtPayment.Text) && paymentTermDict.ContainsKey(txtPayment.Text))
            {
                selectedPaymentID = paymentTermDict[txtPayment.Text];
            }
            BussinessUnit unit = new BussinessUnit
            {
                No = string.IsNullOrEmpty(bu_no_text.Text) ? -1 : int.Parse(bu_no_text.Text),
                Name = nameText.Text,
                Principal = PrincipalText.Text,
                Phone = phoneText.Text,
                Fax = faxText.Text,
                Vat1 = vat1Text.Text,
                Vat2 = vat2Text.Text,
                ComapnyName = companyText.Text,
                EngCompanyName = engCompanyText.Text,
                Address = addressTextBox.Text,
                Email = mailText.Text,
                Sale1 = sale1Text.Text,
                ContactName = contractText.Text,
                ContractPhone = contractPhoneText.Text,
                ContractFax = contractFaxText.Text,
                Mobile = mobileText.Text,
                Level1 = level1Text.Text,
                Level2 = level2Text.Text,
                Code = codeText.Text,
                PaymentID = selectedPaymentID
            };

            BussinessUnitManage manager = new BussinessUnitManage();

            if (string.IsNullOrEmpty(bu_no_text.Text))
            {
                // 新增操作
                bindingList.Add(unit);
                manager.Add(
                    unit.Name,
                    unit.Address,
                    unit.ContactName,
                    unit.Phone,
                    unit.Email,
                    unit.Fax,
                    unit.Mobile,
                    unit.ComapnyName,
                    unit.EngCompanyName,
                    unit.Code,
                    unit.Principal,
                    unit.Vat1,
                    unit.Vat2,
                    unit.ContractPhone,
                    unit.ContractFax,
                    unit.Sale1,
                    unit.Sale2,
                    unit.Level1,
                    unit.Level2,
                    unit.Note,
                    unit.PaymentID
                );
            }
            else
            {
                // 修改操作
                manager.ChangeInfo(
                    bu_no_text.Text,
                    unit.Name,
                    unit.Address,
                    unit.ContactName,
                    unit.Phone,
                    unit.Email,
                    unit.Fax,
                    unit.Mobile,
                    unit.ComapnyName,
                    unit.EngCompanyName,
                    unit.Code,
                    unit.Principal,
                    unit.Vat1,
                    unit.Vat2,
                    unit.ContractPhone,
                    unit.ContractFax,
                    unit.Sale1,
                    unit.Sale2,
                    unit.Level1,
                    unit.Level2,
                    unit.Note,
                    unit.PaymentID
                );
            }

            // 重新加載資料
            ReloadByCondition();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 如果bu_no_text沒有值，認為是新增狀態，直接退出事件並重整畫面
            if (string.IsNullOrEmpty(bu_no_text.Text))
            {
                ReloadByCondition();
                return;
            }

            // 顯示確認視窗
            DialogResult result = MessageBox.Show("確定要刪除此筆資料嗎？", "確認刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // 執行刪除操作
                    new BussinessUnitManage().Delete(bu_no_text.Text);

                    // 重新加載資料
                    ReloadByCondition();

                    MessageBox.Show("資料已刪除！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("刪除失敗！\n" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
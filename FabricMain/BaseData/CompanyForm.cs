using DevExpress.XtraBars;
using FabricCommon;
using FabricModel;
using FabricBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FabricMain.BaseData
{
    public partial class CompanyForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public CompanyInfo company;
        bool ifChanged = false;
        public CompanyForm()
        {
            InitializeComponent();
        }

        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }

        private byte[] ImageToByteArray(Image imageIn)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private void CompanyForm_Load(object sender, EventArgs e)
        {
            // 讀入
            try
            {
                company = new CompanyInfoManage().Get();
            }
            catch (Exception exp)
            {
                MsgBox.ShowError(exp.Message);
                ifChanged = false;
                this.Close();
            }
            if (company != null)
            {
                // 如果有公司資訊，將資訊填充到表單中
                companyText.Text = company.Name;
                shortText.Text = company.Shortname;
                addressText.Text = company.Address;
                zipText.Text = company.Zipcode;
                taxText.Text = company.Taxid;
                phoneText.Text = company.Phone;
                faxText.Text = company.Fax;
                websiteText.Text = company.Website;
                emailText.Text = company.Email;
                byte[] logoBytes = new byte[0];
                if (company.Logo != null && company.Logo.Length > 0)
                {
                    logoBox.Image = ByteArrayToImage(company.Logo);
                }
                else
                {
                    logoBox.Image = null;
                }


                // ... 其他欄位
                ifChanged = false;
                companyText.ReadOnly = true;
            }
            else
            {
                // 如果沒有公司資訊，清空表單
                companyText.Text = "";
                shortText.Text = "";
                addressText.Text = "";
                zipText.Text = "";
                taxText.Text = "";
                phoneText.Text = "";
                faxText.Text = "";
                websiteText.Text = "";
                emailText.Text = "";
                logoBox.Image = null;

                // ... 其他欄位
                ifChanged = true;
            }
        }

        private void SaveButton_Click(object sender, ItemClickEventArgs e)
        {
            if (!ifChanged)
            {
                MsgBox.ShowInfo("無需儲存資料!");
                return;
            }
            if (company == null)
            {
                company = new CompanyInfo();
            }

            // 修改
            byte[] logoBytes = new byte[0];
            if (logoBox.Image != null)
            {
                logoBytes = ImageToByteArray(logoBox.Image);
            }
            try
            {
                new CompanyInfoManage().ChangeInfo(companyText.Text, shortText.Text, addressText.Text, zipText.Text, taxText.Text, phoneText.Text, faxText.Text, websiteText.Text, emailText.Text, logoBytes);
            }
            catch (Exception exp)
            {
                MsgBox.ShowError("資料修改錯誤: " + exp.Message);
                return;
            }
            MsgBox.ShowInfo("資料修正成功！");
            ifChanged = false;
        }

        private void barDockingMenuItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void CompanyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FabMain checkMain = this.MdiParent as FabMain;
            if (checkMain != null)
            {
                checkMain.ShowMenu();
            }
        }
    }
}
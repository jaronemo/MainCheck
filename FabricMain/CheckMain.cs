using DevExpress.Utils.Helpers;
using FabricMain.BaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FabricMain
{
    public partial class FabMain : DevExpress.XtraEditors.XtraForm
    {
        public FabMain()
        {
            InitializeComponent();
        }

        private void Jump<T>(string type = "") where T : Form, new() //跳转函数，避免重复打开mdi窗口
        {
            bool find = false;
            foreach (Form f in this.MdiChildren)
            {
                //直接用类型来判断，不用text属性
                if (f is T)
                {
                    find = true;
                    f.Activate();
                }
            }
            if (find == false)
            {
                T t = new T();
                t.MdiParent = this;
                /*t.Dock = DockStyle.Fill;*/
                t.Tag = type;
                t.Show();
            }
        }
        public void ShowMenu()
        {
            this.bar1.Visible = true;
            this.bar2.Visible = true;
        }
        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Jump<EmployeeForm>();
            this.bar1.Visible = false;
            this.bar2.Visible = false;
           /* this.radMenu1.Visible = false;*/
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Jump<CompanyForm>();
            this.bar1.Visible = false;
            this.bar2.Visible = false;
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Jump<CurrencyInfoForm>();
            this.bar1.Visible = false;
            this.bar2.Visible = false;
        }

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Jump<PaymentTermForm>();
            this.bar1.Visible = false;
            this.bar2.Visible = false;
        }

        private void btnCustomer(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Jump<PartnerInfoForm>();
            this.bar1.Visible = false;
            this.bar2.Visible = false;
        }

        private void btnCloth(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Jump<ClothClassificationForm>();
            this.bar1.Visible = false;
            this.bar2.Visible = false;
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Jump<ProductBasicInfoForm>();
            this.bar1.Visible = false;
            this.bar2.Visible = false;
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Jump<ChineseColorNameForm>();
            this.bar1.Visible = false;
            this.bar2.Visible = false;
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
            Jump<MachineStationForm>();
            this.bar1.Visible = false;
            this.bar2.Visible = false;
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Jump<PickingLabelForm>();
            this.bar1.Visible = false;
            this.bar2.Visible = false;
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Jump<DefectiveItemForm>();
            this.bar1.Visible = false;
            this.bar2.Visible = false;
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Jump<RequestItemForm>();
            this.bar1.Visible = false;
            this.bar2.Visible = false;
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Jump<TubeCategoryForm>();
            this.bar1.Visible = false;
            this.bar2.Visible = false;
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Jump<LevelCategoryForm>();
            this.bar1.Visible = false;
            this.bar2.Visible = false;
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Jump<SaleOrderForm>();
            this.bar1.Visible = false;
            this.bar2.Visible = false;
        }

        private void barButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {         
            
            PasswordPrompt prompt = new PasswordPrompt();
            if (prompt.ShowDialog() == DialogResult.OK)
            {
                // 如果密碼正確，則打開 FabricSystemConfigure 視窗
                Jump<FabricSystemConfigure>();
                this.bar1.Visible = false;
                this.bar2.Visible = false;
            }
            else
            {
                // 如果密碼輸入錯誤或用戶選擇取消，您可以選擇不進行任何操作，或者給予用戶一個提示。
                // 例如:
                MessageBox.Show("配置操作已取消。");
            }
        }
    }
}

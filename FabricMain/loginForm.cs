using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FabricCommon;
using FabricModel;
using FabricBLL;

namespace FabricMain
{
    public partial class loginForm : DevExpress.XtraEditors.XtraForm
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); //formclosing事件
        }

        private void loginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MsgBox.ShowAsk("確認要退出程式嗎？"))
            {
                e.Cancel = false; //formclosed事件会监听,否则有概率会抛出异常
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            this.BeginInvoke((Action)(() => txtUserName.Focus()));
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == string.Empty)
            {
                MsgBox.ShowError("查無此用戶帳號!");
                txtUserName.Focus();
                return;
            }
            if (txtPasswd.Text == string.Empty)
            {
                MsgBox.ShowError("密碼為空!");
                txtPasswd.Focus();
                return;
            }
            UserAccount thisUsr;
            try
            {   
                thisUsr = new UserAccountManage().Get(txtUserName.Text);
            }
            catch (Exception exp)
            {
                MsgBox.ShowError(exp.Message);
                return;
            }
            if (thisUsr.Password == UserAccountManage.GetMD5(txtPasswd.Text))
            {
                //校验成功
                //释放敏感资源：密码
                thisUsr.Password = null;
                string wenhou;
                DateTime dt = DateTime.Now; //获取当前时间
                if (dt.Hour >= 0 && dt.Hour < 8) wenhou = "早上好!";
                else if (dt.Hour >= 8 && dt.Hour < 12) wenhou = "上午好!";
                else if (dt.Hour >= 12 && dt.Hour < 14) wenhou = "中午好!";
                else if (dt.Hour >= 14 && dt.Hour < 18) wenhou = "下午好!";
                else wenhou = "晚上好!";
                MsgBox.ShowInfo(wenhou + " " + thisUsr.Name);
                FabMain mainForm = new FabMain();
                /*mainFrm mainForm = new mainFrm();*/
                CommonData.nowLoginUser = thisUsr;
                this.Hide();
                mainForm.Show();
            }
            else
            {
                MsgBox.ShowError("帳號或密碼輸入錯誤！");
                return;
            }
        }
    }
}
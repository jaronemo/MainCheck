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

namespace FabricMain.BaseData
{
    public partial class PasswordPrompt : DevExpress.XtraEditors.XtraForm
    {
        private const string HardcodedPassword = "!99999IbmQAZWSX";
        public PasswordPrompt()
        {
            InitializeComponent();
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {
            if (txtPw.Text == HardcodedPassword)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("密碼錯誤，請重新輸入！");
                txtPw.Clear();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
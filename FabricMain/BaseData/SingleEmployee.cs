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
using FabricBLL;
using FabricCommon;
using FabricModel;
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace FabricMain.BaseData
{
    public partial class SingleEmployee : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        bool ifChanged = false;
        public string OutterUsername = ""; //从外部调用
        public UserAccount Outter = null; //从外部调用
        public bool ifNew = false; //新建
        UserAccount nowUsr;
        public SingleEmployee()
        {
            InitializeComponent();
        }

        private void Enable()
        {
            txtAccount.ReadOnly = false;
            txtGender.Enabled = true;
            txtDepartment.ReadOnly = false;
            txtPhone.ReadOnly = false;
            txtBirthDay.Enabled = true;
            txtEntryDate.Enabled = true;
           /* permissionGroup.Enabled = true;*/
        }

        private string GeneratePermissionStr()
        {
            string Permission = "0";
            foreach (GroupBox gb in permissionGroup.Controls)
            {
                foreach (CheckBox cb in gb.Controls)
                {
                    if (cb.Tag == null || cb.Tag.ToString() == String.Empty)
                    {
                        cb.Checked = false;
                        continue;
                    }
                    if (cb.Checked) Permission += cb.Tag;
                }
            }
            return Permission;
        }

        private UserAccount GetUser()
        {
            UserAccount newUsr = new UserAccount();
            newUsr.LoginName = txtAccount.Text.Trim();
            newUsr.Name = txtName.Text.Trim();
            newUsr.Sex = txtGender.Text;
            newUsr.Department = txtDepartment.Text.Trim();
            newUsr.Phone = txtPhone.Text.Trim();
            newUsr.Birthday = txtBirthDay.DateTime;
            newUsr.EntryDate = txtEntryDate.DateTime;
            newUsr.Permission = "0";
            //开始生成权限串
            newUsr.Permission = this.GeneratePermissionStr();
            return newUsr;
        }



        private void SingleEmployee_Load(object sender, EventArgs e)
        {
            if (OutterUsername != string.Empty)
            {
                try
                {
                    Outter = new UserAccountManage().Get(OutterUsername);
                }
                catch (Exception exp)
                {
                    MsgBox.ShowError(exp.Message);
                    ifChanged = false;
                    this.Close();
                }
            }
            nowUsr = (Outter == null) ? CommonData.nowLoginUser : Outter;
            if (!ifNew)
            {
                txtAccount.Text = nowUsr.LoginName;
                txtName.Text = nowUsr.Name;
                txtGender.Text = nowUsr.Sex;
                txtDepartment.Text = nowUsr.Department;
                txtPhone.Text = nowUsr.Phone;
                txtBirthDay.DateTime = nowUsr.Birthday;
                txtEntryDate.DateTime = nowUsr.EntryDate;
                //循环加载权限GroupBox
                foreach (GroupBox gb in permissionGroup.Controls)
                {
                    foreach (CheckBox cb in gb.Controls)
                    {
                        if (cb.Tag == null || cb.Tag.ToString() == String.Empty)
                        {
                            cb.Checked = false;
                            continue;
                        }
                        if (new UserAccountManage().IfGranted(nowUsr, cb.Tag.ToString()[0])) cb.Checked = true;
                        else cb.Checked = false;
                    }
                }
                if (nowUsr.LoginName != "admin" && Outter != null) Enable();  //解禁控件
            }
            else
            {
                Enable(); //解禁控件
                txtAccount.ReadOnly = false; //解禁用户名控件
                txtAccount.Focus();
                passwordTipLabel.Visible = false; //修改密码提示不可见
            }
            ifChanged = false;
        }

        private void barDockingMenuItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataSave();
        }
        private void DataSave()
        {
            if (!ifChanged)
            {
                MsgBox.ShowInfo("無需保存資料!");
                return;
            }
            if (!ifNew)
            {
                if (txtPasswd.Text != string.Empty)
                {
                    //修改密码
                    try
                    {
                        new UserAccountManage().ChangePassword(txtAccount.Text, txtPasswd.Text);
                    }
                    catch (Exception exp)
                    {
                        MsgBox.ShowError("密碼修改失敗！原因： " + exp.Message);
                        return;
                    }
                    MsgBox.ShowInfo("密碼修改成功！");
                    txtPasswd.Text = "";
                    ifChanged = false;
                    return;
                }
                if (Outter != null)
                {
                    //执行修改操作
                    try
                    {
                        /*new UserAccountManage().ChangeInfo(usernameText.Text, GeneratePermissionStr(), nameText.Text, sexCombo.Text, deptText.Text, phoneText.Text, birthdayDate.Value, entryDate.Value);*/
                        new UserAccountManage().ChangeInfo(txtAccount.Text, GeneratePermissionStr(), txtName.Text, txtGender.Text, txtDepartment.Text, txtPhone.Text, txtBirthDay.DateTime, txtEntryDate.DateTime);
                    }
                    catch (Exception exp)
                    {
                        MsgBox.ShowError("資料修改失敗！原因： " + exp.Message);
                        return;
                    }
                    MsgBox.ShowInfo("資料修改成功！");
                    txtPasswd.Text = "";
                    ifChanged = false;
                    return;
                }
            }
            else
            {
                //新建
                try
                {
                    /*new UserManager().Add(usernameText.Text, passwordText.Text, GeneratePermissionStr(), nameText.Text, sexCombo.Text, deptText.Text, phoneText.Text, birthdayDate.Value, entryDate.Value);*/
                    new UserAccountManage().Add(txtAccount.Text, txtPasswd.Text,GeneratePermissionStr(), txtName.Text, txtGender.Text, txtDepartment.Text, txtPhone.Text, txtBirthDay.DateTime, txtEntryDate.DateTime);
                }
                catch (Exception exp)
                {
                    MsgBox.ShowError("帳號新增失敗，原因： " + exp.Message);
                    return;
                }
                MsgBox.ShowInfo("帳號新增成功！");
                txtPasswd.Text = "";
                ifChanged = false;
                return;
            }
        }
        private void barDockingMenuItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barDockingMenuItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataSave();
            this.Close();
        }

        private void txtPasswd_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void SingleEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ifChanged)
            {
                if (MsgBox.ShowAsk("還沒有進行資料儲存，確認不儲存就要退出嗎？"))
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void txtGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void SingleEmployee_Shown(object sender, EventArgs e)
        {
            //部分情况下在Load事件中设置焦点会失效，故在Shown事件中再设置一次焦点。
            if (ifNew)
            {
                txtAccount.ReadOnly = false;
                txtAccount.Focus();
            }
        }

        private void txtDepartment_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            ifChanged = true;
        }
    }
}
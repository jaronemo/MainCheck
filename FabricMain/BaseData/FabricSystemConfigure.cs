using DevExpress.XtraBars;
using System;
using System.Windows.Forms;
using System.Configuration;
using FabricCommon;

namespace FabricMain.BaseData
{
    public partial class FabricSystemConfigure : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FabricSystemConfigure()
        {
            InitializeComponent();
        }

        private void btnModify_Click(object sender, ItemClickEventArgs e)
        {
            // 啟用所有的文本框，允許用戶修改
            ToggleTextBoxesReadOnly(false);
        }

        private void btnSave_Click(object sender, ItemClickEventArgs e)
        {
            // 加密資料庫連接資訊並保存到配置文件中
            UpdateAppConfig("DatabaseDatasource", EncryptionHelper.Encrypt(dbAddressTxt.Text));
            UpdateAppConfig("DatabaseName", EncryptionHelper.Encrypt(dbNameTxt.Text));
            UpdateAppConfig("DatabaseUsername", EncryptionHelper.Encrypt(dbUserNameTxt.Text));
            UpdateAppConfig("DatabasePassword", EncryptionHelper.Encrypt(dbPasswdTxt.Text));

            // 重新加載配置文件，以確保後續的操作使用的是最新的設定
            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show("設定已保存成功！");
        }

        private void btnClose_Click(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void FabricSystemConfigure_FormClosed(object sender, FormClosedEventArgs e)
        {
            FabMain checkMain = this.MdiParent as FabMain;
            if (checkMain != null)
            {
                checkMain.ShowMenu();
            }
        }

        private void FabricSystemConfigure_Load(object sender, EventArgs e)
        {
            // 檢查和處理DatabaseUsername和DatabasePassword
            HandleAppConfigValue("DatabaseDatasource", dbAddressTxt);
            HandleAppConfigValue("DatabaseName", dbNameTxt);
            HandleAppConfigValue("DatabaseUsername", dbUserNameTxt);
            HandleAppConfigValue("DatabasePassword", dbPasswdTxt);

            // 設置文本框為只讀，除非用戶點擊"修改"按鈕
            ToggleTextBoxesReadOnly(true);
        }

        private void HandleAppConfigValue(string key, DevExpress.XtraEditors.TextEdit textBox)
        {
            string configValue = ConfigurationManager.AppSettings[key];

            // 檢查設定值是否存在
            if (string.IsNullOrEmpty(configValue))
            {
                textBox.Text = "";
                return;
            }

            // 如果設定值已加密，進行解密操作
            if (configValue.StartsWith("ENC_"))
            {
                textBox.Text = EncryptionHelper.Decrypt(configValue.Substring(4)); // 去除"ENC_"前綴
            }
            else
            {
                textBox.Text = configValue; // 顯示明文
            }
        }

        private void UpdateAppConfig(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = "ENC_" + value;
            config.Save(ConfigurationSaveMode.Modified);
        }

        private void ToggleTextBoxesReadOnly(bool isReadOnly)
        {
            dbAddressTxt.ReadOnly = isReadOnly;
            dbNameTxt.ReadOnly = isReadOnly;
            dbUserNameTxt.ReadOnly = isReadOnly;
            dbPasswdTxt.ReadOnly = isReadOnly;
        }
    }
}

namespace FabricMain.BaseData
{
    partial class FabricSystemConfigure
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barDockingMenuItem1 = new DevExpress.XtraBars.BarDockingMenuItem();
            this.barDockingMenuItem2 = new DevExpress.XtraBars.BarDockingMenuItem();
            this.barDockingMenuItem3 = new DevExpress.XtraBars.BarDockingMenuItem();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dbAddressTxt = new DevExpress.XtraEditors.TextEdit();
            this.dbNameTxt = new DevExpress.XtraEditors.TextEdit();
            this.dbUserNameTxt = new DevExpress.XtraEditors.TextEdit();
            this.dbPasswdTxt = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAddressTxt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbNameTxt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbUserNameTxt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPasswdTxt.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 1;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(442, 54);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 477);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(442, 32);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationButtonDropDownControl = this.ribbon;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.barDockingMenuItem1,
            this.barDockingMenuItem2,
            this.barDockingMenuItem3});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 54);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage2});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            this.ribbonControl1.Size = new System.Drawing.Size(442, 220);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "系統配置維護";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barDockingMenuItem1);
            this.ribbonPageGroup2.ItemLinks.Add(this.barDockingMenuItem2);
            this.ribbonPageGroup2.ItemLinks.Add(this.barDockingMenuItem3);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "基本功能作業";
            // 
            // barDockingMenuItem1
            // 
            this.barDockingMenuItem1.Caption = "修改";
            this.barDockingMenuItem1.Id = 1;
            this.barDockingMenuItem1.ImageOptions.Image = global::FabricMain.Properties.Resources.edit_32x32;
            this.barDockingMenuItem1.Name = "barDockingMenuItem1";
            this.barDockingMenuItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barDockingMenuItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnModify_Click);
            // 
            // barDockingMenuItem2
            // 
            this.barDockingMenuItem2.Caption = "保存";
            this.barDockingMenuItem2.Id = 2;
            this.barDockingMenuItem2.ImageOptions.Image = global::FabricMain.Properties.Resources.save_32x322;
            this.barDockingMenuItem2.Name = "barDockingMenuItem2";
            this.barDockingMenuItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barDockingMenuItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_Click);
            // 
            // barDockingMenuItem3
            // 
            this.barDockingMenuItem3.Caption = "退出";
            this.barDockingMenuItem3.Id = 3;
            this.barDockingMenuItem3.ImageOptions.Image = global::FabricMain.Properties.Resources.close_32x322;
            this.barDockingMenuItem3.Name = "barDockingMenuItem3";
            this.barDockingMenuItem3.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barDockingMenuItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 300);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(90, 22);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "資料庫位址";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 340);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(90, 22);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "資料庫名稱";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 380);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(90, 22);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "資料庫帳號";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(13, 419);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(90, 22);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "資料庫密碼";
            // 
            // dbAddressTxt
            // 
            this.dbAddressTxt.Location = new System.Drawing.Point(136, 300);
            this.dbAddressTxt.MenuManager = this.ribbon;
            this.dbAddressTxt.Name = "dbAddressTxt";
            this.dbAddressTxt.Size = new System.Drawing.Size(261, 28);
            this.dbAddressTxt.TabIndex = 7;
            // 
            // dbNameTxt
            // 
            this.dbNameTxt.Location = new System.Drawing.Point(136, 337);
            this.dbNameTxt.MenuManager = this.ribbon;
            this.dbNameTxt.Name = "dbNameTxt";
            this.dbNameTxt.Size = new System.Drawing.Size(261, 28);
            this.dbNameTxt.TabIndex = 8;
            // 
            // dbUserNameTxt
            // 
            this.dbUserNameTxt.Location = new System.Drawing.Point(136, 377);
            this.dbUserNameTxt.MenuManager = this.ribbon;
            this.dbUserNameTxt.Name = "dbUserNameTxt";
            this.dbUserNameTxt.Size = new System.Drawing.Size(261, 28);
            this.dbUserNameTxt.TabIndex = 9;
            // 
            // dbPasswdTxt
            // 
            this.dbPasswdTxt.Location = new System.Drawing.Point(136, 416);
            this.dbPasswdTxt.MenuManager = this.ribbon;
            this.dbPasswdTxt.Name = "dbPasswdTxt";
            this.dbPasswdTxt.Size = new System.Drawing.Size(261, 28);
            this.dbPasswdTxt.TabIndex = 10;
            // 
            // FabricSystemConfigure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 509);
            this.Controls.Add(this.dbPasswdTxt);
            this.Controls.Add(this.dbUserNameTxt);
            this.Controls.Add(this.dbNameTxt);
            this.Controls.Add(this.dbAddressTxt);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FabricSystemConfigure";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "系統配置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FabricSystemConfigure_FormClosed);
            this.Load += new System.EventHandler(this.FabricSystemConfigure_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAddressTxt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbNameTxt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbUserNameTxt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPasswdTxt.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarDockingMenuItem barDockingMenuItem1;
        private DevExpress.XtraBars.BarDockingMenuItem barDockingMenuItem2;
        private DevExpress.XtraBars.BarDockingMenuItem barDockingMenuItem3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit dbAddressTxt;
        private DevExpress.XtraEditors.TextEdit dbNameTxt;
        private DevExpress.XtraEditors.TextEdit dbUserNameTxt;
        private DevExpress.XtraEditors.TextEdit dbPasswdTxt;
    }
}
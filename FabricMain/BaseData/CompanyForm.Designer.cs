namespace FabricMain.BaseData
{
    partial class CompanyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyForm));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barDockingMenuItem1 = new DevExpress.XtraBars.BarDockingMenuItem();
            this.barDockingMenuItem2 = new DevExpress.XtraBars.BarDockingMenuItem();
            this.barDockingMenuItem3 = new DevExpress.XtraBars.BarDockingMenuItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.companyText = new DevExpress.XtraEditors.TextEdit();
            this.shortText = new DevExpress.XtraEditors.TextEdit();
            this.addressText = new DevExpress.XtraEditors.TextEdit();
            this.zipText = new DevExpress.XtraEditors.TextEdit();
            this.taxText = new DevExpress.XtraEditors.TextEdit();
            this.phoneText = new DevExpress.XtraEditors.TextEdit();
            this.faxText = new DevExpress.XtraEditors.TextEdit();
            this.websiteText = new DevExpress.XtraEditors.TextEdit();
            this.emailText = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.logoBox = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shortText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zipText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phoneText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.faxText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.websiteText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.barDockingMenuItem1,
            this.barDockingMenuItem2,
            this.barDockingMenuItem3});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 4;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(986, 238);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // barDockingMenuItem1
            // 
            this.barDockingMenuItem1.Caption = "修改";
            this.barDockingMenuItem1.Id = 1;
            this.barDockingMenuItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barDockingMenuItem1.ImageOptions.Image")));
            this.barDockingMenuItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barDockingMenuItem1.ImageOptions.LargeImage")));
            this.barDockingMenuItem1.Name = "barDockingMenuItem1";
            // 
            // barDockingMenuItem2
            // 
            this.barDockingMenuItem2.Caption = "退出";
            this.barDockingMenuItem2.Id = 2;
            this.barDockingMenuItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barDockingMenuItem2.ImageOptions.Image")));
            this.barDockingMenuItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barDockingMenuItem2.ImageOptions.LargeImage")));
            this.barDockingMenuItem2.Name = "barDockingMenuItem2";
            this.barDockingMenuItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barDockingMenuItem2_ItemClick);
            // 
            // barDockingMenuItem3
            // 
            this.barDockingMenuItem3.Caption = "修改";
            this.barDockingMenuItem3.Id = 3;
            this.barDockingMenuItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barDockingMenuItem3.ImageOptions.Image")));
            this.barDockingMenuItem3.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barDockingMenuItem3.ImageOptions.LargeImage")));
            this.barDockingMenuItem3.Name = "barDockingMenuItem3";
            this.barDockingMenuItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SaveButton_Click);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "基本資料";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barDockingMenuItem3);
            this.ribbonPageGroup1.ItemLinks.Add(this.barDockingMenuItem2);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "基本功能作業";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 597);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(986, 32);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 261);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 22);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "公司名稱";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(519, 261);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 22);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "公司簡稱";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(23, 301);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(72, 22);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "公司地址";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(23, 340);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(72, 22);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "郵遞區號";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(519, 340);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(72, 22);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "公司統編";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(23, 381);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(72, 22);
            this.labelControl6.TabIndex = 7;
            this.labelControl6.Text = "公司電話";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(519, 381);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(72, 22);
            this.labelControl7.TabIndex = 8;
            this.labelControl7.Text = "公司傳真";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(23, 418);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(72, 22);
            this.labelControl9.TabIndex = 12;
            this.labelControl9.Text = "公司網站";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(519, 418);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(86, 22);
            this.labelControl10.TabIndex = 13;
            this.labelControl10.Text = "公司E-Mail";
            // 
            // companyText
            // 
            this.companyText.Location = new System.Drawing.Point(127, 258);
            this.companyText.MenuManager = this.ribbon;
            this.companyText.Name = "companyText";
            this.companyText.Size = new System.Drawing.Size(371, 28);
            this.companyText.TabIndex = 14;
            // 
            // shortText
            // 
            this.shortText.Location = new System.Drawing.Point(624, 255);
            this.shortText.MenuManager = this.ribbon;
            this.shortText.Name = "shortText";
            this.shortText.Size = new System.Drawing.Size(338, 28);
            this.shortText.TabIndex = 15;
            // 
            // addressText
            // 
            this.addressText.Location = new System.Drawing.Point(127, 298);
            this.addressText.MenuManager = this.ribbon;
            this.addressText.Name = "addressText";
            this.addressText.Size = new System.Drawing.Size(835, 28);
            this.addressText.TabIndex = 16;
            // 
            // zipText
            // 
            this.zipText.Location = new System.Drawing.Point(127, 337);
            this.zipText.MenuManager = this.ribbon;
            this.zipText.Name = "zipText";
            this.zipText.Size = new System.Drawing.Size(371, 28);
            this.zipText.TabIndex = 17;
            // 
            // taxText
            // 
            this.taxText.Location = new System.Drawing.Point(624, 337);
            this.taxText.MenuManager = this.ribbon;
            this.taxText.Name = "taxText";
            this.taxText.Size = new System.Drawing.Size(338, 28);
            this.taxText.TabIndex = 18;
            // 
            // phoneText
            // 
            this.phoneText.Location = new System.Drawing.Point(127, 378);
            this.phoneText.MenuManager = this.ribbon;
            this.phoneText.Name = "phoneText";
            this.phoneText.Size = new System.Drawing.Size(371, 28);
            this.phoneText.TabIndex = 19;
            // 
            // faxText
            // 
            this.faxText.Location = new System.Drawing.Point(624, 378);
            this.faxText.MenuManager = this.ribbon;
            this.faxText.Name = "faxText";
            this.faxText.Size = new System.Drawing.Size(338, 28);
            this.faxText.TabIndex = 20;
            // 
            // websiteText
            // 
            this.websiteText.Location = new System.Drawing.Point(127, 415);
            this.websiteText.MenuManager = this.ribbon;
            this.websiteText.Name = "websiteText";
            this.websiteText.Size = new System.Drawing.Size(371, 28);
            this.websiteText.TabIndex = 21;
            // 
            // emailText
            // 
            this.emailText.Location = new System.Drawing.Point(624, 415);
            this.emailText.MenuManager = this.ribbon;
            this.emailText.Name = "emailText";
            this.emailText.Size = new System.Drawing.Size(338, 28);
            this.emailText.TabIndex = 22;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(23, 460);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(81, 22);
            this.labelControl8.TabIndex = 23;
            this.labelControl8.Text = "公司 Logo";
            // 
            // logoBox
            // 
            this.logoBox.Location = new System.Drawing.Point(138, 460);
            this.logoBox.MenuManager = this.ribbon;
            this.logoBox.Name = "logoBox";
            this.logoBox.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.logoBox.Size = new System.Drawing.Size(147, 131);
            this.logoBox.TabIndex = 24;
            // 
            // CompanyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 629);
            this.Controls.Add(this.logoBox);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.emailText);
            this.Controls.Add(this.websiteText);
            this.Controls.Add(this.faxText);
            this.Controls.Add(this.phoneText);
            this.Controls.Add(this.taxText);
            this.Controls.Add(this.zipText);
            this.Controls.Add(this.addressText);
            this.Controls.Add(this.shortText);
            this.Controls.Add(this.companyText);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "CompanyForm";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "公司基本資料維護";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CompanyForm_FormClosed);
            this.Load += new System.EventHandler(this.CompanyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shortText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zipText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phoneText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.faxText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.websiteText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarDockingMenuItem barDockingMenuItem1;
        private DevExpress.XtraBars.BarDockingMenuItem barDockingMenuItem2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit companyText;
        private DevExpress.XtraEditors.TextEdit shortText;
        private DevExpress.XtraEditors.TextEdit addressText;
        private DevExpress.XtraEditors.TextEdit zipText;
        private DevExpress.XtraEditors.TextEdit taxText;
        private DevExpress.XtraEditors.TextEdit phoneText;
        private DevExpress.XtraEditors.TextEdit faxText;
        private DevExpress.XtraEditors.TextEdit websiteText;
        private DevExpress.XtraEditors.TextEdit emailText;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.PictureEdit logoBox;
        private DevExpress.XtraBars.BarDockingMenuItem barDockingMenuItem3;
    }
}
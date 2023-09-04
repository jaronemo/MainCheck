namespace FabricMain.BaseData
{
    partial class SingleEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingleEmployee));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barDockingMenuItem1 = new DevExpress.XtraBars.BarDockingMenuItem();
            this.barDockingMenuItem2 = new DevExpress.XtraBars.BarDockingMenuItem();
            this.barDockingMenuItem3 = new DevExpress.XtraBars.BarDockingMenuItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtAccount = new DevExpress.XtraEditors.TextEdit();
            this.txtPasswd = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtGender = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtDepartment = new DevExpress.XtraEditors.TextEdit();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.passwordTipLabel = new System.Windows.Forms.Label();
            this.txtBirthDay = new DevExpress.XtraEditors.DateEdit();
            this.txtEntryDate = new DevExpress.XtraEditors.DateEdit();
            this.permissionGroup = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirthDay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirthDay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntryDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntryDate.Properties.CalendarTimeProperties)).BeginInit();
            this.permissionGroup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 267);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 22);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "帳號名稱";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.barDockingMenuItem1,
            this.barDockingMenuItem2,
            this.barDockingMenuItem3});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            this.ribbonControl1.Size = new System.Drawing.Size(609, 238);
            // 
            // barDockingMenuItem1
            // 
            this.barDockingMenuItem1.Caption = "儲存";
            this.barDockingMenuItem1.Id = 1;
            this.barDockingMenuItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barDockingMenuItem1.ImageOptions.Image")));
            this.barDockingMenuItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barDockingMenuItem1.ImageOptions.LargeImage")));
            this.barDockingMenuItem1.Name = "barDockingMenuItem1";
            this.barDockingMenuItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barDockingMenuItem1_ItemClick);
            // 
            // barDockingMenuItem2
            // 
            this.barDockingMenuItem2.Caption = "儲存及退出";
            this.barDockingMenuItem2.Id = 2;
            this.barDockingMenuItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barDockingMenuItem2.ImageOptions.Image")));
            this.barDockingMenuItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barDockingMenuItem2.ImageOptions.LargeImage")));
            this.barDockingMenuItem2.Name = "barDockingMenuItem2";
            this.barDockingMenuItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barDockingMenuItem2_ItemClick);
            // 
            // barDockingMenuItem3
            // 
            this.barDockingMenuItem3.Caption = "退出";
            this.barDockingMenuItem3.Id = 3;
            this.barDockingMenuItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barDockingMenuItem3.ImageOptions.Image")));
            this.barDockingMenuItem3.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barDockingMenuItem3.ImageOptions.LargeImage")));
            this.barDockingMenuItem3.Name = "barDockingMenuItem3";
            this.barDockingMenuItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barDockingMenuItem3_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "帳號資料維護";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barDockingMenuItem1);
            this.ribbonPageGroup2.ItemLinks.Add(this.barDockingMenuItem2);
            this.ribbonPageGroup2.ItemLinks.Add(this.barDockingMenuItem3);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "功能作業";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(21, 304);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(76, 22);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "密        碼";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(21, 341);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(76, 22);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "姓        名";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(300, 341);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(71, 22);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "性       別";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(21, 378);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(76, 22);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "部        門";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(21, 417);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(76, 22);
            this.labelControl6.TabIndex = 7;
            this.labelControl6.Text = "電        話";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(21, 455);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(76, 22);
            this.labelControl7.TabIndex = 8;
            this.labelControl7.Text = "生        日";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(21, 494);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(72, 22);
            this.labelControl8.TabIndex = 9;
            this.labelControl8.Text = "入職日期";
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(120, 264);
            this.txtAccount.MenuManager = this.ribbonControl1;
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(251, 28);
            this.txtAccount.TabIndex = 12;
            // 
            // txtPasswd
            // 
            this.txtPasswd.Location = new System.Drawing.Point(120, 301);
            this.txtPasswd.MenuManager = this.ribbonControl1;
            this.txtPasswd.Name = "txtPasswd";
            this.txtPasswd.Size = new System.Drawing.Size(251, 28);
            this.txtPasswd.TabIndex = 13;
            this.txtPasswd.TextChanged += new System.EventHandler(this.txtPasswd_TextChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(120, 338);
            this.txtName.MenuManager = this.ribbonControl1;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(158, 28);
            this.txtName.TabIndex = 14;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtGender
            // 
            this.txtGender.Location = new System.Drawing.Point(392, 338);
            this.txtGender.MenuManager = this.ribbonControl1;
            this.txtGender.Name = "txtGender";
            this.txtGender.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtGender.Properties.DropDownRows = 2;
            this.txtGender.Properties.Items.AddRange(new object[] {
            "男",
            "女"});
            this.txtGender.Size = new System.Drawing.Size(158, 28);
            this.txtGender.TabIndex = 15;
            this.txtGender.SelectedIndexChanged += new System.EventHandler(this.txtGender_SelectedIndexChanged);
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(120, 375);
            this.txtDepartment.MenuManager = this.ribbonControl1;
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(158, 28);
            this.txtDepartment.TabIndex = 17;
            this.txtDepartment.TextChanged += new System.EventHandler(this.txtDepartment_TextChanged);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(120, 414);
            this.txtPhone.MenuManager = this.ribbonControl1;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(158, 28);
            this.txtPhone.TabIndex = 18;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // passwordTipLabel
            // 
            this.passwordTipLabel.AutoSize = true;
            this.passwordTipLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passwordTipLabel.Location = new System.Drawing.Point(378, 301);
            this.passwordTipLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordTipLabel.Name = "passwordTipLabel";
            this.passwordTipLabel.Size = new System.Drawing.Size(226, 24);
            this.passwordTipLabel.TabIndex = 21;
            this.passwordTipLabel.Text = "(修改資料需填密碼)";
            // 
            // txtBirthDay
            // 
            this.txtBirthDay.EditValue = null;
            this.txtBirthDay.Location = new System.Drawing.Point(120, 452);
            this.txtBirthDay.MenuManager = this.ribbonControl1;
            this.txtBirthDay.Name = "txtBirthDay";
            this.txtBirthDay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtBirthDay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtBirthDay.Properties.DisplayFormat.FormatString = "";
            this.txtBirthDay.Properties.EditFormat.FormatString = "";
            this.txtBirthDay.Properties.Mask.EditMask = "";
            this.txtBirthDay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtBirthDay.Size = new System.Drawing.Size(158, 28);
            this.txtBirthDay.TabIndex = 19;
            // 
            // txtEntryDate
            // 
            this.txtEntryDate.EditValue = null;
            this.txtEntryDate.Location = new System.Drawing.Point(120, 491);
            this.txtEntryDate.MenuManager = this.ribbonControl1;
            this.txtEntryDate.Name = "txtEntryDate";
            this.txtEntryDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtEntryDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtEntryDate.Properties.DisplayFormat.FormatString = "";
            this.txtEntryDate.Properties.EditFormat.FormatString = "";
            this.txtEntryDate.Properties.Mask.EditMask = "";
            this.txtEntryDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtEntryDate.Size = new System.Drawing.Size(158, 28);
            this.txtEntryDate.TabIndex = 20;
            // 
            // permissionGroup
            // 
            this.permissionGroup.Controls.Add(this.groupBox2);
            this.permissionGroup.Enabled = false;
            this.permissionGroup.Location = new System.Drawing.Point(21, 537);
            this.permissionGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.permissionGroup.Name = "permissionGroup";
            this.permissionGroup.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.permissionGroup.Size = new System.Drawing.Size(547, 248);
            this.permissionGroup.TabIndex = 28;
            this.permissionGroup.TabStop = false;
            this.permissionGroup.Text = "權限";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox7);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Location = new System.Drawing.Point(9, 29);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(531, 152);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基礎資料維護";
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(9, 63);
            this.checkBox7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(180, 26);
            this.checkBox7.TabIndex = 6;
            this.checkBox7.Tag = "G";
            this.checkBox7.Text = "客戶基本資料維護";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 29);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(144, 26);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Tag = "A";
            this.checkBox1.Text = "個人資料維護";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // SingleEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 922);
            this.Controls.Add(this.permissionGroup);
            this.Controls.Add(this.passwordTipLabel);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPasswd);
            this.Controls.Add(this.txtAccount);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtGender);
            this.Controls.Add(this.txtBirthDay);
            this.Controls.Add(this.txtEntryDate);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "SingleEmployee";
            this.Ribbon = this.ribbonControl1;
            this.Text = "帳號維護作業";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SingleEmployee_FormClosing);
            this.Load += new System.EventHandler(this.SingleEmployee_Load);
            this.Shown += new System.EventHandler(this.SingleEmployee_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirthDay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirthDay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntryDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntryDate.Properties)).EndInit();
            this.permissionGroup.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarDockingMenuItem barDockingMenuItem1;
        private DevExpress.XtraBars.BarDockingMenuItem barDockingMenuItem2;
        private DevExpress.XtraBars.BarDockingMenuItem barDockingMenuItem3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtAccount;
        private DevExpress.XtraEditors.TextEdit txtPasswd;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.ComboBoxEdit txtGender;
        private DevExpress.XtraEditors.TextEdit txtDepartment;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private System.Windows.Forms.Label passwordTipLabel;
        private DevExpress.XtraEditors.DateEdit txtBirthDay;
        private DevExpress.XtraEditors.DateEdit txtEntryDate;
        private System.Windows.Forms.GroupBox permissionGroup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
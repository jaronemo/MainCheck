namespace FabricMain.BaseData
{
    partial class PasswordPrompt
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPw = new DevExpress.XtraEditors.TextEdit();
            this.BtnDone = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtPw.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(28, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(54, 22);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "密碼：";
            // 
            // txtPw
            // 
            this.txtPw.Location = new System.Drawing.Point(102, 13);
            this.txtPw.Name = "txtPw";
            this.txtPw.Size = new System.Drawing.Size(277, 28);
            this.txtPw.TabIndex = 1;
            // 
            // BtnDone
            // 
            this.BtnDone.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnDone.Appearance.Options.UseBackColor = true;
            this.BtnDone.Location = new System.Drawing.Point(77, 72);
            this.BtnDone.Name = "BtnDone";
            this.BtnDone.Size = new System.Drawing.Size(112, 34);
            this.BtnDone.TabIndex = 2;
            this.BtnDone.Text = "確認";
            this.BtnDone.Click += new System.EventHandler(this.BtnDone_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtnCancel.Appearance.Options.UseBackColor = true;
            this.BtnCancel.Location = new System.Drawing.Point(251, 72);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(112, 34);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // PasswordPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 118);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnDone);
            this.Controls.Add(this.txtPw);
            this.Controls.Add(this.labelControl1);
            this.Name = "PasswordPrompt";
            this.Text = "特殊模式密碼驗證";
            ((System.ComponentModel.ISupportInitialize)(this.txtPw.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtPw;
        private DevExpress.XtraEditors.SimpleButton BtnDone;
        private DevExpress.XtraEditors.SimpleButton BtnCancel;
    }
}
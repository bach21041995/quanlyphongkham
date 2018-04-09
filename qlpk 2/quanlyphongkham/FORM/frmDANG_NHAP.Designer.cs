namespace quanlyphongkham.FORM
{
    partial class frmDANG_NHAP
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDANG_NHAP));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnDangNhap = new DevExpress.XtraEditors.SimpleButton();
            this.txtMK = new DevExpress.XtraEditors.TextEdit();
            this.txtTK = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTK.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnDangNhap);
            this.panelControl1.Controls.Add(this.txtMK);
            this.panelControl1.Controls.Add(this.txtTK);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(360, 193);
            this.panelControl1.TabIndex = 0;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.btnDangNhap.Appearance.Options.UseFont = true;
            this.btnDangNhap.Appearance.Options.UseForeColor = true;
            this.btnDangNhap.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnDangNhap.Location = new System.Drawing.Point(137, 139);
            this.btnDangNhap.LookAndFeel.SkinName = "Glass Oceans";
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(87, 34);
            this.btnDangNhap.TabIndex = 4;
            this.btnDangNhap.Text = "LOGIN";
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            this.btnDangNhap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnDangNhap_KeyDown);
            // 
            // txtMK
            // 
            this.txtMK.Location = new System.Drawing.Point(137, 90);
            this.txtMK.Name = "txtMK";
            this.txtMK.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMK.Properties.Appearance.Options.UseFont = true;
            this.txtMK.Properties.UseSystemPasswordChar = true;
            this.txtMK.Size = new System.Drawing.Size(177, 26);
            this.txtMK.TabIndex = 3;
            this.txtMK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMK_KeyDown);
            // 
            // txtTK
            // 
            this.txtTK.Location = new System.Drawing.Point(137, 34);
            this.txtTK.Name = "txtTK";
            this.txtTK.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTK.Properties.Appearance.Options.UseFont = true;
            this.txtTK.Size = new System.Drawing.Size(177, 26);
            this.txtTK.TabIndex = 2;
            this.txtTK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTK_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(27, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "PASSWORD";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(27, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "USERNAME";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2013";
            // 
            // frmDANG_NHAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 193);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDANG_NHAP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐĂNG NHẬP";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDANG_NHAP_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTK.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnDangNhap;
        private DevExpress.XtraEditors.TextEdit txtMK;
        private DevExpress.XtraEditors.TextEdit txtTK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
    }
}
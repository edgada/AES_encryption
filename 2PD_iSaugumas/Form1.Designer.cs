namespace _2PD_iSaugumas
{
    partial class PagrindisLangas
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
            this.btnAtkoduoti = new System.Windows.Forms.Button();
            this.lblUzkoduotaInfo = new System.Windows.Forms.Label();
            this.ZinuteTextBox = new System.Windows.Forms.TextBox();
            this.btnUzkoduoti = new System.Windows.Forms.Button();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.lblSmsInfo = new System.Windows.Forms.Label();
            this.lblKeyInfo = new System.Windows.Forms.Label();
            this.txtUzkoduota = new System.Windows.Forms.TextBox();
            this.txtBoxAtkoduota = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAtkoduoti
            // 
            this.btnAtkoduoti.Enabled = false;
            this.btnAtkoduoti.Location = new System.Drawing.Point(21, 307);
            this.btnAtkoduoti.Name = "btnAtkoduoti";
            this.btnAtkoduoti.Size = new System.Drawing.Size(298, 40);
            this.btnAtkoduoti.TabIndex = 0;
            this.btnAtkoduoti.Text = "Atkoduoti";
            this.btnAtkoduoti.UseVisualStyleBackColor = true;
            this.btnAtkoduoti.Click += new System.EventHandler(this.btnAtkoduoti_Click);
            // 
            // lblUzkoduotaInfo
            // 
            this.lblUzkoduotaInfo.AutoSize = true;
            this.lblUzkoduotaInfo.Location = new System.Drawing.Point(18, 235);
            this.lblUzkoduotaInfo.MaximumSize = new System.Drawing.Size(298, 0);
            this.lblUzkoduotaInfo.MinimumSize = new System.Drawing.Size(298, 0);
            this.lblUzkoduotaInfo.Name = "lblUzkoduotaInfo";
            this.lblUzkoduotaInfo.Size = new System.Drawing.Size(298, 13);
            this.lblUzkoduotaInfo.TabIndex = 1;
            this.lblUzkoduotaInfo.Text = "Užkoduota naudojant AES:";
            // 
            // ZinuteTextBox
            // 
            this.ZinuteTextBox.Location = new System.Drawing.Point(21, 39);
            this.ZinuteTextBox.MaxLength = 16;
            this.ZinuteTextBox.Name = "ZinuteTextBox";
            this.ZinuteTextBox.Size = new System.Drawing.Size(298, 20);
            this.ZinuteTextBox.TabIndex = 3;
            // 
            // btnUzkoduoti
            // 
            this.btnUzkoduoti.Location = new System.Drawing.Point(21, 148);
            this.btnUzkoduoti.Name = "btnUzkoduoti";
            this.btnUzkoduoti.Size = new System.Drawing.Size(298, 40);
            this.btnUzkoduoti.TabIndex = 4;
            this.btnUzkoduoti.Text = "Uzkoduoti";
            this.btnUzkoduoti.UseVisualStyleBackColor = true;
            this.btnUzkoduoti.Click += new System.EventHandler(this.btnUzkoduoti_Click);
            // 
            // keyTextBox
            // 
            this.keyTextBox.Location = new System.Drawing.Point(21, 105);
            this.keyTextBox.MaxLength = 16;
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.Size = new System.Drawing.Size(298, 20);
            this.keyTextBox.TabIndex = 5;
            // 
            // lblSmsInfo
            // 
            this.lblSmsInfo.AutoSize = true;
            this.lblSmsInfo.Location = new System.Drawing.Point(18, 23);
            this.lblSmsInfo.Name = "lblSmsInfo";
            this.lblSmsInfo.Size = new System.Drawing.Size(93, 13);
            this.lblSmsInfo.TabIndex = 6;
            this.lblSmsInfo.Text = "16 simbolių žinutė:";
            // 
            // lblKeyInfo
            // 
            this.lblKeyInfo.AutoSize = true;
            this.lblKeyInfo.Location = new System.Drawing.Point(18, 89);
            this.lblKeyInfo.Name = "lblKeyInfo";
            this.lblKeyInfo.Size = new System.Drawing.Size(94, 13);
            this.lblKeyInfo.TabIndex = 7;
            this.lblKeyInfo.Text = "16 simbolių raktas:";
            // 
            // txtUzkoduota
            // 
            this.txtUzkoduota.Enabled = false;
            this.txtUzkoduota.Location = new System.Drawing.Point(21, 251);
            this.txtUzkoduota.Name = "txtUzkoduota";
            this.txtUzkoduota.Size = new System.Drawing.Size(298, 20);
            this.txtUzkoduota.TabIndex = 8;
            // 
            // txtBoxAtkoduota
            // 
            this.txtBoxAtkoduota.Enabled = false;
            this.txtBoxAtkoduota.Location = new System.Drawing.Point(21, 381);
            this.txtBoxAtkoduota.Name = "txtBoxAtkoduota";
            this.txtBoxAtkoduota.Size = new System.Drawing.Size(298, 20);
            this.txtBoxAtkoduota.TabIndex = 9;
            // 
            // PagrindisLangas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 454);
            this.Controls.Add(this.txtBoxAtkoduota);
            this.Controls.Add(this.txtUzkoduota);
            this.Controls.Add(this.lblKeyInfo);
            this.Controls.Add(this.lblSmsInfo);
            this.Controls.Add(this.keyTextBox);
            this.Controls.Add(this.btnUzkoduoti);
            this.Controls.Add(this.ZinuteTextBox);
            this.Controls.Add(this.lblUzkoduotaInfo);
            this.Controls.Add(this.btnAtkoduoti);
            this.Name = "PagrindisLangas";
            this.Text = "AES algoritmas (128bit key)";
            this.Load += new System.EventHandler(this.PagrindisLangas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAtkoduoti;
        private System.Windows.Forms.Label lblUzkoduotaInfo;
        private System.Windows.Forms.TextBox ZinuteTextBox;
        private System.Windows.Forms.Button btnUzkoduoti;
        private System.Windows.Forms.TextBox keyTextBox;
        private System.Windows.Forms.Label lblSmsInfo;
        private System.Windows.Forms.Label lblKeyInfo;
        private System.Windows.Forms.TextBox txtUzkoduota;
        private System.Windows.Forms.TextBox txtBoxAtkoduota;
    }
}


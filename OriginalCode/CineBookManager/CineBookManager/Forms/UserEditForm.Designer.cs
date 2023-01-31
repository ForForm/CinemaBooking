namespace CineBookManager.Forms
{
    partial class UserEditForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonOkay = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelUserCode = new System.Windows.Forms.Label();
            this.textBoxUserCode = new System.Windows.Forms.TextBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelMailAddress = new System.Windows.Forms.Label();
            this.labelDeleted = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxMailAddress = new System.Windows.Forms.TextBox();
            this.checkBoxDeleted = new System.Windows.Forms.CheckBox();
            this.labelNewPassword = new System.Windows.Forms.Label();
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxNewPassword, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelNewPassword, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxMailAddress, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxUserName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonOkay, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonCancel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelUserCode, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxUserCode, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelUserName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelMailAddress, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxDeleted, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelDeleted, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(334, 161);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonOkay
            // 
            this.buttonOkay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOkay.Location = new System.Drawing.Point(109, 130);
            this.buttonOkay.Name = "buttonOkay";
            this.buttonOkay.Size = new System.Drawing.Size(222, 26);
            this.buttonOkay.TabIndex = 1;
            this.buttonOkay.TabStop = false;
            this.buttonOkay.Text = "OK";
            this.buttonOkay.UseVisualStyleBackColor = true;
            this.buttonOkay.Click += new System.EventHandler(this.buttonOkay_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Location = new System.Drawing.Point(3, 130);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 26);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.TabStop = false;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelUserCode
            // 
            this.labelUserCode.AutoSize = true;
            this.labelUserCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelUserCode.Location = new System.Drawing.Point(3, 0);
            this.labelUserCode.Name = "labelUserCode";
            this.labelUserCode.Size = new System.Drawing.Size(100, 26);
            this.labelUserCode.TabIndex = 2;
            this.labelUserCode.Text = "User Code:";
            this.labelUserCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxUserCode
            // 
            this.textBoxUserCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxUserCode.Location = new System.Drawing.Point(109, 3);
            this.textBoxUserCode.Name = "textBoxUserCode";
            this.textBoxUserCode.Size = new System.Drawing.Size(222, 20);
            this.textBoxUserCode.TabIndex = 0;
            this.textBoxUserCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxName_KeyDown);
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelUserName.Location = new System.Drawing.Point(3, 26);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(100, 26);
            this.labelUserName.TabIndex = 3;
            this.labelUserName.Text = "User Name:";
            this.labelUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMailAddress
            // 
            this.labelMailAddress.AutoSize = true;
            this.labelMailAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMailAddress.Location = new System.Drawing.Point(3, 52);
            this.labelMailAddress.Name = "labelMailAddress";
            this.labelMailAddress.Size = new System.Drawing.Size(100, 26);
            this.labelMailAddress.TabIndex = 4;
            this.labelMailAddress.Text = "Mail Address:";
            this.labelMailAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDeleted
            // 
            this.labelDeleted.AutoSize = true;
            this.labelDeleted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDeleted.Location = new System.Drawing.Point(3, 104);
            this.labelDeleted.Name = "labelDeleted";
            this.labelDeleted.Size = new System.Drawing.Size(100, 23);
            this.labelDeleted.TabIndex = 5;
            this.labelDeleted.Text = "Deleted:";
            this.labelDeleted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxUserName.Location = new System.Drawing.Point(109, 29);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(222, 20);
            this.textBoxUserName.TabIndex = 6;
            // 
            // textBoxMailAddress
            // 
            this.textBoxMailAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMailAddress.Location = new System.Drawing.Point(109, 55);
            this.textBoxMailAddress.Name = "textBoxMailAddress";
            this.textBoxMailAddress.Size = new System.Drawing.Size(222, 20);
            this.textBoxMailAddress.TabIndex = 7;
            // 
            // checkBoxDeleted
            // 
            this.checkBoxDeleted.AutoSize = true;
            this.checkBoxDeleted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxDeleted.Location = new System.Drawing.Point(109, 107);
            this.checkBoxDeleted.Name = "checkBoxDeleted";
            this.checkBoxDeleted.Size = new System.Drawing.Size(222, 17);
            this.checkBoxDeleted.TabIndex = 8;
            this.checkBoxDeleted.Text = "No";
            this.checkBoxDeleted.UseVisualStyleBackColor = true;
            // 
            // labelNewPassword
            // 
            this.labelNewPassword.AutoSize = true;
            this.labelNewPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNewPassword.Location = new System.Drawing.Point(3, 78);
            this.labelNewPassword.Name = "labelNewPassword";
            this.labelNewPassword.Size = new System.Drawing.Size(100, 26);
            this.labelNewPassword.TabIndex = 9;
            this.labelNewPassword.Text = "New Password:";
            this.labelNewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxNewPassword.Location = new System.Drawing.Point(109, 81);
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.PasswordChar = '*';
            this.textBoxNewPassword.Size = new System.Drawing.Size(222, 20);
            this.textBoxNewPassword.TabIndex = 10;
            // 
            // UserEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 160);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Form";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonOkay;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelUserCode;
        private System.Windows.Forms.TextBox textBoxUserCode;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelMailAddress;
        private System.Windows.Forms.Label labelDeleted;
        private System.Windows.Forms.TextBox textBoxMailAddress;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.CheckBox checkBoxDeleted;
        private System.Windows.Forms.TextBox textBoxNewPassword;
        private System.Windows.Forms.Label labelNewPassword;
    }
}
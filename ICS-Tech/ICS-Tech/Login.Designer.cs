namespace ICS_Tech
{
    partial class Login
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.AvtoLoginText = new System.Windows.Forms.TextBox();
            this.LoginSaveText = new System.Windows.Forms.TextBox();
            this.AvtoLogin = new System.Windows.Forms.CheckBox();
            this.LoginSave = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tPassword = new System.Windows.Forms.TextBox();
            this.tLogin = new System.Windows.Forms.TextBox();
            this.bLogin = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridViewTable = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AvtoLoginText);
            this.panel1.Controls.Add(this.LoginSaveText);
            this.panel1.Controls.Add(this.AvtoLogin);
            this.panel1.Controls.Add(this.LoginSave);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tPassword);
            this.panel1.Controls.Add(this.tLogin);
            this.panel1.Controls.Add(this.bLogin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 141);
            this.panel1.TabIndex = 61;
            // 
            // AvtoLoginText
            // 
            this.AvtoLoginText.Location = new System.Drawing.Point(180, 116);
            this.AvtoLoginText.Name = "AvtoLoginText";
            this.AvtoLoginText.Size = new System.Drawing.Size(83, 20);
            this.AvtoLoginText.TabIndex = 20;
            this.AvtoLoginText.Visible = false;
            // 
            // LoginSaveText
            // 
            this.LoginSaveText.Location = new System.Drawing.Point(180, 90);
            this.LoginSaveText.Name = "LoginSaveText";
            this.LoginSaveText.Size = new System.Drawing.Size(83, 20);
            this.LoginSaveText.TabIndex = 19;
            this.LoginSaveText.Visible = false;
            // 
            // AvtoLogin
            // 
            this.AvtoLogin.AutoSize = true;
            this.AvtoLogin.Location = new System.Drawing.Point(63, 116);
            this.AvtoLogin.Name = "AvtoLogin";
            this.AvtoLogin.Size = new System.Drawing.Size(73, 17);
            this.AvtoLogin.TabIndex = 16;
            this.AvtoLogin.Text = "Автовход";
            this.AvtoLogin.UseVisualStyleBackColor = true;
            // 
            // LoginSave
            // 
            this.LoginSave.AutoSize = true;
            this.LoginSave.Location = new System.Drawing.Point(63, 93);
            this.LoginSave.Name = "LoginSave";
            this.LoginSave.Size = new System.Drawing.Size(79, 17);
            this.LoginSave.TabIndex = 15;
            this.LoginSave.Text = "Сохранить";
            this.LoginSave.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Пароль";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Логин";
            // 
            // tPassword
            // 
            this.tPassword.Location = new System.Drawing.Point(63, 38);
            this.tPassword.Name = "tPassword";
            this.tPassword.Size = new System.Drawing.Size(209, 20);
            this.tPassword.TabIndex = 12;
            this.tPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tPassword_KeyDown);
            // 
            // tLogin
            // 
            this.tLogin.Location = new System.Drawing.Point(63, 12);
            this.tLogin.Name = "tLogin";
            this.tLogin.Size = new System.Drawing.Size(209, 20);
            this.tLogin.TabIndex = 11;
            // 
            // bLogin
            // 
            this.bLogin.Location = new System.Drawing.Point(12, 64);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(260, 23);
            this.bLogin.TabIndex = 10;
            this.bLogin.Text = "Логин";
            this.bLogin.UseVisualStyleBackColor = true;
            this.bLogin.Click += new System.EventHandler(this.bLogin_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridViewTable);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(294, 141);
            this.panel4.TabIndex = 63;
            // 
            // dataGridViewTable
            // 
            this.dataGridViewTable.AllowUserToAddRows = false;
            this.dataGridViewTable.AllowUserToDeleteRows = false;
            this.dataGridViewTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTable.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTable.Name = "dataGridViewTable";
            this.dataGridViewTable.Size = new System.Drawing.Size(294, 141);
            this.dataGridViewTable.TabIndex = 11;
            this.dataGridViewTable.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(293, 347);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 62;
            this.label3.Text = "Монеты";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 141);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label3);
            this.Name = "Login";
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox AvtoLoginText;
        private System.Windows.Forms.TextBox LoginSaveText;
        private System.Windows.Forms.CheckBox AvtoLogin;
        private System.Windows.Forms.CheckBox LoginSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tPassword;
        private System.Windows.Forms.TextBox tLogin;
        private System.Windows.Forms.Button bLogin;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridViewTable;
        private System.Windows.Forms.Label label3;
    }
}
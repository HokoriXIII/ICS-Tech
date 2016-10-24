namespace ICS_Tech
{
    partial class Main
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
            this.messages = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.zakazi = new System.Windows.Forms.Button();
            this.users = new System.Windows.Forms.Button();
            this.kurs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // messages
            // 
            this.messages.Dock = System.Windows.Forms.DockStyle.Top;
            this.messages.Location = new System.Drawing.Point(0, 69);
            this.messages.Name = "messages";
            this.messages.Size = new System.Drawing.Size(284, 23);
            this.messages.TabIndex = 11;
            this.messages.Text = "Сообщения (+)";
            this.messages.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Location = new System.Drawing.Point(0, 241);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(284, 20);
            this.textBox1.TabIndex = 10;
            // 
            // zakazi
            // 
            this.zakazi.Dock = System.Windows.Forms.DockStyle.Top;
            this.zakazi.Location = new System.Drawing.Point(0, 46);
            this.zakazi.Name = "zakazi";
            this.zakazi.Size = new System.Drawing.Size(284, 23);
            this.zakazi.TabIndex = 9;
            this.zakazi.Text = "Заказы и обработка заказов (+)";
            this.zakazi.UseVisualStyleBackColor = true;
            // 
            // users
            // 
            this.users.Dock = System.Windows.Forms.DockStyle.Top;
            this.users.Location = new System.Drawing.Point(0, 23);
            this.users.Name = "users";
            this.users.Size = new System.Drawing.Size(284, 23);
            this.users.TabIndex = 8;
            this.users.Text = "Пользователи и добавление новых (+)";
            this.users.UseVisualStyleBackColor = true;
            // 
            // kurs
            // 
            this.kurs.Dock = System.Windows.Forms.DockStyle.Top;
            this.kurs.Location = new System.Drawing.Point(0, 0);
            this.kurs.Name = "kurs";
            this.kurs.Size = new System.Drawing.Size(284, 23);
            this.kurs.TabIndex = 7;
            this.kurs.Text = "Изменение курса (+)";
            this.kurs.UseVisualStyleBackColor = true;
            this.kurs.Click += new System.EventHandler(this.kurs_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.messages);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.zakazi);
            this.Controls.Add(this.users);
            this.Controls.Add(this.kurs);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button messages;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button zakazi;
        private System.Windows.Forms.Button users;
        private System.Windows.Forms.Button kurs;
    }
}
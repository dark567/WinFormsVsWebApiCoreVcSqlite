namespace WinFormsApp
{
    partial class SecondForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGetUsers = new System.Windows.Forms.Button();
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.labelCountUsers = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel2.Controls.Add(this.listBoxUsers);
            this.panel2.Location = new System.Drawing.Point(243, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(320, 228);
            this.panel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.labelCountUsers);
            this.panel1.Controls.Add(this.labelUser);
            this.panel1.Controls.Add(this.btnGetUsers);
            this.panel1.Location = new System.Drawing.Point(7, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 228);
            this.panel1.TabIndex = 2;
            // 
            // btnGetUsers
            // 
            this.btnGetUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGetUsers.Location = new System.Drawing.Point(15, 172);
            this.btnGetUsers.Name = "btnGetUsers";
            this.btnGetUsers.Size = new System.Drawing.Size(201, 49);
            this.btnGetUsers.TabIndex = 0;
            this.btnGetUsers.Text = "Вернуться";
            this.btnGetUsers.UseVisualStyleBackColor = true;
            this.btnGetUsers.Click += new System.EventHandler(this.btnGetUsers_Click);
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.Location = new System.Drawing.Point(0, 0);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(320, 228);
            this.listBoxUsers.TabIndex = 0;
            // 
            // labelCountUsers
            // 
            this.labelCountUsers.AutoSize = true;
            this.labelCountUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCountUsers.Location = new System.Drawing.Point(12, 36);
            this.labelCountUsers.Name = "labelCountUsers";
            this.labelCountUsers.Size = new System.Drawing.Size(0, 17);
            this.labelCountUsers.TabIndex = 4;
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUser.Location = new System.Drawing.Point(12, 22);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(99, 17);
            this.labelUser.TabIndex = 3;
            this.labelUser.Text = "В базе всего: ";
            // 
            // SecondForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 237);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(583, 276);
            this.MinimumSize = new System.Drawing.Size(583, 276);
            this.Name = "SecondForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Текущий пользователь: ";
            this.Load += new System.EventHandler(this.SecondForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGetUsers;
        private System.Windows.Forms.Label labelCountUsers;
        private System.Windows.Forms.Label labelUser;
    }
}
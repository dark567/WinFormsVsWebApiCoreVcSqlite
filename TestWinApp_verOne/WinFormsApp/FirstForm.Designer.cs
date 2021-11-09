namespace WinFormsApp
{
    partial class FirstForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelCountUsers = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.btnGetUsers = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxSity = new System.Windows.Forms.TextBox();
            this.textBoxFIO = new System.Windows.Forms.TextBox();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.labelCountUsers);
            this.panel1.Controls.Add(this.labelUser);
            this.panel1.Controls.Add(this.btnGetUsers);
            this.panel1.Location = new System.Drawing.Point(6, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 228);
            this.panel1.TabIndex = 0;
            // 
            // labelCountUsers
            // 
            this.labelCountUsers.AutoSize = true;
            this.labelCountUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCountUsers.Location = new System.Drawing.Point(12, 36);
            this.labelCountUsers.Name = "labelCountUsers";
            this.labelCountUsers.Size = new System.Drawing.Size(0, 17);
            this.labelCountUsers.TabIndex = 2;
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUser.Location = new System.Drawing.Point(12, 22);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(99, 17);
            this.labelUser.TabIndex = 1;
            this.labelUser.Text = "В базе всего: ";
            // 
            // btnGetUsers
            // 
            this.btnGetUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGetUsers.Location = new System.Drawing.Point(15, 172);
            this.btnGetUsers.Name = "btnGetUsers";
            this.btnGetUsers.Size = new System.Drawing.Size(201, 49);
            this.btnGetUsers.TabIndex = 0;
            this.btnGetUsers.Text = "Список \r\nпользователей";
            this.btnGetUsers.UseVisualStyleBackColor = true;
            this.btnGetUsers.Click += new System.EventHandler(this.btnGetUsers_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel2.Controls.Add(this.textBoxSity);
            this.panel2.Controls.Add(this.textBoxFIO);
            this.panel2.Controls.Add(this.btnSaveUser);
            this.panel2.Location = new System.Drawing.Point(242, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(320, 228);
            this.panel2.TabIndex = 1;
            // 
            // textBoxSity
            // 
            this.textBoxSity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSity.Location = new System.Drawing.Point(8, 62);
            this.textBoxSity.Name = "textBoxSity";
            this.textBoxSity.Size = new System.Drawing.Size(305, 23);
            this.textBoxSity.TabIndex = 5;
            this.textBoxSity.TextChanged += new System.EventHandler(this.textBoxSity_TextChanged);
            this.textBoxSity.Enter += new System.EventHandler(this.textBoxSity_Enter);
            this.textBoxSity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSity_KeyPress);
            // 
            // textBoxFIO
            // 
            this.textBoxFIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFIO.Location = new System.Drawing.Point(8, 16);
            this.textBoxFIO.Name = "textBoxFIO";
            this.textBoxFIO.Size = new System.Drawing.Size(305, 23);
            this.textBoxFIO.TabIndex = 3;
            this.textBoxFIO.TextChanged += new System.EventHandler(this.textBoxFIO_TextChanged);
            this.textBoxFIO.Enter += new System.EventHandler(this.textBoxFIO_Enter);
            this.textBoxFIO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFIO_KeyPress);
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.Enabled = false;
            this.btnSaveUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveUser.Location = new System.Drawing.Point(8, 172);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(305, 49);
            this.btnSaveUser.TabIndex = 1;
            this.btnSaveUser.Text = "Записать";
            this.btnSaveUser.UseVisualStyleBackColor = true;
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // FirstForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 237);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(583, 276);
            this.MinimumSize = new System.Drawing.Size(583, 276);
            this.Name = "FirstForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Текущий пользователь: ";
            this.Load += new System.EventHandler(this.FirstForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGetUsers;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSaveUser;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.TextBox textBoxSity;
        private System.Windows.Forms.TextBox textBoxFIO;
        private System.Windows.Forms.Label labelCountUsers;
    }
}


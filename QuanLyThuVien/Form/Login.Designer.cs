namespace QuanLyThuVien
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txt_UserName = new TextBox();
            txt_Pass = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            bt_Cancel = new Button();
            bt_Login = new Button();
            SuspendLayout();
            // 
            // txt_UserName
            // 
            txt_UserName.Location = new Point(281, 199);
            txt_UserName.Name = "txt_UserName";
            txt_UserName.Size = new Size(747, 47);
            txt_UserName.TabIndex = 0;
            // 
            // txt_Pass
            // 
            txt_Pass.Location = new Point(281, 338);
            txt_Pass.Name = "txt_Pass";
            txt_Pass.Size = new Size(747, 47);
            txt_Pass.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 199);
            label1.Name = "label1";
            label1.Size = new Size(143, 41);
            label1.TabIndex = 1;
            label1.Text = "Tài khoản";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(66, 338);
            label2.Name = "label2";
            label2.Size = new Size(142, 41);
            label2.TabIndex = 1;
            label2.Text = "Mật khẩu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.9000006F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(452, 54);
            label3.Name = "label3";
            label3.Size = new Size(172, 72);
            label3.TabIndex = 1;
            label3.Text = "Login";
            // 
            // bt_Cancel
            // 
            bt_Cancel.Location = new Point(840, 499);
            bt_Cancel.Name = "bt_Cancel";
            bt_Cancel.Size = new Size(188, 58);
            bt_Cancel.TabIndex = 3;
            bt_Cancel.Text = "Thoát";
            bt_Cancel.UseVisualStyleBackColor = true;
            // 
            // bt_Login
            // 
            bt_Login.Location = new Point(596, 499);
            bt_Login.Name = "bt_Login";
            bt_Login.Size = new Size(188, 58);
            bt_Login.TabIndex = 0;
            bt_Login.Text = "Đăng nhập";
            bt_Login.UseVisualStyleBackColor = true;
            bt_Login.Click += bt_Login_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1085, 647);
            Controls.Add(bt_Login);
            Controls.Add(bt_Cancel);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(txt_Pass);
            Controls.Add(txt_UserName);
            Name = "Login";
            Text = "Đăng nhập";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_UserName;
        private TextBox txt_Pass;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button bt_Cancel;
        private Button bt_Login;
    }
}
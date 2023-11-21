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
            UserName = new TextBox();
            Pass = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // UserName
            // 
            UserName.Location = new Point(281, 199);
            UserName.Name = "UserName";
            UserName.Size = new Size(747, 47);
            UserName.TabIndex = 0;
            // 
            // Pass
            // 
            Pass.Location = new Point(281, 338);
            Pass.Name = "Pass";
            Pass.Size = new Size(747, 47);
            Pass.TabIndex = 0;
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
            label3.Location = new Point(393, 38);
            label3.Name = "label3";
            label3.Size = new Size(172, 72);
            label3.TabIndex = 1;
            label3.Text = "Login";
            // 
            // button1
            // 
            button1.Location = new Point(840, 499);
            button1.Name = "button1";
            button1.Size = new Size(188, 58);
            button1.TabIndex = 2;
            button1.Text = "Thoát";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(596, 499);
            button2.Name = "button2";
            button2.Size = new Size(188, 58);
            button2.TabIndex = 2;
            button2.Text = "Đăng nhập";
            button2.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1085, 647);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(Pass);
            Controls.Add(UserName);
            Name = "Login";
            Text = "Đăng nhập";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UserName;
        private TextBox Pass;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button2;
    }
}
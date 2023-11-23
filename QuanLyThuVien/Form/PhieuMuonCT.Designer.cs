namespace QuanLyThuVien
{
    partial class PhieuMuonCT
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
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            panel2 = new Panel();
            textBox1 = new TextBox();
            label1 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            textBox4 = new TextBox();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(18, 368);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 102;
            dataGridView1.RowTemplate.Height = 49;
            dataGridView1.Size = new Size(1812, 750);
            dataGridView1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(19, 19);
            panel1.Name = "panel1";
            panel1.Size = new Size(1284, 323);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(1350, 19);
            panel2.Name = "panel2";
            panel2.Size = new Size(480, 323);
            panel2.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(269, 25);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(437, 47);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 28);
            label1.Name = "label1";
            label1.Size = new Size(260, 41);
            label1.TabIndex = 1;
            label1.Text = "ID phiếu mượn CT";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(269, 139);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(437, 47);
            textBox2.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 139);
            label2.Name = "label2";
            label2.Size = new Size(217, 41);
            label2.TabIndex = 1;
            label2.Text = "ID phiếu mượn";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(269, 253);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(437, 47);
            textBox3.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 250);
            label3.Name = "label3";
            label3.Size = new Size(211, 41);
            label3.TabIndex = 1;
            label3.Text = "ID sách chi tiết";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(900, 34);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(362, 263);
            textBox4.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(760, 28);
            label4.Name = "label4";
            label4.Size = new Size(119, 41);
            label4.TabIndex = 1;
            label4.Text = "Ghi chú";
            // 
            // button1
            // 
            button1.Location = new Point(3, 34);
            button1.Name = "button1";
            button1.Size = new Size(477, 58);
            button1.TabIndex = 0;
            button1.Text = "Thêm";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(3, 112);
            button2.Name = "button2";
            button2.Size = new Size(477, 58);
            button2.TabIndex = 0;
            button2.Text = "Sửa";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(0, 199);
            button3.Name = "button3";
            button3.Size = new Size(477, 58);
            button3.TabIndex = 0;
            button3.Text = "Xóa";
            button3.UseVisualStyleBackColor = true;
            // 
            // PhieuMuonCT
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1842, 1136);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Name = "PhieuMuonCT";
            Text = "Phiếu mượn chi tiết";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Panel panel1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Panel panel2;
        private Button button3;
        private Button button2;
        private Button button1;
    }
}
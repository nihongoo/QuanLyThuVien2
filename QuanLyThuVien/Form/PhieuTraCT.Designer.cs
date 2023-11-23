namespace QuanLyThuVien
{
    partial class PhieuTraCT
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
            panel2 = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel1 = new Panel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            button4 = new Button();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(1347, 19);
            panel2.Name = "panel2";
            panel2.Size = new Size(480, 323);
            panel2.TabIndex = 5;
            // 
            // button3
            // 
            button3.Location = new Point(0, 220);
            button3.Name = "button3";
            button3.Size = new Size(477, 58);
            button3.TabIndex = 0;
            button3.Text = "Báo cáo vi phạm";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(0, 86);
            button2.Name = "button2";
            button2.Size = new Size(477, 58);
            button2.TabIndex = 0;
            button2.Text = "Sửa";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(0, 19);
            button1.Name = "button1";
            button1.Size = new Size(477, 58);
            button1.TabIndex = 0;
            button1.Text = "Thêm";
            button1.UseVisualStyleBackColor = true;
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
            panel1.Location = new Point(16, 19);
            panel1.Name = "panel1";
            panel1.Size = new Size(1284, 323);
            panel1.TabIndex = 4;
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 250);
            label3.Name = "label3";
            label3.Size = new Size(211, 41);
            label3.TabIndex = 1;
            label3.Text = "ID sách chi tiết";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 139);
            label2.Name = "label2";
            label2.Size = new Size(173, 41);
            label2.TabIndex = 1;
            label2.Text = "ID phiếu trả";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 28);
            label1.Name = "label1";
            label1.Size = new Size(216, 41);
            label1.TabIndex = 1;
            label1.Text = "ID phiếu trả CT";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(900, 34);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(362, 263);
            textBox4.TabIndex = 0;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(269, 253);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(437, 47);
            textBox3.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(269, 139);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(437, 47);
            textBox2.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(269, 25);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(437, 47);
            textBox1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(15, 368);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 102;
            dataGridView1.RowTemplate.Height = 49;
            dataGridView1.Size = new Size(1812, 750);
            dataGridView1.TabIndex = 3;
            // 
            // button4
            // 
            button4.Location = new Point(0, 153);
            button4.Name = "button4";
            button4.Size = new Size(477, 58);
            button4.TabIndex = 0;
            button4.Text = "Xóa";
            button4.UseVisualStyleBackColor = true;
            // 
            // PhieuTraCT
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1842, 1136);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Name = "PhieuTraCT";
            Text = "PhieuTraCT";
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Panel panel1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private DataGridView dataGridView1;
    }
}
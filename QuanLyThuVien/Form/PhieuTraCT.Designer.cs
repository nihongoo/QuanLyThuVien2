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
            button2 = new Button();
            button1 = new Button();
            panel1 = new Panel();
            cbxIDSachCT = new ComboBox();
            cbxIDPhieuT = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtGhiChu = new TextBox();
            txtIDPhieuTCT = new TextBox();
            dgvPhieuTra = new DataGridView();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhieuTra).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(1347, 19);
            panel2.Name = "panel2";
            panel2.Size = new Size(480, 323);
            panel2.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(0, 179);
            button2.Name = "button2";
            button2.Size = new Size(477, 58);
            button2.TabIndex = 0;
            button2.Text = "Sửa";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(0, 74);
            button1.Name = "button1";
            button1.Size = new Size(477, 58);
            button1.TabIndex = 0;
            button1.Text = "Thêm";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(cbxIDSachCT);
            panel1.Controls.Add(cbxIDPhieuT);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtGhiChu);
            panel1.Controls.Add(txtIDPhieuTCT);
            panel1.Location = new Point(16, 19);
            panel1.Name = "panel1";
            panel1.Size = new Size(1284, 323);
            panel1.TabIndex = 4;
            // 
            // cbxIDSachCT
            // 
            cbxIDSachCT.FormattingEnabled = true;
            cbxIDSachCT.Location = new Point(269, 242);
            cbxIDSachCT.Name = "cbxIDSachCT";
            cbxIDSachCT.Size = new Size(437, 49);
            cbxIDSachCT.TabIndex = 2;
            // 
            // cbxIDPhieuT
            // 
            cbxIDPhieuT.FormattingEnabled = true;
            cbxIDPhieuT.Location = new Point(269, 131);
            cbxIDPhieuT.Name = "cbxIDPhieuT";
            cbxIDPhieuT.Size = new Size(437, 49);
            cbxIDPhieuT.TabIndex = 2;
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
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(900, 34);
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(362, 263);
            txtGhiChu.TabIndex = 0;
            // 
            // txtIDPhieuTCT
            // 
            txtIDPhieuTCT.Location = new Point(269, 25);
            txtIDPhieuTCT.Name = "txtIDPhieuTCT";
            txtIDPhieuTCT.Size = new Size(437, 47);
            txtIDPhieuTCT.TabIndex = 0;
            // 
            // dgvPhieuTra
            // 
            dgvPhieuTra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhieuTra.Location = new Point(15, 368);
            dgvPhieuTra.Name = "dgvPhieuTra";
            dgvPhieuTra.RowHeadersWidth = 102;
            dgvPhieuTra.RowTemplate.Height = 49;
            dgvPhieuTra.Size = new Size(1812, 750);
            dgvPhieuTra.TabIndex = 3;
            dgvPhieuTra.CellClick += dgvPhieuTra_CellClick;
            // 
            // PhieuTraCT
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1842, 1136);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dgvPhieuTra);
            Name = "PhieuTraCT";
            Text = "PhieuTraCT";
            Load += PhieuTraCT_Load;
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhieuTra).EndInit();
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
        private TextBox txtGhiChu;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox txtIDPhieuTCT;
        private DataGridView dgvPhieuTra;
        private ComboBox cbxIDSachCT;
        private ComboBox cbxIDPhieuT;
    }
}
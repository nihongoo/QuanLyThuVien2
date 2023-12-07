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
            dgvPMCT = new DataGridView();
            panel1 = new Panel();
            cbxIDSachCT = new ComboBox();
            cbxPhieuM = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtGhiChu = new TextBox();
            txtIDPMCT = new TextBox();
            panel2 = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPMCT).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvPMCT
            // 
            dgvPMCT.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPMCT.Location = new Point(18, 368);
            dgvPMCT.Name = "dgvPMCT";
            dgvPMCT.RowHeadersWidth = 102;
            dgvPMCT.RowTemplate.Height = 49;
            dgvPMCT.Size = new Size(1812, 750);
            dgvPMCT.TabIndex = 0;
            dgvPMCT.CellClick += dgvPMCT_CellClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(cbxIDSachCT);
            panel1.Controls.Add(cbxPhieuM);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtGhiChu);
            panel1.Controls.Add(txtIDPMCT);
            panel1.Location = new Point(19, 19);
            panel1.Name = "panel1";
            panel1.Size = new Size(1284, 323);
            panel1.TabIndex = 1;
            // 
            // cbxIDSachCT
            // 
            cbxIDSachCT.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxIDSachCT.FormattingEnabled = true;
            cbxIDSachCT.Location = new Point(269, 242);
            cbxIDSachCT.Name = "cbxIDSachCT";
            cbxIDSachCT.Size = new Size(437, 49);
            cbxIDSachCT.TabIndex = 3;
            // 
            // cbxPhieuM
            // 
            cbxPhieuM.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxPhieuM.FormattingEnabled = true;
            cbxPhieuM.Location = new Point(269, 139);
            cbxPhieuM.Name = "cbxPhieuM";
            cbxPhieuM.Size = new Size(437, 49);
            cbxPhieuM.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(753, 34);
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
            label2.Size = new Size(217, 41);
            label2.TabIndex = 1;
            label2.Text = "ID phiếu mượn";
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
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(900, 34);
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(362, 263);
            txtGhiChu.TabIndex = 0;
            // 
            // txtIDPMCT
            // 
            txtIDPMCT.Enabled = false;
            txtIDPMCT.Location = new Point(269, 25);
            txtIDPMCT.Name = "txtIDPMCT";
            txtIDPMCT.Size = new Size(437, 47);
            txtIDPMCT.TabIndex = 0;
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
            // button3
            // 
            button3.Location = new Point(0, 199);
            button3.Name = "button3";
            button3.Size = new Size(477, 58);
            button3.TabIndex = 0;
            button3.Text = "Xóa";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(3, 112);
            button2.Name = "button2";
            button2.Size = new Size(477, 58);
            button2.TabIndex = 0;
            button2.Text = "Sửa";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(3, 34);
            button1.Name = "button1";
            button1.Size = new Size(477, 58);
            button1.TabIndex = 0;
            button1.Text = "Thêm";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PhieuMuonCT
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1842, 1136);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dgvPMCT);
            Name = "PhieuMuonCT";
            Text = "Phiếu mượn chi tiết";
            Load += PhieuMuonCT_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPMCT).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPMCT;
        private Panel panel1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtGhiChu;
        private TextBox txtIDPMCT;
        private Panel panel2;
        private Button button3;
        private Button button2;
        private Button button1;
        private ComboBox cbxIDSachCT;
        private ComboBox cbxPhieuM;
    }
}
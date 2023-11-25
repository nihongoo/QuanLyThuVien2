using BUS.IService;
using BUS.Service;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class MainTT : Form
    {
        private bool isClosing = false;// kiểm tra xem đã gọi phương thức đóng chương trình chưa
        List<PhieuMuon> _lst = new();
        PhieuMSev _PhieuMSev;

        public MainTT()
        {
            InitializeComponent();
            _PhieuMSev = new();
        }

        private void MainTT_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosing)//nếu chưa gọi phương thức đóng chương trình
            {
                isClosing = true; // -> đã gọi
                if (MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", "FormClosing", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    e.Cancel = false; // click ok
                    Application.Exit(); // Đóng toàn bộ ứng dụng
                }
                else
                {
                    e.Cancel = true;// click cancel
                    isClosing = false;// trả về trạng thái chưa gọi phương thức
                }
            }
        }
        private void LoadData()
        {
            dgvMainTT.Rows.Clear();
            dgvMainTT.ColumnCount = 8;
            dgvMainTT.Columns[0].Name = "ID Phieu Muon";
            dgvMainTT.Columns[1].Name = "Ngay Muon";
            dgvMainTT.Columns[2].Name = "Ngay Tra";
            dgvMainTT.Columns[3].Name = "ID Doc Gia";
            dgvMainTT.Columns[4].Name = "Ten Doc Gia";
            dgvMainTT.Columns[5].Name = "ID Nhan Vien";
            dgvMainTT.Columns[6].Name = "Ten Nhan Vien";
            dgvMainTT.Columns[7].Name = "Ghi Chu";

            _lst = _PhieuMSev.GetAll();

            foreach (var item in _lst)
            {
                int stt = _lst.IndexOf(item) + 1;
                dgvMainTT.Rows.Add(item.IDPhieuMuon, item.NgayMuon, item.NgayTra, item.IDDocGia, item.TenDocGia, item.IDNhanVien, item.TenNV, item.GhiChu);
            }
        }

        private void MainTT_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}

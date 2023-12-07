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
        List<PhieuMView> _lst = new();
        List<PhieuTraView> _lst2 = new();
        PhieuMSev _PhieuMSev;
        PhieuTSev _PhieuTSev;
        List<DocGia> _lstDocGia = new();
        List<NhanVienView> _lstNguoiDung = new();
        List<QLMSView> _lstQLMS = new();
        int IdCellPM;
        int IdCellPT;

        public MainTT()
        {
            InitializeComponent();
            _PhieuMSev = new();
            _PhieuTSev = new();
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
        }//dong form
        //tab phieu muon
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
            _lstDocGia = _PhieuMSev.GetRecords<DocGia>();
            _lstNguoiDung = _PhieuMSev.GetRecords<NhanVienView>();

            foreach (var item in _lst)
            {
                int stt = _lst.IndexOf(item) + 1;
                dgvMainTT.Rows.Add(item.IDPhieuMuon, item.NgayMuon, item.NgayTra, item.IDDocGia, item.TenDocGia, item.IDNhanVien, item.TenNV, item.GhiChu);
            }

            cbxIDDocGia.DataSource = _lstDocGia;
            cbxIDDocGia.DisplayMember = "Ten";
            cbxIDDocGia.ValueMember = "IDDocGia";

            cbxIDNhanVien.DataSource = _lstNguoiDung;
            cbxIDNhanVien.DisplayMember = "TenNhanVien";
            cbxIDNhanVien.ValueMember = "IDNhanVien";
        }//Phieu muon
        private void MainTT_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadDataT2();
        }

        private int GetSelectedID(ComboBox comboBox)
        {
            // Xác định giá trị thực sự của item được chọn trong ComboBox
            // (Bạn có thể cần thêm kiểm tra null nếu có thể ComboBox chưa được chọn)
            // Giả sử giá trị là kiểu int, bạn có thể điều chỉnh cho kiểu dữ liệu khác
            return comboBox.SelectedIndex + 1; // Điều chỉnh nếu index bắt đầu từ 0
        }// lấy index combobox

        private void button1_Click(object sender, EventArgs e)//them
        {
            if (string.IsNullOrEmpty(cbxIDNhanVien.Text) ||
    string.IsNullOrEmpty(cbxIDDocGia.Text) ||
    string.IsNullOrEmpty(dpkNgayMuon.Text) ||
    string.IsNullOrEmpty(dpkNgayTra.Text))
            {
                MessageBox.Show("Khong duoc de trong thong tin");
                return;
            }
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {

                _PhieuMSev.Create(new PhieuMuon()
                {
                    NgayMuon = dpkNgayMuon.Value,
                    NgayTra = dpkNgayTra.Value,
                    IDDocGia = GetSelectedID(cbxIDDocGia),
                    IDNhanVien = GetSelectedID(cbxIDNhanVien),
                    GhiChu = txtGhiChu.Text,
                });
                LoadData();
            }
        }

        private void button2_Click(object sender, EventArgs e)//sua
        {

            if (string.IsNullOrEmpty(cbxIDNhanVien.Text) ||
    string.IsNullOrEmpty(cbxIDDocGia.Text) ||
    string.IsNullOrEmpty(dpkNgayMuon.Text) ||
    string.IsNullOrEmpty(dpkNgayTra.Text))
            {
                MessageBox.Show("Khong duoc de trong thong tin");
                return;
            }
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                _PhieuMSev.Update(IdCellPM, new PhieuMuon()
                {
                    // = Convert.ToInt32(txtIDSach.Text),
                    NgayMuon = dpkNgayMuon.Value,
                    NgayTra = dpkNgayTra.Value,
                    IDDocGia = GetSelectedID(cbxIDDocGia),
                    IDNhanVien = GetSelectedID(cbxIDNhanVien),
                    GhiChu = txtGhiChu.Text,
                });
                LoadData();
            }
        }

        private void dgvMainTT_CellClick(object sender, DataGridViewCellEventArgs e)//lấy idcell
        {
            int index = e.RowIndex;
            if (index < 0 || index >= _lst.Count) return;
            var objindex = _lst[index];
            IdCellPM = (int)objindex.IDPhieuMuon;
            txtIDPhieuM.Text = objindex.IDPhieuMuon.ToString();
            dpkNgayMuon.Value = objindex.NgayMuon;
            dpkNgayTra.Value = objindex.NgayTra;
            cbxIDDocGia.Text = objindex.IDDocGia.ToString();
            cbxIDNhanVien.Text = objindex.TenNV;
            txtGhiChu.Text = objindex.GhiChu;
        }

        private void button3_Click(object sender, EventArgs e)//xoa
        {
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                _PhieuMSev.Delete(IdCellPM);
                LoadData();
            }
        }

        private void button4_Click(object sender, EventArgs e)//quan ly phieu muon chi tiet
        {
            PhieuMuonCT pmct = new PhieuMuonCT();
            pmct.ShowDialog();
        }

        //tab phieu tra

        private void LoadDataT2()
        {
            dgvPhieuT.Rows.Clear();
            dgvPhieuT.ColumnCount = 8;
            dgvPhieuT.Columns[0].Name = "ID Phieu Tra";
            dgvPhieuT.Columns[1].Name = "Ngay Muon";
            dgvPhieuT.Columns[2].Name = "Ngay Tra";
            dgvPhieuT.Columns[3].Name = "ID Doc Gia";
            dgvPhieuT.Columns[4].Name = "Ten Doc Gia";
            dgvPhieuT.Columns[5].Name = "ID Nhan Vien";
            dgvPhieuT.Columns[6].Name = "Ten Nhan Vien";
            dgvPhieuT.Columns[7].Name = "Ghi Chu";

            _lst2 = _PhieuTSev.GetAll();
            _lstDocGia = _PhieuMSev.GetRecords<DocGia>();
            _lstNguoiDung = _PhieuMSev.GetRecords<NhanVienView>();

            foreach (var item in _lst2)
            {
                int stt = _lst2.IndexOf(item) + 1;
                dgvPhieuT.Rows.Add(item.IDPhieuTra, item.NgayMuon, item.NgayTra, item.IDDocGia, item.TenDocGia, item.IDNhanVien, item.TenNV, item.GhiChu);
            }

            cbxIDDocGiaT2.DataSource = _lstDocGia;
            cbxIDDocGiaT2.DisplayMember = "Ten";
            cbxIDDocGiaT2.ValueMember = "IDDocGia";

            cbxIDNhanVienT2.DataSource = _lstNguoiDung;
            cbxIDNhanVienT2.DisplayMember = "TenNhanVien";
            cbxIDNhanVienT2.ValueMember = "IDNhanVien";
        }//Phieu muon

        private void button8_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbxIDNhanVienT2.Text) ||
string.IsNullOrEmpty(cbxIDDocGiaT2.Text) ||
string.IsNullOrEmpty(dpkNgayMuonT2.Text) ||
string.IsNullOrEmpty(dpkNgayTraT2.Text))
            {
                MessageBox.Show("Khong duoc de trong thong tin");
                return;
            }
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {

                _PhieuTSev.Create(new PhieuTra()
                {
                    NgayMuon = dpkNgayMuonT2.Value,
                    NgayTra = dpkNgayTraT2.Value,
                    IDDocGia = GetSelectedID(cbxIDDocGiaT2),
                    IDNhanVien = GetSelectedID(cbxIDNhanVienT2),
                    GhiChu = txtGhiChuT2.Text,
                });
                LoadDataT2();
            }
        }//them

        private void dgvPhieuT_CellClick(object sender, DataGridViewCellEventArgs e)//idcell tab phieu tra
        {
            int index = e.RowIndex;
            if (index < 0 || index >= _lst2.Count) return;
            var objindex = _lst2[index];
            IdCellPT = (int)objindex.IDPhieuTra;
            txtIDPhieuT.Text = objindex.IDPhieuTra.ToString();
            dpkNgayMuonT2.Value = objindex.NgayMuon;
            dpkNgayTraT2.Value = objindex.NgayTra;
            cbxIDDocGiaT2.Text = objindex.IDDocGia.ToString();
            cbxIDNhanVienT2.Text = objindex.TenNV;
            txtGhiChuT2.Text = objindex.GhiChu;
        }

        private void button7_Click(object sender, EventArgs e)//sua
        {
            if (string.IsNullOrEmpty(cbxIDNhanVienT2.Text) ||
string.IsNullOrEmpty(cbxIDDocGiaT2.Text) ||
string.IsNullOrEmpty(dpkNgayMuonT2.Text) ||
string.IsNullOrEmpty(dpkNgayTraT2.Text))
            {
                MessageBox.Show("Khong duoc de trong thong tin");
                return;
            }
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                _PhieuTSev.Update(IdCellPT, new PhieuTra()
                {
                    NgayMuon = dpkNgayMuonT2.Value,
                    NgayTra = dpkNgayTraT2.Value,
                    IDDocGia = GetSelectedID(cbxIDDocGiaT2),
                    IDNhanVien = GetSelectedID(cbxIDNhanVienT2),
                    GhiChu = txtGhiChuT2.Text,
                });
                LoadDataT2();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PhieuTraCT ptct = new PhieuTraCT();
            ptct.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)// show quanlymuonsach
        {
            LoadList();
        }
        private void LoadList()
        {
            dgvPhieuT.Rows.Clear();
            dgvPhieuT.ColumnCount = 5;
            dgvPhieuT.Columns[0].Name = "Id Doc Gia";
            dgvPhieuT.Columns[1].Name = "Ten Doc Gia";
            dgvPhieuT.Columns[2].Name = "ID sach chi tiet";
            dgvPhieuT.Columns[3].Name = "Ten Sach";
            dgvPhieuT.Columns[4].Name = "Ghi chu";

            _lstQLMS = _PhieuTSev.GetQLMS();

            foreach (var item in _lstQLMS)
            {
                int stt = _lstQLMS.IndexOf(item) + 1;
                dgvPhieuT.Rows.Add(item.IDDocGia, item.TenDocGia, item.IDSachCT, item.TenSach, item.GhiChu);
            }
        }
    }
}

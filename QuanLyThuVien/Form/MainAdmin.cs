using BUS.Service;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class MainAdmin : Form
    {
        private bool isClosing = false;// kiểm tra xem đã gọi phương thức đóng chương trình chưa
        List<NguoiDung> _lst = new();
        List<NgonNgu> _lstNgonNgu = new();
        List<DocGia> _lstDG = new();
        List<SachView> _lst1 = new();
        List<TheLoaiSach> _lstTheLoai = new();
        List<TacGia> _lstTacGia = new();
        List<PhieuMView> _lst3 = new();
        List<PhieuTraView> _lst2 = new();
        List<DocGia> _lstDocGia = new();
        List<NhanVienView> _lstNguoiDung = new();
        List<QLMSView> _lstQLMS = new();

        UserSev _UserSev;
        SachSev _SachSev;
        DocGiaSev _DocGiaSev;
        PhieuMSev _PhieuMSev;
        PhieuTSev _PhieuTSev;

        string idCell;
        int IdCell;
        int IdCellDG;
        int IdCellPM;
        int IdCellPT;

        public MainAdmin()
        {
            InitializeComponent();
            _UserSev = new();
            _SachSev = new();
            _DocGiaSev = new();
            _PhieuMSev = new();
            _PhieuTSev = new();
        }

        private void MainAdmin_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //LoadData();
        }
        private void LoadData(string Search, string Type)
        {
            dataGridView5.DataSource = null;
            dataGridView5.Rows.Clear();
            dataGridView5.ColumnCount = 8;
            dataGridView5.Columns[0].Name = "Tai Khoan";
            dataGridView5.Columns[1].Name = "Mat Khau";
            dataGridView5.Columns[2].Name = "Ten";
            dataGridView5.Columns[3].Name = "Email";
            dataGridView5.Columns[4].Name = "Dia Chi";
            dataGridView5.Columns[5].Name = "Ngay Sinh";
            dataGridView5.Columns[6].Name = "SDT";
            dataGridView5.Columns[7].Name = "Quyen";

            _lst = _UserSev.GetAll(Search, Type);

            foreach (var item in _lst)
            {
                int stt = _lst.IndexOf(item) + 1;
                dataGridView5.Rows.Add(item.TaiKhoan, item.MatKhau, item.Ten, item.Email, item.DiaChi, item.NgaySinh, item.SDT, item.Quyen);
            }
        }

        private void MainAdmin_Load(object sender, EventArgs e)
        {
            LoadData(null, null);
            LoadData1(null, null);
            LoadData2();
            LoadDataT2();
        }

        private void button20_Click(object sender, EventArgs e)//create
        {
            if (string.IsNullOrEmpty(txtUser.Text) ||
                string.IsNullOrEmpty(txtPass.Text) ||
                string.IsNullOrEmpty(txtMail.Text) ||
                string.IsNullOrEmpty(cbxQuyen.Text) ||
                string.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Khong duoc de trong thong tin");
                return;
            }
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {

                _UserSev.Create(new NguoiDung()
                {
                    TaiKhoan = txtUser.Text,
                    MatKhau = txtPass.Text,
                    Ten = txtTen.Text,
                    Email = txtMail.Text,
                    DiaChi = txtDiaChi.Text,
                    NgaySinh = dateTimePicker1.Value,
                    SDT = txtSdt.Text,
                    Quyen = cbxQuyen.Text,
                });
                LoadData(null, null);
            }
        }
        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)//lấy tài khoản và fill lên textbox khi cell click
        {
            int index = e.RowIndex;
            if (index < 0 || index >= _lst.Count) return;
            var objindex = _lst[index];
            idCell = objindex.TaiKhoan;
            txtUser.Text = objindex.TaiKhoan;
            txtPass.Text = objindex.MatKhau;
            txtTen.Text = objindex.Ten;
            txtMail.Text = objindex.Email;
            txtDiaChi.Text = objindex.DiaChi;
            txtSdt.Text = objindex.SDT;
            dateTimePicker1.Value = DateTime.Parse(objindex.NgaySinh.ToString());
            cbxQuyen.Text = objindex.Quyen;
        }

        private void button21_Click(object sender, EventArgs e)//Update
        {
            if (string.IsNullOrEmpty(txtUser.Text) ||
                string.IsNullOrEmpty(txtPass.Text) ||
                string.IsNullOrEmpty(txtMail.Text) ||
                string.IsNullOrEmpty(cbxQuyen.Text) ||
                string.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Khong duoc de trong thong tin");
                return;
            }
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                _UserSev.Update(idCell, new NguoiDung()
                {
                    TaiKhoan = txtUser.Text,
                    MatKhau = txtPass.Text,
                    Ten = txtTen.Text,
                    Email = txtMail.Text,
                    DiaChi = txtDiaChi.Text,
                    NgaySinh = dateTimePicker1.Value,
                    SDT = txtSdt.Text,
                    Quyen = cbxQuyen.Text,
                });
                LoadData(null, null);
            }
        }

        private void button22_Click(object sender, EventArgs e)//xóa
        {
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                _UserSev.Delete(idCell);
                LoadData(null, null);
            }
        }

        private void button24_Click(object sender, EventArgs e)//tim
        {
            if (cbxLoc2.Text == "Tên")
            {
                if (string.IsNullOrEmpty(txtFind2.Text))
                {
                    MessageBox.Show("vui long nhap thong tin can tim");
                    txtFind2.Focus();
                }
                LoadData(txtFind2.Text, cbxLoc2.Text);
            }
            else if (cbxLoc2.Text == "Quyền")
            {
                if (string.IsNullOrEmpty(txtFind2.Text))
                {
                    MessageBox.Show("vui long nhap thong tin can tim");
                    txtFind2.Focus();
                }
                LoadData(txtFind2.Text, cbxLoc2.Text);
            }
            else
            {
                LoadData(null, null);
                MessageBox.Show("vui long chon truong loc thong tin");
                cbxLoc2.Focus();
            }
        }

        private void txtSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            txtUser.Text = txtUser.Text.Trim();
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            txtPass.Text = txtPass.Text.Trim();
        }

        /// <summary>
        /// bdh
        /// </summary>
        /// <param name="Search"></param>
        /// <param name="Type"></param>

        private void LoadData1(string Search, string Type)
        {
            //tab sach
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "ID Sach";
            dataGridView1.Columns[1].Name = "Ten Sach";
            dataGridView1.Columns[2].Name = "The Loai";
            dataGridView1.Columns[3].Name = "Ngon Ngu";
            dataGridView1.Columns[4].Name = "Hang Sach";
            dataGridView1.Columns[5].Name = "Tac Gia";
            //tab doc gia
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.ColumnCount = 7;
            dataGridView2.Columns[0].HeaderText = "ID Doc Gia";
            dataGridView2.Columns[1].HeaderText = "Ten Doc Gia";
            dataGridView2.Columns[2].HeaderText = "Dia Chi";
            dataGridView2.Columns[3].HeaderText = "SDT";
            dataGridView2.Columns[4].HeaderText = "Ngay Dang Ky";
            dataGridView2.Columns[5].HeaderText = "Loai The";
            dataGridView2.Columns[6].HeaderText = "CCCD";

            _lst1 = _SachSev.GetAll(Search);
            _lstTheLoai = _SachSev.GetRecords<TheLoaiSach>();//truyền class TheLoaiSach để lấy dữ liệu từ bảng TheLoaiSach
            _lstNgonNgu = _SachSev.GetRecords<NgonNgu>();
            _lstTacGia = _SachSev.GetRecords<TacGia>();
            _lstDG = _DocGiaSev.GetAll(Search, Type);//lấy list doc gia

            foreach (var item in _lst1)
            {
                int stt = _lst1.IndexOf(item) + 1;
                dataGridView1.Rows.Add(item.IDSach, item.TenSach, item.TenTheLoai, item.TenNgonNgu, item.HangSach, item.TenTacGia);
            }

            foreach (var item in _lstDG)
            {
                int stt = _lstDG.IndexOf(item) + 1;
                dataGridView2.Rows.Add(item.IDDocGia, item.Ten, item.DiaChi, item.SDT, item.NgayDangKy, item.LoaiThe, item.CCCD);
            }
            cbxTheLoai.DataSource = _lstTheLoai;
            cbxTheLoai.DisplayMember = "TenTheLoai";
            cbxTheLoai.ValueMember = "IDTheLoai";

            cbxNgonNgu.DataSource = _lstNgonNgu;
            cbxNgonNgu.DisplayMember = "TenNgonNgu";
            cbxNgonNgu.ValueMember = "IDNgonNgu";

            cbxTacGia.DataSource = _lstTacGia;
            cbxTacGia.DisplayMember = "TenTacGia";
            cbxTacGia.ValueMember = "IDTacGia";
        }

        private void button2_Click(object sender, EventArgs e)// create sach
        {
            ThemSach themSach = new ThemSach();
            themSach.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0 || index >= _lst1.Count) return;
            var objindex = _lst1[index];
            IdCell = (int)objindex.IDSach;
            txtIDSach.Text = objindex.IDSach.ToString();
            txtTenSach.Text = objindex.TenSach;
            cbxTheLoai.Text = objindex.TenTheLoai;
            cbxNgonNgu.Text = objindex.TenNgonNgu;
            cbxTacGia.Text = objindex.TenTacGia;
            cbxHangSach.Text = objindex.HangSach;
        }

        private void button3_Click(object sender, EventArgs e)//update sach
        {
            if (string.IsNullOrEmpty(txtIDSach.Text) ||
                string.IsNullOrEmpty(txtTenSach.Text) ||
                string.IsNullOrEmpty(cbxTheLoai.Text) ||
                string.IsNullOrEmpty(cbxNgonNgu.Text) ||
                string.IsNullOrEmpty(cbxHangSach.Text) ||
                string.IsNullOrEmpty(cbxTacGia.Text))
            {
                MessageBox.Show("Khong duoc de trong thong tin");
                return;
            }
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                _SachSev.Update(IdCell, new Sach()
                {
                    IDSach = Convert.ToInt32(txtIDSach.Text),
                    TenSach = txtTenSach.Text,
                    IDTheLoai = Convert.ToInt32(cbxTheLoai.SelectedValue),
                    IDNgonNgu = Convert.ToInt32(cbxNgonNgu.SelectedValue),
                    IDTacGia = Convert.ToInt32(cbxTacGia.SelectedValue),
                    HangSach = cbxHangSach.Text,
                    //TenNgonNgu = cbxNgonNgu.Text,
                    //TenTacGia = cbxTacGia.Text,
                    //TenTheLoai = cbxTheLoai.Text
                });
                LoadData1(null, null);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0 || index >= _lstDG.Count) return;
            var objindex = _lstDG[index];
            IdCellDG = (int)objindex.IDDocGia;
            txtIDDocGia.Text = objindex.IDDocGia.ToString();
            txtTenDocGia.Text = objindex.Ten;
            txtDiaChi1.Text = objindex.DiaChi;
            txtSDT1.Text = objindex.SDT;
            dpkNgayDangKy.Value = DateTime.Parse(objindex.NgayDangKy.ToString());
            cbxLoaiThe.Text = objindex.LoaiThe;
            txtCCCD.Text = objindex.CCCD;
        }

        private void button9_Click(object sender, EventArgs e)// them doc gia
        {
            if (string.IsNullOrEmpty(txtTenDocGia.Text) ||
    string.IsNullOrEmpty(txtDiaChi1.Text) ||
    string.IsNullOrEmpty(txtSDT1.Text) ||
    string.IsNullOrEmpty(dpkNgayDangKy.Text) ||
    string.IsNullOrEmpty(txtCCCD.Text) ||
    string.IsNullOrEmpty(cbxLoaiThe.Text))
            {
                MessageBox.Show("Khong duoc de trong thong tin");
                return;
            }
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {

                _DocGiaSev.Create(new DocGia()
                {
                    //IDDocGia = _lstDG.Count +1,
                    Ten = txtTenDocGia.Text,
                    DiaChi = txtDiaChi1.Text,
                    SDT = txtSDT1.Text,
                    NgayDangKy = dpkNgayDangKy.Value,
                    LoaiThe = cbxLoaiThe.Text,
                    CCCD = txtCCCD.Text,
                });
                LoadData1(null, null);
            }
        }

        private void button10_Click(object sender, EventArgs e)// sua doc gia
        {
            if (string.IsNullOrEmpty(txtTenDocGia.Text) ||
string.IsNullOrEmpty(txtDiaChi1.Text) ||
string.IsNullOrEmpty(txtSDT1.Text) ||
string.IsNullOrEmpty(dpkNgayDangKy.Text) ||
string.IsNullOrEmpty(txtCCCD.Text) ||
string.IsNullOrEmpty(cbxLoaiThe.Text))
            {
                MessageBox.Show("Khong duoc de trong thong tin");
                return;
            }
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {

                _DocGiaSev.Update(IdCellDG, new DocGia()
                {
                    //IDDocGia = _lstDG.Count +1,
                    Ten = txtTenDocGia.Text,
                    DiaChi = txtDiaChi1.Text,
                    SDT = txtSDT1.Text,
                    NgayDangKy = dpkNgayDangKy.Value,
                    LoaiThe = cbxLoaiThe.Text,
                    CCCD = txtCCCD.Text,
                });
                LoadData1(null, null);
            }
        }

        private void button6_Click(object sender, EventArgs e)//Xoa doc gia
        {
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                _DocGiaSev.Delete(IdCellDG);
                LoadData1(null, null);
            }
        }

        private void button8_Click(object sender, EventArgs e)// tim doc gia
        {
            if (cbxLoc.Text == "ID")
            {
                if (string.IsNullOrEmpty(txtFind.Text))
                {
                    MessageBox.Show("vui long nhap thong tin can tim");
                    txtFind.Focus();
                }
                LoadData1(txtFind.Text, cbxLoc.Text);
            }
            else if (cbxLoc.Text == "Tên")
            {
                if (string.IsNullOrEmpty(txtFind.Text))
                {
                    MessageBox.Show("vui long nhap thong tin can tim");
                    txtFind.Focus();
                }
                //dataGridView2.Rows.Clear();
                LoadData1(txtFind.Text, cbxLoc.Text);
            }
            else
            {
                LoadData1(null, null);
                MessageBox.Show("vui long chon truong loc thong tin");
                cbxLoc.Focus();
            }
        }

        private void button7_Click(object sender, EventArgs e)//quan ly membership
        {
            QuanLyMembership qlmem = new QuanLyMembership();
            qlmem.ShowDialog();
        }

        private void btDelete_Click(object sender, EventArgs e)//xóa sách
        {
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                _SachSev.Delete(IdCell);
                LoadData1(null, null);
            }
        }

        private void button4_Click(object sender, EventArgs e)//tìm sách
        {
            if (string.IsNullOrEmpty(txtFindS.Text))
            {
                MessageBox.Show("vui long nhap thong tin can tim");
                LoadData1(null, null);
                txtFindS.Focus();
            }
            else
            {
                LoadData1(txtFindS.Text, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIDSach.Text))
            {
                MessageBox.Show("Hay chon 1 quyen sach de xem chi tiet");
                return;
            }
            int Id = Convert.ToInt32(txtIDSach.Text);
            string tenSach = txtTenSach.Text;
            string tacGia = cbxTacGia.Text;
            string ngonNgu = cbxNgonNgu.Text;
            string theLoai = cbxTheLoai.Text;
            string hangSach = cbxHangSach.Text;

            QuanLySachChiTiet qlSachCT = new(Id, tenSach, tacGia, ngonNgu, theLoai, hangSach);
            qlSachCT.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)//in the
        {
            if (string.IsNullOrEmpty(txtTenDocGia.Text) ||
                string.IsNullOrEmpty(txtIDDocGia.Text) ||
                string.IsNullOrEmpty(txtDiaChi1.Text) ||
                string.IsNullOrEmpty(txtSDT1.Text) ||
                string.IsNullOrEmpty(dpkNgayDangKy.Text) ||
                string.IsNullOrEmpty(txtCCCD.Text) ||
                string.IsNullOrEmpty(cbxLoaiThe.Text))
            {
                MessageBox.Show("Khong duoc de trong thong tin");
                return;
            }
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {

                var cre = _DocGiaSev.Print(new DocGia()
                {
                    IDDocGia = Convert.ToInt32(txtIDDocGia.Text),
                    Ten = txtTenDocGia.Text,
                    DiaChi = txtDiaChi1.Text,
                    SDT = txtSDT1.Text,
                    NgayDangKy = dpkNgayDangKy.Value,
                    LoaiThe = cbxLoaiThe.Text,
                    CCCD = txtCCCD.Text,
                });
                if (cre)
                {
                    MessageBox.Show("In Thanh Cong");
                }
                else
                {
                    MessageBox.Show("In That Bai");
                }
                LoadData1(null, null);
            }
        }

        /// <summary>
        /// user
        /// </summary>
        /// <param name="Search"></param>
        /// <param name="Type"></param>

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
        private void LoadData2()
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

            _lst3 = _PhieuMSev.GetAll();
            _lstDocGia = _PhieuMSev.GetRecords<DocGia>();
            _lstNguoiDung = _PhieuMSev.GetRecords<NhanVienView>();

            foreach (var item in _lst3)
            {
                int stt = _lst3.IndexOf(item) + 1;
                dgvMainTT.Rows.Add(item.IDPhieuMuon, item.NgayMuon, item.NgayTra, item.IDDocGia, item.TenDocGia, item.IDNhanVien, item.TenNV, item.GhiChu);
            }

            cbxIDDocGia.DataSource = _lstDocGia;
            cbxIDDocGia.DisplayMember = "Ten";
            cbxIDDocGia.ValueMember = "IDDocGia";

            cbxIDNhanVien.DataSource = _lstNguoiDung;
            cbxIDNhanVien.DisplayMember = "TenNhanVien";
            cbxIDNhanVien.ValueMember = "IDNhanVien";
        }//Phieu muon

        private int GetSelectedID(ComboBox comboBox)
        {
            // Xác định giá trị thực sự của item được chọn trong ComboBox
            // (Bạn có thể cần thêm kiểm tra null nếu có thể ComboBox chưa được chọn)
            // Giả sử giá trị là kiểu int, bạn có thể điều chỉnh cho kiểu dữ liệu khác
            return comboBox.SelectedIndex + 1; // Điều chỉnh nếu index bắt đầu từ 0
        }// lấy index combobox

        private void btThemPM_Click(object sender, EventArgs e)//them
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
                LoadData2();
            }
        }

        private void btSuaPM_Click(object sender, EventArgs e)//sua
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
                LoadData2();
            }
        }

        private void dgvMainTT_CellClick(object sender, DataGridViewCellEventArgs e)//lấy idcell
        {
            int index = e.RowIndex;
            if (index < 0 || index >= _lst3.Count) return;
            var objindex = _lst3[index];
            IdCellPM = (int)objindex.IDPhieuMuon;
            txtIDPhieuM.Text = objindex.IDPhieuMuon.ToString();
            dpkNgayMuon.Value = objindex.NgayMuon;
            dpkNgayTra.Value = objindex.NgayTra;
            cbxIDDocGia.Text = objindex.IDDocGia.ToString();
            cbxIDNhanVien.Text = objindex.TenNV;
            txtGhiChu.Text = objindex.GhiChu;
        }

        private void btXoaPM_Click(object sender, EventArgs e)//xoa
        {
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                _PhieuMSev.Delete(IdCellPM);
                LoadData2();
            }
        }

        private void btQLPMCT_Click(object sender, EventArgs e)//quan ly phieu muon chi tiet
        {
            PhieuMuonCT pmct = new PhieuMuonCT();
            pmct.ShowDialog();
        }

        //tab phieu tra
        /// <summary>
        /// phieu tra
        /// </summary>

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

        private void btThemPT_Click(object sender, EventArgs e)
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

        private void btSuaPT_Click(object sender, EventArgs e)//sua
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

        private void btQLPTCT_Click(object sender, EventArgs e)
        {
            PhieuTraCT ptct = new PhieuTraCT();
            ptct.ShowDialog();
        }

        private void btShowDSDG_Click(object sender, EventArgs e)// show quanlymuonsach
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

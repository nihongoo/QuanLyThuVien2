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
    public partial class Main : Form
    {
        private bool isClosing = false;// kiểm tra xem đã gọi phương thức đóng chương trình chưa
        List<SachView> _lst = new();
        List<TheLoaiSach> _lstTheLoai = new();
        List<TacGia> _lstTacGia = new();
        List<NgonNgu> _lstNgonNgu = new();
        SachSev _SachSev;
        DocGiaSev _DocGiaSev;
        List<DocGia> _lstDG = new();
        int IdCell;
        int IdCellDG;
        public Main()
        {
            InitializeComponent();
            _SachSev = new();
            _DocGiaSev = new();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosing)
            {
                isClosing = true;
                if (MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", "FormClosing", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    e.Cancel = false;
                    Application.Exit(); // Đóng toàn bộ ứng dụng
                }
                else
                {
                    e.Cancel = true;
                    isClosing = false;
                }
            }
        }


        private void LoadData(string Search, string Type)
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

            _lst = _SachSev.GetAll(Search);
            _lstTheLoai = _SachSev.GetRecords<TheLoaiSach>();//truyền class TheLoaiSach để lấy dữ liệu từ bảng TheLoaiSach
            _lstNgonNgu = _SachSev.GetRecords<NgonNgu>();
            _lstTacGia = _SachSev.GetRecords<TacGia>();
            _lstDG = _DocGiaSev.GetAll(Search, Type);//lấy list doc gia

            foreach (var item in _lst)
            {
                int stt = _lst.IndexOf(item) + 1;
                dataGridView1.Rows.Add(item.IDSach, item.TenSach, item.TenTheLoai, item.TenNgonNgu, item.HangSach, item.TenTacGia);
            }

            //if (_lstDG != null && _lstDG.Count > 0)
            //{
            //    dataGridView2.Rows[0].Selected = true;
            //}

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

        private void Main_Load(object sender, EventArgs e)
        {
            LoadData(null, null);
        }

        private void button2_Click(object sender, EventArgs e)// create sach
        {
            ThemSach themSach = new ThemSach();
            themSach.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0 || index >= _lst.Count) return;
            var objindex = _lst[index];
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
                LoadData(null, null);
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
            txtDiaChi.Text = objindex.DiaChi;
            txtSDT.Text = objindex.SDT;
            dpkNgayDangKy.Value = DateTime.Parse(objindex.NgayDangKy.ToString());
            cbxLoaiThe.Text = objindex.LoaiThe;
            txtCCCD.Text = objindex.CCCD;
        }

        private void button9_Click(object sender, EventArgs e)// them doc gia
        {
            if (string.IsNullOrEmpty(txtTenDocGia.Text) ||
    string.IsNullOrEmpty(txtDiaChi.Text) ||
    string.IsNullOrEmpty(txtSDT.Text) ||
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
                    DiaChi = txtDiaChi.Text,
                    SDT = txtSDT.Text,
                    NgayDangKy = dpkNgayDangKy.Value,
                    LoaiThe = cbxLoaiThe.Text,
                    CCCD = txtCCCD.Text,
                });
                LoadData(null, null);
            }
        }

        private void button10_Click(object sender, EventArgs e)// sua doc gia
        {
            if (string.IsNullOrEmpty(txtTenDocGia.Text) ||
string.IsNullOrEmpty(txtDiaChi.Text) ||
string.IsNullOrEmpty(txtSDT.Text) ||
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
                    DiaChi = txtDiaChi.Text,
                    SDT = txtSDT.Text,
                    NgayDangKy = dpkNgayDangKy.Value,
                    LoaiThe = cbxLoaiThe.Text,
                    CCCD = txtCCCD.Text,
                });
                LoadData(null, null);
            }
        }

        private void button6_Click(object sender, EventArgs e)//Xoa doc gia
        {
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                _DocGiaSev.Delete(IdCellDG);
                LoadData(null, null);
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
                    LoadData(null, null);
                }
                LoadData(txtFind.Text, cbxLoc.Text);
            }
            else if (cbxLoc.Text == "Tên")
            {
                if (string.IsNullOrEmpty(txtFind.Text))
                {
                    MessageBox.Show("vui long nhap thong tin can tim");
                    txtFind.Focus();
                    LoadData(null, null);
                }
                //dataGridView2.Rows.Clear();
                LoadData(txtFind.Text, cbxLoc.Text);
            }
            else
            {
                LoadData(null, null);
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
                LoadData(null, null);
            }
        }

        private void button4_Click(object sender, EventArgs e)//tìm sách
        {
            if (string.IsNullOrEmpty(txtFindS.Text))
            {
                MessageBox.Show("vui long nhap thong tin can tim");
                LoadData(null, null);
                txtFindS.Focus();
            }
            else
            {
                LoadData(txtFindS.Text, null);
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
                string.IsNullOrEmpty(txtDiaChi.Text) ||
                string.IsNullOrEmpty(txtSDT.Text) ||
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
                    DiaChi = txtDiaChi.Text,
                    SDT = txtSDT.Text,
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
                LoadData(null, null);
            }
        }
    }
}

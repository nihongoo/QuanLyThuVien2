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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class QuanLySachChiTiet : Form
    {
        List<SachCTView> _lst = new();
        List<NXB> _lstNXB = new();
        SCTSev _SCTSev;
        NXBSev _NXBSev = new();
        int Id, IdCell, IdCellNXB;
        string tenSach;
        string tacGia;
        string ngonNgu;
        string theLoai;
        string hangSach;

        public QuanLySachChiTiet(int Id, string tenSach, string tacGia, string ngonNgu, string theLoai, string hangSach)
        {
            InitializeComponent();
            _SCTSev = new();
            this.Id = Id;
            this.tenSach = tenSach;
            this.tacGia = tacGia;
            this.ngonNgu = ngonNgu;
            this.theLoai = theLoai;
            this.hangSach = hangSach;
        }
        private void LoadData(int Id, string tenSach, string tacGia, string ngonNgu, string theLoai, string hangSach)
        {
            //tab sach chi tiet
            dgvSachCT.DataSource = null;
            dgvSachCT.Rows.Clear();
            dgvSachCT.ColumnCount = 13;
            dgvSachCT.Columns[0].Name = "ID Sach CT";
            dgvSachCT.Columns[1].Name = "ID Sach";
            dgvSachCT.Columns[2].Name = "Ten Sach";
            dgvSachCT.Columns[3].Name = "Ngay Xuat Ban";
            dgvSachCT.Columns[4].Name = "Ten The Loai";
            dgvSachCT.Columns[5].Name = "Ten Ngon Ngu";
            dgvSachCT.Columns[6].Name = "Ten Tac Gia";
            dgvSachCT.Columns[7].Name = "ID Nha Xuat Ban";
            dgvSachCT.Columns[8].Name = "Ten Nha Xuat Ban";
            dgvSachCT.Columns[9].Name = "Gia";
            dgvSachCT.Columns[10].Name = "So Luong";
            dgvSachCT.Columns[11].Name = "Trang Thai";
            dgvSachCT.Columns[12].Name = "Hang Sach";

            //tab nxb
            dgvNXB.DataSource = null;
            dgvNXB.Rows.Clear();
            dgvNXB.ColumnCount = 3;
            dgvNXB.Columns[0].Name = "Id NXB";
            dgvNXB.Columns[1].Name = "Ten NXB";
            dgvNXB.Columns[2].Name = "Mo Ta";

            _lst = _SCTSev.GetAll(Id);
            _lstNXB = _NXBSev.GetAll();

            foreach (var item in _lst)
            {
                int stt = _lst.IndexOf(item) + 1;
                dgvSachCT.Rows.Add(item.IDSachCT, Id, tenSach, item.NgayXB, theLoai, ngonNgu, tacGia, item.IDNXB, item.TenNXB, item.Gia + " Đ", item.SoLuong, item.TrangThai, hangSach);
            }

            foreach (var item in _lstNXB)
            {
                int stt = _lstNXB.IndexOf(item) + 1;
                dgvNXB.Rows.Add(item.IDNXB, item.TenNXB, item.MoTa);
            }

            txtSach.Text = Id.ToString();


            cbxIDNXB.DataSource = _lstNXB;
            cbxIDNXB.DisplayMember = "IDNXB";
            cbxIDNXB.ValueMember = "IDNXB";

            cbxTenNXB.DataSource = _lstNXB;
            cbxTenNXB.DisplayMember = "TenNXB";
            cbxTenNXB.ValueMember = "IDNXB";
        }
        private int GetSelectedID(ComboBox comboBox)
        {
            // Xác định giá trị thực sự của item được chọn trong ComboBox
            // (Bạn có thể cần thêm kiểm tra null nếu có thể ComboBox chưa được chọn)
            // Giả sử giá trị là kiểu int, bạn có thể điều chỉnh cho kiểu dữ liệu khác
            return comboBox.SelectedIndex + 1; // Điều chỉnh nếu index bắt đầu từ 0
        }// lấy index combobox

        //tab sach chi tiet
        private void QuanLySachChiTiet_Load(object sender, EventArgs e)
        {
            LoadData(Id, tenSach, tacGia, ngonNgu, theLoai, hangSach);
        }

        private void dgvSachCT_CellClick(object sender, DataGridViewCellEventArgs e)//lay Id cell
        {
            int index = e.RowIndex;
            if (index < 0 || index >= _lst.Count) return;
            var objindex = _lst[index];
            IdCell = (int)objindex.IDSachCT;
            txtIDSachCT.Text = objindex.IDSachCT.ToString();
            txtSach.Text = objindex.IDSach.ToString();
            dpkNgayXB.Text = objindex.NgayXB.ToString();
            cbxIDNXB.Text = objindex.IDNXB.ToString();
            txtGia.Text = objindex.Gia + " Đ";
            txtSoLuong.Text = objindex.SoLuong.ToString();
            txtTrangThai.Text = objindex.TrangThai;
            cbxTenNXB.Text = objindex.TenNXB;
        }

        private void button3_Click(object sender, EventArgs e)//thoat
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)//them
        {
            if (string.IsNullOrEmpty(dpkNgayXB.Text) ||
    string.IsNullOrEmpty(cbxIDNXB.Text) ||
    string.IsNullOrEmpty(txtGia.Text) ||
    string.IsNullOrEmpty(txtSoLuong.Text))
            {
                MessageBox.Show("Khong duoc de trong thong tin");
                return;
            }
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                string giaText = txtGia.Text;
                string giaNumberOnly = Regex.Replace(giaText, "[^0-9]", ""); // Giữ lại chỉ số từ 0 đến 9
                int giaValue = 0; // Mặc định giá trị là 0 nếu không có số

                if (int.TryParse(giaNumberOnly, out giaValue))
                {
                    var createdSachCT = _SCTSev.Create(new SachCT()
                    {
                        NgayXB = dpkNgayXB.Value,
                        IDSach = Convert.ToInt32(txtSach.Text),
                        IDNXB = GetSelectedID(cbxIDNXB),
                        Gia = giaValue, // Gán giá trị số vào thuộc tính Gia
                        SoLuong = Convert.ToInt32(txtSoLuong.Text),
                        TrangThai = txtTrangThai.Text,
                    });

                    if (createdSachCT == null)
                    {
                        MessageBox.Show("Quyen sach chi tiet nay da co trong co so du lieu");
                    }
                    else
                    {
                        LoadData(Id, tenSach, tacGia, ngonNgu, theLoai, hangSach);
                    }
                }
                else
                {
                    MessageBox.Show("Giá không hợp lệ. Hãy nhập giá trị số.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//sua
        {
            if (string.IsNullOrEmpty(dpkNgayXB.Text) ||
    string.IsNullOrEmpty(cbxIDNXB.Text) ||
    string.IsNullOrEmpty(txtGia.Text) ||
    string.IsNullOrEmpty(txtSoLuong.Text))
            {
                MessageBox.Show("Khong duoc de trong thong tin");
                return;
            }
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                string giaText = txtGia.Text;
                string giaNumberOnly = Regex.Replace(giaText, "[^0-9]", ""); // Giữ lại chỉ số từ 0 đến 9
                int giaValue = 0; // Mặc định giá trị là 0 nếu không có số

                if (int.TryParse(giaNumberOnly, out giaValue))
                {
                    var createdSachCT = _SCTSev.Update(IdCell, new SachCT()
                    {
                        NgayXB = dpkNgayXB.Value,
                        IDSach = Convert.ToInt32(txtSach.Text),
                        IDNXB = GetSelectedID(cbxIDNXB),
                        Gia = giaValue,
                        SoLuong = Convert.ToInt32(txtSoLuong.Text),
                        TrangThai = txtTrangThai.Text,
                    });
                    LoadData(Id, tenSach, tacGia, ngonNgu, theLoai, hangSach);
                    if (createdSachCT == null)
                    {
                        MessageBox.Show("Quyen sach chi tiet nay da co trong co so du lieu");
                    }
                    else
                    {
                        LoadData(Id, tenSach, tacGia, ngonNgu, theLoai, hangSach);
                    }
                }
                else
                {
                    MessageBox.Show("Giá không hợp lệ. Hãy nhập giá trị số.");
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)//xoa
        {
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                if (IdCell <= 0)
                {
                    MessageBox.Show("vui long chon 1 quyen sach can xoa");
                }
                else
                {
                    _SCTSev.Delete(Convert.ToInt32(txtIDSachCT.Text));
                    LoadData(Id, tenSach, tacGia, ngonNgu, theLoai, hangSach);
                }
            }
        }

        //tab NXB
        private void button4_Click(object sender, EventArgs e)//them
        {
            if (string.IsNullOrEmpty(txtTenNXB.Text))
            {
                MessageBox.Show("Khong duoc de trong thong tin");
                return;
            }
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                _NXBSev.Create(new NXB()
                {
                    TenNXB = txtTenNXB.Text,
                    MoTa = txtMoTa3.Text,
                });
                LoadData(Id, tenSach, tacGia, ngonNgu, theLoai, hangSach);
            }
        }

        private void button5_Click(object sender, EventArgs e)//sua
        {
            if (string.IsNullOrEmpty(txtTenNXB.Text))
            {
                MessageBox.Show("Khong duoc de trong thong tin");
                return;
            }
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                _NXBSev.Update(IdCellNXB, new NXB()
                {
                    TenNXB = txtTenNXB.Text,
                    MoTa = txtMoTa3.Text,
                });
                LoadData(Id, tenSach, tacGia, ngonNgu, theLoai, hangSach);
            }
        }

        private void dgvNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0 || index >= _lstNXB.Count) return;
            var objindex = _lstNXB[index];
            IdCellNXB = Convert.ToInt32(objindex.IDNXB);
            txtIDNXB.Text = objindex.IDNXB.ToString();
            txtTenNXB.Text = objindex.TenNXB;
            txtMoTa3.Text = objindex.MoTa;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                _NXBSev.Delete(IdCellNXB);
                LoadData(Id, tenSach, tacGia, ngonNgu, theLoai, hangSach);
            }
        }
    }
}

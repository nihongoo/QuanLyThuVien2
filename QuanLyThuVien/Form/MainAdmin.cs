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
        UserSev _UserSev;
        string idCell;
        public MainAdmin()
        {
            InitializeComponent();
            _UserSev = new();
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
    }
}

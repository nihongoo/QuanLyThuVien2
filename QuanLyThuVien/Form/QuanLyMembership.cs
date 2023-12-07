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
    public partial class QuanLyMembership : Form
    {
        List<DocGia> _lst = new();
        List<SachView> _lstSachView = new();
        MemberSev _MemberSev;
        int IdCell;
        public QuanLyMembership()
        {
            InitializeComponent();
            _MemberSev = new();
        }

        private void QuanLyMembership_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            dgvMember.DataSource = null;
            dgvMember.Rows.Clear();
            dgvMember.ColumnCount = 7;
            dgvMember.Columns[0].HeaderText = "ID Doc Gia";
            dgvMember.Columns[1].HeaderText = "Ten Doc Gia";
            dgvMember.Columns[2].HeaderText = "Dia Chi";
            dgvMember.Columns[3].HeaderText = "SDT";
            dgvMember.Columns[4].HeaderText = "Ngay Dang Ky";
            dgvMember.Columns[5].HeaderText = "Loai The";
            dgvMember.Columns[6].HeaderText = "CCCD";

            _lst = _MemberSev.GetAll();

            foreach (var item in _lst)
            {
                int stt = _lst.IndexOf(item) + 1;
                dgvMember.Rows.Add(item.IDDocGia, item.Ten, item.DiaChi, item.SDT, item.DiaChi, item.NgayDangKy, item.LoaiThe, item.CCCD);
            }
        }
        private void LoadDataSach()
        {
            dgvMember.DataSource = null;
            dgvMember.Rows.Clear();
            dgvMember.ColumnCount = 6;
            dgvMember.Columns[0].Name = "ID Sach";
            dgvMember.Columns[1].Name = "Ten Sach";
            dgvMember.Columns[2].Name = "The Loai";
            dgvMember.Columns[3].Name = "Ngon Ngu";
            dgvMember.Columns[4].Name = "Hang Sach";
            dgvMember.Columns[5].Name = "Tac Gia";

            _lstSachView = _MemberSev.GetHangSach();

            foreach (var item in _lstSachView)
            {
                int stt = _lstSachView.IndexOf(item) + 1;
                dgvMember.Rows.Add(item.IDSach, item.TenSach, item.TenTheLoai, item.TenNgonNgu, item.HangSach, item.TenTacGia);
            }
        }

        private void dgvMember_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0 || index >= _lst.Count) return;
            var objindex = _lst[index];
            IdCell = (int)objindex.IDDocGia;
            txtIDDocGia.Text = objindex.IDDocGia.ToString();
            txtTenDocGia.Text = objindex.Ten;
            txtDiaChi.Text = objindex.DiaChi;
            txtSDT.Text = objindex.SDT;
            dpkNgayDangKy.Text = objindex.NgayDangKy.ToString();
            txtLoaiThe.Text = objindex.LoaiThe;
            txtCCCD.Text = objindex.CCCD;
        }

        private void button1_Click(object sender, EventArgs e)//hiện list sách vjp
        {
            LoadDataSach();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIDDocGia.Text))
            {
                MessageBox.Show("Hay chon 1 doc gia de thuc hien chuc nang");
                return;
            }
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                _MemberSev.Update(IdCell);
                LoadData();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}

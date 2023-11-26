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
    public partial class ThemSach : Form
    {
        List<Sach> _lst = new();
        List<TheLoaiSach> _lstTheLoai = new();
        List<TacGia> _lstTacGia = new();
        List<NgonNgu> _lstNgonNgu = new();
        SachSev _SachSev;
        public ThemSach()
        {
            InitializeComponent();
            _SachSev = new();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadData()
        {
            dataGridView4.Rows.Clear();
            dataGridView4.ColumnCount = 6;
            dataGridView4.Columns[0].Name = "ID Sach";
            dataGridView4.Columns[1].Name = "Ten Sach";
            dataGridView4.Columns[2].Name = "The Loai";
            dataGridView4.Columns[3].Name = "Ngon Ngu";
            dataGridView4.Columns[4].Name = "Hang Sach";
            dataGridView4.Columns[5].Name = "Tac Gia";

            _lst = _SachSev.GetAll();
            _lstTheLoai = _SachSev.GetRecords<TheLoaiSach>();//truyền class TheLoaiSach để lấy dữ liệu từ bảng TheLoaiSach
            _lstNgonNgu = _SachSev.GetRecords<NgonNgu>();
            _lstTacGia = _SachSev.GetRecords<TacGia>();

            foreach (var item in _lst)
            {
                int stt = _lst.IndexOf(item) + 1;
                dataGridView4.Rows.Add(item.IDSach, item.TenSach, item.TenTheLoai, item.TenNgonNgu, item.HangSach, item.TenTacGia);
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

        private void ThemSach_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button11_Click(object sender, EventArgs e)//create
        {
            if (string.IsNullOrEmpty(txtTenSach.Text) ||
                string.IsNullOrEmpty(cbxTheLoai.Text) ||
                string.IsNullOrEmpty(cbxTacGia.Text) ||
                string.IsNullOrEmpty(cbxHangSach.Text) ||
                string.IsNullOrEmpty(cbxNgonNgu.Text))
            {
                MessageBox.Show("Khong duoc de trong thong tin");
                return;
            }
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {

                _SachSev.Create(new Sach()
                {
                    TenSach = txtTenSach.Text,
                    IDTheLoai = cbxTheLoai.SelectedIndex,
                    IDNgonNgu = cbxNgonNgu.SelectedIndex,
                    IDTacGia = cbxTacGia.SelectedIndex,
                    HangSach = cbxHangSach.Text,
                });
                LoadData();
            }
        }
    }
}

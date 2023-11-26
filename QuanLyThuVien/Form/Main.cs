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
        List<Sach> _lst = new();
        List<TheLoaiSach> _lstTheLoai = new();
        List<TacGia> _lstTacGia = new();
        List<NgonNgu> _lstNgonNgu = new();
        SachSev _SachSev;
        int IdCell;
        public Main()
        {
            InitializeComponent();
            _SachSev = new();
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
        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "ID Sach";
            dataGridView1.Columns[1].Name = "Ten Sach";
            dataGridView1.Columns[2].Name = "The Loai";
            dataGridView1.Columns[3].Name = "Ngon Ngu";
            dataGridView1.Columns[4].Name = "Hang Sach";
            dataGridView1.Columns[5].Name = "Tac Gia";

            _lst = _SachSev.GetAll();
            _lstTheLoai = _SachSev.GetRecords<TheLoaiSach>();//truyền class TheLoaiSach để lấy dữ liệu từ bảng TheLoaiSach
            _lstNgonNgu = _SachSev.GetRecords<NgonNgu>();
            _lstTacGia = _SachSev.GetRecords<TacGia>();

            foreach (var item in _lst)
            {
                int stt = _lst.IndexOf(item) + 1;
                dataGridView1.Rows.Add(item.IDSach, item.TenSach, item.TenTheLoai, item.TenNgonNgu, item.HangSach, item.TenTacGia);
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
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)// create
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

        private void button3_Click(object sender, EventArgs e)//update
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
                    IDTheLoai = Convert.ToInt32(cbxTheLoai.SelectedIndex),
                    IDNgonNgu = Convert.ToInt32(cbxNgonNgu.SelectedIndex),
                    IDTacGia = Convert.ToInt32(cbxTacGia.SelectedIndex),
                    HangSach = cbxHangSach.Text
                });
                LoadData();
            }
        }
    }
}

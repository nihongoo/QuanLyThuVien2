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
        List<SachView> _lst = new();
        List<Sach> _lstS = new();
        List<TheLoaiSach> _lstTheLoai = new();
        List<TacGia> _lstTacGia = new();
        List<NgonNgu> _lstNgonNgu = new();
        SachSev _SachSev;
        int IDSach;
        int IdCell;
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
                IDSach = _lst.Count;
                _SachSev.Create(new Sach()
                {
                    //DSach = IDSach + 1,
                    TenSach = txtTenSach.Text,
                    IDTheLoai = GetSelectedID(cbxTheLoai),
                    IDNgonNgu = GetSelectedID(cbxNgonNgu),
                    IDTacGia = GetSelectedID(cbxTacGia),
                    HangSach = cbxHangSach.Text,
                });
                LoadData();
            }
        }
        private int GetSelectedID(ComboBox comboBox)
        {
            // Xác định giá trị thực sự của item được chọn trong ComboBox
            // (Bạn có thể cần thêm kiểm tra null nếu có thể ComboBox chưa được chọn)
            // Giả sử giá trị là kiểu int, bạn có thể điều chỉnh cho kiểu dữ liệu khác
            return comboBox.SelectedIndex + 1; // Điều chỉnh nếu index bắt đầu từ 0
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
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
    }
}

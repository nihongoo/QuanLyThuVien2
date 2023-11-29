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
        TacGiaSev _TacGiaSev = new();
        TheLoaiSachSev _TheLoaiSev = new();
        NgonNguSev _NgonNguSev = new();
        int IDSach;
        int IdCell;
        int IdCellTG;
        int IdCellNN;
        int IdCellTL;
        public ThemSach()
        {
            InitializeComponent();
            _SachSev = new();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadData(string Search)
        {
            //datagird them sach
            dataGridView4.DataSource = null;
            dataGridView4.Rows.Clear();
            dataGridView4.ColumnCount = 6;
            dataGridView4.Columns[0].Name = "ID Sach";
            dataGridView4.Columns[1].Name = "Ten Sach";
            dataGridView4.Columns[2].Name = "The Loai";
            dataGridView4.Columns[3].Name = "Ngon Ngu";
            dataGridView4.Columns[4].Name = "Hang Sach";
            dataGridView4.Columns[5].Name = "Tac Gia";

            //datagrid tac gia
            dgvTacGia.DataSource = null;
            dgvTacGia.Rows.Clear();
            dgvTacGia.ColumnCount = 3;
            dgvTacGia.Columns[0].Name = "Id Tac Gia";
            dgvTacGia.Columns[1].Name = "Ten Tac Gia";
            dgvTacGia.Columns[2].Name = "Mo Ta";

            //datagrid ngon ngu
            dgvNgonNgu.DataSource = null;
            dgvNgonNgu.Rows.Clear();
            dgvNgonNgu.ColumnCount = 3;
            dgvNgonNgu.Columns[0].Name = "Id Ngon Ngu";
            dgvNgonNgu.Columns[1].Name = "Ten Ngon Ngu";
            dgvNgonNgu.Columns[2].Name = "Mo Ta";

            //datagird the loai
            dgvTheLoai.DataSource = null;
            dgvTheLoai.Rows.Clear();
            dgvTheLoai.ColumnCount = 3;
            dgvTheLoai.Columns[0].Name = "Id The Loai";
            dgvTheLoai.Columns[1].Name = "Ten The Loai";
            dgvTheLoai.Columns[2].Name = "Mo Ta";

            _lst = _SachSev.GetAll(Search);
            _lstTheLoai = _SachSev.GetRecords<TheLoaiSach>();//truyền class TheLoaiSach để lấy dữ liệu từ bảng TheLoaiSach
            _lstNgonNgu = _SachSev.GetRecords<NgonNgu>();
            _lstTacGia = _SachSev.GetRecords<TacGia>();

            foreach (var item in _lst)//fill sach
            {
                int stt = _lst.IndexOf(item) + 1;
                dataGridView4.Rows.Add(item.IDSach, item.TenSach, item.TenTheLoai, item.TenNgonNgu, item.HangSach, item.TenTacGia);
            }

            foreach (var item in _lstTacGia)//fill tac gia
            {
                int stt = _lstTacGia.IndexOf(item) + 1;
                dgvTacGia.Rows.Add(item.IDTacGia, item.TenTacGia, item.MoTa);
            }

            foreach (var item in _lstNgonNgu)//fill ngon ngu
            {
                int stt = _lstNgonNgu.IndexOf(item) + 1;
                dgvNgonNgu.Rows.Add(item.IDNgonNgu, item.TenNgonNgu, item.MoTa);
            }

            foreach (var item in _lstTheLoai)//fill the loai
            {
                int stt = _lstTheLoai.IndexOf(item) + 1;
                dgvTheLoai.Rows.Add(item.IDTheLoai, item.TenTheLoai, item.MoTa);
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

        private void ThemSach_Load(object sender, EventArgs e)//load form
        {
            LoadData(null);
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
                //IDSach = _lst.Count;
                _SachSev.Create(new Sach()
                {
                    //DSach = IDSach + 1,
                    TenSach = txtTenSach.Text,
                    IDTheLoai = GetSelectedID(cbxTheLoai),
                    IDNgonNgu = GetSelectedID(cbxNgonNgu),
                    IDTacGia = GetSelectedID(cbxTacGia),
                    HangSach = cbxHangSach.Text,
                });
                LoadData(null);
            }
        }
        private int GetSelectedID(ComboBox comboBox)
        {
            // Xác định giá trị thực sự của item được chọn trong ComboBox
            // (Bạn có thể cần thêm kiểm tra null nếu có thể ComboBox chưa được chọn)
            // Giả sử giá trị là kiểu int, bạn có thể điều chỉnh cho kiểu dữ liệu khác
            return comboBox.SelectedIndex + 1; // Điều chỉnh nếu index bắt đầu từ 0
        }// lấy index combobox

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)//them sach dgv cell click
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

        //tab tac gia
        private void button4_Click(object sender, EventArgs e)//them tac gia
        {
            if (string.IsNullOrEmpty(txtTenTacGia.Text))
            {
                MessageBox.Show("Khong duoc de trong thong tin");
                return;
            }
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                _TacGiaSev.Create(new TacGia()
                {
                    TenTacGia = txtTenTacGia.Text,
                    MoTa = txtMoTa.Text,
                });
                LoadData(null);
            }
        }

        private void dgvTacGia_CellClick(object sender, DataGridViewCellEventArgs e)// lấy ID cell tac gia
        {
            int index = e.RowIndex;
            if (index < 0 || index >= _lstTacGia.Count) return;
            var objindex = _lstTacGia[index];
            IdCellTG = (int)objindex.IDTacGia;
            txtIDTacGia.Text = objindex.IDTacGia.ToString();
            txtTenTacGia.Text = objindex.TenTacGia;
            txtMoTa.Text = objindex.MoTa;
        }

        private void button5_Click(object sender, EventArgs e)//sua tac gia
        {
            if (string.IsNullOrEmpty(txtTenTacGia.Text))
            {
                MessageBox.Show("Khong duoc de trong thong tin");
                return;
            }
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                _TacGiaSev.Update(IdCellTG, new TacGia()
                {
                    TenTacGia = txtTenTacGia.Text,
                    MoTa = txtMoTa.Text,
                });
                LoadData(null);
            }
        }

        private void button6_Click(object sender, EventArgs e)//xoa tac gia
        {
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                _TacGiaSev.Delete(IdCellTG);
                LoadData(null);
            }
        }

        //tab ngon ngu
        private void button3_Click(object sender, EventArgs e)//them ngon ngu
        {
            if (string.IsNullOrEmpty(txtTenNgonNgu.Text))
            {
                MessageBox.Show("Khong duoc de trong thong tin");
                return;
            }
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                _NgonNguSev.Create(new NgonNgu()
                {
                    TenNgonNgu = txtTenNgonNgu.Text,
                    MoTa = txtMota1.Text,
                });
                LoadData(null);
            }
        }

        private void button2_Click(object sender, EventArgs e)//sua ngon ngu
        {
            if (string.IsNullOrEmpty(txtTenNgonNgu.Text))
            {
                MessageBox.Show("Khong duoc de trong thong tin");
                return;
            }
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                _NgonNguSev.Update(IdCellNN, new NgonNgu()
                {
                    TenNgonNgu = txtTenNgonNgu.Text,
                    MoTa = txtMota1.Text,
                });
                LoadData(null);
            }
        }

        private void button1_Click(object sender, EventArgs e)//xoa ngon ngu
        {
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                _NgonNguSev.Delete(IdCellNN);
                LoadData(null);
            }
        }

        private void dgvNgonNgu_CellClick(object sender, DataGridViewCellEventArgs e)//lấy idcell ngon ngu
        {
            int index = e.RowIndex;
            if (index < 0 || index >= _lstNgonNgu.Count) return;
            var objindex = _lstNgonNgu[index];
            IdCellNN = (int)objindex.IDNgonNgu;
            txtIDNgonNgu.Text = objindex.IDNgonNgu.ToString();
            txtTenNgonNgu.Text = objindex.TenNgonNgu;
            txtMota1.Text = objindex.MoTa;
        }
        //tab the loai
        private void button9_Click(object sender, EventArgs e)//them the loai
        {
            if (string.IsNullOrEmpty(txtTenTheLoai.Text))
            {
                MessageBox.Show("Khong duoc de trong thong tin");
                return;
            }
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                _TheLoaiSev.Create(new TheLoaiSach()
                {
                    TenTheLoai = txtTenTheLoai.Text,
                    MoTa = txtMoTa2.Text,
                });
                LoadData(null);
            }
        }

        private void button8_Click(object sender, EventArgs e)//sua the loai
        {
            if (string.IsNullOrEmpty(txtTenTheLoai.Text))
            {
                MessageBox.Show("Khong duoc de trong thong tin");
                return;
            }
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                _TheLoaiSev.Update(IdCellTL, new TheLoaiSach()
                {
                    TenTheLoai = txtTenTheLoai.Text,
                    MoTa = txtMoTa2.Text,
                });
                LoadData(null);
            }
        }

        private void dgvTheLoai_CellClick(object sender, DataGridViewCellEventArgs e)//lấy id cell the loai
        {
            int index = e.RowIndex;
            if (index < 0 || index >= _lstTheLoai.Count) return;
            var objindex = _lstTheLoai[index];
            IdCellTL = (int)objindex.IDTheLoai;
            txtIDTheLoai.Text = objindex.IDTheLoai.ToString();
            txtTenTheLoai.Text = objindex.TenTheLoai;
            txtMoTa2.Text = objindex.MoTa;
        }

        private void button7_Click(object sender, EventArgs e)//xoa the loai
        {
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                _TheLoaiSev.Delete(IdCellTL);
                LoadData(null);
            }
        }
    }
}

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
        SachSev _SachSev;
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
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "ID Sach";
            dataGridView1.Columns[1].Name = "Ten Sach";
            dataGridView1.Columns[2].Name = "The Loai";
            dataGridView1.Columns[3].Name = "Ngon Ngu";
            dataGridView1.Columns[4].Name = "Hang Sach";

            _lst = _SachSev.GetAll();

            foreach (var item in _lst)
            {
                int stt = _lst.IndexOf(item) + 1;
                dataGridView1.Rows.Add(item.IDSach, item.TenSach, item.TenTheLoai, item.IDNgonNgu, item.HangSach);
            }
        }
    }
}

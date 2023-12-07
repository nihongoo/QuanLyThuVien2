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
    public partial class PhieuTraCT : Form
    {
        PhieuTCTSev _PhieuTCTSev;
        List<PhieuTCTView> _lstPTCT = new();
        List<SachCT> _lstSCT = new();
        List<PhieuTra> _lstPT = new();
        int idCell;
        int iddg, idsct;
        public PhieuTraCT()
        {
            InitializeComponent();
            _PhieuTCTSev = new();
        }
        private void LoadData()
        {
            dgvPhieuTra.Rows.Clear();
            dgvPhieuTra.ColumnCount = 7;
            dgvPhieuTra.Columns[0].Name = "ID Phieu Muon CT";
            dgvPhieuTra.Columns[1].Name = "ID Phieu Muon";
            dgvPhieuTra.Columns[2].Name = "Ten Doc Gia";
            dgvPhieuTra.Columns[3].Name = "ID Sach CT";
            dgvPhieuTra.Columns[4].Name = "Ten Sach";
            dgvPhieuTra.Columns[5].Name = "So Luong";
            dgvPhieuTra.Columns[6].Name = "Ghi Chu";

            _lstPTCT = _PhieuTCTSev.GetAll();
            _lstPT = _PhieuTCTSev.GetRecords<PhieuTra>();
            _lstSCT = _PhieuTCTSev.GetRecords<SachCT>();

            foreach (var item in _lstPTCT)
            {
                int stt = _lstPTCT.IndexOf(item) + 1;
                dgvPhieuTra.Rows.Add(item.IDPhieuTraCT, item.IDPhieuTra, item.TenDocGia, item.IDSachCT, item.TenSach, item.SoLuong, item.GhiChu);
            }

            cbxIDPhieuT.DataSource = _lstPT;
            cbxIDPhieuT.DisplayMember = "IDPhieuTra";
            cbxIDPhieuT.ValueMember = "IDPhieuTra";

            cbxIDSachCT.DataSource = _lstSCT;
            cbxIDSachCT.DisplayMember = "IDSachCT";
            cbxIDSachCT.ValueMember = "IDSachCT";
        }//Phieu muon

        private void PhieuTraCT_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)//them
        {
            if (string.IsNullOrEmpty(cbxIDPhieuT.Text) ||
string.IsNullOrEmpty(cbxIDSachCT.Text))
            {
                MessageBox.Show("Khong duoc de trong thong tin");
                return;
            }
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {

                var cre = _PhieuTCTSev.Create(new DAL.Models.PhieuTraCT()
                {
                    IDPhieuTra = Convert.ToInt32(cbxIDPhieuT.SelectedValue),
                    IDSachCT = Convert.ToInt32(cbxIDSachCT.SelectedValue),
                    SoLuong = 1,
                    GhiChu = txtGhiChu.Text,
                    //mes = ""
                });
                if (!cre)
                {
                    MessageBox.Show("Them that bai");
                }
                LoadData();
            }
        }

        private void dgvPhieuTra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0 || index >= _lstPTCT.Count) return;
            var objindex = _lstPTCT[index];
            idCell = (int)objindex.IDPhieuTraCT;
            iddg = (int)objindex.IDPhieuTra;
            idsct = (int)objindex.IDSachCT;
            txtIDPhieuTCT.Text = objindex.IDPhieuTraCT.ToString();
            cbxIDPhieuT.Text = objindex.IDPhieuTra.ToString();
            cbxIDSachCT.Text = objindex.IDSachCT.ToString();
            txtGhiChu.Text = objindex.GhiChu;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbxIDPhieuT.Text) ||
  string.IsNullOrEmpty(cbxIDSachCT.Text))
            {
                MessageBox.Show("Khong duoc de trong thong tin");
                return;
            }
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                _PhieuTCTSev.Update(idCell, new DAL.Models.PhieuTraCT()
                {
                    IDPhieuTra = Convert.ToInt32(cbxIDPhieuT.SelectedValue),
                    IDSachCT = Convert.ToInt32(cbxIDSachCT.SelectedValue),
                    GhiChu = txtGhiChu.Text,
                }, iddg, idsct);
                LoadData();
            }
        }
    }
}

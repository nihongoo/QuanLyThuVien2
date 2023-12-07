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
    public partial class PhieuMuonCT : Form
    {
        PhieuMCTSev _PhieuMCTSev;
        List<PhieuMCTView> _lstPMCT = new();
        List<SachCTView> _lstSCT = new();
        List<PhieuMView> _lstPM = new();
        int idCell;
        int iddg, idsct;
        public PhieuMuonCT()
        {
            InitializeComponent();
            _PhieuMCTSev = new();
        }

        private void PhieuMuonCT_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            dgvPMCT.Rows.Clear();
            dgvPMCT.ColumnCount = 7;
            dgvPMCT.Columns[0].Name = "ID Phieu Muon CT";
            dgvPMCT.Columns[1].Name = "ID Phieu Muon";
            dgvPMCT.Columns[2].Name = "Ten Doc Gia";
            dgvPMCT.Columns[3].Name = "ID Sach CT";
            dgvPMCT.Columns[4].Name = "Ten Sach";
            dgvPMCT.Columns[5].Name = "So Luong";
            dgvPMCT.Columns[6].Name = "Ghi Chu";

            _lstPMCT = _PhieuMCTSev.GetAll();
            _lstPM = _PhieuMCTSev.GetRecords<PhieuMView>();
            _lstSCT = _PhieuMCTSev.GetRecords<SachCTView>();

            foreach (var item in _lstPMCT)
            {
                int stt = _lstPMCT.IndexOf(item) + 1;
                dgvPMCT.Rows.Add(item.IDPhieuMuonCT, item.IDPhieuMuon, item.TenDocGia, item.IDSachCT, item.TenSach, item.SoLuong, item.GhiChu);
            }

            cbxPhieuM.DataSource = _lstPM;
            cbxPhieuM.DisplayMember = "IDPhieuMuon";
            cbxPhieuM.ValueMember = "IDPhieuMuon";

            cbxIDSachCT.DataSource = _lstSCT;
            cbxIDSachCT.DisplayMember = "IDSachCT";
            cbxIDSachCT.ValueMember = "IDSachCT";
        }//Phieu muon

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbxPhieuM.Text) ||
string.IsNullOrEmpty(cbxIDSachCT.Text))
            {
                MessageBox.Show("Khong duoc de trong thong tin");
                return;
            }
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {

                var cre = _PhieuMCTSev.Create(new DAL.Models.PhieuMuonCT()
                {
                    IDPhieuMuon = Convert.ToInt32(cbxPhieuM.SelectedValue),
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
        }//them

        private void dgvPMCT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0 || index >= _lstPMCT.Count) return;
            var objindex = _lstPMCT[index];
            idCell = (int)objindex.IDPhieuMuonCT;
            iddg = (int)objindex.IDPhieuMuon;
            idsct = (int)objindex.IDSachCT;
            txtIDPMCT.Text = objindex.IDPhieuMuonCT.ToString();
            cbxPhieuM.Text = objindex.IDPhieuMuon.ToString();
            cbxIDSachCT.Text = objindex.IDSachCT.ToString();
            txtGhiChu.Text = objindex.GhiChu;
        }//lấy idCell

        private void button3_Click(object sender, EventArgs e)//xoa
        {
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                _PhieuMCTSev.Delete(idCell);
                LoadData();
            }
        }

        private void button2_Click(object sender, EventArgs e)//sua
        {
            if (string.IsNullOrEmpty(cbxPhieuM.Text) ||
  string.IsNullOrEmpty(cbxIDSachCT.Text))
            {
                MessageBox.Show("Khong duoc de trong thong tin");
                return;
            }
            var confirm = MessageBox.Show("xac nhan thuc hien chuc nang", "xac nhan", MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                _PhieuMCTSev.Update(idCell, new DAL.Models.PhieuMuonCT()
                {
                    IDPhieuMuon = Convert.ToInt32(cbxPhieuM.SelectedValue),
                    IDSachCT = Convert.ToInt32(cbxIDSachCT.SelectedValue),
                    GhiChu = txtGhiChu.Text,
                }, iddg, idsct);
                LoadData();
            }
        }
    }
}

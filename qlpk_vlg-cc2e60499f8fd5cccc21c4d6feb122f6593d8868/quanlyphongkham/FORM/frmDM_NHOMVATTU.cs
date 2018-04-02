using quanlyphongkham.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using quanlyphongkham.DTO;

namespace quanlyphongkham.FORM
{
    public partial class frmDM_NHOMVATTU : Form
    {
        public frmDM_NHOMVATTU()
        {
            InitializeComponent();
        }
        ConnectionDatabase connecDB = new ConnectionDatabase();
        DAO_NHOMVATTU daoNVT = new DAO_NHOMVATTU();
        DAO_DM_LOAIVATTU daoLVT = new DAO_DM_LOAIVATTU();
        bool dieukien = true;

        private void frmDM_NHOMVATTU_Load(object sender, EventArgs e)
        {
            GetLVT();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            resetText();
            dieukien = true;
            xuLyControl(true);
            txtMaLoai.ReadOnly = false;
            showFormThongTin();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dieukien = false;
            xuLyControl(true);
            txtMaLoai.ReadOnly = true;
            showFormThongTin();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa nhóm vật tư '" + txtTenLoai.Text + "' ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (daoNVT.Delete(lbID.Text))
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetLVT();
                    }
                }
            }
            catch
            {
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetLVT();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DM_NHOM_VAT_TU nvt = LayTTLVT();
            if (dieukien)
            {
                if (KiemTraLoi() == "")
                {
                    if (daoNVT.Insert(nvt))
                    {
                        MessageBox.Show("Thêm thành công");
                        GetLVT();
                        frm.Visible = false;
                    }
                }
            }
            else
            {
                if (KiemTraLoi() == "")
                {
                    if (daoNVT.Update(nvt))
                    {
                        MessageBox.Show("Sửa thành công");
                        GetLVT();
                        frm.Visible = false;
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xuLyControl(true);
            frm.Visible = false;
        }
       

        void xuLyControl(bool b)
        {
            pnThem.Enabled = b;
            btnLuu.Visible = b;
            btnHuy.Visible = b;
        }
        void resetText()
        {
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
            txtGhiChu.Text = "";
        }

        private DM_NHOM_VAT_TU LayTTLVT()
        {
            string ma = txtMaLoai.Text;
            string ten = txtTenLoai.Text;
            string ghichu = txtGhiChu.Text;
            string lvt_id = cbbLoaiVT.SelectedValue.ToString();

            DM_NHOM_VAT_TU nhom_vat_tu = new DM_NHOM_VAT_TU(ma, ten, ghichu, lvt_id);
            return nhom_vat_tu;
        }

        Form frm = null;
        public void showFormThongTin()
        {
            if (frm == null)
            {
                frm = new Form();
                frm.Text = "THÔNG TIN NHÓM VẬT TƯ";
                frm.MaximizeBox = false;
                frm.MinimizeBox = false;
                frm.FormClosing += frm_Closing;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                pnThem.Dock = DockStyle.Top | DockStyle.Left;
                frm.Controls.Add(pnThem);
                frm.Size = new System.Drawing.Size(425, 380);
            }
            pnThem.Visible = true;
            frm.ShowDialog();
        }

        private void frm_Closing(object sender, FormClosingEventArgs e)
        {
            xuLyControl(false);
        }

        void GetLVT()
        {
            grcNhomVatTu.DataSource = daoNVT.getNhomVT();
            cbbLoaiVT.DataSource = daoLVT.getLoaiVT();
            cbbLoaiVT.ValueMember = "LVT_ID";
            cbbLoaiVT.DisplayMember = "LVT_TEN";
        }

        void TimKiem()
        {
            string s = txtTimKiem.Text;
            if (s.Length > 0)
            {
                grcNhomVatTu.DataSource = daoNVT.TimNVT(txtTimKiem.Text);
            }
            else
            {
                GetLVT();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtMaLoai.Text = gridView1.GetFocusedRowCellValue("NVT_ID").ToString();
                lbID.Text = gridView1.GetFocusedRowCellValue("NVT_ID").ToString();
                txtTenLoai.Text = gridView1.GetFocusedRowCellValue("NVT_TEN").ToString();
                txtGhiChu.Text = gridView1.GetFocusedRowCellValue("NVT_GHICHU").ToString();
                cbbLoaiVT.Text = gridView1.GetFocusedRowCellValue("LVT_TEN").ToString();
            }
            catch
            {
            }
        }

        public string KiemTraLoi()
        {
            string err = "";
            if (txtMaLoai.TextLength == 0)
            {
                err = "Chưa nhập mã nhóm vật tư";
            }
            else if (txtTenLoai.TextLength == 0)
            {
                err = "Chưa nhập tên nhóm vật tư";
            }
            lbLoi.Text = err;
            return err;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            TimKiem();
        }
    }
}

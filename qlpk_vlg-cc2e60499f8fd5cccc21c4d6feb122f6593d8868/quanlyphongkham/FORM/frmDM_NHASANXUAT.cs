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
    public partial class frmDM_NHASANXUAT : Form
    {
        public frmDM_NHASANXUAT()
        {
            InitializeComponent();
        }

        ConnectionDatabase connecDB = new ConnectionDatabase();
        DAO_NHASANXUAT daoNhaSX = new DAO_NHASANXUAT();
        bool dieukien = true;

        private void frmDM_NHASANXUAT_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            dieukien = true;
            resetText();
            xuLyControl(true);
            txtMa.ReadOnly = false;
            showFormThongTin();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dieukien = false;
            xuLyControl(true);
            txtMa.ReadOnly = true;
            showFormThongTin();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa nhà sản xuất '" + txtTenLoai.Text + "' ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (daoNhaSX.Delete(lbID.Text))
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetNHASX();
                    }
                }
            }
            catch
            {
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetNHASX();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DM_NHA_SAN_XUAT nhasx = LayNHASX();
            if (dieukien)
            {
                if (KiemTraLoi() == "")
                {
                    if (daoNhaSX.Insert(nhasx))
                    {
                        MessageBox.Show("Thêm thành công");
                        frm.Visible = false;
                        GetNHASX();
                    }
                }
            }
            else
            {
                if (KiemTraLoi() == "")
                {
                    if (daoNhaSX.Update(nhasx))
                    {
                        MessageBox.Show("Sửa thành công");
                        frm.Visible = false;
                        GetNHASX();
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frm.Visible = false;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            TimKiem();
        }

        void xuLyControl(bool b)
        {
            pnThem.Enabled = b;
            btnLuu.Visible = b;
            btnHuy.Visible = b;
        }
        void resetText()
        {
            txtMa.Text = "";
            txtTenLoai.Text = "";
            txtEmail.Text = "";
            txtDienThoai.Text = "";
            txtDiaChi.Text = "";
        }

        private DM_NHA_SAN_XUAT LayNHASX()
        {
            string ma = txtMa.Text;
            string ten = txtTenLoai.Text;
            string email = txtEmail.Text;
            string dienhoai = txtDienThoai.Text;
            string diachi = txtDiaChi.Text;
            DM_NHA_SAN_XUAT nhasx = new DM_NHA_SAN_XUAT(ma, ten, email, dienhoai, diachi);

            return nhasx;
        }

        Form frm = null;
        public void showFormThongTin()
        {
            if (frm == null)
            {
                frm = new Form();
                frm.Text = "THÔNG TIN NHÀ SẢN XUẤT";
                frm.MaximizeBox = false;
                frm.MinimizeBox = false;
                frm.FormClosing += frm_Closing;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                pnThem.Dock = DockStyle.Top | DockStyle.Left;
                frm.Controls.Add(pnThem);
                frm.Size = new System.Drawing.Size(425, 420);
            }
            pnThem.Visible = true;
            frm.ShowDialog();
        }

        private void frm_Closing(object sender, FormClosingEventArgs e)
        {
            xuLyControl(false);
        }

        void GetNHASX()
        {
            grcNhaSX.DataSource = daoNhaSX.getNhaSX();
        }

        void TimKiem()
        {
            string s = txtTimKiem.Text;
            if (s.Length > 0)
            {
                grcNhaSX.DataSource = daoNhaSX.TimNhaSX(txtTimKiem.Text);
            }
            else
            {
                GetNHASX();
            }
        }

        public string KiemTraLoi()
        {
            string err = "";
            if (txtMa.TextLength == 0)
            {
                err = "Chưa nhập mã nhà sản xuất";
            }
            else if (txtTenLoai.TextLength == 0)
            {
                err = "Chưa nhập tên nhà sản xuất";
            }

            lbLoi.Text = err;
            return err;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtMa.Text = gridView1.GetFocusedRowCellValue("NSX_ID").ToString();
                lbID.Text = gridView1.GetFocusedRowCellValue("NSX_ID").ToString();
                txtTenLoai.Text = gridView1.GetFocusedRowCellValue("NSX_TEN").ToString();
                txtDienThoai.Text = gridView1.GetFocusedRowCellValue("NSX_DIENTHOAI").ToString();
                txtEmail.Text = gridView1.GetFocusedRowCellValue("NSX_EMAIL").ToString();
                txtDiaChi.Text = gridView1.GetFocusedRowCellValue("NSX_DIACHI").ToString();
            }
            catch { }
        }
    }
}

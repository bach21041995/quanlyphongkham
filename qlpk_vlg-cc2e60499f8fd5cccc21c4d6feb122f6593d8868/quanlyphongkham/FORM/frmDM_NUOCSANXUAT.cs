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
    public partial class frmDM_NUOCSANXUAT : Form
    {
        public frmDM_NUOCSANXUAT()
        {
            InitializeComponent();
        }

        ConnectionDatabase connecDB = new ConnectionDatabase();
        DAO_NUOCSANXUAT daoNCSX = new DAO_NUOCSANXUAT();
        bool dieukien = true;

        private void frmDM_NUOCSANXUAT_Load(object sender, EventArgs e)
        {
            GetNCSX();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyControl(true);
            dieukien = true;
            resetText();
            showFormThongTin();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyControl(true);
            dieukien = false;
            showFormThongTin();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa nước'" + txtTenLoai.Text + "' ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (daoNCSX.Delete(lbID.Text))
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetNCSX();
                    }
                }
            }
            catch
            {
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetNCSX();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frm.Visible = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DM_NUOC_SAN_XUAT ncsx = LayNCSX();
            if (dieukien)
            {
                if (KiemTraLoi() == "")
                {
                    if (daoNCSX.Insert(ncsx))
                    {
                        MessageBox.Show("Thêm thành công");
                        GetNCSX();
                        frm.Visible = false;
                    }
                }
            }
            else
            {
                if (KiemTraLoi() == "")
                {
                    if (daoNCSX.Update(ncsx, int.Parse(lbID.Text)))
                    {
                        MessageBox.Show("Sửa thành công");
                        GetNCSX();
                        frm.Hide();
                    }
                }
            }
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
            txtTenLoai.Text = "";
        }

        private DM_NUOC_SAN_XUAT LayNCSX()
        {
            string ten = txtTenLoai.Text;
            DM_NUOC_SAN_XUAT ncsx = new DM_NUOC_SAN_XUAT(ten);

            return ncsx;
        }

        Form frm = null;
        public void showFormThongTin()
        {
            if (frm == null)
            {
                frm = new Form();
                frm.Text = "THÔNG TIN NƯỚC SẢN XUẤT";
                frm.MaximizeBox = false;
                frm.MinimizeBox = false;
                frm.FormClosing += frm_Closing;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                pnThem.Dock = DockStyle.Top | DockStyle.Left;
                frm.Controls.Add(pnThem);
                frm.Size = new System.Drawing.Size(425, 250);
            }
            pnThem.Visible = true;
            frm.ShowDialog();
        }

        private void frm_Closing(object sender, FormClosingEventArgs e)
        {
            xuLyControl(false);
        }

        void GetNCSX()
        {
            grcNuocSX.DataSource = daoNCSX.getNCSX();
        }

        void TimKiem()
        {
            string s = txtTimKiem.Text;
            if (s.Length > 0)
            {
                grcNuocSX.DataSource = daoNCSX.TimNCSX(txtTimKiem.Text);
            }
            else
            {
                GetNCSX();
            }
        }

        public string KiemTraLoi()
        {
            string err = "";
            if (txtTenLoai.TextLength == 0)
            {
                err = "Chưa nhập tên nước";
            }
            
            lbLoi.Text = err;
            return err;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtTenLoai.Text = gridView1.GetFocusedRowCellValue("NUOC_TEN").ToString();
                lbID.Text = gridView1.GetFocusedRowCellValue("NUOC_ID").ToString();
            }
            catch
            {
            }
        }
    }
}

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
    public partial class frmDM_KHO : Form
    {
        public frmDM_KHO()
        {
            InitializeComponent();
        }

        ConnectionDatabase connecDB = new ConnectionDatabase();
        DAO_DM_KHO daoKho = new DAO_DM_KHO();
        bool dieukien = true;

        private void frmDM_KHO_Load(object sender, EventArgs e)
        {
            GetKHO();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            dieukien = true;
            resetText();
            xuLyControl(true);
            txtTenLoai.ReadOnly = false;
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
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa kho '" + txtTenLoai.Text + "' ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (daoKho.Delete(lbID.Text))
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetKHO();
                    }
                }
            }
            catch
            {
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetKHO();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DM_KHO kho = LayKho();
            if (dieukien)
            {
                if (KiemTraLoi() == "")
                {
                    if (daoKho.Insert(kho))
                    {
                        MessageBox.Show("Thêm thành công");
                        GetKHO();
                        frm.Visible = false;
                    }
                }
            }
            else
            {
                if (KiemTraLoi() == "")
                {
                    if (daoKho.Update(kho))
                    {
                        MessageBox.Show("Sửa thành công");
                        GetKHO();
                        frm.Visible = false;
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frm.Visible = false;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtMa.Text = gridView1.GetFocusedRowCellValue("KHO_ID").ToString();
                lbID.Text = gridView1.GetFocusedRowCellValue("KHO_ID").ToString();
                txtTenLoai.Text = gridView1.GetFocusedRowCellValue("KHO_TEN").ToString();
            }
            catch { }
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
        }

        private DM_KHO LayKho()
        {
            string ma = txtMa.Text;
            string ten = txtTenLoai.Text;
            DM_KHO kho = new DM_KHO(ma, ten);

            return kho;
        }

        Form frm = null;
        public void showFormThongTin()
        {
            if (frm == null)
            {
                frm = new Form();
                frm.Text = "THÔNG TIN KHO";
                frm.MaximizeBox = false;
                frm.MinimizeBox = false;
                frm.FormClosing += frm_Closing;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                pnThem.Dock = DockStyle.Top | DockStyle.Left;
                frm.Controls.Add(pnThem);
                frm.Size = new System.Drawing.Size(425, 300);
            }
            pnThem.Visible = true;
            frm.ShowDialog();
        }

        private void frm_Closing(object sender, FormClosingEventArgs e)
        {
            xuLyControl(false);
        }

        void GetKHO()
        {
            grcKho.DataSource = daoKho.getKho();
        }

        void TimKiem()
        {
            string s = txtTimKiem.Text;
            if (s.Length > 0)
            {
                grcKho.DataSource = daoKho.TimKho(txtTimKiem.Text);
            }
            else
            {
                GetKHO();
            }
        }

        public string KiemTraLoi()
        {
            string err = "";
            if (txtMa.TextLength == 0)
            {
                err = "Chưa nhập mã kho";
            }
            else if (txtTenLoai.TextLength == 0)
            {
                err = "Chưa nhập tên kho";
            }
           
            lbLoi.Text = err;
            return err;
        }
    }
}

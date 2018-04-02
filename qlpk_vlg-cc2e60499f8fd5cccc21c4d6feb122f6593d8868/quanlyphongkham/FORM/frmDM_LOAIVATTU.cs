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
    public partial class frmDM_LOAIVATTU : Form
    {
        public frmDM_LOAIVATTU()
        {
            InitializeComponent();
        }

        ConnectionDatabase connecDB = new ConnectionDatabase();
        DAO_DM_LOAIVATTU daoLVT = new DAO_DM_LOAIVATTU();
        bool dieukien = true;

        void xuLyControl(bool b)
        {
            //btnThem.Enabled = !b;
            //btnSua.Enabled = !b;
            //btnXoa.Enabled = !b;
            
            pnThem.Enabled = b;
            btnLuu.Visible = b;
            btnHuy.Visible = b;
            //btnThemTiep.Visible = b;
        }
        void resetText()
        {
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
            txtGhiChu.Text = "";
        }

        private DM_LOAI_VAT_TU LayTTLVT()
        {
            string ma = txtMaLoai.Text;
            string ten = txtTenLoai.Text;
            string ghichu = txtGhiChu.Text;


            DM_LOAI_VAT_TU loai_vat_tu = new DM_LOAI_VAT_TU(ma, ten, ghichu);
            return loai_vat_tu;
        }

        Form frm = null;
        public void showFormThongTin()
        {
            if (frm == null)
            {
                frm = new Form();
                frm.Text = "THÔNG TIN LOẠI VẬT TƯ";
                frm.MaximizeBox = false;
                frm.MinimizeBox = false;
                frm.FormClosing += frm_Closing;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                pnThem.Dock = DockStyle.Top | DockStyle.Left;
                frm.Controls.Add(pnThem);
                frm.Size = new System.Drawing.Size(425, 340);
            }
            pnThem.Visible = true;
            frm.ShowDialog();
        }

        void GetLVT()
        {
            grcLoaiVatTu.DataSource = daoLVT.getLoaiVT();
            //BindingSource bs = new BindingSource();
            //bs.DataSource = daoLVT.getLoaiVT();
            //txtMaLoai.DataBindings.Add("Text", bs, "LVT_ID");
            //txtTenLoai.DataBindings.Add("Text", bs, "LVT_TEN");
            //txtGhiChu.DataBindings.Add("Text", bs, "LVT_GHICHU");
            //string check = ckbTamNgung.DataBindings.Add("Text", bs, "LVT_TRANGTHAI").ToString();
            //if(check == "Tạm ngưng") {
            //    ckbTamNgung.Checked = true;
            //}
            //else{
            //    ckbTamNgung.Checked = false;
            //}
        }

        private void frmDM_LOAIVATTU_Load(object sender, EventArgs e)
        {
            GetLVT();
        }

        private void frm_Closing(object sender, FormClosingEventArgs e)
        {
            xuLyControl(false);
        }

        void TimKiem()
        {
            string s = txtTimKiem.Text;
            if (s.Length > 0)
            {
                grcLoaiVatTu.DataSource = daoLVT.TimLVT(txtTimKiem.Text);
            }
            else
            {
                GetLVT();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            resetText();
            dieukien = true;
            txtMaLoai.Enabled = true;
            xuLyControl(true);
            showFormThongTin();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dieukien = false;
            txtMaLoai.Enabled = false;
            xuLyControl(true);
            showFormThongTin();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa loại vật tư '" + txtTenLoai.Text + "' ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (daoLVT.Delete(lbID.Text))
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaLoai.Enabled = true;
            xuLyControl(false);
            frm.Visible = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DM_LOAI_VAT_TU lvt = LayTTLVT();
            if (dieukien)
            {
                if (KiemTraLoi() == "")
                {
                    if (daoLVT.Insert(lvt))
                    {
                        MessageBox.Show("Thêm thành công");
                        GetLVT();
                        frm.Visible = false;
                        resetText();
                    }
                }
            }
            else
            {
                if (KiemTraLoi() == "")
                {
                    if (daoLVT.Update(lvt))
                    {
                        MessageBox.Show("Sửa thành công");
                        GetLVT();
                        frm.Visible = false;
                        resetText();
                    }
                }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtMaLoai.Text = gridView1.GetFocusedRowCellValue("LVT_ID").ToString();
                lbID.Text = gridView1.GetFocusedRowCellValue("LVT_ID").ToString();
                txtTenLoai.Text = gridView1.GetFocusedRowCellValue("LVT_TEN").ToString();
                txtGhiChu.Text = gridView1.GetFocusedRowCellValue("LVT_GHICHU").ToString();
            }
            catch { }
        }

        public string KiemTraLoi()
        {
            string err = "";
            if (txtMaLoai.TextLength == 0)
            {
                err = "Chưa nhập mã loại vật tư";
            }
            else if (txtTenLoai.TextLength == 0)
            {
                err = "Chưa nhập tên loại vật tư";
            }
            lbLoi.Text = err;
            return err;
        }
    }
}

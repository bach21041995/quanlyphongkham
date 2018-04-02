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
using quanlyphongkham.DAO;
using DevExpress.XtraGrid;

namespace quanlyphongkham.FORM
{
    public partial class frmDM_THUOC : Form
    {
        public frmDM_THUOC()
        {
            InitializeComponent();
            
        }

        DAO_DM_THUOC    daoThuoc = new DAO_DM_THUOC();
        ConnectionDatabase connecDB = new ConnectionDatabase();
        DAO_NHOMVATTU daoNVT = new DAO_NHOMVATTU();
        bool dieukien = true;

        void loadThuoc()
        {
            gcThuoc.DataSource = daoThuoc.getDSThuoc();
        }

        public void loadData()
        {     
            //cbLT.DataSource = daoThuoc.getLT();
            //cbLT.DisplayMember = "LT_TEN";
            //cbLT.ValueMember = "LT_ID";
            //cbLT.Items.Insert(0, "Tất cả");
            //cbLT.SelectedIndex = 0;
            cbbNhomVT.DataSource = daoNVT.getNhomVT();
            cbbNhomVT.DisplayMember = "NVT_TEN";
            cbbNhomVT.ValueMember = "NVT_ID";
        }

        void binding()
        {
            //cbLT.DataBindings.Clear();
            //cbLT.DataBindings.Add("SelectedValue", gcThuoc.DataSource, "LT_ID");
        }

        private void frmDM_THUOC_Load(object sender, EventArgs e)
        {
            loadThuoc();
            loadData();
            //binding();
            //cbLT_SelectedIndexChanged(null, null);
            //gridView1_FocusedRowChanged(null, null);
            //cbLT_SelectedIndexChanged(sender, e);
        }

        void xuLyControl(bool b)
        {
            //btnThem.Enabled = !b;
            //btnSua.Enabled = !b;
            //btnXoa.Enabled = !b;
            pnEdit.Enabled = b;
            btnLuu.Visible = b;
            btnHuy.Visible = b;
            //btnThemTiep.Visible = b;
        }

        void resetText()
        {
            txtTen.Text = "";
            txtHoatChat.Text = "";
            txtCachDung.Text = "";
            txtMa.Text = "";
            txtDVT.Text = "";
            txtGia.Text = "";
            txtHamLuong.Text = "";
            txtQuyCach.Text = "";
            txtGhiChu.Text = "";
        }

        private DM_VATTU LayTTThuoc()
        {
            string ma = txtMa.Text;
            string ten = txtTen.Text;
            string hdsd = txtCachDung.Text;
            string cd = txtCachDung.Text;
            string dvt = txtDVT.Text;
            float gia = float.Parse(txtGia.Text);
            string cachdung = txtCachDung.Text;
            string hoatchat = txtHoatChat.Text;
            string hamluong = txtHamLuong.Text;
            string quycach = txtQuyCach.Text;
            string ghichu = txtGhiChu.Text;
            string nvt = cbbNhomVT.SelectedValue.ToString();
            int nuocsx = 0;
            string nhasx = "";

            DM_VATTU vt = new DM_VATTU(ma, ten, dvt, gia, cachdung, hoatchat, hamluong, quycach, ghichu, nhasx, nvt, nuocsx);

            return vt;
        }

        Form frm = null;
        public void showFormThongTin()
        {

            //cbGioiTinh.SelectedIndex = 0;
            //cbLT2_SelectedIndexChanged(null, null);
            //cbbDT_SelectedIndexChanged(null, null);
            if (frm == null)
            {
                frm = new Form();
                frm.Text = "THÔNG TIN VẬT TƯ";
                frm.MaximizeBox = false;
                frm.MinimizeBox = false;
                frm.FormClosing += frm_Closing;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                pnEdit.Dock = DockStyle.Top | DockStyle.Left;
                frm.Controls.Add(pnEdit);
                frm.Size = new System.Drawing.Size(750, 410);
            }
            pnEdit.Visible = true;
            frm.ShowDialog();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            resetText();
            xuLyControl(true);
            dieukien = true;
            txtMa.ReadOnly = false;
            loadData();
            showFormThongTin();
            cbLT2_SelectedIndexChanged(sender, e);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //try
            //{
            //    txtMa.Text = gridView1.GetFocusedRowCellValue("THUOC_ID").ToString();
            //    lbMa.Text = gridView1.GetFocusedRowCellValue("THUOC_ID").ToString();
            //    lbTen.Text = gridView1.GetFocusedRowCellValue("THUOC_TEN").ToString();
                
            //    txtTen.Text = gridView1.GetFocusedRowCellValue("THUOC_TEN").ToString();
            //    txtCachDung.Text = gridView1.GetFocusedRowCellValue("THUOC_HDSD").ToString();
            //    txtCD.Text = gridView1.GetFocusedRowCellValue("THUOC_CONGDUNG").ToString();
            //    txtDVT.Text = gridView1.GetFocusedRowCellValue("THUOC_DVT").ToString();
            //    txtGia.Text = gridView1.GetFocusedRowCellValue("THUOC_GIA").ToString();
            //    cbbNhomVT.Text = gridView1.GetFocusedRowCellValue("LT_TEN").ToString();
            //}
            //catch
            //{
            //}
        }

        

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            if (KiemTraLoi() == "")
            {
                DM_VATTU vt = LayTTThuoc();
                if (dieukien)
                {
                    if (daoThuoc.InsertThuoc(vt))
                    {
                        MessageBox.Show("Thêm thành công");
                        frm.Visible = false;
                        loadThuoc();
                        xuLyControl(false);
                        //txtMa.Enabled = true;
                    }
                }
                else
                {
                    if (daoThuoc.UpdateThuoc(vt))
                    {
                        MessageBox.Show("Sửa thành công");
                        frm.Visible = false;
                        loadThuoc();
                        xuLyControl(false);
                        //txtMa.Enabled = true;
                        //sua(true);
                    }
                }
            }
        }

        private void frm_Closing(object sender, FormClosingEventArgs e)
        {
            xuLyControl(false);
            //sua(true);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xuLyControl(false);
            //sua(true);
            frm.Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                loadData();
                loadThuoc();
                //string value = cbLT.SelectedValue.ToString();
                //gcThuoc.DataSource = daoThuoc.getThuocByLT(value);
                //loadData();
            }
            catch
            {
                //MessageBox.Show("Chưa có thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dieukien = false;
            xuLyControl(true);
            txtMa.ReadOnly = true;
            //btnThemTiep.Enabled = false;
            showFormThongTin();
        }

        private void cbLT2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    string malt = cbbNhomVT.SelectedValue.ToString();

            //    if (dieukien == true)
            //    {
            //        txtMa.Text = daoThuoc.insertMaThuoc(malt);
            //    }
            //   else
            //   {
            //        txtMa.Text = gridView1.GetFocusedRowCellValue("THUOC_ID").ToString();
            //   }
            //}
            //catch
            //{
            //}
        }

        void timKiem()
        {
            string s = txtTim.Text;
            
            if (s.Length > 0)
            {
                gcThuoc.DataSource = daoThuoc.TimKiemVatTu(s);
            }
            else if (s.Length == 0)
            {
                loadThuoc();
            }
        }

        

        private void txtTim_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            timKiem();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa vật tư  '" + lbTen.Text + "' ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    daoThuoc.deleteThuoc(lbMa.Text);
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    xuLyControl(false);
                    loadThuoc();
                }
            }
            catch
            {
                //MessageBox.Show("Không thể xóa thuốc '" + lbTen.Text + "' vì có nhân viên sử dụng thông tin Chức vụ này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public string KiemTraLoi()
        {
            string err = "";
            if (txtMa.Text == "")
            {
                err = "Chưa nhập mã vật tư";
            }
            else if (txtTen.Text == "")
            {
                err = "Chưa nhập tên vật tư";
            }
            else if (txtNhaSX.Text == "")
            {
                err = "Chưa nhập nhà sản xuất";
            }
            else if (txtNuocSX.Text == "")
            {
                err = "Chưa nhập nước sản xuất";
            }
            else if (txtGia.Text == "")
            {
                err = "Chưa nhập giá bán";
            }
            else if (cbbNhomVT.Text == "")
            {
                err = "Chưa nhập nhóm vật tư";
            }
            lbLoi.Text = err;
            return err;
        }
    }
}

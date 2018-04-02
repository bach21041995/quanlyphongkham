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
using System.Threading;

namespace quanlyphongkham.FORM
{
    public partial class frmNHAP_KHO : Form
    {
        public frmNHAP_KHO()
        {
            InitializeComponent();
        }

        ConnectionDatabase connecDB = new ConnectionDatabase();
        DAO_PHIEU_NHAP_KHO daoPNK = new DAO_PHIEU_NHAP_KHO();
        DAO_DM_KHO daoKho = new DAO_DM_KHO();
        DAO_NHACUNGCAP daoNCC = new DAO_NHACUNGCAP();
        DAO_DM_THUOC daoThuoc = new DAO_DM_THUOC();
        DAO_CT_PHIEUNHAP  daoCTPN = new DAO_CT_PHIEUNHAP();
        DAO_KHO_CHI_TIET daoKCT = new DAO_KHO_CHI_TIET();

        DataTable dtThuoc = new DataTable();
        bool dieukien = true;

        private void frmNHAP_KHO_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            dieukien = true;
            xuLyControl(false);
            resetText();
            txtMaPN.ReadOnly = false;
            btnThemThuoc.Enabled = true;
            txtTenVT.Focus();
            grcListVT.DataSource = null;
            GetTT();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dieukien = false;
            xuLyControl(false);
            txtMaPN.ReadOnly = true;
            btnThemThuoc.Enabled = true;
            GetTT();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa phiếu nhập '" + txtMaPN.Text + "' ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (daoPNK.Delete(txtMaPN.Text))
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetPhieuNhap();
                    }
                }
            }
            catch { }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (KiemTraRong() == "")
            {
                PHIEU_NHAP_KHO pnk = LayPNK();
                if (dieukien)
                {
                    if (daoPNK.Insert(pnk))
                    {
                        MessageBox.Show("Thêm thành công");
                        xuLyControl(true);
                        GetPhieuNhap();
                        txtMaPN.ReadOnly = true;
                    }
                }
                else
                {
                    if (daoPNK.Update(pnk))
                    {
                        MessageBox.Show("Sửa thành công");
                        xuLyControl(true);
                        txtMaPN.ReadOnly = true;
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xuLyControl(true);
            resetText();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtMaPN.Text = gridView1.GetFocusedRowCellValue("PN_ID").ToString();
                txtNguoiNhan.Text = gridView1.GetFocusedRowCellValue("PN_NGUOIGIAO").ToString();
                txtNguoiNhan.Text = gridView1.GetFocusedRowCellValue("PN_NGUOINHAN").ToString();
                txtVAT.Text = gridView1.GetFocusedRowCellValue("PN_VAT").ToString();
                txtGhiChu.Text = gridView1.GetFocusedRowCellValue("PN_GHICHU").ToString();
                dtpNgayNhap.Text = gridView1.GetFocusedRowCellValue("PN_NGAYNHAP").ToString();
                cbbKho.Text = gridView1.GetFocusedRowCellValue("KHO_TEN").ToString();
                cbbNhaCC.Text = gridView1.GetFocusedRowCellValue("NCC_TEN").ToString();

                grcListVT.DataSource = daoCTPN.Get_CTPN_TheoID(txtMaPN.Text);
            }
            catch { }
        }


        void xuLyControl(bool b)
        {
            btnThem.Enabled = b;
            btnLuu.Enabled = !b;
            btnHuy.Enabled = !b;
            btnXoa.Enabled = b;
            btnSua.Enabled = b;
        }

        void resetText()
        {
            txtMaPN.Text = "";
            txtNguoiNhan.Text = "";
            txtNguoiNhan.Text = "";
            txtVAT.Text = "";
            txtGhiChu.Text = "";
        }

        private PHIEU_NHAP_KHO LayPNK()
        {
            string ma = txtMaPN.Text;
            string nggiao = txtNguoiNhan.Text;
            string nguoinhan = txtNguoiNhan.Text;
            float vat = 0;
            if (txtVAT.TextLength == 0)
            {
                vat = 0;
            }
            else
            {
                vat = float.Parse(txtVAT.Text);
            }
            string ghichu = txtGhiChu.Text;
            string nhacc = cbbNhaCC.SelectedValue.ToString();
            string kho = cbbKho.SelectedValue.ToString();
            DateTime ngaynhap = DateTime.Parse(dtpNgayNhap.Text);
            DateTime ngayhd = DateTime.Parse(dtpNgayHD.Text);
            string sohd = txtSoHD.Text;

            PHIEU_NHAP_KHO pnk = new PHIEU_NHAP_KHO(ma, nggiao, nguoinhan, ngaynhap, vat, ghichu, kho, nhacc, sohd, ngayhd);
            return pnk;
        }

        void GetPhieuNhap()
        {
            DataTable dt = daoPNK.Get_PN_TheoNgay(dtpTuNgay.Text, dtpcDenNgay.Text);
            if(dt.Rows.Count == 0){
                resetText();
                grcDSPhieuNhap.DataSource = null;
            }
            else
            {
                grcDSPhieuNhap.DataSource = dt;
            }
        }

        void LoadData()
        {
            cbbKho.DataSource = daoKho.getKho();
            cbbKho.ValueMember = "KHO_ID";
            cbbKho.DisplayMember = "KHO_TEN";

            cbbNhaCC.DataSource = daoNCC.Get_NhaCC();
            cbbNhaCC.ValueMember = "NCC_ID";
            cbbNhaCC.DisplayMember = "NCC_TEN";
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            GetPhieuNhap();
        }


        private void dtpTuNgay_ValueChanged_1(object sender, EventArgs e)
        {
            GetPhieuNhap();
        }

        private void txtVAT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }


        public string KiemTraRong()
        {
            string err = "";
            if (txtMaPN.Text == "")
            {
                err = "Chưa nhập mã phiếu nhập";
            }
            else if(cbbNhaCC.Text == ""){
                err = "Chưa chọn nhà cung cấp";
            }
            else if (cbbKho.Text == "")
            {
                err = "Chưa chọn kho";
            }
            
            lbLoi.Text = err;

            return err;
        }


        void GetTT()
        {
            txtTenVT.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTenVT.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTenVT.AutoCompleteCustomSource = daoPNK.getThuoc();
        }

        private KHO_CHI_TIET layTTKHOCT(string id_ctpn)
        {
            string vt_id = daoThuoc.getIDTHUOCbyTEN(txtTenVT.Text);
            string kho = cbbKho.SelectedValue.ToString();
            DateTime thoidiem = DateTime.Parse(dtpNgayNhap.Text);
            int solg = int.Parse(txtSoLG.Text);
            float dongia = float.Parse(txtGiaNhap.Text);
            string tt = "";
            string ctpn = id_ctpn;
            int ngvu = 1;
            KHO_CHI_TIET kct = new KHO_CHI_TIET(kho, ngvu, vt_id, thoidiem, ctpn, solg, dongia, tt);
            return kct;
        }
       
        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            if (KiemTraLoi() == "")
            {
                string ctpn_id = daoCTPN.Get_ID_Auto();
                string pn_id = txtMaPN.Text;
                string vt_id = daoThuoc.getIDTHUOCbyTEN(txtTenVT.Text);
                string ten = txtTenVT.Text;
                string dvt = txtDVT.Text;
                string hoatchat = txtHoatChat.Text;
                int solg = int.Parse(txtSoLG.Text);
                float gianhap = float.Parse(txtGiaNhap.Text);
                string solo = txtSoLo.Text;
                DateTime ngaysx = Convert.ToDateTime(DateTime.Parse(dtpNgaySX.Text).ToShortDateString());
                DateTime hansd = Convert.ToDateTime(DateTime.Parse(dtpHanSuDung.Text).ToShortDateString());
                float vat = 0;
                if (txtVAT.TextLength != 0)
                {
                    vat = float.Parse(txtVAT.Text);
                }
                float truocthue = solg * gianhap;
                float sauthue = truocthue + ((truocthue * vat) / 100);
                string hamlg = txtHamLuong.Text;
                string quycach = txtQuyCach.Text;
                float giaban = float.Parse(txtGiaBan.Text);
               
                        if (dtThuoc.Columns.Count == 0)
                        {
                            dtThuoc.Columns.AddRange(new DataColumn[16]{ new DataColumn("VT_ID"), new DataColumn("VT_TEN"), new DataColumn("CTPN_HOATCHAT"), new DataColumn("CTPN_DONVITINH"), new DataColumn("CTPN_SOLUONG"),
                            new DataColumn("CTPN_SOLO"),  new DataColumn("CTPN_DONGIANHAP"), new DataColumn("CTPN_NGAYSANXUAT"), new DataColumn("CTPN_HANSUDUNG"),
                            new DataColumn("CTPN_TTTRUOCTHUE"),new DataColumn("CTPN_TTSAUTHUE"),new DataColumn("CTPN_GIABAN"),new DataColumn("CTPN_HAMLUONG"),new DataColumn("CTPN_QCDONGGOI"), new DataColumn("PN_ID"), new DataColumn("CTPN_ID") });

                            dtThuoc.Rows.Add(vt_id, ten, hoatchat, dvt, solg, solo, gianhap, ngaysx.ToString("dd/MM/yyyy"), hansd.ToString("dd/MM/yyyy"), 
                            truocthue, sauthue, giaban, hamlg, quycach, pn_id, ctpn_id);
                            dtThuoc.AcceptChanges();
                        }
                        else
                        {
                            dtThuoc.Rows.Add(vt_id, ten, hoatchat, dvt, solg, solo, gianhap, ngaysx.ToString("dd/MM/yyyy"), hansd.ToString("dd/MM/yyyy"), 
                             truocthue, sauthue, giaban, hamlg, quycach, pn_id, ctpn_id);
                            dtThuoc.AcceptChanges();
                        }
                           
                            CHITIET_PHIEUNHAP ctpn = new CHITIET_PHIEUNHAP(ctpn_id, hoatchat, dvt, solg, gianhap, solo, ngaysx, hansd,
                              truocthue, sauthue, hamlg, quycach, giaban, vt_id, pn_id);
                            if (pn_id != "")
                            {
                                if (daoPNK.KiemTraTrung(pn_id) == 0)
                                {
                                    lbLoi2.Text = "Chưa có phiếu nhập " + txtMaPN.Text;
                                }
                                else
                                {
                                   
                                    if (daoCTPN.KiemTraVT(pn_id, vt_id) == 0)
                                    {
                                        if (daoCTPN.Insert(ctpn))
                                        {
                                            KHO_CHI_TIET kct = layTTKHOCT(ctpn_id);
                                            daoKCT.Insert_KCT(kct);
                                        }
                                        grcListVT.DataSource = dtThuoc;
                                        resetThuoc();
                                    }
                                    else
                                    {
                                        if (daoCTPN.Update(ctpn))
                                        {
                                            KHO_CHI_TIET kct = layTTKHOCT(lbID_CTPN.Text);
                                            daoKCT.Update_KCT(kct);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                lbLoi2.Text = "Chưa có phiếu nhập";
                            }
                           
                            grcListVT.DataSource = daoCTPN.Get_CTPN_TheoID(pn_id);
            }
        }

        public string KiemTraLoi()
        {
            string err = "";
            if (txtTenVT.Text == "")
            {
                err = "Chưa có vật tư";
                txtTenVT.Focus();
            }
            else if (txtSoLG.Text == "")
            {
                err = "Chưa có số lượng";
                txtSoLG.Focus();
            }
            else if (txtGiaNhap.Text == "")
            {
                err = "Chưa có giá nhập";
                txtGiaNhap.Focus();
            }
            lbLoi2.Text = err;
            return err;
        }

        void resetThuoc()
        {
            txtTenVT.Text = "";
            txtSoLG.Text = "";
            txtGiaNhap.Text = "";
            txtHoatChat.Text = "";
            txtDVT.Text = "";
            txtSoLo.Text = "";
            txtTenVT.Focus();
        }

        private void grvDSThuoc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try {
                 lbID_CTPN.Text = grvDSThuoc.GetFocusedRowCellValue("ID_NHAPKHOCHITIET").ToString();
                txtTenVT.Text = grvDSThuoc.GetFocusedRowCellValue("VT_TEN").ToString();
                txtSoLG.Text = grvDSThuoc.GetFocusedRowCellValue("CTPN_SOLUONG").ToString();
                txtSoLo.Text = grvDSThuoc.GetFocusedRowCellValue("CTPN_SOLO").ToString();
                txtHoatChat.Text = grvDSThuoc.GetFocusedRowCellValue("CTPN_HOATCHAT").ToString();
                txtDVT.Text = grvDSThuoc.GetFocusedRowCellValue("CTPN_DONVITINH").ToString();
                txtGiaNhap.Text = grvDSThuoc.GetFocusedRowCellValue("CTPN_DONGIANHAP").ToString();
                dtpNgaySX.Text = grvDSThuoc.GetFocusedRowCellValue("CTPN_NGAYSANXUAT").ToString();
                dtpHanSuDung.Text = grvDSThuoc.GetFocusedRowCellValue("CTPN_HANSUDUNG").ToString();
                txtHamLuong.Text = grvDSThuoc.GetFocusedRowCellValue("CTPN_HAMLUONG").ToString();
                txtQuyCach.Text = grvDSThuoc.GetFocusedRowCellValue("CTPN_QCDONGGOI").ToString();
                txtGiaBan.Text = grvDSThuoc.GetFocusedRowCellValue("CTPN_GIABAN").ToString();
               
            }
            catch
            {
            }
        }

        bool Insert_CTPN()
        {
            bool b = false;
            DataTable dt = new DataTable();
            dt = dtThuoc;
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = dt.Rows[i]["CTPN_ID"].ToString();
                string hoatchat = dt.Rows[i]["CTPN_HOATCHAT"].ToString();
                string id_pn = dt.Rows[i]["PN_ID"].ToString();
                string tenvt = dt.Rows[i]["VT_TEN"].ToString();
                string vt_id = daoThuoc.getIDTHUOCbyTEN(tenvt);
                string dvt = dt.Rows[i]["CTPN_DONVITINH"].ToString();
                int solg = int.Parse(dt.Rows[i]["CTPN_SOLUONG"].ToString());
                string solo = dt.Rows[i]["CTPN_SOLO"].ToString();
                float gianhap = float.Parse(dt.Rows[i]["CTPN_DONGIANHAP"].ToString());
                DateTime ngaysx = DateTime.Parse(dt.Rows[i]["CTPN_NGAYSANXUAT"].ToString());
                DateTime hansd = DateTime.Parse(dt.Rows[i]["CTPN_HANSUDUNG"].ToString());
                float truocthue = float.Parse(dt.Rows[i]["CTPN_TTTRUOCTHUE"].ToString());
                 float sauthue = float.Parse(dt.Rows[i]["CTPN_TTSAUTHUE"].ToString());
                 string hamlg = dt.Rows[i]["CTPN_HAMLUONG"].ToString();
                 string quycach = dt.Rows[i]["CTPN_QCDONGGOI"].ToString();
                 float giaban = float.Parse(dt.Rows[i]["CTPN_GIABAN"].ToString());

                 CHITIET_PHIEUNHAP ctpn = new CHITIET_PHIEUNHAP(id, hoatchat, dvt, solg, gianhap, solo, ngaysx, hansd,
                    truocthue,sauthue, hamlg, quycach, giaban, vt_id, id_pn);

                 if (daoCTPN.Insert(ctpn))
                 {
                     b = true;
                 }
                 else { b = false; }
            }
            return b;
        }

        private void txtTenVT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtVT = daoCTPN.Get_VT_TheoTen(txtTenVT.Text);
                for (int i = 0; i < dtVT.Rows.Count; i++)
                {
                    txtDVT.Text = dtVT.Rows[i]["VT_DVT"].ToString();
                    txtHoatChat.Text = dtVT.Rows[i]["VT_HOATCHAT"].ToString();
                    txtGiaNhap.Text = dtVT.Rows[i]["VT_GIANHAP"].ToString();
                    txtHamLuong.Text = dtVT.Rows[i]["VT_HAMLUONG"].ToString();
                    txtQuyCach.Text = dtVT.Rows[i]["VT_QCDONGGOI"].ToString();
                    txtGiaBan.Text = dtVT.Rows[i]["VT_GIABAN"].ToString();
                    dtpNgaySX.Text = dtVT.Rows[i]["VT_NGAYSX"].ToString();
                    dtpHanSuDung.Text = dtVT.Rows[i]["VT_HANSD"].ToString();
                    txtSoLo.Text = dtVT.Rows[i]["VT_SOLO"].ToString();
                }
            }
            catch { }
        }

      

        private void btnIn_Click(object sender, EventArgs e)
        {

        }

        private void btnLuuCTPN_Click(object sender, EventArgs e)
        {
            if (Insert_CTPN())
            {
                MessageBox.Show("Thêm thành công");
            }
        }

        private void txtTenVT_Click(object sender, EventArgs e)
        {
            GetTT();
        }

        private void grvDSThuoc_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string vt = grvDSThuoc.GetFocusedRowCellValue("VT_TEN").ToString();
                string pn_id = grvDSThuoc.GetFocusedRowCellValue("PN_ID").ToString();
                string vt_id = grvDSThuoc.GetFocusedRowCellValue("VT_ID").ToString();
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa vật tư '" + vt + "' ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (daoCTPN.Delete(pn_id, vt_id))
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        grcListVT.DataSource = daoCTPN.Get_CTPN_TheoID(pn_id);
                    }
                }
            }
            catch { }
        }
    }
}

﻿using quanlyphongkham.DAO;
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
    public partial class frmPHIEU_THANH_LY : Form
    {
        public frmPHIEU_THANH_LY()
        {
            InitializeComponent();
        }

        ConnectionDatabase connecDB = new ConnectionDatabase();
        DAO_DM_KHO daoKho = new DAO_DM_KHO();
        DAO_NHACUNGCAP daoNCC = new DAO_NHACUNGCAP();
        DAO_DM_THUOC daoThuoc = new DAO_DM_THUOC();
        DAO_PHIEU_THANH_LY daoPTL = new DAO_PHIEU_THANH_LY();
        DAO_CT_PHIEUTHANHLY daoCTPTL = new DAO_CT_PHIEUTHANHLY();
        DAO_KHO_CHI_TIET daoKCT = new DAO_KHO_CHI_TIET();
        DAO_CT_PHIEUNHAP daoCTPN = new DAO_CT_PHIEUNHAP();
        bool dieukien = true;
        DataTable dtThuoc = new DataTable();

        private void frmPHIEU_THANH_LY_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            cbbKho.DataSource = daoKho.getKho();
            cbbKho.ValueMember = "KHO_ID";
            cbbKho.DisplayMember = "KHO_TEN";

            cbbNhaCC.DataSource = daoNCC.Get_NhaCC();
            cbbNhaCC.ValueMember = "NCC_ID";
            cbbNhaCC.DisplayMember = "NCC_TEN";

            cbbHTTL.SelectedItem = 1;
        }

        void GetTT()
        {
            txtTenVT.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTenVT.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTenVT.AutoCompleteCustomSource = daoPTL.getThuoc();
        }

        public string KiemTraRong()
        {
            string err = "";
            if (txtMaPTL.Text == "")
            {
                err = "Chưa nhập mã phiếu thanh lý";
            }
            else if (cbbNhaCC.Text == "")
            {
                err = "Chưa chọn nhà cung cấp";
            }
            else if (cbbKho.Text == "")
            {
                err = "Chưa chọn kho";
            }
            else if (cbbHTTL.Text == "")
            {
                err = "Chưa chọn hình thức thanh lý";
            }

            lbLoi.Text = err;

            return err;
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
            txtMaPTL.Text = "";
            dtpNgayTL.Value = DateTime.Now;
            txtGhiChu.Text = "";
        }

        private PHIEU_THANH_LY LayTTPTL(){
            string ma_ptl = txtMaPTL.Text;
            string httl_ma = cbbHTTL.Text;
            DateTime ngay = dtpNgayTL.Value;
            string kho_id = cbbKho.SelectedValue.ToString();
            string ncc_id = cbbNhaCC.SelectedValue.ToString();
            string ghichu = txtGhiChu.Text;

            PHIEU_THANH_LY ptl = new PHIEU_THANH_LY(ma_ptl, ncc_id, kho_id, httl_ma, ngay, ghichu);
            return ptl;
        }

        void GetPhieuNhap()
        {
            DataTable dt = daoPTL.Get_PN_TheoNgay(dtpTuNgay.Text, dtpcDenNgay.Text);
            if (dt.Rows.Count == 0)
            {
                resetText();
                grcDSPhieuTL.DataSource = null;
            }
            else
            {
                grcDSPhieuTL.DataSource = dt;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            dieukien = true;
            xuLyControl(false);
            txtMaPTL.ReadOnly = false;
            txtMaPTL.Focus();
            grcListVT.DataSource = null;
            resetText();
            btnVT_TL.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dieukien = false;
            xuLyControl(false);
            btnVT_TL.Enabled = true;
            txtMaPTL.ReadOnly = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa phiếu thanh lý '" + txtMaPTL.Text + "' ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (daoPTL.Delete(txtMaPTL.Text))
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetPhieuNhap();
                        dtpcDenNgay_ValueChanged(sender, e);
                    }
                }
            }
            catch { }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (KiemTraRong() == "")
            {
                PHIEU_THANH_LY ptl = LayTTPTL();
                if (dieukien)
                {
                    if (daoPTL.Insert(ptl))
                    {
                        MessageBox.Show("Thêm thành công");
                        lbMAPTL.Text = txtMaPTL.Text;
                        xuLyControl(true);
                        txtMaPTL.ReadOnly = true;
                    }
                }
                else
                {
                    if (daoPTL.Update(ptl))
                    {
                        MessageBox.Show("Sửa thành công");
                        xuLyControl(true);
                        txtMaPTL.ReadOnly = true;
                    }
                }

                GetPhieuNhap();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xuLyControl(true);
            txtMaPTL.ReadOnly = true;
        }

        private void txtTenVT_Click(object sender, EventArgs e)
        {
            GetTT();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtMaPTL.Text = gridView1.GetFocusedRowCellValue("PTL_ID").ToString();
                cbbHTTL.Text = gridView1.GetFocusedRowCellValue("HTTL_ID").ToString();
                cbbKho.Text = gridView1.GetFocusedRowCellValue("KHO_TEN").ToString();
                cbbNhaCC.Text = gridView1.GetFocusedRowCellValue("NCC_TEN").ToString();
                txtGhiChu.Text = gridView1.GetFocusedRowCellValue("PTL_GHICHU").ToString();
                dtpNgayTL.Text = gridView1.GetFocusedRowCellValue("PTL_NGAY").ToString();
            }
            catch { }
            grcListVT.DataSource = daoCTPTL.Get_CTPTL_TheoID(txtMaPTL.Text);
        }

        private void dtpcDenNgay_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetPhieuNhap();
                grcListVT.DataSource = daoCTPTL.Get_CTPTL_TheoID(txtMaPTL.Text);
            }
            catch { }
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetPhieuNhap();
                grcListVT.DataSource = daoCTPTL.Get_CTPTL_TheoID(txtMaPTL.Text);
            }
            catch {  }
        }

        private void txtSoLG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }


        private void txtCPTL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnVT_TL_Click(object sender, EventArgs e)
        {
            if (KiemTraLoi() == "")
            {
                string ptl_id = txtMaPTL.Text;
                string vt_id = lbID_VT.Text;
                string id_nhapkho = lbIDNK.Text;
                float cpthanhly = 0;
                if (txtCPTL.TextLength != 0)
                {
                    cpthanhly = float.Parse(txtCPTL.Text);
                }
                else
                {
                    cpthanhly = 0;
                }

                float solg = 0;
                if (txtSoLG.TextLength == 0)
                {
                    solg = 0;
                }
                else
                {
                    solg = float.Parse(txtSoLG.Text);
                }

                float gia = 0;
                if (txtGia.TextLength == 0)
                {
                    gia = 0;
                }
                else
                {
                    gia = float.Parse(txtGia.Text);
                }
                float cpthuhoi = solg * gia;

                CT_PHIEUTHANHLY ctptl = new CT_PHIEUTHANHLY(ptl_id, vt_id, id_nhapkho, cpthuhoi, cpthanhly, solg, gia);
                KHO_CHI_TIET kct = new KHO_CHI_TIET(cbbKho.SelectedValue.ToString(), 3, vt_id, DateTime.Now, id_nhapkho,
                                                       solg, gia, "", ptl_id);
                float solgton = float.Parse(lbSoLgTon.Text);
                if (ptl_id != "")
                {
                    if (daoPTL.KiemTraTrung(ptl_id) == 0)
                    {
                        lbLoi2.Text = "Chưa có phiếu thanh lý " + txtMaPTL.Text;
                    }
                    else
                    {
                        if (daoCTPTL.KiemTraVT(ptl_id, vt_id) == 0)
                        {
                            if (daoCTPTL.Insert(ctptl))
                            {
                                
                                float slgconlai = solgton - solg;
                                daoKCT.Insert_KCT(kct);
                                daoCTPN.Update_CTPN_SOLG(id_nhapkho, int.Parse(slgconlai.ToString()));
                                lbSoLgTon.Text = slgconlai.ToString();
                            }
                        }
                        else
                        {
                            if (daoCTPTL.Update(ctptl))
                            {
                                float solgcu = float.Parse(lbSolgCu.Text);
                                float solgconlai = 0;
                                float solgmoi = 0;
                                if (solg > solgcu)
                                {
                                    solgmoi = solg - solgcu;
                                    solgconlai = solgton - solgmoi;
                                }
                                else if (solgcu > solg)
                                {
                                    solgmoi = solgcu - solg;
                                    solgconlai = solgton + solgmoi;
                                }
                                daoKCT.Update_KCT(kct);
                                daoCTPN.Update_CTPN_SOLG(id_nhapkho, int.Parse(solgconlai.ToString()));
                                lbSoLgTon.Text = solgconlai.ToString();
                            }
                        }
                    }
                }
                else
                {
                    lbLoi2.Text = "Chưa có phiếu thanh lý";
                }
                grcListVT.DataSource = daoCTPTL.Get_CTPTL_TheoID(ptl_id);
                gcVT.DataSource = daoPTL.get_VatTuTon(txtTenVT.Text);
                lbSolgCu.Text = txtSoLG.Text;
            }
        }

        public string KiemTraLoi()
        {
            string err = "";
            if (txtTenVT.TextLength == 0)
            {
                err = "Chưa có vật tư";
                txtTenVT.Focus();
            }
            else if (txtSoLG.TextLength == 0)
            {
                err = "Chưa có số lượng";
                txtSoLG.Focus();
            }
            else if (txtSoLG.TextLength != 0)
            {
                int sltly = int.Parse(txtSoLG.Text);
                int solgton = int.Parse(lbSoLgTon.Text);
                if (sltly > solgton)
                {
                    err = "Số lượng thanh lý lớn hơn số lượng tồn trong kho";
                    txtSoLG.Focus();
                }
            }
            lbLoi2.Text = err;
            return err;
        }

        private void txtTenVT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtVT = daoThuoc.Get_VT_TheoTen(txtTenVT.Text);
                for (int i = 0; i < dtVT.Rows.Count; i++)
                {
                    txtDVT.Text = dtVT.Rows[i]["VT_DVT"].ToString();
                    txtHoatChat.Text = dtVT.Rows[i]["VT_HOATCHAT"].ToString();
                    txtHamLuong.Text = dtVT.Rows[i]["VT_HAMLUONG"].ToString();
                    txtQuyCach.Text = dtVT.Rows[i]["VT_QCDONGGOI"].ToString();
                    dtpNgaySX.Text = dtVT.Rows[i]["VT_NGAYSX"].ToString();
                    dtpHanSuDung.Text = dtVT.Rows[i]["VT_HANSD"].ToString();
                    txtSoLo.Text = dtVT.Rows[i]["VT_SOLO"].ToString();
                }
                if (txtTenVT.TextLength != 0)
                {
                    DataTable dt = daoPTL.get_VatTuTon(txtTenVT.Text);
                    gcVT.DataSource = dt;
                }
            }
            catch { }
        }
    
        private void grvDSThuoc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtGia.Text = grvDSThuoc.GetFocusedRowCellValue("DONGIA").ToString();
                lbID_VT.Text = grvDSThuoc.GetFocusedRowCellValue("VT_ID").ToString();
                lbIDNK.Text = grvDSThuoc.GetFocusedRowCellValue("ID_NHAPKHOCHITIET").ToString();
                txtTenVT.Text = grvDSThuoc.GetFocusedRowCellValue("VT_TEN").ToString();
                txtSoLG.Text = grvDSThuoc.GetFocusedRowCellValue("SOLUONG").ToString();
                lbSolgCu.Text = grvDSThuoc.GetFocusedRowCellValue("SOLUONG").ToString();
                txtSoLo.Text = grvDSThuoc.GetFocusedRowCellValue("VT_SOLO").ToString();
                txtHoatChat.Text = grvDSThuoc.GetFocusedRowCellValue("VT_HOATCHAT").ToString();
                txtDVT.Text = grvDSThuoc.GetFocusedRowCellValue("VT_DVT").ToString();
                txtGia.Text = grvDSThuoc.GetFocusedRowCellValue("VT_GIANHAP").ToString();
                dtpNgaySX.Text = grvDSThuoc.GetFocusedRowCellValue("VT_NGAYSX").ToString();
                dtpHanSuDung.Text = grvDSThuoc.GetFocusedRowCellValue("VT_HANSD").ToString();
                txtHamLuong.Text = grvDSThuoc.GetFocusedRowCellValue("VT_HAMLUONG").ToString();
                txtQuyCach.Text = grvDSThuoc.GetFocusedRowCellValue("VT_QCDONGGOI").ToString();
                txtCPTL.Text = grvDSThuoc.GetFocusedRowCellValue("CP_THANHLY").ToString();
            }
            catch { }
        }

       

        private void grvDSThuoc_DoubleClick(object sender, EventArgs e)
        {
            bool b = false;
            try
            {
                string vt = grvDSThuoc.GetFocusedRowCellValue("VT_TEN").ToString();
                string ptl_id = grvDSThuoc.GetFocusedRowCellValue("PTL_ID").ToString();
                string vt_id = grvDSThuoc.GetFocusedRowCellValue("VT_ID").ToString();
                string pnk_id = grvDSThuoc.GetFocusedRowCellValue("ID_NHAPKHOCHITIET").ToString();
                int solgtl = int.Parse(grvDSThuoc.GetFocusedRowCellValue("SOLUONG").ToString());
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa vật tư '" + vt + "' ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (daoCTPTL.Delete(ptl_id, vt_id))
                    {
                        if (daoKCT.Delete(pnk_id, 3))
                        {
                           // MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            int solgton = daoCTPN.get_SoLgTon(pnk_id);
                            int solgthucte = solgton + solgtl;
                            daoCTPN.Update_CTPN_SOLG(pnk_id, solgthucte);
                            b = true;
                        }
                    }
                }
            }
            catch { }
            if (b == true)
            {
                DataTable dt2 = daoPTL.get_VatTuTon(grvDSThuoc.GetFocusedRowCellValue("VT_TEN").ToString());
                gcVT.DataSource = dt2;
                DataTable dt = daoCTPTL.Get_CTPTL_TheoID(txtMaPTL.Text);
                grcListVT.DataSource = dt;
              
            }
        }


        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                lbID_VT.Text = gridView2.GetFocusedRowCellValue("VT_ID").ToString();
                txtTenVT.Text = gridView2.GetFocusedRowCellValue("VT_TEN").ToString();
                txtDVT.Text = gridView2.GetFocusedRowCellValue("CTPN_DONVITINH").ToString();
                txtHoatChat.Text = gridView2.GetFocusedRowCellValue("CTPN_HOATCHAT").ToString();
                txtHamLuong.Text = gridView2.GetFocusedRowCellValue("CTPN_HAMLUONG").ToString();
                txtQuyCach.Text = gridView2.GetFocusedRowCellValue("CTPN_QCDONGGOI").ToString();
                dtpNgaySX.Text = gridView2.GetFocusedRowCellValue("CTPN_NGAYSANXUAT").ToString();
                dtpHanSuDung.Text = gridView2.GetFocusedRowCellValue("CTPN_HANSUDUNG").ToString();
                txtSoLo.Text = gridView2.GetFocusedRowCellValue("CTPN_SOLO").ToString();
                lbIDNK.Text = gridView2.GetFocusedRowCellValue("ID_NHAPKHOCHITIET").ToString();
                lbSoLgTon.Text = gridView2.GetFocusedRowCellValue("CTPN_SOLUONG").ToString();
            }
            catch { }
        }

        private void grvDSThuoc_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                txtGia.Text = grvDSThuoc.GetFocusedRowCellValue("DONGIA").ToString();
                lbID_VT.Text = grvDSThuoc.GetFocusedRowCellValue("VT_ID").ToString();
                lbIDNK.Text = grvDSThuoc.GetFocusedRowCellValue("ID_NHAPKHOCHITIET").ToString();
                txtTenVT.Text = grvDSThuoc.GetFocusedRowCellValue("VT_TEN").ToString();
                txtSoLG.Text = grvDSThuoc.GetFocusedRowCellValue("SOLUONG").ToString();
                lbSolgCu.Text = grvDSThuoc.GetFocusedRowCellValue("SOLUONG").ToString();
                txtSoLo.Text = grvDSThuoc.GetFocusedRowCellValue("VT_SOLO").ToString();
                txtHoatChat.Text = grvDSThuoc.GetFocusedRowCellValue("VT_HOATCHAT").ToString();
                txtDVT.Text = grvDSThuoc.GetFocusedRowCellValue("VT_DVT").ToString();
                txtGia.Text = grvDSThuoc.GetFocusedRowCellValue("VT_GIANHAP").ToString();
                dtpNgaySX.Text = grvDSThuoc.GetFocusedRowCellValue("VT_NGAYSX").ToString();
                dtpHanSuDung.Text = grvDSThuoc.GetFocusedRowCellValue("VT_HANSD").ToString();
                txtHamLuong.Text = grvDSThuoc.GetFocusedRowCellValue("VT_HAMLUONG").ToString();
                txtQuyCach.Text = grvDSThuoc.GetFocusedRowCellValue("VT_QCDONGGOI").ToString();
                txtCPTL.Text = grvDSThuoc.GetFocusedRowCellValue("CP_THANHLY").ToString();
            }
            catch { }
        }
        

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                lbID_VT.Text = gridView2.GetFocusedRowCellValue("VT_ID").ToString();
                txtTenVT.Text = gridView2.GetFocusedRowCellValue("VT_TEN").ToString();
                txtDVT.Text = gridView2.GetFocusedRowCellValue("CTPN_DONVITINH").ToString();
                txtHoatChat.Text = gridView2.GetFocusedRowCellValue("CTPN_HOATCHAT").ToString();
                txtHamLuong.Text = gridView2.GetFocusedRowCellValue("CTPN_HAMLUONG").ToString();
                txtQuyCach.Text = gridView2.GetFocusedRowCellValue("CTPN_QCDONGGOI").ToString();
                dtpNgaySX.Text = gridView2.GetFocusedRowCellValue("CTPN_NGAYSANXUAT").ToString();
                dtpHanSuDung.Text = gridView2.GetFocusedRowCellValue("CTPN_HANSUDUNG").ToString();
                txtSoLo.Text = gridView2.GetFocusedRowCellValue("CTPN_SOLO").ToString();
                lbIDNK.Text = gridView2.GetFocusedRowCellValue("ID_NHAPKHOCHITIET").ToString();
                lbSoLgTon.Text = gridView2.GetFocusedRowCellValue("CTPN_SOLUONG").ToString();
            }
            catch { }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                txtMaPTL.Text = gridView1.GetFocusedRowCellValue("PTL_ID").ToString();
                cbbHTTL.Text = gridView1.GetFocusedRowCellValue("HTTL_ID").ToString();
                cbbKho.Text = gridView1.GetFocusedRowCellValue("KHO_TEN").ToString();
                cbbNhaCC.Text = gridView1.GetFocusedRowCellValue("NCC_TEN").ToString();
                txtGhiChu.Text = gridView1.GetFocusedRowCellValue("PTL_GHICHU").ToString();
                dtpNgayTL.Text = gridView1.GetFocusedRowCellValue("PTL_NGAY").ToString();
            }
            catch { }
            grcListVT.DataSource = daoCTPTL.Get_CTPTL_TheoID(txtMaPTL.Text);
        }

        private void cbbKho_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                gcVT.DataSource = daoPTL.get_VatTuTheoKho(cbbKho.SelectedValue.ToString());
            }
            catch { }
        }
    }
}

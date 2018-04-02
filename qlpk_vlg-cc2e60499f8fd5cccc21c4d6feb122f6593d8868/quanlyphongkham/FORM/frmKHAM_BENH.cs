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
using quanlyphongkham.Report;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid;
using DevExpress.XtraTab;
using DevExpress.XtraGrid.Views.Grid;

namespace quanlyphongkham.FORM
{
    public partial class frmKHAM_BENH : Form
    {
        public frmKHAM_BENH()
        {
            InitializeComponent();
        }

        DAO_PHIEU_TIEP_NHAN daoPTN = new DAO_PHIEU_TIEP_NHAN();
        DAO_BENH_NHAN daoBN = new DAO_BENH_NHAN();
        DAO_NHAN_VIEN daoNV = new DAO_NHAN_VIEN();
        DAO_BENH_LY daoBL = new DAO_BENH_LY();
        DAO_KHAM_BENH daoKB = new DAO_KHAM_BENH();
        DAO_CT_BENHLY daoCTBL = new DAO_CT_BENHLY();
        DAO_DM_THUOC daoTHUOC = new DAO_DM_THUOC();
        DAO_TOA_THUOC daoTT = new DAO_TOA_THUOC();
        DAO_CT_TOATHUOC daoCTTT = new DAO_CT_TOATHUOC();
        DAO_DM_CANLAMSAN daoCLS = new DAO_DM_CANLAMSAN();
        DAO_PHIEU_CHI_DINH daoPCD = new DAO_PHIEU_CHI_DINH();
        DAO_CT_CLS daoCTCLS = new DAO_CT_CLS();
        
        //DAO_NGAY daoNgay = new DAO_NGAY();
        ConnectionDatabase connecDB = new ConnectionDatabase();
        bool dieukien = true;

        bool dieukien2 = true;

        bool themtt = true;

        bool delete = false;

        bool delete_pcd = false;

        bool delete_ctpcd = false;

        int bl;

        string kbid = "";
        int ttid;

        int suatt = 0;

        void loadPTN()
        {
            DateTime ht = System.DateTime.Now;
            string ngay = ht.ToShortDateString();
            ngay = ngay.Replace("/", "");

            gdPTNH.DataSource = daoPTN.getPTN_NGAY(ngay);
            xuly(false);

            //gdPTN.DataSource = daoPTN.getDSPTN();
        }

        void loadPTN_ALL()
        {
            DateTime ht = System.DateTime.Now;
            string ngay = ht.ToShortDateString();
            ngay = ngay.Replace("/", "");
            gdPTNH.DataSource = daoPTN.getDSPTN_ALL(ngay);
            xuly(false);
        }


        void loadPTN_DK()
        {
            DateTime ht = System.DateTime.Now;
            string ngay = ht.ToShortDateString();
            ngay = ngay.Replace("/", "");
            gdPTNH.DataSource = daoPTN.getDSPTN_DK(ngay);
            xuly(false);
        }

        void loadPTN_KX()
        {
            DateTime ht = System.DateTime.Now;
            string ngay = ht.ToShortDateString();
            ngay = ngay.Replace("/", "");
            gdPTNH.DataSource = daoPTN.getDSPTN_KX(ngay);
            xuly(false);
        }


        //load DS Khám bệnh
        void loadKB_NGAY()
        {
            DateTime ht = System.DateTime.Now;
            string ngay = ht.ToShortDateString();
            ngay = ngay.Replace("/", "");

            gdPTNH.DataSource = daoKB.getKB_NGAY(ngay);
            xuly(false);
        }

        void loadKB_NGAY_DK()
        {
            DateTime ht = System.DateTime.Now;
            string ngay = ht.ToShortDateString();
            ngay = ngay.Replace("/", "");

            gdPTNH.DataSource = daoKB.getKB_NGAY_DK(ngay);
            xuly(false);
        }


        void loadKB_NGAY_KX()
        {
            DateTime ht = System.DateTime.Now;
            string ngay = ht.ToShortDateString();
            ngay = ngay.Replace("/", "");

            gdPTNH.DataSource = daoKB.getKB_NGAY_KX(ngay);
            xuly(false);
        }

        void loadBL()
        {
            gdBL.DataSource = daoBL.getBL();
            xuly(false);
        }


        void loadDMCLS()
        {
            gcDM_CLS.DataSource = daoCLS.getDSCLS();
        }

        void xuly(bool b)
        {
            txtMaICD.Enabled = b;
            txtICD.Enabled = b;
            txtChuyenmon.Enabled = b;
            txtMucdo.Enabled = b;
            txtBenhphu.Enabled = b;
            txtMaBP.Enabled = b;
            txtKetluan.Enabled = b;
            //btnKham.Enabled = !b;
            btnSua.Enabled = b;
            btnLuu2.Enabled = b;
            btnHuy2.Enabled = b;
            btnHoantat.Enabled = b;
            btnICD.Enabled = b;
            btnBP.Enabled = b;
            btnKetoa.Enabled = b;
            btnLapPCD.Enabled = b;
            //btnLamMoi.Enabled = b;
        }

        void dongbang()
        {
            pnKB.Enabled = false;
            pnTT.Enabled = false;
            pnCDCLS.Enabled = false;
            //pnLSK.Enabled = false;
        }

        void reset()
        {
            txtICD.Text = "";
            txtMaICD.Text = "";
            txtChuyenmon.Text = "";
            txtMucdo.Text = "";
            txtBenhphu.Text = "";
            txtMaBP.Text = "";
            txtKetluan.Text = "";
            DateTime ht = System.DateTime.Now;
            string ngay = ht.ToShortDateString();
            DateTK.Text = ngay;
        }


        public void loadData()
        {
            var items = new BindingList<KeyValuePair<string, string>>();

            items.Add(new KeyValuePair<string, string>("1", "Nam"));
            items.Add(new KeyValuePair<string, string>("0", "Nữ"));

            cbGioitinh2.DataSource = items;
            cbGioitinh2.ValueMember = "Key";
            cbGioitinh2.DisplayMember = "Value";

            var items2 = new BindingList<KeyValuePair<string, string>>();

            items2.Add(new KeyValuePair<string, string>("A", "A"));
            items2.Add(new KeyValuePair<string, string>("O", "O"));
            items2.Add(new KeyValuePair<string, string>("B", "B"));
            items2.Add(new KeyValuePair<string, string>("AB", "AB"));

            cbNhommau.DataSource = items2;
            cbNhommau.ValueMember = "Key";
            cbNhommau.DisplayMember = "Value";

            var items3 = new BindingList<KeyValuePair<string, string>>();

            items3.Add(new KeyValuePair<string, string>("TT", "Chờ khám"));
            items3.Add(new KeyValuePair<string, string>("DK", "Đang khám"));
            items3.Add(new KeyValuePair<string, string>("KX", "Đã khám"));
            items3.Add(new KeyValuePair<string, string>("TC", "Tất cả"));

            cbTT.DataSource = items3;
            cbTT.ValueMember = "Key";
            cbTT.DisplayMember = "Value";
        }

        private void frmKHAM_BENH_Load(object sender, EventArgs e)
        {
            loadData();
            loadPTN();
            loadBL();
            
            xuly(false);
            btnKham.Enabled = false;
        }

        private void cbTT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTT.Text == "Chờ khám")
            {
                //btnKham.Enabled = true;
                btnSua.Enabled = false;
                //DateChonNgay.Enabled = false;
                loadPTN();
                dongbang();
            }
            else if (cbTT.Text == "Đang khám")
            {
                
                
                //DateChonNgay.Enabled = true;
                loadKB_NGAY_DK();
                btnKham.Enabled = false;
                //btnSua.Enabled = true;
                dongbang();

            }
            else if (cbTT.Text == "Đã khám")
            {
                btnKham.Enabled = false;
                //btnSua.Enabled = true;
                //DateChonNgay.Enabled = false;
                loadKB_NGAY_KX();
                dongbang();
            }
            else
            {
                loadKB_NGAY();
                dongbang();
            }
        }

        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //txtMa2.Text = gridView3.GetFocusedRowCellValue("TN_ID").ToString();
            
        }

        Form frmBL = null;
        public void showFormBL()
        {

            if (frmBL == null)
            {
                frmBL = new Form();
                frmBL.Text = "DANH MỤC BỆNH LÝ";
                frmBL.MaximizeBox = false;
                frmBL.MinimizeBox = false;
                frmBL.BackColor = Color.White;
                frmBL.FormClosing += frm_Closing;
                frmBL.StartPosition = FormStartPosition.CenterScreen;
                frmBL.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                panelBL.Dock = DockStyle.Top | DockStyle.Left;
                frmBL.Controls.Add(panelBL);
                frmBL.Size = new System.Drawing.Size(510, 350);
            }
            panelBL.Visible = true;
            frmBL.ShowDialog();
        }

        Form frmTT = null;
        public void showFormTT()
        {
            txtTenThuoc.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTenThuoc.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTenThuoc.AutoCompleteCustomSource = daoTHUOC.getDSTHUOC_TOA();

            txtSoNgay.Text = "0";
            txtSang.Text = "0";
            txtTrua.Text = "0";
            txtChieu.Text = "0";
            txtToi.Text = "0";
            if (frmTT == null)
            {
                
                frmTT = new Form();
                frmTT.Text = "TOA THUỐC";
                frmTT.MaximizeBox = false;
                frmTT.MinimizeBox = false;
                frmTT.BackColor = Color.White;
                frmTT.FormClosing += frmTT_Closing;
                frmTT.StartPosition = FormStartPosition.CenterScreen;
                frmTT.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                panelTT.Dock = DockStyle.Top | DockStyle.Left;
                frmTT.Controls.Add(panelTT);
                frmTT.Size = new System.Drawing.Size(840, 470);
            }
            panelTT.Visible = true;
            dieukien2 = false;
            frmTT.ShowDialog();
        }

        private void frm_Closing(object sender, FormClosingEventArgs e)
        {
            //xuLyControl(false);
            //sua(true);
        }

        void resetTXTTT()
        {
            txtTenThuoc.Text = "";
            txtDVT.Text = "";
            txtCachDung.Text = "";
            txtSoNgay.Text = "";
            txtSang.Text = "";
            txtTrua.Text = "";
            txtChieu.Text = "";
            txtToi.Text = "";
        }

        private void frmTT_Closing(object sender, FormClosingEventArgs e)
        {
            resetTXTTT();
            //gcThuoc.DataSource = "";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            bl = 1;
            showFormBL();
            
        }

        private void gridView4_DoubleClick(object sender, EventArgs e)
        {
            if(bl == 1)
            {
                txtMaICD.Text = gridView4.GetFocusedRowCellValue("BL_ID").ToString();
                txtICD.Text = gridView4.GetFocusedRowCellValue("BL_TEN").ToString();
                frmBL.Visible = false;
            }
            else if(bl == 2)
            {
                txtMaBP.Text = gridView4.GetFocusedRowCellValue("BL_ID").ToString();
                txtBenhphu.Text = gridView4.GetFocusedRowCellValue("BL_TEN").ToString();
                frmBL.Visible = false;
            }
            
        }

        private void btnBP_Click(object sender, EventArgs e)
        {
            bl = 2;
            showFormBL();
            
        }

        private TOA_THUOC LayTTTT()
        {
            string kbid = txtIdTT_KB.Text;
            string ten = "";
            string loidan = txtLoiDan.Text;
            int tt = 1;
            DateTime ngay = Convert.ToDateTime(DateTK.Text);
            string ngay2 = ngay.ToShortDateString();

            TOA_THUOC t = new TOA_THUOC(kbid, ten, loidan, tt, ngay2);
            return t;
        }

        private CT_TOATHUOC LayCTTT()
        {
            CT_TOATHUOC t = new CT_TOATHUOC();
            //int id = daoTT.getIDTT_MAX();
            int id = daoTT.getTT_ID_MAX_by_KBID(txtIdTT_KB.Text);
            int idtt = id;
            t.Id_tt = idtt;
            t.Id_thuoc = daoTHUOC.getIDTHUOCbyTEN(txtTenThuoc.Text);
            t.Ctt_songayuong = int.Parse(txtSoNgay.Text);
            t.Ctt_cachdung = txtCachDung.Text;
            t.Ctt_sang = int.Parse(txtSang.Text);
            t.Ctt_trua = int.Parse(txtTrua.Text);
            t.Ctt_chieu = int.Parse(txtChieu.Text);
            t.Ctt_toi = int.Parse(txtToi.Text);
            int sl = int.Parse(txtSL.Text);
            t.Ctt_sl = sl;
            t.Ctt_dongia = float.Parse(txtDonGia.Text);
            t.Ctt_thanhtien = float.Parse(txtThanhTien.Text);
            return t;
        }

        private CT_TOATHUOC LayCTTT_SUA()
        {
            CT_TOATHUOC t = new CT_TOATHUOC();
            string id = gridView1.GetFocusedRowCellValue("TT_ID").ToString();
            int idtt = int.Parse(id);
            t.Id_tt = idtt;
            t.Id_thuoc = daoTHUOC.getIDTHUOCbyTEN(txtTenThuoc.Text);
            t.Ctt_songayuong = int.Parse(txtSoNgay.Text);
            t.Ctt_cachdung = txtCachDung.Text;
            t.Ctt_sang = int.Parse(txtSang.Text);
            t.Ctt_trua = int.Parse(txtTrua.Text);
            t.Ctt_chieu = int.Parse(txtChieu.Text);
            t.Ctt_toi = int.Parse(txtToi.Text);
            int sl = int.Parse(txtSL.Text);
            t.Ctt_sl = sl;
            t.Ctt_dongia = float.Parse(txtDonGia.Text);
            t.Ctt_thanhtien = float.Parse(txtThanhTien.Text);
            return t;
        }


        private KHAM_BENH LayTTKB()
        {
            string kbid = daoKB.insertMaKB(txtMaBN2.Text);
            txtIdTT_KB.Text = kbid;
            string tnid = gridView3.GetFocusedRowCellValue("TN_ID").ToString();
            DateTime htk = Convert.ToDateTime(DateTK.Text);
            string htk2 = htk.ToShortDateString();
            string ngay2 = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            //string ngay2 = ngay.ToLongDateString();
            int tt = 1;
            string kl = txtKetluan.Text;
            string bp = txtBenhphu.Text;

            KHAM_BENH t = new KHAM_BENH(kbid, tnid, htk2, ngay2, tt, kl, bp);
            return t;
        }

        private KHAM_BENH LayTTKB_SUA()
        {
            string kbid = gridView3.GetFocusedRowCellValue("KB_ID").ToString();
            string tnid = gridView3.GetFocusedRowCellValue("TN_ID").ToString();
            DateTime htk = Convert.ToDateTime(DateTK.Text);
            string htk2 = htk.ToShortDateString();
            DateTime ngay = System.DateTime.Now;
            string ngay2 = ngay.ToLongDateString();
            int tt = 1;
            string kl = txtKetluan.Text;
            string bp = txtBenhphu.Text;

            KHAM_BENH t = new KHAM_BENH(kbid, tnid, htk2, ngay2, tt, kl, bp);
            return t;
        }

        private KHAM_BENH LayTTKB_HT()
        {
            string kbid = gridView3.GetFocusedRowCellValue("KB_ID").ToString();
            string tnid = gridView3.GetFocusedRowCellValue("TN_ID").ToString();
            DateTime htk = Convert.ToDateTime(DateTK.Text);
            string htk2 = htk.ToShortDateString();
            DateTime ngay = System.DateTime.Now;
            string ngay2 = ngay.ToLongDateString();
            int tt = 2;
            string kl = txtKetluan.Text;
            string bp = txtBenhphu.Text;

            KHAM_BENH t = new KHAM_BENH(kbid, tnid, htk2, ngay2, tt, kl, bp);
            return t;
        }

        

        private PHIEU_TIEP_NHAN LayTTPTN_DK()
        {
            string ma = gridView3.GetFocusedRowCellValue("TN_ID").ToString();
            int idnv = 2;
            int idbn = int.Parse(txtMaBN2.Text);
            string idbs = "2";
            int idbs2 = int.Parse(idbs);
            int stt = int.Parse(txtSTT2.Text);
            string dvk = "";
            int tuoithang = int.Parse(txtTuoithang2.Text);
            int tuoinam = int.Parse(txtTuoinam2.Text);
            string ngaygio = System.DateTime.Now.ToShortDateString();
            //string ngaygio = DateNgayhen.Text;
            float mach = float.Parse(txtMach.Text);
            float nhietdo = float.Parse(txtNhietdo.Text);
            float nhiptho = float.Parse(txtNhiptho.Text);
            //float huyetap = float.Parse(txtHuyetap.Text);
            float chieucao = float.Parse(txtChieucao.Text);
            float cannang = float.Parse(txtCannang.Text);
            string huyetap = txtHuyetap.Text + "/" + txtHuyetap2.Text;
            float bmi = float.Parse(txtBMI.Text);
            int tt = 1;

            PHIEU_TIEP_NHAN t = new PHIEU_TIEP_NHAN(ma, idnv, idbn, stt, idbs2, dvk, tuoithang, tuoinam, ngaygio, mach, nhietdo, nhiptho, huyetap, chieucao, cannang, bmi, tt);

            return t;
        }

        

        private PHIEU_TIEP_NHAN LayTTPTN_KX()
        {
            string ma = gridView3.GetFocusedRowCellValue("TN_ID").ToString();
            int idnv = 2;
            int idbn = int.Parse(txtMaBN2.Text);
            //string idbs = gridView3.GetFocusedRowCellValue("NV_ID").ToString();
            int idbs = frmDANG_NHAP.idnv;
            //int idbs2 = int.Parse(idbs);
            int stt = int.Parse(txtSTT2.Text);
            string dvk = "";
            int tuoithang = int.Parse(txtTuoithang2.Text);
            int tuoinam = int.Parse(txtTuoinam2.Text);
            string ngaygio = System.DateTime.Now.ToShortDateString();
            //string ngaygio = DateNgayhen.Text;
            float mach = float.Parse(txtMach.Text);
            float nhietdo = float.Parse(txtNhietdo.Text);
            float nhiptho = float.Parse(txtNhiptho.Text);
            //float huyetap = float.Parse(txtHuyetap.Text);
            float chieucao = float.Parse(txtChieucao.Text);
            float cannang = float.Parse(txtCannang.Text);
            string huyetap = txtHuyetap.Text + "/" + txtHuyetap2.Text;
            float bmi = float.Parse(txtBMI.Text);
            int tt = 2;

            PHIEU_TIEP_NHAN t = new PHIEU_TIEP_NHAN(ma, idnv, idbn, stt, idbs, dvk, tuoithang, tuoinam, ngaygio, mach, nhietdo, nhiptho, huyetap, chieucao, cannang, bmi, tt);

            return t;
        }

        private CT_BENHLY LayTTCTBL()
        {
            CT_BENHLY t = new CT_BENHLY();
            t.Id_kb = txtMaICD.Text; //test
            t.Id_bl = txtIdTT_KB.Text; //test
            t.Ctbl_chuyenmon = txtChuyenmon.Text;
            t.Ctbl_mucdo = txtMucdo.Text;
            t.Ctbl_trangthai = 1;
            return t;
        }

        private CT_BENHLY LayTTCTBL_SUA()
        {
            CT_BENHLY t = new CT_BENHLY();
            t.Id_kb = txtMaICD.Text;  //test
            t.Id_bl = gridView3.GetFocusedRowCellValue("KB_ID").ToString();  //test
            t.Ctbl_chuyenmon = txtChuyenmon.Text;
            t.Ctbl_mucdo = txtMucdo.Text;
            t.Ctbl_trangthai = 1;
            return t;
        }

        private CT_BENHLY LayTTCTBL_P()
        {
            CT_BENHLY t = new CT_BENHLY();
            t.Id_bl = txtMaBP.Text;
            t.Id_kb = txtIdTT_KB.Text;
            t.Ctbl_chuyenmon = "";
            t.Ctbl_mucdo = "";
            t.Ctbl_trangthai = 2;
            return t;
        }

        private CT_BENHLY LayTTCTBL_P_SUA()
        {
            CT_BENHLY t = new CT_BENHLY();
            t.Id_bl = txtMaBP.Text;
            t.Id_kb = gridView3.GetFocusedRowCellValue("KB_ID").ToString();
            t.Ctbl_chuyenmon = "";
            t.Ctbl_mucdo = "";
            t.Ctbl_trangthai = 2;
            return t;
        }

        private PHIEU_CHI_DINH LayTTPCD()
        {
            string idkb = txtIdTT_KB.Text;
            string ngaygio = DatePCD.Text;
            int tt = 0;
            PHIEU_CHI_DINH t = new PHIEU_CHI_DINH(idkb, ngaygio, tt);
            return t;
        }

        private CT_CLS LayCTCLS()
        {
            CT_CLS t = new CT_CLS();
            t.Id_pcd = int.Parse(gridView8.GetFocusedRowCellValue("PCD_ID").ToString());
            t.Id_cls = int.Parse(gridView7.GetFocusedRowCellValue("CLS_ID").ToString());
            t.Ctcls_soluong = 1;
            t.Ctcls_ketqua = "";
            return t;
        }

        private void btnKham_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(txtMaBN2.Text);
            KHAM_BENH t = LayTTKB();
            dieukien = true;
            string dk = dieukien.ToString();
            xuly(true);
            btnKetoa.Enabled = false;
            btnSua.Enabled = false;
            btnKham.Enabled = false;
            gdPTNH.Enabled = false;
            pnKB.Enabled = true;
            //if (daoKB.InsertKB(t))
           // {
            //    MessageBox.Show(txtIdTT_KB.Text);
            //}

        }

        private void btnHuy2_Click(object sender, EventArgs e)
        {
            if (cbTT.Text == "Chờ khám")
            {
                btnKham.Enabled = true;
                btnSua.Enabled = false;
                gdPTNH.Enabled = true;
                //DateChonNgay.Enabled = false;
                loadPTN();
                dongbang();
                reset();
            }
            else if (cbTT.Text == "Đang khám")
            {

                reset();
                //DateChonNgay.Enabled = true;
                loadKB_NGAY_DK();
                btnKham.Enabled = false;
                btnSua.Enabled = true;
                btnICD.Enabled = true;
                btnBP.Enabled = true;
                gdPTNH.Enabled = true;
                dongbang();
            }
            else if (cbTT.Text == "Đã khám")
            {
                btnKham.Enabled = false;
                btnSua.Enabled = true;
                btnICD.Enabled = true;
                btnBP.Enabled = true;
                gdPTNH.Enabled = true;
                //DateChonNgay.Enabled = false;
                loadKB_NGAY_KX();
                dongbang();
                reset();
            }
            else
            {
                loadKB_NGAY();
                gdPTNH.Enabled = true;
                dongbang();
                reset();
            }
            
            //xuly(false);
        }

        private void btnLuu2_Click(object sender, EventArgs e)
        {
            KHAM_BENH t = LayTTKB();
            
            CT_BENHLY c = LayTTCTBL();
            CT_BENHLY cp = LayTTCTBL_P();
            
            PHIEU_TIEP_NHAN p = LayTTPTN_DK();
            if(dieukien == true)
            {
                if(daoKB.InsertKB(t))
                {
                    if(txtMaICD.Text == "" || txtICD.Text == "")
                    {
                        MessageBox.Show("Chưa nhập chuẩn đoán ICD");
                    }
                    else
                    {
                        daoCTBL.InsertCTBL(c);
                        //daoCTBL.InsertCTBL(cp);
                        daoPTN.UpdatePTN_DK(p);
                        MessageBox.Show("Lưu thành công");
                        xuly(false);
                        btnKham.Enabled = true;
                        btnKetoa.Enabled = true;
                        btnLapPCD.Enabled = true;
                        gdPTNH.Enabled = true;
                        gcPCD.DataSource = daoPCD.getPCD_by_KBID(txtIdTT_KB.Text);
                        pnTT.Enabled = true;
                        pnCDCLS.Enabled = true;
                        pnLSK.Enabled = true;
                        btnHoantat.Enabled = true;
                    }
                }
            }
            else
            {
                KHAM_BENH s = LayTTKB_SUA();
                CT_BENHLY cs = LayTTCTBL_SUA();
                CT_BENHLY cps = LayTTCTBL_P_SUA();
                if (daoKB.UpdateKB(s))
                {
                    if (txtMaICD.Text == "" || txtICD.Text == "")
                    {
                        MessageBox.Show("Chưa nhập chuẩn đoán ICD");
                    }
                    else
                    {
                        daoCTBL.deleteCTBL(cs);
                        daoCTBL.InsertCTBL(cs);
                        //daoCTBL.deleteCTBL(cps);
                        //daoCTBL.InsertCTBL(cps);
                        daoKB.UpdateKB(s);
                        daoPTN.UpdatePTN_DK(p);
                        MessageBox.Show("Lưu thành công");
                        btnLuu2.Enabled = false;
                        xuly(false);
                        btnKham.Enabled = false;
                        btnSua.Enabled = true;
                        btnKetoa.Enabled = false;
                        pnTT.Enabled = false;
                        gdPTNH.Enabled = true;
                        pnCDCLS.Enabled = false;
                        pnLSK.Enabled = false;
                        btnHoantat.Enabled = true;
                    }
                }
            }
        }

        public DataTable dt = new DataTable();
        public string ttid_sua = "";
        private void btnSua_Click(object sender, EventArgs e)
        {
            xuly(true);
            btnKham.Enabled = false;
            btnSua.Enabled = false;
            dieukien = false;
            ttid = daoTT.getTT_ID_MAX_by_KBID(kbid);
            string idtt = daoTT.getTT_ID_MAX_by_KBID(kbid).ToString();
            gcThuoc.DataSource = daoCTTT.getCT_TOATHUOCbyID(idtt);

            dt = daoTT.ktTT_ID_by_KBID(kbid);
            pnKB.Enabled = true;
            pnCDCLS.Enabled = true;
            pnLSK.Enabled = true;
            pnTT.Enabled = true;
            gdPTNH.Enabled = false;

            if (dt.Rows.Count == 0)
            {
                btnKetoa.Enabled = true;
                suatt = 0;
            }
            else
            {
                btnKetoa.Enabled = false;
                pnTT.Enabled = true;
                int tt = daoTT.getTT_ID_MAX_by_KBID(kbid);
                ttid_sua = tt.ToString();
                suatt = 1;
            }

           // MessageBox.Show(suatt.ToString());


            if (themtt == false)
            {
                
            }
        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void txtMaICD_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if(txtMaICD.Text != "")
            {
                txtICD.Enabled = false;
                string tk = txtMaICD.Text;
                txtICD.Text = daoBL.TimBL(tk);
            }
            //else
            //{
            //    txtICD.Enabled = true;
            //}
        }

        private void txtICD_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            
        }

        private void gridView3_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbTT.Text == "Chờ khám")
                {
                    txtSTT2.Text = gridView3.GetFocusedRowCellValue("TN_STT").ToString();
                    txtMaBN2.Text = gridView3.GetFocusedRowCellValue("BN_ID").ToString();
                    txtTen2.Text = gridView3.GetFocusedRowCellValue("BN_HOTEN").ToString();
                    txtCDCLS_TENBN.Text = gridView3.GetFocusedRowCellValue("BN_HOTEN").ToString();
                    txtCMT2.Text = gridView3.GetFocusedRowCellValue("BN_CMT").ToString();
                    //txtSDT2.Text = gridView3.GetFocusedRowCellValue("BN_SDT").ToString();
                    txtDiachi2.Text = gridView3.GetFocusedRowCellValue("BN_DIACHI").ToString();
                    //DateNS2.Text = gridView3.GetFocusedRowCellValue("BN_NGAYSINH").ToString();
                    cbGioitinh2.Text = gridView3.GetFocusedRowCellValue("BN_GIOITINH").ToString();
                    txtCDCLS_GT.Text = gridView3.GetFocusedRowCellValue("BN_GIOITINH").ToString();
                    cbNhommau.Text = gridView3.GetFocusedRowCellValue("BN_NHOMMAU").ToString();
                    txtTuoithang2.Text = gridView3.GetFocusedRowCellValue("TN_TUOITHANG").ToString();
                    txtTuoinam2.Text = gridView3.GetFocusedRowCellValue("TN_TUOINAM").ToString();
                    txtCDCLS_TUOI.Text = gridView3.GetFocusedRowCellValue("TN_TUOINAM").ToString();
                    //cbBSK2.Text = gridView3.GetFocusedRowCellValue("NV_HOTEN").ToString();
                    txtMach.Text = gridView3.GetFocusedRowCellValue("TN_MACH").ToString();
                    txtNhietdo.Text = gridView3.GetFocusedRowCellValue("TN_NHIETDO").ToString();
                    txtNhiptho.Text = gridView3.GetFocusedRowCellValue("TN_NHIPTHO").ToString();
                    //txtHuyetap.Text = gridView3.GetFocusedRowCellValue("TN_HUYETAP").ToString();
                    string ha = gridView3.GetFocusedRowCellValue("TN_HUYETAP").ToString();
                    string[] ha_split = ha.Split('/');
                    txtHuyetap.Text = ha_split[0];
                    txtHuyetap2.Text = ha_split[1];

                    txtChieucao.Text = gridView3.GetFocusedRowCellValue("TN_CHIEUCAO").ToString();
                    txtCannang.Text = gridView3.GetFocusedRowCellValue("TN_CANNANG").ToString();
                    txtBMI.Text = gridView3.GetFocusedRowCellValue("TN_BMI").ToString();

                    gdToa.DataSource = daoTT.getTTbyBN(int.Parse(gridView3.GetFocusedRowCellValue("BN_ID").ToString()));

                    btnKham.Enabled = true;

                    kbid = daoKB.getKBID_by_TNID(gridView3.GetFocusedRowCellValue("TN_ID").ToString());
                }
                else if (cbTT.Text == "Đang khám")
                {
                    txtSTT2.Text = gridView3.GetFocusedRowCellValue("TN_STT").ToString();
                    txtMaBN2.Text = gridView3.GetFocusedRowCellValue("BN_ID").ToString();
                    txtTen2.Text = gridView3.GetFocusedRowCellValue("BN_HOTEN").ToString();
                    txtCDCLS_TENBN.Text = gridView3.GetFocusedRowCellValue("BN_HOTEN").ToString();
                    txtCMT2.Text = gridView3.GetFocusedRowCellValue("BN_CMT").ToString();
                    //txtSDT2.Text = gridView3.GetFocusedRowCellValue("BN_SDT").ToString();
                    txtDiachi2.Text = gridView3.GetFocusedRowCellValue("BN_DIACHI").ToString();
                    //DateNS2.Text = gridView3.GetFocusedRowCellValue("BN_NGAYSINH").ToString();
                    cbGioitinh2.Text = gridView3.GetFocusedRowCellValue("BN_GIOITINH").ToString();
                    txtCDCLS_GT.Text = gridView3.GetFocusedRowCellValue("BN_GIOITINH").ToString();
                    cbNhommau.Text = gridView3.GetFocusedRowCellValue("BN_NHOMMAU").ToString();
                    txtTuoithang2.Text = gridView3.GetFocusedRowCellValue("TN_TUOITHANG").ToString();
                    txtTuoinam2.Text = gridView3.GetFocusedRowCellValue("TN_TUOINAM").ToString();
                    txtCDCLS_TUOI.Text = gridView3.GetFocusedRowCellValue("TN_TUOINAM").ToString();
                    //cbBSK2.Text = gridView3.GetFocusedRowCellValue("NV_HOTEN").ToString();
                    txtMach.Text = gridView3.GetFocusedRowCellValue("TN_MACH").ToString();
                    txtNhietdo.Text = gridView3.GetFocusedRowCellValue("TN_NHIETDO").ToString();
                    txtNhiptho.Text = gridView3.GetFocusedRowCellValue("TN_NHIPTHO").ToString();
                    //txtHuyetap.Text = gridView3.GetFocusedRowCellValue("TN_HUYETAP").ToString();
                    string ha = gridView3.GetFocusedRowCellValue("TN_HUYETAP").ToString();
                    string[] ha_split = ha.Split('/');
                    txtHuyetap.Text = ha_split[0];
                    txtHuyetap2.Text = ha_split[1];

                    txtChieucao.Text = gridView3.GetFocusedRowCellValue("TN_CHIEUCAO").ToString();
                    txtCannang.Text = gridView3.GetFocusedRowCellValue("TN_CANNANG").ToString();
                    txtBMI.Text = gridView3.GetFocusedRowCellValue("TN_BMI").ToString();
                    string kb = gridView3.GetFocusedRowCellValue("KB_ID").ToString();
                    txtIdTT_KB.Text = gridView3.GetFocusedRowCellValue("KB_ID").ToString();

                    string icd = daoKB.getBL_ICD(kb);
                    string[] icd_split = icd.Split('/');
                    txtMaICD.Text = icd_split[0];
                    txtICD.Text = icd_split[1];
                    txtChuyenmon.Text = icd_split[2];
                    txtMucdo.Text = icd_split[3];

                    string bp = daoKB.getBL_PHU(kb);
                    string[] bp_split = bp.Split('/');
                    txtMaBP.Text = bp_split[0];
                    txtBenhphu.Text = gridView3.GetFocusedRowCellValue("KB_BENHPHU").ToString();

                    gdToa.DataSource = daoTT.getTTbyBN(int.Parse(gridView3.GetFocusedRowCellValue("BN_ID").ToString()));

                    gcPCD.DataSource = daoPCD.getPCD_by_KBID(txtIdTT_KB.Text);
                    string idtt = daoTT.getTT_ID_MAX_by_KBID(txtIdTT_KB.Text).ToString();

                    gcThuoc.DataSource = daoCTTT.getCT_TOATHUOCbyID(idtt);

                    btnSua.Enabled = true;

                    kbid = daoKB.getKBID_by_TNID(gridView3.GetFocusedRowCellValue("TN_ID").ToString());
                }
                else if (cbTT.Text == "Đã khám")
                {
                    txtSTT2.Text = gridView3.GetFocusedRowCellValue("TN_STT").ToString();
                    txtMaBN2.Text = gridView3.GetFocusedRowCellValue("BN_ID").ToString();
                    txtTen2.Text = gridView3.GetFocusedRowCellValue("BN_HOTEN").ToString();
                    txtCDCLS_TENBN.Text = gridView3.GetFocusedRowCellValue("BN_HOTEN").ToString();
                    txtCMT2.Text = gridView3.GetFocusedRowCellValue("BN_CMT").ToString();
                    //txtSDT2.Text = gridView3.GetFocusedRowCellValue("BN_SDT").ToString();
                    txtDiachi2.Text = gridView3.GetFocusedRowCellValue("BN_DIACHI").ToString();
                    //DateNS2.Text = gridView3.GetFocusedRowCellValue("BN_NGAYSINH").ToString();
                    cbGioitinh2.Text = gridView3.GetFocusedRowCellValue("BN_GIOITINH").ToString();
                    txtCDCLS_GT.Text = gridView3.GetFocusedRowCellValue("BN_GIOITINH").ToString();
                    cbNhommau.Text = gridView3.GetFocusedRowCellValue("BN_NHOMMAU").ToString();
                    txtTuoithang2.Text = gridView3.GetFocusedRowCellValue("TN_TUOITHANG").ToString();
                    txtTuoinam2.Text = gridView3.GetFocusedRowCellValue("TN_TUOINAM").ToString();
                    txtCDCLS_TUOI.Text = gridView3.GetFocusedRowCellValue("TN_TUOINAM").ToString();
                    //cbBSK2.Text = gridView3.GetFocusedRowCellValue("NV_HOTEN").ToString();
                    txtMach.Text = gridView3.GetFocusedRowCellValue("TN_MACH").ToString();
                    txtNhietdo.Text = gridView3.GetFocusedRowCellValue("TN_NHIETDO").ToString();
                    txtNhiptho.Text = gridView3.GetFocusedRowCellValue("TN_NHIPTHO").ToString();
                    //txtHuyetap.Text = gridView3.GetFocusedRowCellValue("TN_HUYETAP").ToString();
                    string ha = gridView3.GetFocusedRowCellValue("TN_HUYETAP").ToString();
                    string[] ha_split = ha.Split('/');
                    txtHuyetap.Text = ha_split[0];
                    txtHuyetap2.Text = ha_split[1];

                    txtChieucao.Text = gridView3.GetFocusedRowCellValue("TN_CHIEUCAO").ToString();
                    txtCannang.Text = gridView3.GetFocusedRowCellValue("TN_CANNANG").ToString();
                    txtBMI.Text = gridView3.GetFocusedRowCellValue("TN_BMI").ToString();
                    txtICD.Text = gridView3.GetFocusedRowCellValue("BL_TEN").ToString();
                    txtMaICD.Text = gridView3.GetFocusedRowCellValue("BL_ID").ToString();

                    txtBenhphu.Text = gridView3.GetFocusedRowCellValue("KB_BENHPHU").ToString();

                    gdToa.DataSource = daoTT.getTTbyBN(int.Parse(gridView3.GetFocusedRowCellValue("BN_ID").ToString()));

                    gcPCD.DataSource = daoPCD.getPCD_by_KBID(txtIdTT_KB.Text);

                    btnSua.Enabled = true;

                    kbid = daoKB.getKBID_by_TNID(gridView3.GetFocusedRowCellValue("TN_ID").ToString());
                }
            }
            catch
            {
            }
        }

        void TT()
        {
            txtTenThuoc.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTenThuoc.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTenThuoc.AutoCompleteCustomSource = daoTHUOC.getDSTHUOC_TOA();

            txtSoNgay.Text = "0";
            txtSang.Text = "0";
            txtTrua.Text = "0";
            txtChieu.Text = "0";
            txtToi.Text = "0";
        }

        private void btnKetoa_Click(object sender, EventArgs e)
        {
            TOA_THUOC t = LayTTTT();
            TT();
            suatt = 0;
            themtt = false;

            if (daoTT.InsertTT(t))
            {
                string idtt = daoTT.getTT_ID_MAX_by_KBID(txtIdTT_KB.Text).ToString();
                //gcThuoc.DataSource = daoCTTT.getCT_TOATHUOCbyID(idtt);
                //MessageBox.Show(idtt);
            }
            
        }

        private void txtTenThuoc_TextChanged(object sender, EventArgs e)
        {
            string tt = txtTenThuoc.Text;
            string dvt_cd = daoTHUOC.getDVT_CD_GIA(tt);
            string[] dvt_cd_split = dvt_cd.Split('/');
            txtDVT.Text = dvt_cd_split[0];
            txtCachDung.Text = dvt_cd_split[1];
            txtDonGia.Text = dvt_cd_split[2];
        }

        private void txtTenThuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSoNgay.Focus();
            }

            if (e.KeyCode == Keys.Tab)
            {
                txtSoNgay.Focus();
            }
        }

        private void txtSoNgay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                txtSang.Focus();
                int sn = int.Parse(txtSoNgay.Text);
                int sang = int.Parse(txtSang.Text);
                int trua = int.Parse(txtTrua.Text);
                int chieu = int.Parse(txtChieu.Text);
                int toi = int.Parse(txtToi.Text);
                int slg = sn * (sang + trua + chieu + toi);
                int dg = int.Parse(txtDonGia.Text);
                int tt = slg * dg;

                txtSL.Text = slg.ToString();
                txtThanhTien.Text = tt.ToString();
            }

            if (e.KeyCode == Keys.Tab)
            {

                txtSang.Focus();
                int sn = int.Parse(txtSoNgay.Text);
                int sang = int.Parse(txtSang.Text);
                int trua = int.Parse(txtTrua.Text);
                int chieu = int.Parse(txtChieu.Text);
                int toi = int.Parse(txtToi.Text);
                int slg = sn * (sang + trua + chieu + toi);
                int dg = int.Parse(txtDonGia.Text);
                int tt = slg * dg;

                txtSL.Text = slg.ToString();
                txtThanhTien.Text = tt.ToString();
            }
        }

        private void txtSang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                int sn = int.Parse(txtSoNgay.Text);
                int sang = int.Parse(txtSang.Text);
                int trua = int.Parse(txtTrua.Text);
                int chieu = int.Parse(txtChieu.Text);
                int toi = int.Parse(txtToi.Text);
                int slg = sn * (sang + trua + chieu + toi);
                int dg = int.Parse(txtDonGia.Text);
                int tt = slg * dg;

                txtSL.Text = slg.ToString();
                txtThanhTien.Text = tt.ToString();
                txtTrua.Focus();
            }

            if (e.KeyCode == Keys.Tab)
            {

                int sn = int.Parse(txtSoNgay.Text);
                int sang = int.Parse(txtSang.Text);
                int trua = int.Parse(txtTrua.Text);
                int chieu = int.Parse(txtChieu.Text);
                int toi = int.Parse(txtToi.Text);
                int slg = sn * (sang + trua + chieu + toi);
                int dg = int.Parse(txtDonGia.Text);
                int tt = slg * dg;

                txtSL.Text = slg.ToString();
                txtThanhTien.Text = tt.ToString();
                txtTrua.Focus();
            }
        }

        private void txtTrua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                int sn = int.Parse(txtSoNgay.Text);
                int sang = int.Parse(txtSang.Text);
                int trua = int.Parse(txtTrua.Text);
                int chieu = int.Parse(txtChieu.Text);
                int toi = int.Parse(txtToi.Text);
                int slg = sn * (sang + trua + chieu + toi);
                int dg = int.Parse(txtDonGia.Text);
                int tt = slg * dg;

                txtSL.Text = slg.ToString();
                txtThanhTien.Text = tt.ToString();
                txtChieu.Focus();
            }

            if (e.KeyCode == Keys.Tab)
            {

                int sn = int.Parse(txtSoNgay.Text);
                int sang = int.Parse(txtSang.Text);
                int trua = int.Parse(txtTrua.Text);
                int chieu = int.Parse(txtChieu.Text);
                int toi = int.Parse(txtToi.Text);
                int slg = sn * (sang + trua + chieu + toi);
                int dg = int.Parse(txtDonGia.Text);
                int tt = slg * dg;

                txtSL.Text = slg.ToString();
                txtThanhTien.Text = tt.ToString();
                txtChieu.Focus();
            }
        }

        private void txtChieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                int sn = int.Parse(txtSoNgay.Text);
                int sang = int.Parse(txtSang.Text);
                int trua = int.Parse(txtTrua.Text);
                int chieu = int.Parse(txtChieu.Text);
                int toi = int.Parse(txtToi.Text);
                int slg = sn * (sang + trua + chieu + toi);
                int dg = int.Parse(txtDonGia.Text);
                int tt = slg * dg;

                txtSL.Text = slg.ToString();
                txtThanhTien.Text = tt.ToString();
                txtToi.Focus();
            }

            if (e.KeyCode == Keys.Tab)
            {

                int sn = int.Parse(txtSoNgay.Text);
                int sang = int.Parse(txtSang.Text);
                int trua = int.Parse(txtTrua.Text);
                int chieu = int.Parse(txtChieu.Text);
                int toi = int.Parse(txtToi.Text);
                int slg = sn * (sang + trua + chieu + toi);
                int dg = int.Parse(txtDonGia.Text);
                int tt = slg * dg;

                txtSL.Text = slg.ToString();
                txtThanhTien.Text = tt.ToString();
                txtToi.Focus();
            }
        }

        private void txtToi_KeyDown(object sender, KeyEventArgs e)
        {
            

        }

        private void txtSoNgay_EditValueChanged(object sender, EventArgs e)
        {
            if(txtSoNgay.Text == "")
            {
                txtSoNgay.Text = "0";
            }
        }

        private void txtSang_EditValueChanged(object sender, EventArgs e)
        {
            if(txtSang.Text == "")
            {
                txtSang.Text = "0";
            }
        }

        private void txtTrua_EditValueChanged(object sender, EventArgs e)
        {
            if(txtTrua.Text == "")
            {
                txtTrua.Text = "0";
            }
        }

        private void txtChieu_EditValueChanged(object sender, EventArgs e)
        {
            if(txtChieu.Text == "")
            {
                txtChieu.Text = "0";
            }
        }

        private void txtToi_EditValueChanged(object sender, EventArgs e)
        {
            if(txtToi.Text == "")
            {
                txtToi.Text = "0";
            }
        }

        private void txtToi_KeyDown_1(object sender, KeyEventArgs e)
        {
            TOA_THUOC t = LayTTTT();
            CT_TOATHUOC ct = LayCTTT();
            if (e.KeyCode == Keys.Enter)
            {
                
                int sn = int.Parse(txtSoNgay.Text);
                int sang = int.Parse(txtSang.Text);
                int trua = int.Parse(txtTrua.Text);
                int chieu = int.Parse(txtChieu.Text);
                int toi = int.Parse(txtToi.Text);
                int slg = sn * (sang + trua + chieu + toi);
                int dg = int.Parse(txtDonGia.Text);
                float ttien = slg * dg;
                txtSL.Text = slg.ToString();
                txtThanhTien.Text = ttien.ToString();
                txtSL.Focus();
                
                //daoCTTT.InsertCTTT(ct);
                //gcThuoc.DataSource = daoCTTT.getCT_TOATHUOCbyID(daoTT.getIDTT_MAX().ToString());
                //MessageBox.Show("Thêm thành công");
                    
            }

            if (e.KeyCode == Keys.Tab)
            {

                int sn = int.Parse(txtSoNgay.Text);
                int sang = int.Parse(txtSang.Text);
                int trua = int.Parse(txtTrua.Text);
                int chieu = int.Parse(txtChieu.Text);
                int toi = int.Parse(txtToi.Text);
                int slg = sn * (sang + trua + chieu + toi);
                int dg = int.Parse(txtDonGia.Text);
                float ttien = slg * dg;
                txtSL.Text = slg.ToString();
                txtThanhTien.Text = ttien.ToString();
                txtSL.Focus();

                //daoCTTT.InsertCTTT(ct);
                //gcThuoc.DataSource = daoCTTT.getCT_TOATHUOCbyID(daoTT.getIDTT_MAX().ToString());
                //MessageBox.Show("Thêm thành công");

            }
        }

        private void txtSL_KeyDown(object sender, KeyEventArgs e)
        {
            TOA_THUOC t = LayTTTT();
            CT_TOATHUOC ct = LayCTTT();
            
            if (e.KeyCode == Keys.Enter)
            {

                int sn = int.Parse(txtSoNgay.Text);
                int sang = int.Parse(txtSang.Text);
                int trua = int.Parse(txtTrua.Text);
                int chieu = int.Parse(txtChieu.Text);
                int toi = int.Parse(txtToi.Text);
                int slg = sn * (sang + trua + chieu + toi);
                int dg = int.Parse(txtDonGia.Text);
                float ttien = slg * dg;
                txtSL.Text = slg.ToString();
                txtThanhTien.Text = ttien.ToString();

                string idtt = daoTT.getTT_ID_MAX_by_KBID(txtIdTT_KB.Text).ToString();
                //gcThuoc.DataSource = daoCTTT.getCT_TOATHUOCbyID(idtt);


                if (suatt == 1)
                {
                    CT_TOATHUOC ctt = LayCTTT_SUA();
                    daoCTTT.InsertCTTT(ctt);
                    gcThuoc.DataSource = daoCTTT.getCT_TOATHUOCbyID(idtt);
                }
                else
                {
                    daoCTTT.InsertCTTT(ct);
                    gcThuoc.DataSource = daoCTTT.getCT_TOATHUOCbyID(idtt);
                }
                //MessageBox.Show("Thêm thành công");

            }

            if (e.KeyCode == Keys.Tab)
            {

                int sn = int.Parse(txtSoNgay.Text);
                int sang = int.Parse(txtSang.Text);
                int trua = int.Parse(txtTrua.Text);
                int chieu = int.Parse(txtChieu.Text);
                int toi = int.Parse(txtToi.Text);
                int slg = sn * (sang + trua + chieu + toi);
                int dg = int.Parse(txtDonGia.Text);
                float ttien = slg * dg;
                txtSL.Text = slg.ToString();
                txtThanhTien.Text = ttien.ToString();

                string idtt = daoTT.getTT_ID_MAX_by_KBID(txtIdTT_KB.Text).ToString();
                //gcThuoc.DataSource = daoCTTT.getCT_TOATHUOCbyID(idtt);

                if (suatt == 1)
                {
                    CT_TOATHUOC ctt = LayCTTT_SUA();
                    daoCTTT.InsertCTTT(ctt);
                    //gcThuoc.DataSource = daoCTTT.getCT_TOATHUOCbyID(gridView1.GetFocusedRowCellValue("TT_ID").ToString());
                    gcThuoc.DataSource = daoCTTT.getCT_TOATHUOCbyID(idtt);
                }
                else
                {
                    daoCTTT.InsertCTTT(ct);
                    gcThuoc.DataSource = daoCTTT.getCT_TOATHUOCbyID(idtt);
                }
                
                //MessageBox.Show("Thêm thành công");

            }
        }

        private void gridView5_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            delete = true;
        }

        private void gridView5_KeyDown(object sender, KeyEventArgs e)
        {
            if(delete == true)
            {
                try
                {
                    DialogResult dr = MessageBox.Show("Bạn có muốn xóa thuốc '" + gridView5.GetFocusedRowCellValue("THUOC_TEN").ToString() + "' trong toa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        daoCTTT.xoaCT_TOATHUOC(gridView5.GetFocusedRowCellValue("THUOC_ID").ToString());
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gcThuoc.DataSource = daoCTTT.getCT_TOATHUOCbyID(daoTT.getIDTT_MAX().ToString());
                    }
                }
                catch
                {
                    //MessageBox.Show("Không thể xóa loại bệnh lý '" + lbTen.Text + "' vì có bệnh lý thuộc loại bệnh lý này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void gdToa_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            gcThuoc2.DataSource = daoCTTT.getCT_TOATHUOCbyID(gridView1.GetFocusedRowCellValue("TT_ID").ToString());
            showFormTT();
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            intoathuoc();
        }

        

        void intoathuoc()
        {
            rptToaThuoc tt = new rptToaThuoc();
            tt.lbTenBN.Text = txtTen2.Text;
            tt.lbDiaChi.Text = txtDiachi2.Text;
            tt.lbICD.Text = txtICD.Text;
            tt.lbNgay.Text = DateTime.Now.Day.ToString();
            tt.lbThang.Text = DateTime.Now.Month.ToString();
            tt.lbNam.Text = DateTime.Now.Year.ToString();
            tt.lbTuoi.Text = txtTuoinam2.Text;
            tt.lbGioiTinh.Text = cbGioitinh2.Text;
            tt.lbTenBS.Text = gridView3.GetFocusedRowCellValue("NV_HOTEN").ToString();
            

            tt.DataSource = gcThuoc.DataSource;
            tt.BindData();
            //printControl1.PrintingSystem = tt.PrintingSystem;
            tt.CreateDocument();
            tt.ShowPreviewDialog();
        }

        void timKiemICD_BL()
        {
            string s = txtTKBL.Text;


            if (s.Length > 0)
            {
                gdBL.DataSource = daoBL.timICD_BL(s);
                //gdPTN.DataSource = daoPTN.TimPTN(s);
                //gcCLS.DataSource = daoCLS.TimCLS(s);

            }
            else if (s.Length == 0)
            {
                gdBL.DataSource = daoBL.getBL();
            }
        }

        private void txtTKBL_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            
        }

        private void txtTKBL_EditValueChanged(object sender, EventArgs e)
        {
            timKiemICD_BL();
        }

        private void tabKT_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if(ttid_sua == gridView1.GetFocusedRowCellValue("TT_ID").ToString())
                {
                    pnNhapThuoc.Enabled = true;
                    gcThuoc.DataSource = daoCTTT.getCT_TOATHUOCbyID(gridView1.GetFocusedRowCellValue("TT_ID").ToString());
                    TT();
                    suatt = 1;

                }
                else
                {
                    DataTable dt = new DataTable();
                    gcThuoc.DataSource = dt;
                    pnNhapThuoc.Enabled = false;
                }
            }
        }

        private void gridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
           
        }

        private void btnLapPCD_Click(object sender, EventArgs e)
        {
            PHIEU_CHI_DINH t = LayTTPCD();
            if(daoPCD.InsertPCD(t))
            {
                gcPCD.DataSource = daoPCD.getPCD_by_KBID(txtIdTT_KB.Text);
                loadDMCLS();
            }
        }

        private void gridView8_Click(object sender, EventArgs e)
        {
            txtSoPCD.Text = gridView8.GetFocusedRowCellValue("PCD_ID").ToString();
            gcCTPCD.DataSource = daoCTCLS.getCT_CLS_by_IDPCD(gridView8.GetFocusedRowCellValue("PCD_ID").ToString());
        }

        private void gridView8_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            delete_pcd = true;
        }

        private void gridView8_KeyDown(object sender, KeyEventArgs e)
        {
            if(delete_pcd == true)
            {
                try
                {
                    DialogResult dr = MessageBox.Show("Bạn có muốn xóa phiếu chỉ định '" + gridView8.GetFocusedRowCellValue("PCD_ID").ToString() + "' ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        daoPCD.deletePCD(gridView8.GetFocusedRowCellValue("PCD_ID").ToString());
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gcPCD.DataSource = daoPCD.getPCD_by_KBID(txtIdTT_KB.Text);
                    }
                }
                catch
                {
                    MessageBox.Show("Không thể xóa phiếu chỉ định này vì có chỉ định cận lâm sàn trong phiếu !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void gridView7_DoubleClick(object sender, EventArgs e)
        {
            CT_CLS t = LayCTCLS();
            if(daoCTCLS.InsertCT_CLS(t))
            {
                gcCTPCD.DataSource = daoCTCLS.getCT_CLS_by_IDPCD(gridView8.GetFocusedRowCellValue("PCD_ID").ToString());
            }
        }

        private void gridView7_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedRowHandle == e.RowHandle && !view.FocusedColumn.Equals(e.Column))
                e.Appearance.BackColor = Color.Orange;
        }

        private void gridView9_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            delete_ctpcd = true;
        }

        private void gridView9_KeyDown(object sender, KeyEventArgs e)
        {
            if (delete_ctpcd == true)
            {
                try
                {
                    DialogResult dr = MessageBox.Show("Bạn có muốn xóa phiếu chỉ định '" + gridView8.GetFocusedRowCellValue("PCD_ID").ToString() + "' ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        daoCTCLS.deleteCT_CLS(gridView9.GetFocusedRowCellValue("CLS_ID").ToString());
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gcCTPCD.DataSource = daoCTCLS.getCT_CLS_by_IDPCD(gridView8.GetFocusedRowCellValue("PCD_ID").ToString());
                    }
                }
                catch
                {
                    MessageBox.Show("Không thể xóa phiếu chỉ định này vì có chỉ định cận lâm sàn trong phiếu !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnThemCLS_Click(object sender, EventArgs e)
        {
            pnDMCLS.Enabled = true;
            gcDM_CLS.DataSource = daoCLS.getDSCLS();
        }

        private void btnSuDungLaiToaCu_Click(object sender, EventArgs e)
        {
            TOA_THUOC t = LayTTTT();
            CT_TOATHUOC ct = new CT_TOATHUOC();
            //TT();
            //suatt = 0;
            //themtt = false;

            if (daoTT.InsertTT(t))
            {
                string idtt = daoTT.getTT_ID_MAX_by_KBID(txtIdTT_KB.Text).ToString();
                //gcThuoc.DataSource = daoCTTT.getCT_TOATHUOCbyID(idtt);
                MessageBox.Show(idtt);
            }

            DataTable dt = new DataTable();
            dt = daoCTTT.getCT_TOATHUOCbyID(gridView1.GetFocusedRowCellValue("TT_ID").ToString());

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int idtt = daoTT.getTT_ID_MAX_by_KBID(txtIdTT_KB.Text);
                ct.Id_tt = idtt;
                ct.Id_thuoc = dt.Rows[i]["THUOC_ID"].ToString();
                ct.Ctt_songayuong = int.Parse(dt.Rows[i]["CTT_SONGAYUONG"].ToString());
                ct.Ctt_cachdung = dt.Rows[i]["CTT_CACHDUNG"].ToString();
                ct.Ctt_sang = int.Parse(dt.Rows[i]["CTT_SANG"].ToString());
                ct.Ctt_trua = int.Parse(dt.Rows[i]["CTT_TRUA"].ToString());
                ct.Ctt_chieu = int.Parse(dt.Rows[i]["CTT_CHIEU"].ToString());
                ct.Ctt_toi = int.Parse(dt.Rows[i]["CTT_TOI"].ToString());
                int sl = int.Parse(dt.Rows[i]["CTT_SOLUONG"].ToString());
                ct.Ctt_sl = sl;
                ct.Ctt_dongia = float.Parse(dt.Rows[i]["CTT_DONGIA"].ToString());
                ct.Ctt_thanhtien = float.Parse(dt.Rows[i]["CTT_THANHTIEN"].ToString());
                //ct.Thuoc_ten = dt.Rows[i]["THUOC_TEN"].ToString();
                //MessageBox.Show(a);
                daoCTTT.InsertCTTT(ct);
                gcThuoc.DataSource = daoCTTT.getCT_TOATHUOCbyID(daoTT.getTT_ID_MAX_by_KBID(txtIdTT_KB.Text).ToString());
            }
            gdToa.DataSource = daoTT.getTTbyBN(int.Parse(gridView3.GetFocusedRowCellValue("BN_ID").ToString()));
            frmTT.Close();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            if (cbTT.Text == "Chờ khám")
            {
                //btnKham.Enabled = true;
                btnSua.Enabled = false;
                //DateChonNgay.Enabled = false;
                loadPTN();
                dongbang();
            }
            else if (cbTT.Text == "Đang khám")
            {


                //DateChonNgay.Enabled = true;
                loadKB_NGAY_DK();
                btnKham.Enabled = false;
                //btnSua.Enabled = true;
                dongbang();

            }
            else if (cbTT.Text == "Đã khám")
            {
                btnKham.Enabled = false;
                //btnSua.Enabled = true;
                //DateChonNgay.Enabled = false;
                loadKB_NGAY_KX();
                dongbang();
            }
            else
            {
                loadKB_NGAY();
                dongbang();
            }
        }

        void loadLSK()
        {
            string bnid = gridView3.GetFocusedRowCellValue("BN_ID").ToString();
            string ngay = DateLSK_BD.Text;
            string ngay2 = DateLSK_KT.Text;
            gcLSK.DataSource = daoKB.getKB_NGAY_LSK(bnid, ngay, ngay2);
        }

        private void btnLamMoiLSK_Click(object sender, EventArgs e)
        {
            loadLSK();
        }

        private void gridView10_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //txtSTT2.Text = gridView3.GetFocusedRowCellValue("TN_STT").ToString();
            txtMaBN_LSK.Text = gridView10.GetFocusedRowCellValue("BN_ID").ToString();
            txtTenBN_LSK.Text = gridView10.GetFocusedRowCellValue("BN_HOTEN").ToString();
            //txtCDCLS_TENBN.Text = gridView3.GetFocusedRowCellValue("BN_HOTEN").ToString();
            //txtCMT2.Text = gridView3.GetFocusedRowCellValue("BN_CMT").ToString();
            //txtSDT2.Text = gridView3.GetFocusedRowCellValue("BN_SDT").ToString();
            txtDiachi_LSK.Text = gridView10.GetFocusedRowCellValue("BN_DIACHI").ToString();
            //DateNS2.Text = gridView3.GetFocusedRowCellValue("BN_NGAYSINH").ToString();
            txtGioitinh_LSK.Text = gridView10.GetFocusedRowCellValue("BN_GIOITINH").ToString();
            //txtCDCLS_GT.Text = gridView3.GetFocusedRowCellValue("BN_GIOITINH").ToString();
            //cbNhommau.Text = gridView3.GetFocusedRowCellValue("BN_NHOMMAU").ToString();
            //txtTuoithang2.Text = gridView3.GetFocusedRowCellValue("TN_TUOITHANG").ToString();
            txtTuoi_LSK.Text = gridView10.GetFocusedRowCellValue("TN_TUOINAM").ToString();
            //txtCDCLS_TUOI.Text = gridView3.GetFocusedRowCellValue("TN_TUOINAM").ToString();
            //cbBSK2.Text = gridView3.GetFocusedRowCellValue("NV_HOTEN").ToString();
            txtMach_LSK.Text = gridView10.GetFocusedRowCellValue("TN_MACH").ToString();
            txtNhietdo_LSK.Text = gridView10.GetFocusedRowCellValue("TN_NHIETDO").ToString();
            txtNhiptho_LSK.Text = gridView10.GetFocusedRowCellValue("TN_NHIPTHO").ToString();
            //txtHuyetap.Text = gridView3.GetFocusedRowCellValue("TN_HUYETAP").ToString();
            string ha = gridView10.GetFocusedRowCellValue("TN_HUYETAP").ToString();
            string[] ha_split = ha.Split('/');
            txtHuyetap_LSK.Text = ha_split[0];
            txtHuyetap2_LSK.Text = ha_split[1];

            txtChieucao_LSK.Text = gridView10.GetFocusedRowCellValue("TN_CHIEUCAO").ToString();
            txtCannang_LSK.Text = gridView10.GetFocusedRowCellValue("TN_CANNANG").ToString();
            txtBMI_LSK.Text = gridView10.GetFocusedRowCellValue("TN_BMI").ToString();
            string kb = gridView10.GetFocusedRowCellValue("KB_ID").ToString();
            txtIdTT_KB.Text = gridView10.GetFocusedRowCellValue("KB_ID").ToString();

            string icd = daoKB.getBL_ICD(kb);
            string[] icd_split = icd.Split('/');
            //txtMaICD.Text = icd_split[0];
            txtICD_LSK.Text = icd_split[0];
            txtTenICD_LSK.Text = icd_split[1];
            //txtChuyenmon.Text = icd_split[2];
            //txtMucdo.Text = icd_split[3];

            //string bp = daoKB.getBL_PHU(kb);
            //string[] bp_split = bp.Split('/');
            //txtMaBP.Text = bp_split[0];
            txtBP_LSK.Text = gridView10.GetFocusedRowCellValue("KB_BENHPHU").ToString();

            //gdToa.DataSource = daoTT.getTTbyBN(int.Parse(gridView3.GetFocusedRowCellValue("BN_ID").ToString()));

            //gcPCD.DataSource = daoPCD.getPCD_by_KBID(txtIdTT_KB.Text);
            string idtt = daoTT.getTT_ID_MAX_by_KBID(txtIdTT_KB.Text).ToString();

            gcTT_LSK.DataSource = daoCTTT.getCT_TOATHUOCbyID(idtt);

            gcCLS_LSK.DataSource = daoCTCLS.getCLS_LSK(txtIdTT_KB.Text);

            //btnSua.Enabled = true;

            //kbid = daoKB.getKBID_by_TNID(gridView3.GetFocusedRowCellValue("TN_ID").ToString());
        }

        

        AutoCompleteStringCollection Sudung_LSK()
        {
            AutoCompleteStringCollection auto2 = new AutoCompleteStringCollection();
            auto2.Add("Sử dụng lại lịch sử khám");
            

            return auto2;
        }

        private void auto2_Click(object sender, EventArgs e)
        {

        }

        private void gridView10_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Right)
            {
                Sudung_LSK();
            }
        }

        private void SDL_LSK_Click(object sender, EventArgs e)
        {

        }

        private void btnSDL_LSK_Click(object sender, EventArgs e)
        {
            txtMaICD.Text = txtICD_LSK.Text;
            txtICD.Text = txtTenICD_LSK.Text;

            string kb = gridView10.GetFocusedRowCellValue("KB_ID").ToString();

            string icd = daoKB.getBL_ICD(kb);
            string[] icd_split = icd.Split('/');
            txtChuyenmon.Text = icd_split[2];
            txtMucdo.Text = icd_split[3];

            txtBenhphu.Text = gridView10.GetFocusedRowCellValue("KB_BENHPHU").ToString();
        }

        void timPTN()
        {
            DateTime ht = System.DateTime.Now;
            string ngay = ht.ToShortDateString();
            ngay = ngay.Replace("/", "");
            string tk = txtTimKiem.Text;

            gdPTNH.DataSource = daoPTN.timPTN_NGAY(ngay, tk);
            xuly(false);

            //gdPTN.DataSource = daoPTN.getDSPTN();
        }

        void timKB_NGAY()
        {
            DateTime ht = System.DateTime.Now;
            string ngay = ht.ToShortDateString();
            ngay = ngay.Replace("/", "");

            string tk = txtTimKiem.Text;

            gdPTNH.DataSource = daoKB.timKB_NGAY(ngay,tk);
            xuly(false);
        }

        void timKB_NGAY_DK()
        {
            DateTime ht = System.DateTime.Now;
            string ngay = ht.ToShortDateString();
            ngay = ngay.Replace("/", "");
            string tk = txtTimKiem.Text;

            gdPTNH.DataSource = daoKB.timKB_NGAY_DK(ngay,tk);
            xuly(false);
        }


        void timKB_NGAY_KX()
        {
            DateTime ht = System.DateTime.Now;
            string ngay = ht.ToShortDateString();
            ngay = ngay.Replace("/", "");
            string tk = txtTimKiem.Text;

            gdPTNH.DataSource = daoKB.timKB_NGAY_KX(ngay,tk);
            xuly(false);
        }


        private void txtTimKiem_EditValueChanged(object sender, EventArgs e)
        {
            if (cbTT.Text == "Chờ khám")
            {
                //btnKham.Enabled = true;
                btnSua.Enabled = false;
                //DateChonNgay.Enabled = false;
                timPTN();
                dongbang();
            }
            else if (cbTT.Text == "Đang khám")
            {


                //DateChonNgay.Enabled = true;
                timKB_NGAY_DK();
                btnKham.Enabled = false;
                //btnSua.Enabled = true;
                dongbang();

            }
            else if (cbTT.Text == "Đã khám")
            {
                btnKham.Enabled = false;
                //btnSua.Enabled = true;
                //DateChonNgay.Enabled = false;
                timKB_NGAY_KX();
                dongbang();
            }
            else
            {
                timKB_NGAY();
                dongbang();
            }
        }

        void inPCD()
        {
            rptPCD_CLS tt = new rptPCD_CLS();
            tt.lbTenBN.Text = txtTen2.Text;
            tt.lbDiaChi.Text = txtDiachi2.Text;
            tt.lbICD.Text = txtICD.Text;
            tt.lbNgay.Text = DateTime.Now.Day.ToString();
            tt.lbThang.Text = DateTime.Now.Month.ToString();
            tt.lbNam.Text = DateTime.Now.Year.ToString();
            tt.lbTuoi.Text = txtTuoinam2.Text;
            tt.lbGioiTinh.Text = cbGioitinh2.Text;
            tt.lbTenBS.Text = frmDANG_NHAP.nguoidung;
            tt.lbMach.Text = txtMach.Text;
            tt.lbNhietdo.Text = txtNhietdo.Text;
            tt.lbHuyetap.Text = txtHuyetap.Text;
            tt.lbHuyetap2.Text = txtHuyetap2.Text;
            tt.lbMaPhieu.Text = txtSoPCD.Text;

            tt.DataSource = gcCTPCD.DataSource;
            tt.BindData();
            //printControl1.PrintingSystem = tt.PrintingSystem;
            tt.CreateDocument();
            tt.ShowPreviewDialog();
        }

        private void btnInPCD_Click(object sender, EventArgs e)
        {
            inPCD();
        }

        private void btnHoantat_Click(object sender, EventArgs e)
        {
            KHAM_BENH s = LayTTKB_HT();
            CT_BENHLY cs = LayTTCTBL_SUA();
            CT_BENHLY cps = LayTTCTBL_P_SUA();
            PHIEU_TIEP_NHAN p = LayTTPTN_KX();
            if (daoKB.UpdateKB(s))
            {
                if (txtMaICD.Text == "" || txtICD.Text == "")
                {
                    MessageBox.Show("Chưa nhập chuẩn đoán ICD");
                }
                else
                {
                    daoCTBL.deleteCTBL(cs);
                    daoCTBL.InsertCTBL(cs);
                    //daoCTBL.deleteCTBL(cps);
                    //daoCTBL.InsertCTBL(cps);
                    daoKB.UpdateKB(s);
                    daoPTN.UpdatePTN_KX(p);
                    MessageBox.Show("Hoàn tất khám thành công");
                    btnLuu2.Enabled = false;
                    xuly(false);
                    btnKham.Enabled = false;
                    btnSua.Enabled = true;
                    btnKetoa.Enabled = false;
                    pnTT.Enabled = false;
                    gdPTNH.Enabled = true;
                    pnCDCLS.Enabled = false;
                    pnLSK.Enabled = false;
                }
            }
        }

        private void cmSDL_LSK_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}

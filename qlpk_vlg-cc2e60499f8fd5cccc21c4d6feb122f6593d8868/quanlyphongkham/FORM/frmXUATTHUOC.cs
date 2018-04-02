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
    public partial class frmXUATTHUOC : Form
    {
        public frmXUATTHUOC()
        {
            InitializeComponent();
        }
        DAO_XUATTHUOC daoXT = new DAO_XUATTHUOC();
        DAO_HOADON daoHD = new DAO_HOADON();
        DataTable dtCTTT = null;
        DataTable dtCTCLS = null;
        DataTable dtDVK = null;
        DataTable dtCTKHO = null;

        private void frmXUATTHUOC_Load(object sender, EventArgs e)
        {
           
           
        }

        void loadData()
        {
            dtCTTT = new DataTable();
            dtCTTT = daoXT.getCTToaThuoc(lbID_TT.Text);

            dtDVK = new DataTable();
            dtDVK = daoXT.getDVKham(lbID_BN.Text);

            dtCTCLS = new DataTable();
            dtCTCLS = daoXT.getCLS(lbID_BN.Text);

            dtCTKHO = new DataTable();
            dtCTKHO = daoXT.getCTKHO(lbID_TT.Text);
        }

        private void lstCP_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (var sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;

                using (var headerFont = new Font("Microsoft Sans Serif", 9, FontStyle.Bold))
                {
                    //e.Graphics.FillRectangle(Brushes.Pink, e.Bounds);
                    e.Graphics.DrawString(e.Header.Text, headerFont,
                        Brushes.Black, e.Bounds, sf);
                }
            }
        }

        void loadlist(){
            dtCTCLS = null;
            dtCTTT = null;
            dtDVK = null;
            try
            {
                loadData();

                lstCP.Items.Clear();
                lstCP.Groups.Clear();
                ListViewGroup group = new ListViewGroup("Công khám");
                ListViewGroup group2 = new ListViewGroup("Cận lâm sàng");
                ListViewGroup group3 = new ListViewGroup("Thuốc");
                ListViewGroup group4 = new ListViewGroup("Tổng tiền");
                lstCP.Groups.AddRange(new ListViewGroup[] { group, group2, group3, group4 });

                float solg = 0;
                float dongia = 0;
                float thanhtien = 0;
                float tongtien = 0;

                if (gcDSBN.DataSource != null)
                {
                    for (int i = 0; i < dtCTTT.Rows.Count; i++)
                    {
                        solg = float.Parse(dtCTTT.Rows[i]["CTT_SOLUONG"].ToString());
                        dongia = float.Parse(dtCTTT.Rows[i]["CTPN_GIABAN"].ToString());
                        thanhtien = dongia * solg;
                        ListViewItem item2 = new ListViewItem((i + 1).ToString(), group3);
                        item2.SubItems.Add(dtCTTT.Rows[i]["VT_TEN"].ToString());
                        item2.SubItems.Add(dtCTTT.Rows[i]["CTT_SOLUONG"].ToString());
                        item2.SubItems.Add(dongia.ToString("#,###"));
                        item2.SubItems.Add(thanhtien.ToString("#,###"));
                        lstCP.Items.Add(item2);

                        tongtien += thanhtien;
                    }

                    for (int i = 0; i < dtDVK.Rows.Count; i++)
                    {
                        solg = 1;
                        dongia = float.Parse(dtDVK.Rows[i]["DVK_DONGIA"].ToString());
                        thanhtien = dongia * solg;
                        lbId_TNHAN.Text = dtDVK.Rows[i]["TN_ID"].ToString();
                        ListViewItem item2 = new ListViewItem((i + 1).ToString(), group);
                        item2.SubItems.Add(dtDVK.Rows[i]["DVK_TEN"].ToString());
                        item2.SubItems.Add("");
                        item2.SubItems.Add(dongia.ToString("#,###"));
                        item2.SubItems.Add(thanhtien.ToString("#,###"));
                        lstCP.Items.Add(item2);

                        tongtien += thanhtien;
                    }

                    for (int i = 0; i < dtCTCLS.Rows.Count; i++)
                    {
                        solg = float.Parse(dtCTCLS.Rows[i]["CTCLS_SOLUONG"].ToString());
                        dongia = float.Parse(dtCTCLS.Rows[i]["CLS_DONGIA"].ToString());
                        thanhtien = dongia * solg;
                        ListViewItem item2 = new ListViewItem((i + 1).ToString(), group2);
                        item2.SubItems.Add(dtCTCLS.Rows[i]["CLS_TEN"].ToString());
                        item2.SubItems.Add(solg.ToString());
                        item2.SubItems.Add(dongia.ToString("#,###"));
                        item2.SubItems.Add(thanhtien.ToString("#,###"));
                        lstCP.Items.Add(item2);

                        tongtien += thanhtien;
                    }
                    lbTongTien.Text = tongtien.ToString();

                    ListViewItem item4 = new ListViewItem("Tổng tiền", group4);
                    item4.SubItems.Add("");
                    item4.SubItems.Add("");
                    item4.SubItems.Add("");
                    item4.SubItems.Add(tongtien.ToString("#,###"));
                    lstCP.Items.Add(item4);
                }

                gcThanhToan.DataSource = daoXT.getHoaDonDaTT(lbId_TNHAN.Text);
            }
            catch { }
        }

        
        private HOA_DON layTTHD(string id)
        {
            string hoadon_id = id;
            string tn = lbId_TNHAN.Text;
            int nv = 1;
            DateTime ngay = DateTime.Now;
            string trangthai = "Đã thanh toán";
            if (daoXT.KiemTraHoaDonDaTT(lbId_TNHAN.Text) == 0)
            {
                trangthai = "Đã thanh toán";
            }
            else
            {
                trangthai = "Hủy";
            }
            
            int lantt = 1;
            HOA_DON hdon = new HOA_DON(hoadon_id, tn, nv, ngay, trangthai, lantt);
            return hdon;
        }

        
        private void btnTT_Click(object sender, EventArgs e)
        {
            //try
            //{
                bool b = false;
                if (daoXT.KiemTraHoaDonDaTT(lbId_TNHAN.Text) == 0)
                {
                    string hd_id = daoXT.get_ID_auto();
                    HOA_DON hoadon = layTTHD(hd_id);
                    daoHD.Insert_HoaDon(hoadon);
                    if (dtCTCLS.Rows.Count != 0)
                    {
                       
                        for (int i = 0; i < dtCTCLS.Rows.Count; i++)
                        {
                            string hd = hd_id;
                            int cls = int.Parse(dtCTCLS.Rows[i]["CLS_ID"].ToString());
                            int pcd = int.Parse(dtCTCLS.Rows[i]["PCD_ID"].ToString());
                            int solg = int.Parse(dtCTCLS.Rows[i]["CTCLS_SOLUONG"].ToString());
                            float gia = float.Parse(dtCTCLS.Rows[i]["CLS_DONGIA"].ToString());
                            float thanhtien = solg * gia;

                            CT_HOADONVIENPHI hdvp = new CT_HOADONVIENPHI(pcd, cls, hd, solg, gia, thanhtien);
                            if (daoXT.Insert_HDVP(hdvp))
                            {
                                b = true;
                            }
                        }
                    }

                    if (dtCTKHO.Rows.Count != 0)
                    {
                       
                        for (int i = 0; i < dtCTKHO.Rows.Count; i++)
                        {
                            string hd = hd_id;
                            string kho = dtCTKHO.Rows[i]["KHO_ID"].ToString();
                            int ngvu = int.Parse(dtCTKHO.Rows[i]["NGV_ID"].ToString());
                            string vattu = dtCTKHO.Rows[i]["VT_ID"].ToString();
                            DateTime thoidiem = DateTime.Parse(dtCTKHO.Rows[i]["KCT_THOIDIEM"].ToString());
                            string id_nhapkhoct = dtCTKHO.Rows[i]["ID_NHAPKHOCHITIET"].ToString();
                            int solg = int.Parse(dtCTKHO.Rows[i]["KCT_SOLUONG"].ToString());
                            float gia = float.Parse(dtCTKHO.Rows[i]["KCT_DONGIA"].ToString());
                            float thanhtien = solg * gia;

                            CT_HOADONTHUOC hoadonthuoc = new CT_HOADONTHUOC(hd, kho, vattu, ngvu, thoidiem,
                                                                    id_nhapkhoct, solg, gia, thanhtien);
                            daoXT.Insert_HDTHUOC(hoadonthuoc);
                            //if ()
                            //{
                            //    b = true;
                            //}
                        }
                    }
                    if (b == true)
                    {
                        MessageBox.Show("Thanh toán thành công", "Thông báo");
                    }

                    gcThanhToan.DataSource = daoXT.getHoaDonDaTT(lbId_TNHAN.Text);
                }
                else
                {
                    MessageBox.Show("Hóa đơn này đã được thanh toán. Nếu muốn thanh toán lại hãy hủy thanh toán", "Thông báo");
                }
              
            //}
            //catch { }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                lbID_BN.Text = gridView1.GetFocusedRowCellValue("BN_ID").ToString();
                lbID_TT.Text = gridView1.GetFocusedRowCellValue("TT_ID").ToString();
                txtBN.Text = gridView1.GetFocusedRowCellValue("BN_HOTEN").ToString();
                int gt = int.Parse(gridView1.GetFocusedRowCellValue("BN_GIOITINH").ToString());
                if (gt == 1)
                {
                    txtGT.Text = "Nam";
                }
                else
                {
                    txtGT.Text = "Nữ";
                }
                DateTime ns = DateTime.Parse(gridView1.GetFocusedRowCellValue("BN_NGAYSINH").ToString());
                txtNgaySinh.Text = ns.ToShortDateString();
                txtChuanDoan.Text = gridView1.GetFocusedRowCellValue("KB_KETLUAN").ToString();

                loadlist();
            }
            catch { }
        }


        void LoadListDSToa()
        {
            DataTable dt = daoXT.getToaThuocByBN(dtpNgay.Text, dtpDenNgay.Text);
            if (dt.Rows.Count != 0)
            {
                gcDSBN.DataSource = dt;
            }
            else
            {
                gcDSBN.DataSource = null;
            }
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    LoadListDSToa();
            //}
            //catch { }
        }

        private void btnF5_Click(object sender, EventArgs e)
        {
            LoadListDSToa();
            loadlist();
            if (gcDSBN.DataSource == null)
            {
                lstCP.Items.Clear();
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                lbHD_ID.Text = gridView2.GetFocusedRowCellValue("HD_ID").ToString();
                txtNV.Text = gridView2.GetFocusedRowCellValue("NV_HOTEN").ToString();
                txtSoTien.Text = gridView2.GetFocusedRowCellValue("tongtien").ToString();
                txtNgayTT.Text = gridView2.GetFocusedRowCellValue("HD_NGAY").ToString();
                txtLanTT.Text = gridView2.GetFocusedRowCellValue("HD_LANTT").ToString();
            }
            catch { }
        }

        private void btnHuyTT_Click(object sender, EventArgs e)
        {
            try
            {
                HOA_DON hoadon = layTTHD(lbHD_ID.Text);
                if (daoHD.update_HoaDon(hoadon))
                {
                    gcThanhToan.DataSource = daoXT.getHoaDonDaTT(lbId_TNHAN.Text);
                }
            }
            catch { }
        }
    }
}

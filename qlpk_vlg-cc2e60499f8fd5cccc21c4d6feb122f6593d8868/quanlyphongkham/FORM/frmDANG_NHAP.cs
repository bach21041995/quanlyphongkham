using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using quanlyphongkham.DAO;

namespace quanlyphongkham.FORM
{
    public partial class frmDANG_NHAP : Form
    {
        public frmDANG_NHAP()
        {
            InitializeComponent();
        }

        DAO_DANG_NHAP dao_dn = new DAO_DANG_NHAP();
        public DataTable dt = new DataTable();
        public static string nguoidung = "";
        public static string ngaysinh = "";
        public static string gioitinh = "";
        public static string cv = "";
        public static string cd = "";
        public static string sdt = "";
        public static string taikhoan = "";
        public static string matkhau = "";
        public static int idnv = 0;

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            taikhoan = txtTK.Text;
            matkhau = txtMK.Text;
            frmMain main = new frmMain();
            if (dao_dn.checkLogin(taikhoan, matkhau))
            {
                dt = dao_dn.getTK_MK(taikhoan, matkhau);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Đăng nhập không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTK.Focus();
                }
                else
                {
                    DialogResult = DialogResult.OK;
                    foreach (DataRow item in dt.Rows)
                    {
                        idnv = int.Parse(item["NV_ID"].ToString());
                        nguoidung = item["NV_HOTEN"].ToString();
                        cv = item["CV_TEN"].ToString();
                        cd = item["CD_TEN"].ToString();
                        sdt = item["NV_SDT"].ToString();
                        gioitinh = item["NV_GIOITINH"].ToString();
                        ngaysinh = item["NV_NGAYSINH"].ToString();
                        idnv = int.Parse(item["NV_ID"].ToString());
                    }

                }
            }
        }

        private void btnDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            taikhoan = txtTK.Text;
            matkhau = txtMK.Text;
            frmMain main = new frmMain();
            if (e.KeyCode == Keys.Enter)
            {
                if (dao_dn.checkLogin(taikhoan, matkhau))
                {
                    dt = dao_dn.getTK_MK(taikhoan, matkhau);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Đăng nhập không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTK.Focus();
                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                        foreach (DataRow item in dt.Rows)
                        {
                            nguoidung = item["NV_HOTEN"].ToString();
                            cv = item["CV_TEN"].ToString();
                            cd = item["CD_TEN"].ToString();
                            sdt = item["NV_SDT"].ToString();
                            gioitinh = item["NV_GIOITINH"].ToString();
                            ngaysinh = item["NV_NGAYSINH"].ToString();
                            idnv = int.Parse(item["NV_ID"].ToString());
                        }

                    }
                }
             }
        }

        private void frmDANG_NHAP_KeyDown(object sender, KeyEventArgs e)
        {
            txtTK.Focus();
            taikhoan = txtTK.Text;
            matkhau = txtMK.Text;
            frmMain main = new frmMain();
            if (e.KeyCode == Keys.Enter)
            {
                if(txtTK.Text == "")
                {
                    MessageBox.Show("Tên đăng nhập không được rỗng");
                    txtTK.Focus();
                }
                else if(txtMK.Text == "")
                {
                    MessageBox.Show("Mật khẩu không được rỗng");
                    txtMK.Focus();
                }
                else
                {
                    if (dao_dn.checkLogin(taikhoan, matkhau))
                    {
                        dt = dao_dn.getTK_MK(taikhoan, matkhau);

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Đăng nhập không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtTK.Focus();
                        }
                        else
                        {
                            DialogResult = DialogResult.OK;
                            foreach (DataRow item in dt.Rows)
                            {
                                nguoidung = item["NV_HOTEN"].ToString();
                                cv = item["CV_TEN"].ToString();
                                cd = item["CD_TEN"].ToString();
                                sdt = item["NV_SDT"].ToString();
                                gioitinh = item["NV_GIOITINH"].ToString();
                                ngaysinh = item["NV_NGAYSINH"].ToString();
                                idnv = int.Parse(item["NV_ID"].ToString());
                            }
                        }
                    }
                }
            }
        }

        private void txtTK_KeyDown(object sender, KeyEventArgs e)
        {
            taikhoan = txtTK.Text;
            matkhau = txtMK.Text;
            frmMain main = new frmMain();
            if (e.KeyCode == Keys.Enter)
            {
                if (txtTK.Text == "")
                {
                    MessageBox.Show("Tên đăng nhập không được rỗng");
                    txtTK.Focus();
                }
                else if (txtMK.Text == "")
                {
                    MessageBox.Show("Mật khẩu không được rỗng");
                    txtMK.Focus();
                }
                else
                {
                    if (dao_dn.checkLogin(taikhoan, matkhau))
                    {
                        dt = dao_dn.getTK_MK(taikhoan, matkhau);

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Đăng nhập không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtTK.Focus();
                        }
                        else
                        {
                            DialogResult = DialogResult.OK;
                            foreach (DataRow item in dt.Rows)
                            {
                                nguoidung = item["NV_HOTEN"].ToString();
                                cv = item["CV_TEN"].ToString();
                                cd = item["CD_TEN"].ToString();
                                sdt = item["NV_SDT"].ToString();
                                gioitinh = item["NV_GIOITINH"].ToString();
                                ngaysinh = item["NV_NGAYSINH"].ToString();
                                idnv = int.Parse(item["NV_ID"].ToString());
                            }
                        }
                    }
                }
            }
        }

        private void txtMK_KeyDown(object sender, KeyEventArgs e)
        {
            taikhoan = txtTK.Text;
            matkhau = txtMK.Text;
            frmMain main = new frmMain();
            if (e.KeyCode == Keys.Enter)
            {
                if (txtTK.Text == "")
                {
                    MessageBox.Show("Tên đăng nhập không được rỗng");
                    txtTK.Focus();
                }
                else if (txtMK.Text == "")
                {
                    MessageBox.Show("Mật khẩu không được rỗng");
                    txtMK.Focus();
                }
                else
                {
                    if (dao_dn.checkLogin(taikhoan, matkhau))
                    {
                        dt = dao_dn.getTK_MK(taikhoan, matkhau);

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Đăng nhập không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtTK.Focus();
                        }
                        else
                        {
                            DialogResult = DialogResult.OK;
                            foreach (DataRow item in dt.Rows)
                            {
                                nguoidung = item["NV_HOTEN"].ToString();
                                cv = item["CV_TEN"].ToString();
                                cd = item["CD_TEN"].ToString();
                                sdt = item["NV_SDT"].ToString();
                                gioitinh = item["NV_GIOITINH"].ToString();
                                ngaysinh = item["NV_NGAYSINH"].ToString();
                                idnv = int.Parse(item["NV_ID"].ToString());
                            }
                        }
                    }
                }
            }
        }
    }
}

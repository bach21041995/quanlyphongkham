using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlyphongkham.DTO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace quanlyphongkham.DAO
{
    class DAO_DM_THUOC
    {
        ConnectionDatabase connecDB = new ConnectionDatabase();

        public DataTable getDSThuoc()
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("get_VatTu", conn);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            return dt;
           
        }

        public DataTable Get_VT_TheoTen(string id)
        {
            SqlConnection con = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("get_VatTuTheoTen", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@vt_ten", SqlDbType.NVarChar, 150);

            cmd.Parameters["@vt_ten"].Value = id;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public string insertMaThuoc(string malt)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("THUOC_ID_auto", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@malt", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@ma_next", SqlDbType.NVarChar, 20);
            cmd.Parameters["@ma_next"].Direction = ParameterDirection.Output;
            cmd.Parameters["@malt"].Value = malt;
            cmd.Parameters["@ma_next"].Value = "";
            conn.Open();
            cmd.ExecuteNonQuery();
            string mathuoc = cmd.Parameters["@ma_next"].Value.ToString();
            conn.Close();

            return mathuoc;
        }

        public string getIDTHUOCbyTEN(string ten)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("get_VTTheoTen", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@vt_ten", SqlDbType.NVarChar, 150);
            cmd.Parameters.Add("@vt_id", SqlDbType.NVarChar, 20);
            cmd.Parameters["@vt_id"].Direction = ParameterDirection.Output;
            cmd.Parameters["@vt_ten"].Value = ten;
            cmd.Parameters["@vt_id"].Value = "";
            conn.Open();
            cmd.ExecuteNonQuery();
            string mathuoc = cmd.Parameters["@vt_id"].Value.ToString();
            conn.Close();

            return mathuoc;
        }

        public DataTable TimKiemVatTu(string tk)
        {
            string t = tk.ToLower();
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("TimKiemVatTu", conn);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@str_Timkiem", SqlDbType.NVarChar, 50);
            cmd.Parameters["@str_Timkiem"].Value = t;
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            return dt;

            //string query = "select MaHV, TenHV, (CASE GioiTinh when 'true' then N'Nam' else N'Nữ' end) as GioiTinh, NgaySinhHV, DiaChi, DienThoai, a.MaLop, a.MaDT, TenDT, TenLop"
            //+ " from hocvien a , lop b, doituong c where a.MaLop = b.MaLop and a.MaDT = c.MaDT and " + tk + "";
            //string query = "select THUOC_ID, THUOC_TEN, THUOC_HDSD, THUOC_CONGDUNG, THUOC_DVT, THUOC_GIA, LT_TEN"
            //+ " from DM_THUOC a, LOAI_THUOC b where a.LT_ID = b.LT_ID and (lower(THUOC_TEN) like N'%" + tk.ToLower() + "%' or lower(THUOC_ID) like N'%" + tk.ToLower() + "%' or lower(LT_TEN) like N'%" + tk.ToLower() + "%')";
            //return connecDB.ExecuteQuery(query);
        }

        public DataTable getLT()
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getLOAI_THUOC", conn);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            return dt;

            //string query = " select LT_ID, LT_TEN from LOAI_THUOC where LT_TRANGTHAI = '1'";
            //return connecDB.ExecuteQuery(query);
        }

        /*public DataTable getThuocByLT(string lt)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getLOAI_THUOC", conn);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            return dt;
            string query = "select THUOC_ID, THUOC_TEN, THUOC_HDSD, THUOC_CONGDUNG, THUOC_DVT, THUOC_GIA, LT_TEN"
                            + " from DM_THUOC a, LOAI_THUOC b where a.LT_ID = b.LT_ID and a.LT_ID = '" + lt + "'";
            return connecDB.ExecuteQuery(query);
        }*/

        public void deleteThuoc(string mt)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("xoaDM_THUOC", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@mathuoc", SqlDbType.NVarChar, 20);
            cmd.Parameters["@mathuoc"].Value = mt;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            /*string query = "Update DM_THUOC set THUOC_TRANGTHAI = '1' where THUOC_ID = '" + mathuoc + "'";
            int result = connecDB.ExecuteNonQuery(query);

            return result > 0;*/
        }

        public bool InsertThuoc(DM_VATTU vt)
        {
           
                try
                {
                    SqlConnection conn = new SqlConnection(connecDB.connectionStr);
                    SqlCommand cmd = new SqlCommand("insertVatTu", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@vt_id", SqlDbType.NVarChar, 20);
                    cmd.Parameters.Add("@vt_ten", SqlDbType.NVarChar, 150);
                    cmd.Parameters.Add("@vt_dvt", SqlDbType.NVarChar, 20);
                    cmd.Parameters.Add("@vt_cachdung", SqlDbType.NVarChar, 100);
                    cmd.Parameters.Add("@vt_giaban", SqlDbType.Float);
                    cmd.Parameters.Add("@vt_hoatchat", SqlDbType.NVarChar,100);
                    cmd.Parameters.Add("@vt_hamluong", SqlDbType.NVarChar, 100);
                    cmd.Parameters.Add("@vt_qcdonggoi", SqlDbType.NVarChar,100);
                    cmd.Parameters.Add("@vt_ghichu", SqlDbType.NVarChar, 100);
                    cmd.Parameters.Add("@nuocsx_id", SqlDbType.NVarChar, 20);
                    cmd.Parameters.Add("@nsx_id", SqlDbType.NVarChar, 20);
                    cmd.Parameters.Add("@nvt_id", SqlDbType.NVarChar, 20);

                    cmd.Parameters["@vt_id"].Value = vt.Vt_id;
                    cmd.Parameters["@vt_ten"].Value = vt.Vt_ten;
                    cmd.Parameters["@vt_dvt"].Value = vt.Vt_dvt;
                    cmd.Parameters["@vt_giaban"].Value = vt.Vt_giaban;
                    cmd.Parameters["@vt_cachdung"].Value = vt.Vt_cachdung;
                    cmd.Parameters["@vt_hoatchat"].Value = vt.Vt_hoatchat;
                    cmd.Parameters["@vt_hamluong"].Value = vt.Vt_hamluong;
                    cmd.Parameters["@vt_qcdonggoi"].Value = vt.Qcdonggoi;
                    cmd.Parameters["@vt_ghichu"].Value = vt.Vt_ghichu;
                    cmd.Parameters["@nuocsx_id"].Value = vt.Nuocsx;
                    cmd.Parameters["@nsx_id"].Value = vt.Nhasx;
                    cmd.Parameters["@nvt_id"].Value = vt.Nhomvt;

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    return result > 0;
                    

                    /*string query = string.Format("Insert DM_THUOC (THUOC_ID, LT_ID, THUOC_TEN, THUOC_HDSD, THUOC_DVT, THUOC_CONGDUNG, THUOC_GIA, THUOC_TRANGTHAI) values ('{0}', '{1}', N'{2}', N'{3}', N'{4}', N'{5}', '{6}', '{7}')",
                                    t.Id_thuoc, t.Id_lt, t.Thuoc_ten, t.Thuoc_hdsd, t.Thuoc_dvt, t.Thuoc_congdung, t.Thuoc_gia, t.Thuoc_trangthai);
                    int result = connecDB.ExecuteNonQuery(query);
                    return result > 0;*/
                }
                catch
                {
                    if (KiemTraTrungTenThuoc(vt) != 0)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công do mã thuốc đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                
                    /*if(KiemTraTrungSDT(nv).Rows.Count == 0)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công do Số điện thoại của giáo viên đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }*/
                }
            return false;
        }


        public bool KiemTraNhapLieu(DM_THUOC t)
        {
            if (t.Thuoc_ten.Equals(""))
            {
                MessageBox.Show("Tên thuốc không được trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        public int KiemTraTrungTenThuoc(DM_VATTU vt)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("insertVatTu", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@vt_id", SqlDbType.NVarChar, 20);
            cmd.Parameters["@nvt_id"].Value = vt.Vt_id;

            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        public bool UpdateThuoc(DM_VATTU vt)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connecDB.connectionStr);
                SqlCommand cmd = new SqlCommand("updateVatTu", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@vt_id", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@vt_ten", SqlDbType.NVarChar, 150);
                cmd.Parameters.Add("@vt_dvt", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@vt_cachdung", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@vt_giaban", SqlDbType.Float);
                cmd.Parameters.Add("@vt_hoatchat", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@vt_hamluong", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@vt_qcdonggoi", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@vt_ghichu", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@nuocsx_id", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@nsx_id", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@nvt_id", SqlDbType.NVarChar, 20);

                cmd.Parameters["@vt_id"].Value = vt.Vt_id;
                cmd.Parameters["@vt_ten"].Value = vt.Vt_ten;
                cmd.Parameters["@vt_dvt"].Value = vt.Vt_dvt;
                cmd.Parameters["@vt_giaban"].Value = vt.Vt_giaban;
                cmd.Parameters["@vt_cachdung"].Value = vt.Vt_cachdung;
                cmd.Parameters["@vt_hoatchat"].Value = vt.Vt_hoatchat;
                cmd.Parameters["@vt_hamluong"].Value = vt.Vt_hamluong;
                cmd.Parameters["@vt_qcdonggoi"].Value = vt.Qcdonggoi;
                cmd.Parameters["@vt_ghichu"].Value = vt.Vt_ghichu;
                cmd.Parameters["@nuocsx_id"].Value = vt.Nuocsx;
                cmd.Parameters["@nsx_id"].Value = vt.Nhasx;
                cmd.Parameters["@nvt_id"].Value = vt.Nhomvt;
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                return result > 0;
              }
            catch { }
            return true;
        }


        public AutoCompleteStringCollection getDSTHUOC_TOA()
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getTHUOC", conn);
            AutoCompleteStringCollection auto2 = new AutoCompleteStringCollection();
            cmd.CommandType = CommandType.StoredProcedure;
            
            conn.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    auto2.Add(reader["THUOC_TEN"].ToString());
                }
            }
            //cmd.ExecuteNonQuery();
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //adapter.Fill(dt);
            conn.Close();
            return auto2;

            //string query = " select LT_ID, LT_TEN from LOAI_THUOC where LT_TRANGTHAI = '1'";
            //return connecDB.ExecuteQuery(query);
        }

        public string getDVT_CD_GIA(string tk)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getDVT_CD_GIA", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tt", SqlDbType.NVarChar, 60);
            cmd.Parameters.Add("@dvt", SqlDbType.NVarChar, 10);
            cmd.Parameters.Add("@cd", SqlDbType.NVarChar, 60);
            cmd.Parameters.Add("@dg", SqlDbType.Float);
            cmd.Parameters["@dvt"].Direction = ParameterDirection.Output;
            cmd.Parameters["@cd"].Direction = ParameterDirection.Output;
            cmd.Parameters["@dg"].Direction = ParameterDirection.Output;
            cmd.Parameters["@tt"].Value = tk;
            cmd.Parameters["@dvt"].Value = "";
            cmd.Parameters["@cd"].Value = "";
            cmd.Parameters["@dg"].Value = 0;
            conn.Open();
            cmd.ExecuteNonQuery();
            string dvt = cmd.Parameters["@dvt"].Value.ToString();
            string cd = cmd.Parameters["@cd"].Value.ToString();
            string dg = cmd.Parameters["@dg"].Value.ToString();
            string dvt_cd_dg = dvt + "/" + cd + "/" + dg;
            conn.Close();
            return dvt_cd_dg;
        }
    }
}

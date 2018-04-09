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
    class DAO_PHIEU_CHI_DINH
    {
        ConnectionDatabase connecDB = new ConnectionDatabase();

        public DataTable getPCD_by_KBID(string tk)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getPCD_by_KBID", conn);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@KBID", SqlDbType.NVarChar, 20);
            cmd.Parameters["@KBID"].Value = tk;
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

        public bool InsertPCD(PHIEU_CHI_DINH t)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connecDB.connectionStr);
                SqlCommand cmd = new SqlCommand("themPHIEU_CHI_DINH", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@mathuoc", SqlDbType.NVarChar, 20);
                //cmd.Parameters["@mathuoc"].Value = mt;
                cmd.Parameters.Add("@KB_ID", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@PCD_NGAYGIO", SqlDbType.DateTime);
                cmd.Parameters.Add("@PCD_TRANGTHAI", SqlDbType.Int);
                cmd.Parameters["@KB_ID"].Value = t.Id_kb;
                cmd.Parameters["@PCD_NGAYGIO"].Value = t.Pcd_ngaygio;
                cmd.Parameters["@PCD_TRANGTHAI"].Value = t.Pcd_trangthai;
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                return result > 0;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }

        }

        public void deletePCD(string mt)
        {
            try
            {
                int id = int.Parse(mt);
                SqlConnection conn = new SqlConnection(connecDB.connectionStr);
                SqlCommand cmd = new SqlCommand("xoaPHIEU_CHI_DINH", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PCD_ID", SqlDbType.Int);
                cmd.Parameters["@PCD_ID"].Value = id;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            

            /*string query = "Update DM_THUOC set THUOC_TRANGTHAI = '1' where THUOC_ID = '" + mathuoc + "'";
            int result = connecDB.ExecuteNonQuery(query);

            return result > 0;*/
        }
    }
}

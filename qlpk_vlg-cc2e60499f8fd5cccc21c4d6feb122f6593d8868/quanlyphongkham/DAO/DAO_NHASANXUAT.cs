using quanlyphongkham.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlyphongkham.DAO
{
    class DAO_NHASANXUAT
    {
        ConnectionDatabase db = new ConnectionDatabase();

        public DataTable getNhaSX()
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("get_NhaSX", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable TimNhaSX(string text)
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("TimNhaSX", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@strTimKiem", SqlDbType.NVarChar, 50);
            cmd.Parameters["@strTimKiem"].Value = text.ToLower();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int KiemTraTrungMa(DM_NHA_SAN_XUAT nhasx)
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("KiemTraNhaSX", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nsx_ma", SqlDbType.NVarChar, 20);
            cmd.Parameters["@nsx_ma"].Value = nhasx.Nsx_id.ToLower();
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public bool Insert(DM_NHA_SAN_XUAT nhasx)
        {
            try
            {
                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("insertNSX", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nsx_ma", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@nsx_ten", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@nsx_email", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@nsx_dienthoai", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@nsx_diachi", SqlDbType.NVarChar, 100);

                cmd.Parameters["@nsx_ma"].Value = nhasx.Nsx_id;
                cmd.Parameters["@nsx_ten"].Value = nhasx.Nsx_ten;
                cmd.Parameters["@nsx_email"].Value = nhasx.Email;
                cmd.Parameters["@nsx_dienthoai"].Value = nhasx.Dienthoai;
                cmd.Parameters["@nsx_diachi"].Value = nhasx.Diachi;

                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result > 0;

            }
            catch
            {
                if (KiemTraTrungMa(nhasx) == 0)
                {
                }
                else
                {
                    MessageBox.Show("Thêm không thành công do trùng mã kho", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }

        public bool Update(DM_NHA_SAN_XUAT nhasx)
        {
            try
            {
                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("updateNSX", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nsx_ma", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@nsx_ten", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@nsx_email", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@nsx_dienthoai", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@nsx_diachi", SqlDbType.NVarChar, 100);

                cmd.Parameters["@nsx_ma"].Value = nhasx.Nsx_id;
                cmd.Parameters["@nsx_ten"].Value = nhasx.Nsx_ten;
                cmd.Parameters["@nsx_email"].Value = nhasx.Email;
                cmd.Parameters["@nsx_dienthoai"].Value = nhasx.Dienthoai;
                cmd.Parameters["@nsx_diachi"].Value = nhasx.Diachi;

                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result > 0;
            }
            catch
            {
            }
            return true;
        }

        public bool Delete(string id)
        {
            try
            {
                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("deleteNSX", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nsx_ma", SqlDbType.NVarChar, 20);
                cmd.Parameters["@nsx_ma"].Value = id;
                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result > 0;
            }
            catch
            {
            }
            return true;
        }
    }
}

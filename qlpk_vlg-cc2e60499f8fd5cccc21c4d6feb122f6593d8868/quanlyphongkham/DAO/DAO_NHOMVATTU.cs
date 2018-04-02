using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlyphongkham.DTO;
using System.Windows.Forms;

namespace quanlyphongkham.DAO
{
    class DAO_NHOMVATTU
    {
        ConnectionDatabase db = new ConnectionDatabase();


        public DataTable getNhomVT()
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("getNhomVatTu", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable TimNVT(string text)
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("TimNhomVatTu", con);
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

        public int KiemTraTrungMa(DM_NHOM_VAT_TU nvt)
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("KiemTraTrungNVT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 20);
            cmd.Parameters["@id"].Value = nvt.Nvt_ma.ToLower();
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public bool Insert(DM_NHOM_VAT_TU nvt)
        {
            try
            {
                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("insertNhomVatTu", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nvt_ma", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@nvt_ten", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@nvt_ghichu", SqlDbType.NVarChar,100);
                cmd.Parameters.Add("@lvt_id", SqlDbType.NVarChar, 20);

                cmd.Parameters["@nvt_ma"].Value = nvt.Nvt_ma;
                cmd.Parameters["@nvt_ten"].Value = nvt.Nvt_ten;
                cmd.Parameters["@nvt_ghichu"].Value = nvt.Nvt_ghichu;
                cmd.Parameters["@lvt_id"].Value = nvt.Lvt_id;

                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result > 0;
            }
            catch
            {
                if (KiemTraTrungMa(nvt) != 0)
                {
                    MessageBox.Show("Thêm không thành công do trùng mã nhóm vật tư", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return false;
        }

        public bool Update(DM_NHOM_VAT_TU nvt)
        {
            try
            {
                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("updateNhomVatTu", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nvt_ma", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@nvt_ten", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@nvt_ghichu", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@lvt_id", SqlDbType.NVarChar, 20);

                cmd.Parameters["@nvt_ma"].Value = nvt.Nvt_ma;
                cmd.Parameters["@nvt_ten"].Value = nvt.Nvt_ten;
                cmd.Parameters["@nvt_ghichu"].Value = nvt.Nvt_ghichu;
                cmd.Parameters["@lvt_id"].Value = nvt.Lvt_id;

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
                SqlCommand cmd = new SqlCommand("deleteNhomVatTu", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nvt_ma", SqlDbType.NVarChar, 20);
                cmd.Parameters["@nvt_ma"].Value = id;
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

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
    class DAO_DM_LOAIVATTU
    {
        ConnectionDatabase db = new ConnectionDatabase();


        public DataTable getLoaiVT()
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("get_LoaiVatTu", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable TimLVT(string text)
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("TimLoaiVatTu", con);
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

        public int KiemTraTrungMa(DM_LOAI_VAT_TU lvt)
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("KiemTraTrungLVT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 20);
            cmd.Parameters["@id"].Value = lvt.Lvt_id.ToLower();
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public bool Insert(DM_LOAI_VAT_TU lvt)
        {
            try
            {
                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("insertLoaiVatTu", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@lvt_ma", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@lvt_ten", SqlDbType.NVarChar, 200);
                cmd.Parameters.Add("@lvt_ghichu", SqlDbType.NVarChar, 200);

                cmd.Parameters["@lvt_ma"].Value = lvt.Lvt_id;
                cmd.Parameters["@lvt_ten"].Value = lvt.Lvt_ten;
                cmd.Parameters["@lvt_ghichu"].Value = lvt.Lvt_ghichu;

                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result > 0;
            }
            catch
            {
                if (KiemTraTrungMa(lvt) != 0)
                {
                    MessageBox.Show("Thêm không thành công do trùng mã loại vật tư", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return false;
        }

        public bool Update(DM_LOAI_VAT_TU lvt)
        {
            try
            {
                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("updateLoaiVatTu", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@lvt_ma", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@lvt_ten", SqlDbType.NVarChar, 200);
                cmd.Parameters.Add("@lvt_ghichu", SqlDbType.NVarChar, 200);

                cmd.Parameters["@lvt_ma"].Value = lvt.Lvt_id;
                cmd.Parameters["@lvt_ten"].Value = lvt.Lvt_ten;
                cmd.Parameters["@lvt_ghichu"].Value = lvt.Lvt_ghichu;

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
                SqlCommand cmd = new SqlCommand("deleteLoaiVatTu", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@lvt_ma", SqlDbType.NVarChar, 20);
                cmd.Parameters["@lvt_ma"].Value = id;
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

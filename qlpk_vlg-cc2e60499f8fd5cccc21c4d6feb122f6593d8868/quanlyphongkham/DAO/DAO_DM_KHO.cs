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
    class DAO_DM_KHO
    {
        ConnectionDatabase db = new ConnectionDatabase();

        public DataTable getKho()
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("get_Kho", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable TimKho(string text)
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("TimKiem_Kho", con);
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

        public int KiemTraTrungMa(DM_KHO kho)
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("KiemTra_Kho", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@kho_id", SqlDbType.NVarChar, 10);
            cmd.Parameters["@kho_id"].Value = kho.Makho.ToLower();
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public bool Insert(DM_KHO kho)
        {
            try
            {
                    SqlConnection con = new SqlConnection(db.connectionStr);
                    SqlCommand cmd = new SqlCommand("insertKho", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@kho_id", SqlDbType.NVarChar, 10);
                    cmd.Parameters.Add("@kho_ten", SqlDbType.NVarChar, 20);

                    cmd.Parameters["@kho_id"].Value = kho.Makho;
                    cmd.Parameters["@kho_ten"].Value = kho.Tenkho;


                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    return result > 0;
               
            }
            catch
            {
                if (KiemTraTrungMa(kho) == 0)
                {
                 }
                else
                {
                    MessageBox.Show("Thêm không thành công do trùng mã kho", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }

        public bool Update(DM_KHO kho)
        {
            try
            {
                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("updateKho", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@kho_id", SqlDbType.NVarChar,10);
                cmd.Parameters.Add("@kho_ten", SqlDbType.NVarChar, 20);

                cmd.Parameters["@kho_id"].Value = kho.Makho;
                cmd.Parameters["@kho_ten"].Value = kho.Tenkho;


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
                SqlCommand cmd = new SqlCommand("deleteKho", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@kho_id", SqlDbType.NVarChar, 10);
                cmd.Parameters["@kho_id"].Value = id;
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

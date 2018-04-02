using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlyphongkham.DTO;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace quanlyphongkham.DAO
{
    class DAO_NUOCSANXUAT
    {
        ConnectionDatabase db = new ConnectionDatabase();


        public DataTable getNCSX()
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("getNuocSX", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable TimNCSX(string text)
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("TimNCSANXUAT", con);
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

        public bool Insert(DM_NUOC_SAN_XUAT ncsx)
        {
            try
            {
                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("insertNuocSX", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nuocsx_ma", SqlDbType.Int);
                cmd.Parameters.Add("@nuocsx_ten", SqlDbType.NVarChar, 20);

                cmd.Parameters["@nuocsx_ma"].Value = ncsx.Nuocsx_id;
                cmd.Parameters["@nuocsx_ten"].Value = ncsx.Nuocsx_ten;
               

                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result > 0;
            }
            catch
            {
            }
            return false;
        }

        public bool Update(DM_NUOC_SAN_XUAT ncsx, int id)
        {
            try
            {
                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("updateNuocSX", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nuocsx_ma", SqlDbType.Int);
                cmd.Parameters.Add("@nuocsx_ten", SqlDbType.NVarChar, 20);

                cmd.Parameters["@nuocsx_ma"].Value = id;
                cmd.Parameters["@nuocsx_ten"].Value = ncsx.Nuocsx_ten;
               

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
                SqlCommand cmd = new SqlCommand("deleteNuocSX", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nuocsx_ma", SqlDbType.Int);
                cmd.Parameters["@nuocsx_ma"].Value = id;
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

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
    class DAO_TOA_THUOC
    {
        ConnectionDatabase connecDB = new ConnectionDatabase();

        public bool InsertTT(TOA_THUOC t)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connecDB.connectionStr);
                SqlCommand cmd = new SqlCommand("themTOA_THUOC", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@mathuoc", SqlDbType.NVarChar, 20);
                //cmd.Parameters["@mathuoc"].Value = mt;
                cmd.Parameters.Add("@KB_ID", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@TT_TEN", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@TT_LOIDAN", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@TT_TRANGTHAI", SqlDbType.Int);
                cmd.Parameters.Add("@TT_NGAY", SqlDbType.DateTime);
                cmd.Parameters["@KB_ID"].Value = t.Id_kb;
                cmd.Parameters["@TT_TEN"].Value = t.Tt_ten;
                cmd.Parameters["@TT_LOIDAN"].Value = t.Tt_loidan;
                cmd.Parameters["@TT_TRANGTHAI"].Value = t.Tt_trangthai;
                cmd.Parameters["@TT_NGAY"].Value = t.Tt_ngay;
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                return result > 0;
            }
            catch(SqlException e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
            
        }

        public int getIDTT_MAX()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connecDB.connectionStr);
                SqlCommand cmd = new SqlCommand("getIDTT_MAX", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@last", SqlDbType.Int);
                cmd.Parameters["@last"].Direction = ParameterDirection.Output;
                cmd.Parameters["@last"].Value = "";
                conn.Open();
                cmd.ExecuteNonQuery();
                int ma = int.Parse(cmd.Parameters["@last"].Value.ToString());
                conn.Close();

                return ma;
            }
            catch
            {
                return 0;
            }
            
        }

        public int getTT_ID_MAX_by_KBID(string kbid)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connecDB.connectionStr);
                SqlCommand cmd = new SqlCommand("getTT_ID_MAX_by_KBID", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TTID", SqlDbType.Int);
                cmd.Parameters.Add("@KBID", SqlDbType.NVarChar, 10);
                cmd.Parameters["@TTID"].Direction = ParameterDirection.Output;
                cmd.Parameters["@TTID"].Value = "";
                cmd.Parameters["@KBID"].Value = kbid;
                conn.Open();
                cmd.ExecuteNonQuery();
                int ttid = int.Parse(cmd.Parameters["@TTID"].Value.ToString());
                conn.Close();

                return ttid;
            }
            catch
            {
                return 0;
            }
        }

        public DataTable getTTbyBN(int idbn)
        {
           
                SqlConnection conn = new SqlConnection(connecDB.connectionStr);
                SqlCommand cmd = new SqlCommand("getTTbyBN", conn);
                DataTable dt = new DataTable();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BN_ID", SqlDbType.Int).Value = idbn;
                conn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                conn.Close();
                return dt;
           
            
        }

        public DataTable ktTT_ID_by_KBID(string idkb)
        {

            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("ktTT_ID_by_KBID", conn);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@KBID", SqlDbType.NVarChar, 10).Value = idkb;
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            return dt;


        }
    }
}

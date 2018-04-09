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
    class DAO_CT_CLS
    {
        ConnectionDatabase connecDB = new ConnectionDatabase();

        public bool InsertCT_CLS(CT_CLS t)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connecDB.connectionStr);
                SqlCommand cmd = new SqlCommand("themCT_CLS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@mathuoc", SqlDbType.NVarChar, 20);
                //cmd.Parameters["@mathuoc"].Value = mt;
                cmd.Parameters.Add("@PCD_ID", SqlDbType.Int);
                cmd.Parameters.Add("@CLS_ID", SqlDbType.Int);
                cmd.Parameters.Add("@CTCLS_SOLUONG", SqlDbType.Int);
                cmd.Parameters.Add("@CTCLS_KETQUA", SqlDbType.NVarChar, 50);
                cmd.Parameters["@PCD_ID"].Value = t.Id_pcd;
                cmd.Parameters["@CLS_ID"].Value = t.Id_cls;
                cmd.Parameters["@CTCLS_SOLUONG"].Value = t.Ctcls_soluong;
                cmd.Parameters["@CTCLS_KETQUA"].Value = t.Ctcls_ketqua;
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                return result > 0;
            }
            catch
            {
                MessageBox.Show("Đã tồn tài tên cận lâm sàn");
                return false;
            }

        }

        public DataTable getCT_CLS_by_IDPCD(string tk)
        {
            int id = int.Parse(tk);
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getCT_CLS_by_IDPCD", conn);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PCD_ID", SqlDbType.Int);
            cmd.Parameters["@PCD_ID"].Value = id;
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            return dt;
        }

        public DataTable getCLS_LSK(string kbid)
        {
            //int id = int.Parse(tk);
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getCLS_LSK", conn);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@kbid", SqlDbType.NVarChar, 20);
            cmd.Parameters["@kbid"].Value = kbid;
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            return dt;
        }


        public void deleteCT_CLS(string mt)
        {
            try
            {
                int id = int.Parse(mt);
                SqlConnection conn = new SqlConnection(connecDB.connectionStr);
                SqlCommand cmd = new SqlCommand("xoaCT_CLS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CLS_ID", SqlDbType.Int);
                cmd.Parameters["@CLS_ID"].Value = id;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }


            /*string query = "Update DM_THUOC set THUOC_TRANGTHAI = '1' where THUOC_ID = '" + mathuoc + "'";
            int result = connecDB.ExecuteNonQuery(query);

            return result > 0;*/
        }
    }
}

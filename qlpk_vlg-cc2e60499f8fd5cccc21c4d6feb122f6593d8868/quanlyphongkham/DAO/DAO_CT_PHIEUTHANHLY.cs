using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlyphongkham.DTO;

namespace quanlyphongkham.DAO
{
    class DAO_CT_PHIEUTHANHLY
    {
        ConnectionDatabase db = new ConnectionDatabase();

        public DataTable Get_CTPTL_TheoID(string id)
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("get_CTTLyTheoID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pn_id", SqlDbType.NVarChar, 20);

            cmd.Parameters["@pn_id"].Value = id;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Get_VT_TheoTen(string id)
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
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

      

        public bool Insert(CT_PHIEUTHANHLY ctptl)
        {
            int result = 0;
           try
          {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("insert_CTPhieuNhap", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ptl_id", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@vt_id", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@id_nhapkhoct", SqlDbType.VarChar, 30);
            cmd.Parameters.Add("@cttl_thuhoi", SqlDbType.Float);
            cmd.Parameters.Add("@cttl_thanhly", SqlDbType.Float);
            cmd.Parameters.Add("@solg", SqlDbType.Float);

            cmd.Parameters["@ptl_id"].Value = ctptl.Ptl_id;
            cmd.Parameters["@vt_id"].Value = ctptl.Vt_id;
            cmd.Parameters["@id_nhapkhoct"].Value = ctptl.Id_ctnk;
            cmd.Parameters["@cttl_thuhoi"].Value = ctptl.Cp_thuhoi;
            cmd.Parameters["@cttl_thanhly"].Value = ctptl.Cp_thanhly;
            cmd.Parameters["@solg"].Value = ctptl.Solg;

            con.Open();

             result = cmd.ExecuteNonQuery();
            con.Close();
           
          }
           catch
           {
           }
           return result > 0;
        }

        public bool Update(CT_PHIEUTHANHLY ctptl)
        {
            int result = 0;
           try
            {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("update_CTPhieuNhap", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ptl_id", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@vt_id", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@id_nhapkhoct", SqlDbType.VarChar, 30);
            cmd.Parameters.Add("@cttl_thuhoi", SqlDbType.Float);
            cmd.Parameters.Add("@cttl_thanhly", SqlDbType.Float);
            cmd.Parameters.Add("@solg", SqlDbType.Float);


            cmd.Parameters["@ptl_id"].Value = ctptl.Ptl_id;
            cmd.Parameters["@vt_id"].Value = ctptl.Vt_id;
            cmd.Parameters["@id_nhapkhoct"].Value = ctptl.Id_ctnk;
            cmd.Parameters["@cttl_thuhoi"].Value = ctptl.Cp_thuhoi;
            cmd.Parameters["@cttl_thanhly"].Value = ctptl.Cp_thanhly;
            cmd.Parameters["@solg"].Value = ctptl.Solg;

            con.Open();

            result = cmd.ExecuteNonQuery();
            con.Close();
            }
           catch
           {
           }
           return result > 0;
        }

        public bool Delete(string pnid, string vtid)
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("delete_CTTLY", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ptl_id", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@vt_id", SqlDbType.NVarChar, 20);
            cmd.Parameters["@ptl_id"].Value = pnid;
            cmd.Parameters["@vt_id"].Value = vtid;
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();

            return result > 0;
        }

        public int KiemTraVT(string pn_id, string vt_id)
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("KiemTraVT_CTTLY", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ptl_id", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@vt_id", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@kq", SqlDbType.Int);
            cmd.Parameters["@kq"].Direction = ParameterDirection.Output;

            cmd.Parameters["@ptl_id"].Value = pn_id;
            cmd.Parameters["@vt_id"].Value = vt_id;
            cmd.Parameters["@kq"].Value = "";
            con.Open();
            cmd.ExecuteNonQuery();
            int result = int.Parse(cmd.Parameters["@kq"].Value.ToString());
            con.Close();

            return result;
        }
    }
}

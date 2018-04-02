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
    class DAO_CT_PHIEUNHAP
    {
        ConnectionDatabase db = new ConnectionDatabase();

        public DataTable Get_PN_TheoNgay(string tungay, string denngay)
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("Get_PNKHO_THEONGAY", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tungay", SqlDbType.DateTime);
            cmd.Parameters.Add("@denngay", SqlDbType.DateTime);

            cmd.Parameters["@tungay"].Value = DateTime.Parse(tungay);
            cmd.Parameters["@denngay"].Value = DateTime.Parse(denngay);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Get_CTPN_TheoID(string id)
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("get_CTPNTheoID", con);
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

        public string Get_ID_Auto()
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("ID_CTPN_auto", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ma_next", SqlDbType.NVarChar, 30);
            cmd.Parameters["@ma_next"].Direction = ParameterDirection.Output;
            cmd.Parameters["@ma_next"].Value = "";
            con.Open();
            cmd.ExecuteNonQuery();
            string result = cmd.Parameters["@ma_next"].Value.ToString();
            con.Close();
            return result;
        }

        public bool Insert(CHITIET_PHIEUNHAP ctpn)
        {
        //    try
        //    {
                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("insert_CTPhieuNhap", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.VarChar, 30);
                cmd.Parameters.Add("@pn_id", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@vt_id", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@ctpn_hoatchat", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@ctpn_dvt", SqlDbType.NVarChar,100);
                cmd.Parameters.Add("@ctpn_solg", SqlDbType.Int);
                cmd.Parameters.Add("@ctpn_gianhap", SqlDbType.Float);
                cmd.Parameters.Add("@ngaysx", SqlDbType.DateTime);
                cmd.Parameters.Add("@hansd", SqlDbType.DateTime);
                cmd.Parameters.Add("@solo", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@truocthue", SqlDbType.Float);
                cmd.Parameters.Add("@sauthue", SqlDbType.Float);
                cmd.Parameters.Add("@giaban", SqlDbType.Float);
                cmd.Parameters.Add("@hamlg", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@quycach", SqlDbType.NVarChar, 100);

                cmd.Parameters["@id"].Value = ctpn.Id_ctpn;
                cmd.Parameters["@pn_id"].Value = ctpn.Pn_id;
                cmd.Parameters["@vt_id"].Value = ctpn.Vt_id;
                cmd.Parameters["@ctpn_hoatchat"].Value = ctpn.Ctpn_hoatchat;
                cmd.Parameters["@ctpn_dvt"].Value = ctpn.Ctpn_dvt;
                cmd.Parameters["@ctpn_solg"].Value = ctpn.Ctpn_solg;
                cmd.Parameters["@ctpn_gianhap"].Value = ctpn.Ctpn_gianhap;
                cmd.Parameters["@ngaysx"].Value = ctpn.Ctpn_ngaysx;
                cmd.Parameters["@hansd"].Value = ctpn.Ctpn_hsd;
                cmd.Parameters["@solo"].Value = ctpn.Ctpn_solo;
                cmd.Parameters["@truocthue"].Value = ctpn.Tt_truocthue;
                cmd.Parameters["@sauthue"].Value = ctpn.Tt_sauthue;
                cmd.Parameters["@giaban"].Value = ctpn.Giaban;
                cmd.Parameters["@hamlg"].Value = ctpn.Hamluong;
                cmd.Parameters["@quycach"].Value = ctpn.Quycach;
                
                con.Open();

                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result > 0;
            //}
            //catch
            //{
            //}
        }

        public bool Update(CHITIET_PHIEUNHAP ctpn)
        {
            //    try
            //    {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("update_CTPhieuNhap", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pn_id", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@vt_id", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@ctpn_hoatchat", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@ctpn_dvt", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@ctpn_solg", SqlDbType.Int);
            cmd.Parameters.Add("@ctpn_gianhap", SqlDbType.Float);
            cmd.Parameters.Add("@ngaysx", SqlDbType.DateTime);
            cmd.Parameters.Add("@hansd", SqlDbType.DateTime);
            cmd.Parameters.Add("@solo", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@truocthue", SqlDbType.Float);
            cmd.Parameters.Add("@sauthue", SqlDbType.Float);
            cmd.Parameters.Add("@giaban", SqlDbType.Float);
            cmd.Parameters.Add("@hamlg", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@quycach", SqlDbType.NVarChar, 100);

            cmd.Parameters["@pn_id"].Value = ctpn.Pn_id;
            cmd.Parameters["@vt_id"].Value = ctpn.Vt_id;
            cmd.Parameters["@ctpn_hoatchat"].Value = ctpn.Ctpn_hoatchat;
            cmd.Parameters["@ctpn_dvt"].Value = ctpn.Ctpn_dvt;
            cmd.Parameters["@ctpn_solg"].Value = ctpn.Ctpn_solg;
            cmd.Parameters["@ctpn_gianhap"].Value = ctpn.Ctpn_gianhap;
            cmd.Parameters["@ngaysx"].Value = ctpn.Ctpn_ngaysx;
            cmd.Parameters["@hansd"].Value = ctpn.Ctpn_hsd;
            cmd.Parameters["@solo"].Value = ctpn.Ctpn_solo;
            cmd.Parameters["@truocthue"].Value = ctpn.Tt_truocthue;
            cmd.Parameters["@sauthue"].Value = ctpn.Tt_sauthue;
            cmd.Parameters["@giaban"].Value = ctpn.Giaban;
            cmd.Parameters["@hamlg"].Value = ctpn.Hamluong;
            cmd.Parameters["@quycach"].Value = ctpn.Quycach;

            con.Open();

            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result > 0;
            //}
            //catch
            //{
            //}
        }

        public bool Delete(string pnid, string vtid)
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("delete_CTPhieuNhap", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pn_id", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@vt_id", SqlDbType.NVarChar, 20);
            cmd.Parameters["@pn_id"].Value = pnid;
            cmd.Parameters["@vt_id"].Value = vtid;
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();

            return result > 0;
        }

        public int KiemTraVT(string pn_id, string vt_id)
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("KiemTraVT_CTPhieuNhap", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pn_id", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@vt_id", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@kq", SqlDbType.Int);
            cmd.Parameters["@kq"].Direction = ParameterDirection.Output;

            cmd.Parameters["@pn_id"].Value = pn_id;
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

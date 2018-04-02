using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlyphongkham.DTO;
using quanlyphongkham.DAO;
using System.Data;
using System.Data.SqlClient;

namespace quanlyphongkham.DAO
{
    class DAO_XUATTHUOC
    {
        ConnectionDatabase db = new ConnectionDatabase();


        public DataTable getToaThuocByBN(string ngay, string denngay)
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("get_ToaThuocTheoBN", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tungay", SqlDbType.DateTime);
            cmd.Parameters.Add("@dengay", SqlDbType.DateTime);
            cmd.Parameters["@tungay"].Value = DateTime.Parse(ngay);
            cmd.Parameters["@dengay"].Value = DateTime.Parse(denngay);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable getCTToaThuoc(string id_tt)
        {
            DataTable dt = null;
            try
            {
                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("get_CTToaThuocTheoBN", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_tt", SqlDbType.Int);

                cmd.Parameters["@id_tt"].Value = int.Parse(id_tt);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                 dt = new DataTable();
                da.Fill(dt);
                con.Close();
            }
            catch { }
            return dt;
        }

        public DataTable getDVKham(string id_bn)
        {
            DataTable dt = null;
            try
            {
                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("get_DVKhamTheoBN", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_bn", SqlDbType.Int);

                cmd.Parameters["@id_bn"].Value = int.Parse(id_bn);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                 dt = new DataTable();
                da.Fill(dt);
                con.Close();
            }
            catch { }
            return dt;
        }

        public DataTable getCLS(string id_bn)
        {
            DataTable dt = null;
            try
            {
                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("get_CLSTheoBN", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_bn", SqlDbType.Int);

                cmd.Parameters["@id_bn"].Value = int.Parse(id_bn);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                 dt = new DataTable();
                da.Fill(dt);
                con.Close();
            }
            catch { }
            return dt;
        }

        public DataTable getCTKHO(string tt_id)
        {
            DataTable dt = null;
            try
            {
                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("get_KHOCT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_tt", SqlDbType.Int);

                cmd.Parameters["@id_tt"].Value = int.Parse(tt_id);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                con.Close();
            }
            catch { }
            return dt;
        }

        public bool Insert_HDVP(CT_HOADONVIENPHI hdvp)
        {
            try
            {
                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("insert_CTHDVienPhi", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@hd_id", SqlDbType.NVarChar, 15);
                cmd.Parameters.Add("@pcd_id", SqlDbType.Int);
                cmd.Parameters.Add("@cls_id", SqlDbType.Int);
                cmd.Parameters.Add("@solg", SqlDbType.Int);
                cmd.Parameters.Add("@dongia", SqlDbType.Float);
                cmd.Parameters.Add("@thanhtien", SqlDbType.Float);

                cmd.Parameters["@hd_id"].Value = hdvp.Hd_id;
                cmd.Parameters["@pcd_id"].Value = hdvp.Pcd_id;
                cmd.Parameters["@cls_id"].Value = hdvp.Cls_id;
                cmd.Parameters["@solg"].Value = hdvp.Solg;
                cmd.Parameters["@dongia"].Value = hdvp.Dongia;
                cmd.Parameters["@thanhtien"].Value = hdvp.Thanhtien;

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

        public string get_ID_auto()
        {
            string id = "";
            try
            {
                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("ID_HOADON_auto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ma_next", SqlDbType.NVarChar,20);
                cmd.Parameters["@ma_next"].Direction = ParameterDirection.Output;
                cmd.Parameters["@ma_next"].Value = "";
                con.Open();
                cmd.ExecuteNonQuery();
                 id = cmd.Parameters["@ma_next"].Value.ToString();
                con.Close();
            }
            catch { }
            return id;
        }

        public bool Insert_HDTHUOC(CT_HOADONTHUOC hdt)
        {
           
            try
            {
                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("insert_CTHDThuoc", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@hd_id", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@kho_id", SqlDbType.NVarChar,20);
                cmd.Parameters.Add("@nvu_id", SqlDbType.Int);
                cmd.Parameters.Add("@vt_id", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@id_nkct", SqlDbType.VarChar,30);
                cmd.Parameters.Add("@ngay", SqlDbType.DateTime);
                cmd.Parameters.Add("@solg", SqlDbType.Int);
                cmd.Parameters.Add("@dongia", SqlDbType.Float);
                cmd.Parameters.Add("@thanhtien", SqlDbType.Float);

                cmd.Parameters["@hd_id"].Value = hdt.Hd;
                cmd.Parameters["@kho_id"].Value = hdt.Kho;
                cmd.Parameters["@nvu_id"].Value = hdt.Ngvu;
                cmd.Parameters["@vt_id"].Value = hdt.Vattu;
                cmd.Parameters["@id_nkct"].Value = hdt.Id_nhapkho;
                cmd.Parameters["@ngay"].Value = hdt.Thoidiem;
                cmd.Parameters["@solg"].Value = hdt.Solg;
                cmd.Parameters["@dongia"].Value = hdt.Dongia;
                cmd.Parameters["@thanhtien"].Value = hdt.Thanhtien;

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

        public DataTable getHoaDonDaTT(string tn_id)
        {
            DataTable dt = null;
            try
            {
                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("get_HoaDonDaTT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@tn_id", SqlDbType.NVarChar,15);

                cmd.Parameters["@tn_id"].Value = tn_id;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                con.Close();
            }
            catch { }
            return dt;
        }

        public int KiemTraHoaDonDaTT(string tn_id)
        {
            int result = 0;
            try
            {
                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("KiemTraHoaDonDaTT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@tn_id", SqlDbType.NVarChar, 15);
                cmd.Parameters.Add("@dem", SqlDbType.Int);
                cmd.Parameters["@dem"].Direction = ParameterDirection.Output;

                cmd.Parameters["@tn_id"].Value = tn_id;
                cmd.Parameters["@dem"].Value = "";
                con.Open();
                cmd.ExecuteNonQuery();
                result = int.Parse(cmd.Parameters["@dem"].Value.ToString());
                con.Close();
            }
            catch { }
            return result;
        }
    }
}

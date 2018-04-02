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
    class DAO_PHIEU_THANH_LY
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

        public DataTable Get_PN_TheoNgay(string tungay, string denngay)
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("Get_PNTLY_THEONGAY", con);
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

        public bool Insert(PHIEU_THANH_LY ptl)
        {
            try
            {

                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("insert_PhieuTL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ptl_id", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@nhacc_id", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@kho_id", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@httl", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@ngaytl", SqlDbType.DateTime);
                cmd.Parameters.Add("@ghichu", SqlDbType.NVarChar, 200);

                cmd.Parameters["@ptl_id"].Value = ptl.Ptl_id;
                cmd.Parameters["@nhacc_id"].Value = ptl.Nhacc;
                cmd.Parameters["@kho_id"].Value = ptl.Kho_id;
                cmd.Parameters["@httl"].Value = ptl.Httl;
                cmd.Parameters["@ngaytl"].Value = ptl.Ptl_ngay;
                cmd.Parameters["@ghichu"].Value = ptl.Ptl_ghichu;
                con.Open();

                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result > 0;
            }
            catch
            {
                if (KiemTraTrung(ptl.Ptl_id) != 0)
                {
                    MessageBox.Show("Thêm không thành công do trùng mã phiếu thanh lý", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }

        public bool Update(PHIEU_THANH_LY ptl)
        {
            try
            {
                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("update_PhieuTL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ptl_id", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@nhacc_id", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@kho_id", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@httl", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@ngaytl", SqlDbType.DateTime);
                cmd.Parameters.Add("@ghichu", SqlDbType.NVarChar, 200);

                cmd.Parameters["@ptl_id"].Value = ptl.Ptl_id;
                cmd.Parameters["@nhacc_id"].Value = ptl.Nhacc;
                cmd.Parameters["@kho_id"].Value = ptl.Kho_id;
                cmd.Parameters["@httl"].Value = ptl.Httl;
                cmd.Parameters["@ngaytl"].Value = ptl.Ptl_ngay;
                cmd.Parameters["@ghichu"].Value = ptl.Ptl_ghichu;
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
            int result = 0;
            try
            {
                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("delete_PhieuTL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ptl_id", SqlDbType.NVarChar, 20);

                cmd.Parameters["@ptl_id"].Value = id;

                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch { }

            return result > 0;
        }

        public int KiemTraTrung(string id)
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("KiemTra_PhieuTL", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pn_id", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;
            con.Open();
            cmd.Parameters["@pn_id"].Value = id.ToLower();
            cmd.ExecuteNonQuery();
            int result = int.Parse(cmd.Parameters["@id"].Value.ToString());
            con.Close();

            return result;
        }

        public AutoCompleteStringCollection getThuoc()
        {
            AutoCompleteStringCollection auto = null;
            try
            {
                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("get_VatTu", con);
                cmd.CommandType = CommandType.StoredProcedure;

                auto = new AutoCompleteStringCollection();
                con.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        auto.Add(reader["VT_TEN"].ToString());
                    }
                }
                con.Close();
               
            }
            catch { }
            return auto;
        }
    }
}

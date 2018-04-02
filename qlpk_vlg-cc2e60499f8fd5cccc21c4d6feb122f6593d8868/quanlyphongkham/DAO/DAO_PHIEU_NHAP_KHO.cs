using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlyphongkham.DTO;
using quanlyphongkham.DAO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace quanlyphongkham.DAO
{
    class DAO_PHIEU_NHAP_KHO
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

        public bool Insert(PHIEU_NHAP_KHO pnk)
        {
            try{

                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("insert_PhieuNhap", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pn_id", SqlDbType.NVarChar,20);
                cmd.Parameters.Add("@pn_nguoigiao", SqlDbType.NVarChar,100);
                cmd.Parameters.Add("@pn_nguoinhan", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@ngaynhap", SqlDbType.DateTime);
                cmd.Parameters.Add("@vat", SqlDbType.Float);
                cmd.Parameters.Add("@ghichu", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@nhacc", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@kho", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@ngayhd", SqlDbType.DateTime);
                cmd.Parameters.Add("@sohd", SqlDbType.VarChar, 50);

                cmd.Parameters["@pn_id"].Value = pnk.Mapn;
                cmd.Parameters["@pn_nguoigiao"].Value = pnk.Pn_nguoigiao;
                cmd.Parameters["@pn_nguoinhan"].Value = pnk.Pn_nguoinhan;
                cmd.Parameters["@ngaynhap"].Value = pnk.Pn_ngaynhap;
                cmd.Parameters["@vat"].Value = pnk.Pn_vat;
                cmd.Parameters["@ghichu"].Value = pnk.Ghichu;
                cmd.Parameters["@nhacc"].Value = pnk.Ncc_id;
                cmd.Parameters["@kho"].Value = pnk.Kho_id;
                cmd.Parameters["@ngayhd"].Value = pnk.Ngayhd;
                cmd.Parameters["@sohd"].Value = pnk.Sohd;
                con.Open();

                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result > 0;
             }
            catch
            {
                if (KiemTraTrung(pnk.Mapn) != 0)
                {
                    MessageBox.Show("Thêm không thành công do trùng mã phiếu nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }

        public bool Update(PHIEU_NHAP_KHO pnk)
        {
            try
            {
                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("update_PhieuNhap", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pn_id", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@pn_nguoigiao", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@pn_nguoinhan", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@ngaynhap", SqlDbType.DateTime);
                cmd.Parameters.Add("@vat", SqlDbType.Float);
                cmd.Parameters.Add("@ghichu", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@nhacc", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@kho", SqlDbType.NVarChar, 20);

                cmd.Parameters["@pn_id"].Value = pnk.Mapn;
                cmd.Parameters["@pn_nguoigiao"].Value = pnk.Pn_nguoigiao;
                cmd.Parameters["@pn_nguoinhan"].Value = pnk.Pn_nguoinhan;
                cmd.Parameters["@ngaynhap"].Value = pnk.Pn_ngaynhap;
                cmd.Parameters["@vat"].Value = pnk.Pn_vat;
                cmd.Parameters["@ghichu"].Value = pnk.Ghichu;
                cmd.Parameters["@nhacc"].Value = pnk.Ncc_id;
                cmd.Parameters["@kho"].Value = pnk.Kho_id;
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
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("delete_PhieuNhap", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pn_id", SqlDbType.NVarChar, 20);

            cmd.Parameters["@pn_id"].Value = id;
           
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
           
            return result > 0;
        }

        public int KiemTraTrung(string id)
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("KiemTra_PhieuNhap", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pn_id", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;
            con.Open();
            cmd.Parameters["@pn_id"].Value = id.ToLower();
            cmd.ExecuteNonQuery();
            int result =  int.Parse(cmd.Parameters["@id"].Value.ToString());
            con.Close();

            return result;
        }

        public AutoCompleteStringCollection getThuoc()
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("get_VatTu", con);
            cmd.CommandType = CommandType.StoredProcedure;

            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
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
            return auto;
        }


    }
}

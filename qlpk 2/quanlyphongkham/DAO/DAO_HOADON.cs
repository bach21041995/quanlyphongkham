using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlyphongkham.DTO;
using System.Data.SqlClient;
using System.Data;

namespace quanlyphongkham.DAO
{
    class DAO_HOADON
    {
        ConnectionDatabase db = new ConnectionDatabase();

        public bool Insert_HoaDon(HOA_DON hd)
        {
            try
            {
                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("insert_HoaDon", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@hd_id", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@tn_id", SqlDbType.NVarChar,15);
                cmd.Parameters.Add("@nv_id", SqlDbType.Int);
                cmd.Parameters.Add("@ngay", SqlDbType.DateTime);
                cmd.Parameters.Add("@lan_tt", SqlDbType.Int);
                cmd.Parameters.Add("@trangthai", SqlDbType.NVarChar,50);

                cmd.Parameters["@hd_id"].Value = hd.Id;
                cmd.Parameters["@tn_id"].Value = hd.Tn_id;
                cmd.Parameters["@nv_id"].Value = hd.Nv_id;
                cmd.Parameters["@ngay"].Value = hd.Ngay;
                cmd.Parameters["@lan_tt"].Value = hd.Lantt;
                cmd.Parameters["@trangthai"].Value = hd.Trangthai;

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

        public bool update_HoaDon(HOA_DON hd)
        {
            int result = 0;
            try
            {
                SqlConnection con = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("update_HoaDon", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@hd_id", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@tn_id", SqlDbType.NVarChar, 15);
                cmd.Parameters.Add("@nv_id", SqlDbType.Int);
                cmd.Parameters.Add("@ngay", SqlDbType.DateTime);
                cmd.Parameters.Add("@lan_tt", SqlDbType.Int);
                cmd.Parameters.Add("@trangthai", SqlDbType.NVarChar, 50);

                cmd.Parameters["@hd_id"].Value = hd.Id;
                cmd.Parameters["@tn_id"].Value = hd.Tn_id;
                cmd.Parameters["@nv_id"].Value = hd.Nv_id;
                cmd.Parameters["@ngay"].Value = hd.Ngay;
                cmd.Parameters["@lan_tt"].Value = hd.Lantt;
                cmd.Parameters["@trangthai"].Value = hd.Trangthai;

                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch { }
            return result > 0;
        }
    }
}

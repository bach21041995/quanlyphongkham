﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlyphongkham.DTO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace quanlyphongkham.DAO
{
    class DAO_KHO_CHI_TIET
    {
        ConnectionDatabase db = new ConnectionDatabase();

        public bool Insert_KCT(KHO_CHI_TIET kct)
        {
            try
            {
                SqlConnection conn = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("insert_CTKho", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add("@kho_id", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@ngvu_id", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@vattu_id", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@thoidiem", SqlDbType.DateTime);
                cmd.Parameters.Add("@id_nhapkhoct", SqlDbType.VarChar,30);
                cmd.Parameters.Add("@solg", SqlDbType.Int);
                cmd.Parameters.Add("@gia", SqlDbType.Float);
                cmd.Parameters.Add("@tt_id", SqlDbType.NVarChar,20);
                cmd.Parameters.Add("@id_ptl", SqlDbType.VarChar, 50);

                cmd.Parameters["@kho_id"].Value = kct.Kho_id;
                cmd.Parameters["@ngvu_id"].Value = kct.Ngvu;
                cmd.Parameters["@vattu_id"].Value = kct.Vattu;
                cmd.Parameters["@thoidiem"].Value = kct.Thoidiem;
                cmd.Parameters["@id_nhapkhoct"].Value = kct.Id_nhapkho;
                cmd.Parameters["@solg"].Value = kct.Solg;
                cmd.Parameters["@gia"].Value = kct.Dongia;
                cmd.Parameters["@tt_id"].Value = kct.Toathuoc;
                cmd.Parameters["@id_ptl"].Value = kct.Id_ptl;
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                return result > 0;

            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
                return false;
            }
         }
           

        public bool Update_KCT(KHO_CHI_TIET kct)
        {

            try
            {
                SqlConnection conn = new SqlConnection(db.connectionStr);
                SqlCommand cmd = new SqlCommand("update_CTKho", conn);
                cmd.CommandType = CommandType.StoredProcedure;
              
               cmd.Parameters.Add("@kho_id", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@ngvu_id", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@vattu_id", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@thoidiem", SqlDbType.DateTime);
                cmd.Parameters.Add("@id_nhapkhoct", SqlDbType.VarChar,30);
                cmd.Parameters.Add("@solg", SqlDbType.Int);
                cmd.Parameters.Add("@gia", SqlDbType.Float);
                cmd.Parameters.Add("@tt_id", SqlDbType.NVarChar,20);
                cmd.Parameters.Add("@id_ptl", SqlDbType.VarChar, 50);

                cmd.Parameters["@kho_id"].Value = kct.Kho_id;
                cmd.Parameters["@ngvu_id"].Value = kct.Ngvu;
                cmd.Parameters["@vattu_id"].Value = kct.Vattu;
                cmd.Parameters["@thoidiem"].Value = kct.Thoidiem;
                cmd.Parameters["@id_nhapkhoct"].Value = kct.Id_nhapkho;
                cmd.Parameters["@solg"].Value = kct.Solg;
                cmd.Parameters["@gia"].Value = kct.Dongia;
                cmd.Parameters["@tt_id"].Value = kct.Toathuoc;
                cmd.Parameters["@id_ptl"].Value = kct.Id_ptl;
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                return result > 0;
            }
            catch
            {
            }
            return false;
        }

        public bool Delete(string pnid, string ptl_id)
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("delete_CTKho", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id_nk", SqlDbType.VarChar, 30);
            cmd.Parameters.Add("@ptl_id", SqlDbType.VarChar, 50);

            cmd.Parameters["@id_nk"].Value = pnid;
            cmd.Parameters["@ptl_id"].Value = ptl_id;
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();

            return result > 0;
        }

        public bool Delete(string pnid, int nvid)
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("delete_CTKho", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id_nk", SqlDbType.VarChar, 30);
            cmd.Parameters.Add("@nv_id", SqlDbType.Int);

            cmd.Parameters["@id_nk"].Value = pnid;
            cmd.Parameters["@nv_id"].Value = nvid;
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();

            return result > 0;
        }
        }
    }


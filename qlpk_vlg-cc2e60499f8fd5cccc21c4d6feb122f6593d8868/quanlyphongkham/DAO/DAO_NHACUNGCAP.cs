using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DAO
{
    class DAO_NHACUNGCAP
    {
        ConnectionDatabase db = new ConnectionDatabase();
        public DataTable Get_NhaCC()
        {
            SqlConnection con = new SqlConnection(db.connectionStr);
            SqlCommand cmd = new SqlCommand("get_NhaCungCap", con);
            cmd.CommandType = CommandType.StoredProcedure;
           
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}

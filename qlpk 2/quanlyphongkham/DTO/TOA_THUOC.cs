using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class TOA_THUOC
    {
        //int id_tt;
        //public int Id_tt
        //{
        //    get { return id_tt; }
        //    set { id_tt = value; }
        //}

        string id_kb;
        public string Id_kb
        {
            get { return id_kb; }
            set { id_kb = value; }
        }

        string tt_loidan;
        public string Tt_loidan
        {
            get { return tt_loidan; }
            set { tt_loidan = value; }
        }


        int tt_trangthai;
        public int Tt_trangthai
        {
            get { return tt_trangthai; }
            set { tt_trangthai = value; }
        }

        string ngay;
        public string Tt_ngay
        {
            get { return ngay; }
            set { ngay = value; }
        }

        public TOA_THUOC(string idkb, string loidan, int trangthai, string ngay)
        {
            //this.Id_tt = idtt;
            this.Id_kb = idkb;
            //this.Tt_ten = ten;
            this.Tt_loidan = loidan;
            this.Tt_trangthai = trangthai;
            this.Tt_ngay = ngay;
        }
    }
}

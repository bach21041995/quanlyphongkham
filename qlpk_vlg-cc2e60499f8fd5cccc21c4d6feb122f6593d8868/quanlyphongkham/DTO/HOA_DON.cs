using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class HOA_DON
    {
        string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        string tn_id;

        public string Tn_id
        {
            get { return tn_id; }
            set { tn_id = value; }
        }

        int nv_id;

        public int Nv_id
        {
            get { return nv_id; }
            set { nv_id = value; }
        }

        DateTime ngay;

        public DateTime Ngay
        {
            get { return ngay; }
            set { ngay = value; }
        }

        string trangthai;

        public string Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }

        int lantt;

        public int Lantt
        {
            get { return lantt; }
            set { lantt = value; }
        }

      

        public HOA_DON(string hd, string tn, int nv, DateTime ngay, string trangthai, int lantt)
        {
            this.Id = hd;
            this.Tn_id = tn;
            this.Nv_id = nv;
            this.Ngay = ngay;
            this.Trangthai = trangthai;
            this.Lantt = lantt;
        }
    }
}

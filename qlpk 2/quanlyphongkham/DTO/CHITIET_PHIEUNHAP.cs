using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class CHITIET_PHIEUNHAP
    {
        string id_ctpn;

        public string Id_ctpn
        {
            get { return id_ctpn; }
            set { id_ctpn = value; }
        }

        string pn_id;

        public string Pn_id
        {
            get { return pn_id; }
            set { pn_id = value; }
        }

        string vt_id;

        public string Vt_id
        {
            get { return vt_id; }
            set { vt_id = value; }
        }


        string ctpn_hoatchat;

        public string Ctpn_hoatchat
        {
            get { return ctpn_hoatchat; }
            set { ctpn_hoatchat = value; }
        }

        string ctpn_dvt;

        public string Ctpn_dvt
        {
            get { return ctpn_dvt; }
            set { ctpn_dvt = value; }
        }

        float ctpn_gianhap;

        public float Ctpn_gianhap
        {
            get { return ctpn_gianhap; }
            set { ctpn_gianhap = value; }
        }

        int ctpn_solg;

        public int Ctpn_solg
        {
            get { return ctpn_solg; }
            set { ctpn_solg = value; }
        }

        DateTime ctpn_ngaysx;

        public DateTime Ctpn_ngaysx
        {
            get { return ctpn_ngaysx; }
            set { ctpn_ngaysx = value; }
        }

        DateTime ctpn_hsd;

        public DateTime Ctpn_hsd
        {
            get { return ctpn_hsd; }
            set { ctpn_hsd = value; }
        }

        string ctpn_solo;

        public string Ctpn_solo
        {
            get { return ctpn_solo; }
            set { ctpn_solo = value; }
        }

        float tt_truocthue;

        public float Tt_truocthue
        {
            get { return tt_truocthue; }
            set { tt_truocthue = value; }
        }

        float tt_sauthue;

        public float Tt_sauthue
        {
            get { return tt_sauthue; }
            set { tt_sauthue = value; }
        }

        string hamluong;

        public string Hamluong
        {
            get { return hamluong; }
            set { hamluong = value; }
        }

        string quycach;

        public string Quycach
        {
            get { return quycach; }
            set { quycach = value; }
        }

        float giaban;

        public float Giaban
        {
            get { return giaban; }
            set { giaban = value; }
        }

        public CHITIET_PHIEUNHAP(string id, string hoatchat, string dvt, int solg, float gianhap, string solo, 
            DateTime ngaysx, DateTime hansd, float trcthue, float sauthue, string hamlg, string quycach, float giaban, string vt_id, string pn_id)
        {
            this.Id_ctpn = id;
            this.Ctpn_hoatchat = hoatchat;
            this.Ctpn_dvt = dvt;
            this.Ctpn_solg = solg;
            this.Ctpn_gianhap = gianhap;
            this.Ctpn_solo = solo;
            this.Ctpn_ngaysx = ngaysx;
            this.Ctpn_hsd = hansd;
            this.Tt_truocthue = trcthue;
            this.Tt_sauthue = sauthue;
            this.Vt_id = vt_id;
            this.Pn_id = pn_id;
            this.Hamluong = hamlg;
            this.Quycach = quycach;
            this.Giaban = giaban;
        }
    }
}

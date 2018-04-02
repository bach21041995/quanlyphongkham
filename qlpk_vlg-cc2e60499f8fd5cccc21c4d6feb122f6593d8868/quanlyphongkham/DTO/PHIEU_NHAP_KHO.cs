using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class PHIEU_NHAP_KHO
    {
        string mapn;

        public string Mapn
        {
            get { return mapn; }
            set { mapn = value; }
        }

        string pn_nguoigiao;

        public string Pn_nguoigiao
        {
            get { return pn_nguoigiao; }
            set { pn_nguoigiao = value; }
        }

        string pn_nguoinhan;

        public string Pn_nguoinhan
        {
            get { return pn_nguoinhan; }
            set { pn_nguoinhan = value; }
        }

        DateTime pn_ngaynhap;

        public DateTime Pn_ngaynhap
        {
            get { return pn_ngaynhap; }
            set { pn_ngaynhap = value; }
        }

        float pn_vat;

        public float Pn_vat
        {
            get { return pn_vat; }
            set { pn_vat = value; }
        }

        string ghichu;

        public string Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }

        string kho_id;

        public string Kho_id
        {
            get { return kho_id; }
            set { kho_id = value; }
        }

        string ncc_id;

        public string Ncc_id
        {
            get { return ncc_id; }
            set { ncc_id = value; }
        }

        string sohd;

        public string Sohd
        {
            get { return sohd; }
            set { sohd = value; }
        }

        DateTime ngayhd;

        public DateTime Ngayhd
        {
            get { return ngayhd; }
            set { ngayhd = value; }
        }

        public PHIEU_NHAP_KHO(string ma, string nguoigiao, string nguoinhan, DateTime ngaynhap, float vat, string ghichu, string kho, string ncc, string sohd, DateTime ngayhd)
        {
            this.Mapn = ma;
            this.Pn_nguoigiao = nguoigiao;
            this.Pn_nguoinhan = nguoinhan;
            this.Pn_ngaynhap = ngaynhap;
            this.Pn_vat = vat;
            this.Ghichu = ghichu;
            this.Kho_id = kho;
            this.Ncc_id = ncc;
            this.Sohd = sohd;
            this.Ngayhd = ngayhd;
        }
    }
}

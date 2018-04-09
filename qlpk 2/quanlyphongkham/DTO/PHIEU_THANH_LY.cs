using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class PHIEU_THANH_LY
    {
        string ptl_id;

        public string Ptl_id
        {
            get { return ptl_id; }
            set { ptl_id = value; }
        }

        string httl;

        public string Httl
        {
            get { return httl; }
            set { httl = value; }
        }

        string nhacc;

        public string Nhacc
        {
            get { return nhacc; }
            set { nhacc = value; }
        }

        string kho_id;

        public string Kho_id
        {
            get { return kho_id; }
            set { kho_id = value; }
        }

        DateTime ptl_ngay;

        public DateTime Ptl_ngay
        {
            get { return ptl_ngay; }
            set { ptl_ngay = value; }
        }

        string ptl_ghichu;

        public string Ptl_ghichu
        {
            get { return ptl_ghichu; }
            set { ptl_ghichu = value; }
        }

        public PHIEU_THANH_LY(string id, string ncc, string kho, string httl, DateTime ngay, string ghichu)
        {
            this.Ptl_id = id;
            this.Kho_id = id;
            this.Nhacc = ncc;
            this.Kho_id = kho;
            this.Httl = httl;
            this.Ptl_ngay = ngay;
            this.Ptl_ghichu = ghichu;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class CT_HOADONTHUOC
    {
        string hd;

        public string Hd
        {
            get { return hd; }
            set { hd = value; }
        }

        string kho;

        public string Kho
        {
            get { return kho; }
            set { kho = value; }
        }

        int ngvu;

        public int Ngvu
        {
            get { return ngvu; }
            set { ngvu = value; }
        }

        string vattu;

        public string Vattu
        {
            get { return vattu; }
            set { vattu = value; }
        }

        DateTime thoidiem;

        public DateTime Thoidiem
        {
            get { return thoidiem; }
            set { thoidiem = value; }
        }

        string id_nhapkho;

        public string Id_nhapkho
        {
            get { return id_nhapkho; }
            set { id_nhapkho = value; }
        }

        int solg;

        public int Solg
        {
            get { return solg; }
            set { solg = value; }
        }

        float dongia;

        public float Dongia
        {
            get { return dongia; }
            set { dongia = value; }
        }

        float thanhtien;

        public float Thanhtien
        {
            get { return thanhtien; }
            set { thanhtien = value; }
        }

        public CT_HOADONTHUOC(string hd, string kho, string vt, int ngvu, DateTime thoidiem, string id_nhapkho,
            int solg, float gia, float tien)
        {
            this.Hd = hd;
            this.Kho = kho;
            this.Vattu = vt;
            this.Ngvu = ngvu;
            this.Thoidiem = thoidiem;
            this.Id_nhapkho = id_nhapkho;
            this.Solg = solg;
            this.Dongia = gia;
            this.Thanhtien = tien;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class KHO_CHI_TIET
    {
        string kho_id;

        public string Kho_id
        {
            get { return kho_id; }
            set { kho_id = value; }
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

        string toathuoc;

        public string Toathuoc
        {
            get { return toathuoc; }
            set { toathuoc = value; }
        }

        public KHO_CHI_TIET(string kho, int ngvu, string vattu, DateTime thoidiem, string id_nk, int solg, float gia, string tt_id)
        {
            this.Kho_id = kho;
            this.Ngvu = ngvu;
            this.Vattu = vattu;
            this.Thoidiem = thoidiem;
            this.Id_nhapkho = id_nk;
            this.Solg = solg;
            this.Dongia = gia;
            this.Toathuoc = tt_id;
        }
    }
}

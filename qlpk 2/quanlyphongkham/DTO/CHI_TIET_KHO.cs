using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class CHI_TIET_KHO
    {
        string kho_id;

        public string Kho_id
        {
            get { return kho_id; }
            set { kho_id = value; }
        }

        string ngvu_id;

        public string Ngvu_id
        {
            get { return ngvu_id; }
            set { ngvu_id = value; }
        }

        string vt_id;

        public string Vt_id
        {
            get { return vt_id; }
            set { vt_id = value; }
        }

        string id_nkc;

        public string Id_nkc
        {
            get { return id_nkc; }
            set { id_nkc = value; }
        }

        DateTime thoidiem;

        public DateTime Thoidiem
        {
            get { return thoidiem; }
            set { thoidiem = value; }
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

        int id_toathuoc;

        public int Id_toathuoc
        {
            get { return id_toathuoc; }
            set { id_toathuoc = value; }
        }

        public CHI_TIET_KHO(string kho, string ngvu, string vattu, string id_ctnhap, DateTime thoidiem, int solg, float dongia, int toathuoc)
        {
            this.Kho_id = kho;
            this.Ngvu_id = ngvu;
            this.Vt_id = vattu;
            this.Id_nkc = id_ctnhap;
            this.Thoidiem = thoidiem;
            this.Solg = solg;
            this.Dongia = -dongia;
            this.Id_toathuoc = toathuoc;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class DM_THUOC
    {
        string id_thuoc;
        public string Id_thuoc
        {
            get { return id_thuoc; }
            set { id_thuoc = value; }
        }


        string thuoc_ten;
        public string Thuoc_ten
        {
            get { return thuoc_ten; }
            set { thuoc_ten = value; }
        }


        string thuoc_dvt;
        public string Thuoc_dvt
        {
            get { return thuoc_dvt; }
            set { thuoc_dvt = value; }
        }


        float thuoc_gia;
        public float Thuoc_gia
        {
            get { return thuoc_gia; }
            set { thuoc_gia = value; }
        }

        string thuoc_cachdung;
        public string Thuoc_cachdung
        {
            get { return thuoc_cachdung; }
            set { thuoc_cachdung = value; }
        }

        string hoatchat;

        public string Hoatchat
        {
            get { return hoatchat; }
            set { hoatchat = value; }
        }

        string hamluong;

        public string Hamluong
        {
            get { return hamluong; }
            set { hamluong = value; }
        }

        string qcdongoi;

        public string Qcdongoi
        {
            get { return qcdongoi; }
            set { qcdongoi = value; }
        }

        string ghichu;

        public string Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }

        int nuocsx;

        public int Nuocsx
        {
            get { return nuocsx; }
            set { nuocsx = value; }
        }

        string nhasx;

        public string Nhasx
        {
            get { return nhasx; }
            set { nhasx = value; }
        }

        string nhomthuoc;

        public string Nhomthuoc
        {
            get { return nhomthuoc; }
            set { nhomthuoc = value; }
        }

        //public DM_THUOC(string idthuoc, string idlthuoc, string ten, string hdsd, string dvt, string congdung, float gia, int trangthai, string cachdung)
        //{
        //    this.Id_thuoc = idthuoc;
        //    this.Id_lt = idlthuoc;
        //    this.Thuoc_ten = ten;
        //    this.Thuoc_hdsd = hdsd;
        //    this.Thuoc_dvt = dvt;
        //    this.Thuoc_congdung = congdung;
        //    this.Thuoc_gia = gia;
        //    this.Thuoc_trangthai = trangthai;
        //    this.Thuoc_cachdung = cachdung;
        //}
    }
}

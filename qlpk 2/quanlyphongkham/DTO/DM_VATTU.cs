using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class DM_VATTU
    {
        string vt_id;

        public string Vt_id
        {
            get { return vt_id; }
            set { vt_id = value; }
        }

        string vt_ten;

        public string Vt_ten
        {
            get { return vt_ten; }
            set { vt_ten = value; }
        }

        string vt_dvt;

        public string Vt_dvt
        {
            get { return vt_dvt; }
            set { vt_dvt = value; }
        }


        float vt_giaban;

        public float Vt_giaban
        {
            get { return vt_giaban; }
            set { vt_giaban = value; }
        }

       

        int vt_tinhtrang;

        public int Vt_tinhtrang
        {
            get { return vt_tinhtrang; }
            set { vt_tinhtrang = value; }
        }

        string vt_cachdung;

        public string Vt_cachdung
        {
            get { return vt_cachdung; }
            set { vt_cachdung = value; }
        }

        string vt_hoatchat;

        public string Vt_hoatchat
        {
            get { return vt_hoatchat; }
            set { vt_hoatchat = value; }
        }

        string vt_hamluong;

        public string Vt_hamluong
        {
            get { return vt_hamluong; }
            set { vt_hamluong = value; }
        }

        string qcdonggoi;

        public string Qcdonggoi
        {
            get { return qcdonggoi; }
            set { qcdonggoi = value; }
        }

        string vt_ghichu;

        public string Vt_ghichu
        {
            get { return vt_ghichu; }
            set { vt_ghichu = value; }
        }

        string nhasx;

        public string Nhasx
        {
            get { return nhasx; }
            set { nhasx = value; }
        }

        int nuocsx;

        public int Nuocsx
        {
            get { return nuocsx; }
            set { nuocsx = value; }
        }

        string nhomvt;

        public string Nhomvt
        {
            get { return nhomvt; }
            set { nhomvt = value; }
        }

        public DM_VATTU(string id, string ten, string dvt, float giaban, 
            string cachdung, string hoatchat, string hamluong, 
            string qcdongoi, string ghichu, string nhasx, string nhomvt, int nuocsx)
        {
            this.Vt_id = id;
            this.Vt_ten = ten;
            this.Vt_dvt = dvt;
            this.Vt_giaban = giaban;
            this.Vt_cachdung = cachdung;
            this.Vt_hoatchat = hoatchat;
            this.Vt_hamluong = hamluong;
            this.Qcdonggoi = qcdonggoi;
            this.Vt_ghichu = ghichu;
            this.Nhasx = nhasx;
            this.nhomvt = nhomvt;
            this.Nuocsx = nuocsx;
        }
    }
}

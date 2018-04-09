using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class CT_HOADONVIENPHI
    {
        int pcd_id;

        public int Pcd_id
        {
            get { return pcd_id; }
            set { pcd_id = value; }
        }

        int cls_id;

        public int Cls_id
        {
            get { return cls_id; }
            set { cls_id = value; }
        }

        string hd_id;

        public string Hd_id
        {
            get { return hd_id; }
            set { hd_id = value; }
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

        public CT_HOADONVIENPHI(int pcd, int cls, string hd, int solg, float gia, float tien)
        {
            this.Pcd_id = pcd;
            this.Cls_id = cls;
            this.Hd_id = hd;
            this.Solg = solg;
            this.Dongia = gia;
            this.Thanhtien = tien;
        }
    }

}

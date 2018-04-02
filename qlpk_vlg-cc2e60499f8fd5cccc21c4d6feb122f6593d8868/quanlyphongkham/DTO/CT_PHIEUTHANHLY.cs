using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class CT_PHIEUTHANHLY
    {
        string ptl_id;

        public string Ptl_id
        {
            get { return ptl_id; }
            set { ptl_id = value; }
        }

        string vt_id;

        public string Vt_id
        {
            get { return vt_id; }
            set { vt_id = value; }
        }

        string id_ctnk;

        public string Id_ctnk
        {
            get { return id_ctnk; }
            set { id_ctnk = value; }
        }

        float cp_thuhoi;

        public float Cp_thuhoi
        {
            get { return cp_thuhoi; }
            set { cp_thuhoi = value; }
        }

        float cp_thanhly;

        public float Cp_thanhly
        {
            get { return cp_thanhly; }
            set { cp_thanhly = value; }
        }

        float solg;

        public float Solg
        {
            get { return solg; }
            set { solg = value; }
        }

        public CT_PHIEUTHANHLY(string ptl, string vt, string ctnk, float thuhoi, float thanhly, float solg)
        {
            this.Ptl_id = ptl;
            this.Vt_id = vt;
            this.Id_ctnk = ctnk;
            this.Cp_thuhoi = thuhoi;
            this.Cp_thanhly = thanhly;
            this.Solg = solg;
        }
    }
}

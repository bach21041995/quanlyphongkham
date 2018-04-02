using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class DM_NHOM_VAT_TU
    {
        string nvt_ma;

        public string Nvt_ma
        {
            get { return nvt_ma; }
            set { nvt_ma = value; }
        }

        string nvt_ten;

        public string Nvt_ten
        {
            get { return nvt_ten; }
            set { nvt_ten = value; }
        }

        string nvt_ghichu;

        public string Nvt_ghichu
        {
            get { return nvt_ghichu; }
            set { nvt_ghichu = value; }
        }

        string lvt_id;

        public string Lvt_id
        {
            get { return lvt_id; }
            set { lvt_id = value; }
        }

        public DM_NHOM_VAT_TU(string id, string ten, string ghichu, string lvt_id)
        {
            this.Nvt_ma = id;
            this.Nvt_ten = ten;
            this.Nvt_ghichu = ghichu;
            this.Lvt_id = lvt_id;
        }
    }
}

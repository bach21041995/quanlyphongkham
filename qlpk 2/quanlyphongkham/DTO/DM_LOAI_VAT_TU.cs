using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class DM_LOAI_VAT_TU
    {
         string lvt_id;
        public string Lvt_id
        {
            get { return lvt_id; }
            set { lvt_id = value; }
        }

        string lvt_ten;
        public string Lvt_ten
        {
            get { return lvt_ten; }
            set { lvt_ten = value; }
        }

        
        string lvt_ghichu;
        public string Lvt_ghichu
        {
            get { return lvt_ghichu; }
            set { lvt_ghichu = value; }
        }

        public DM_LOAI_VAT_TU(string id, string ten, string ghichu)
        {
            this.Lvt_id = id;
            this.Lvt_ten = ten;
            this.Lvt_ghichu = ghichu;
        }
    }
}

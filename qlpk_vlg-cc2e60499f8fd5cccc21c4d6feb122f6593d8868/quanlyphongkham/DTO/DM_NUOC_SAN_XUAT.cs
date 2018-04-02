using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class DM_NUOC_SAN_XUAT
    {
        int nuocsx_id;

        public int Nuocsx_id
        {
            get { return nuocsx_id; }
            set { nuocsx_id = value; }
        }

        string nuocsx_ten;

        public string Nuocsx_ten
        {
            get { return nuocsx_ten; }
            set { nuocsx_ten = value; }
        }

        public DM_NUOC_SAN_XUAT(string ten)
        {
            this.Nuocsx_ten = ten;
        }
    }
}

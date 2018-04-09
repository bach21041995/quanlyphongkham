using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class DM_KHO
    {
        string makho;

        public string Makho
        {
            get { return makho; }
            set { makho = value; }
        }

        string tenkho;

        public string Tenkho
        {
            get { return tenkho; }
            set { tenkho = value; }
        }

        public DM_KHO(string ma, string ten)
        {
            this.Makho = ma;
            this.Tenkho = ten;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class DM_NHA_SAN_XUAT
    {
        string nsx_id;

        public string Nsx_id
        {
            get { return nsx_id; }
            set { nsx_id = value; }
        }

        string nsx_ten;

        public string Nsx_ten
        {
            get { return nsx_ten; }
            set { nsx_ten = value; }
        }

        string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        string dienthoai;

        public string Dienthoai
        {
            get { return dienthoai; }
            set { dienthoai = value; }
        }

        string diachi;

        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }

        public DM_NHA_SAN_XUAT(string id, string ten, string email, string dienthoai, string diachi)
        {
            this.Nsx_id = id;
            this.Nsx_ten = ten;
            this.Email = email;
            this.Dienthoai = dienthoai;
            this.Diachi = diachi;
        }
    }
}

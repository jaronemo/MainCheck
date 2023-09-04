using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricModel
{
    public class CompanyInfo
    {
        private int id;
        private string name;
        private string shortname;
        private string address;
        private string zipcode;
        private string taxid;
        private string phone;
        private string fax;

        private string website;
        private string email;
        private byte[] logo;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Shortname { get => shortname; set => shortname = value; }
        public string Address { get => address; set => address = value; }
        public string Zipcode { get => zipcode; set => zipcode = value; }
        public string Taxid { get => taxid; set => taxid = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Fax { get => fax; set => fax = value; }
        public string Website { get => website; set => website = value; }
        public string Email { get => email; set => email = value; }
        public byte[] Logo { get => logo; set => logo = value; }
    }
}

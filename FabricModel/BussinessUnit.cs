using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricModel
{
    public class BussinessUnit
    {
        private int no;
        private string name;
        private string address;
        private string contactName;
        private string phone;
        private string email;
        private string fax;
        private string mobile;
        private string company_name;
        private string eng_company_name;
        private string code;
        private string principal;
        private string vat1;
        private string vat2;
        private string contract_phone;
        private string contract_fax;
        private string sale1;
        private string sale2;
        private string level1;
        private string level2;
        private string note;
        private int? payment_id;

        public int No { get => no; set => no = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string ContactName { get => contactName; set => contactName = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Fax { get => fax; set => fax = value; }
        public string Mobile { get => mobile; set => mobile = value; }
        public string ComapnyName { get => company_name; set => company_name = value; }

        public string EngCompanyName { get => eng_company_name; set => eng_company_name = value; }
        public string Code { get => code; set => code = value; }
        public string Principal { get => principal; set => principal = value; }

        public string Vat1 { get => vat1; set => vat1 = value; }
        public string Vat2 { get => vat2; set => vat2 = value; }
        public string ContractPhone { get => contract_phone; set => contract_phone = value; }
        public string ContractFax { get => contract_fax; set => contract_fax = value; }
        public string Sale1 { get => sale1; set => sale1 = value; }
        public string Sale2 { get => sale2; set => sale2 = value; }

        public string Level1 { get => level1; set => level1 = value; }
        public string Level2 { get => level2; set => level2 = value; }

        public string Note { get => note; set => note = value; }
        public int? PaymentID { get => payment_id; set => payment_id = value; }

    }
}

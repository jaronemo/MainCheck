using FabricDAL;
using FabricModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricBLL
{
    public class BussinessUnitManage
    {
        public BussinessUnit Get(string no)
        {
            int n;
            if (!Int32.TryParse(no, out n))
            {
                throw new Exception("編號不正確!");
            }
            return new BussinessUnitService().Get(n);
        }

        public List<BussinessUnit> GetList(string condition = "", string find = "")
        {
            if (condition == "簡稱")
            {
                condition = " BU_Name ";
            }
            else if (condition == "公司名稱")
            {
                condition = " BU_company_name ";
            }
            else if (condition == "電話")
            {
                condition = " BU_phone ";
            }
            else if (condition == "聯絡人")
            {
                condition = " BU_ContactName ";
            }
            else
            {
                condition = "";
            }
            return new BussinessUnitService().Get(condition, find);
        }


        private void ValidateInfo(string name, string address, string contactName, string phone, string email, string fax, string mobile, string company_name)
        {
            if (name == string.Empty)
            {
                throw new Exception("請填寫名稱!");
            }
            if (name.Length > 20)
            {
                throw new Exception("名稱填寫太長!");
            }

            if (address.Length > 100)
            {
                throw new Exception("地址太長！");
            }
            if (contactName.Length > 10)
            {
                throw new Exception("聯絡人姓名太長！");
            }
            if (phone.Length > 11)
            {
                throw new Exception("聯絡電話超出長度限制");
            }
            if (email.Length > 50)
            {
                throw new Exception("Email太長");
            }
            if (fax.Length > 16)
            {
                throw new Exception("Fax 太長");
            }
            if (mobile.Length > 11)
            {
                throw new Exception("手機號設定太長");
            }
            if (company_name.Length > 50)
            {
                throw new Exception("公司名稱設定太長");
            }
        }

        private BussinessUnit GetModel(int no, string name, string address, string contactName, string phone, string email, string fax, string mobile, string company_name, string eng_company_name, string code, string principal, string vat1, string vat2, string contract_phone, string contract_fax, string sale1, string sale2, string level1, string level2, string note, int? payment_id)
        {
            BussinessUnit bu = new BussinessUnit();
            bu.No = no;
            bu.Name = name;
            bu.Address = address;
            bu.ContactName = contactName;
            bu.Phone = phone;
            bu.Email = email;
            bu.Fax = fax;
            bu.Mobile = mobile;
            bu.ComapnyName = company_name;
            bu.EngCompanyName = eng_company_name;
            bu.Code = code;
            bu.Principal = principal;
            bu.Vat1 = vat1;
            bu.Vat2 = vat2;
            bu.ContractPhone = contract_phone;
            bu.ContractFax = contract_fax;
            bu.Sale1 = sale1;
            bu.Sale2 = sale2;
            bu.Level1 = level1;
            bu.Level2 = level2;
            bu.Note = note;
            bu.PaymentID = payment_id;

            return bu;
        }

        public void ChangeInfo(string no, string name, string address, string contactName, string phone, string email, string fax, string mobile, string company_name, string eng_company_name, string code, string principal, string vat1, string vat2, string contract_phone, string contract_fax, string sale1, string sale2, string level1, string level2, string note, int? payment_id)
        {
            //更改时无需类别信息
            ValidateInfo(name, address, contactName, phone, email, fax, mobile, company_name);
            int noInt;
            if (!Int32.TryParse(no, out noInt))
            {
                throw new Exception("編號不正確！");
            }
            new BussinessUnitService().ChangeInfo(GetModel(noInt, name, address, contactName, phone, email, fax, mobile, company_name, eng_company_name, code, principal, vat1, vat2, contract_phone, contract_fax, sale1, sale2, level1, level2, note, payment_id));
        }

        public void Add(string name, string address, string contactName, string phone, string email, string fax, string mobile, string company_name, string eng_company_name, string code, string principal, string vat1, string vat2, string contract_phone, string contract_fax, string sale1, string sale2, string level1, string level2, string note, int? payment_id)
        {
            ValidateInfo(name, address, contactName, phone, email, fax, mobile, company_name);
            new BussinessUnitService().Add(GetModel(-1, name, address, contactName, phone, email, fax, mobile, company_name, eng_company_name, code, principal, vat1, vat2, contract_phone, contract_fax, sale1, sale2, level1, level2, note, payment_id));
        }

        public void Delete(string no)
        {
            int noInt;
            if (!Int32.TryParse(no, out noInt))
            {
                throw new Exception("編號不正確！");
            }
            new BussinessUnitService().Delete(noInt);
        }
    }
}

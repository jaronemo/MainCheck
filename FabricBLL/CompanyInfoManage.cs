using FabricDAL;
using FabricModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricBLL
{
    public class CompanyInfoManage
    {
        public CompanyInfo Get()
        {
            return new CompanyInfoServices().Get();
        }
        private CompanyInfo GetModel(string name, string shortname, string address, string zipcode, string taxid, string phone, string fax, string website, string email, byte[] logo)
        {
            CompanyInfo companyInfo = new CompanyInfo();

            companyInfo.Name = name;
            companyInfo.Shortname = shortname;
            companyInfo.Address = address;
            companyInfo.Zipcode = zipcode;
            companyInfo.Taxid = taxid;
            companyInfo.Phone = phone;
            companyInfo.Fax = fax;
            companyInfo.Website = website;
            companyInfo.Email = email;
            companyInfo.Logo = logo;
            return companyInfo;
        }

        public void ChangeInfo(string name, string shortname, string address, string zipcode, string taxid, string phone, string fax, string website, string email, byte[] logo)
        {
            //更改时无需类别信息
            ValidateInfo(name, shortname, address, zipcode, phone, email, fax, taxid);
            new CompanyInfoServices().ChangeInfo(GetModel(name, shortname, address, zipcode, taxid, phone, fax, website, email, logo));
        }

        private void ValidateInfo(string name, string shortname, string address, string zipcode, string phone, string email, string fax, string taxid)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("公司名稱不能為空");
            }
            if (string.IsNullOrEmpty(shortname))
            {
                throw new Exception("公司簡稱不能為空");
            }
            if (string.IsNullOrEmpty(address))
            {
                throw new Exception("公司地址不能為空");
            }
            if (string.IsNullOrEmpty(zipcode))
            {
                throw new Exception("郵編不能為空");
            }
            if (string.IsNullOrEmpty(phone))
            {
                throw new Exception("電話不能為空");
            }
            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("電子郵件不能為空");
            }
            if (string.IsNullOrEmpty(fax))
            {
                throw new Exception("傳真不能為空");
            }
            if (string.IsNullOrEmpty(taxid))
            {
                throw new Exception("統一編號不能為空");
            }
        }
    }
}

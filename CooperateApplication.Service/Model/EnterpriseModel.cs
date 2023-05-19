using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperateApplication.Service.Model
{
    public class EnterpriseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CorporateTaxCode { get; set; }
        public string Director { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public string ImageLogo { get; set; }
        public byte[] ImageByte { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; }
        public List<EnterpriseField> FieldCompanyList { get; set; }
        public List<EnterpriseFacility> AddressCompanyList { get; set; }
    }
    public class EnterpriseField
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class EnterpriseFacility 
    {
        public int Id { get; set; }
        public string DetailAddress { get; set; }
    }
    public class EnterpriseModels
    {
        public List<EnterpriseModel> EnterpriseList { get; set; }
        public int Total { get; set; }
    }
}

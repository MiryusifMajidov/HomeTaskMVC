using HospitalMApi.Model.CustomEnums;
using HospitalMApi.Model.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMApi.Model.Models
{
    public class Patient: BaseAudiTableEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public string PhoneNumber { get; set; }
        public string SeriaNumber { get; set; }
        public string RegistrationAddress { get; set; }
        public string CurrentAddress { get; set; }
        public int InsuranceId { get; set; }
        public Insurance Insurance { get; set; }
        public string Email { get; set; }

    }
}

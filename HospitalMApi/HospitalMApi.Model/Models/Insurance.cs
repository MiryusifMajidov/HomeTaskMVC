using HospitalMApi.Model.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMApi.Model.Models
{
    public class Insurance: BaseAudiTableEntity
    {
        public string PersonInsurance { get; set; }
        public float Discount { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}

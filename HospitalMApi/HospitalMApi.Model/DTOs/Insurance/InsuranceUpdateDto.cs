using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMApi.Model.DTOs.Insurance
{
    public class InsuranceUpdateDto
    {
        public int Id { get; set; }
        public string PersonInsurance { get; set; }
        public float Discount { get; set; }
    }
}

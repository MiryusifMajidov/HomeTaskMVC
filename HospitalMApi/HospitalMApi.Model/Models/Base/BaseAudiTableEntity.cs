using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMApi.Model.Models.Base
{
    public class BaseAudiTableEntity:BaseEntity
    {
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int CreateBy { get; set; }
        public int UpdateBy { get; set; }

    }
}

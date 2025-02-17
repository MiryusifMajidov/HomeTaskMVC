﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApi.Model.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }

    }
}

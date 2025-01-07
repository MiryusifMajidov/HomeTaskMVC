using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalMApi.Model.Models;

namespace HospitalMApi.Dal.DAL.Configurations
{
    public class InsuranceConfiguration:IEntityTypeConfiguration<Insurance>
    {
        
            public void Configure(EntityTypeBuilder<Insurance> builder)
            {
                builder.HasKey(s => s.Id);
                builder.Property(s => s.PersonInsurance)
                           .IsRequired()
                       .HasMaxLength(50);
            }
       
    }
}

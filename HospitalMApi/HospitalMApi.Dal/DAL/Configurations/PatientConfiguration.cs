using HospitalMApi.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMApi.Dal.DAL.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {

        public void Configure(EntityTypeBuilder<Patient> builder)
        {
         
            builder.HasKey(p => p.Id);

           
            builder.Property(p => p.Name)
                   .IsRequired() 
                   .HasMaxLength(44);

            builder.Property(p => p.Surname)
                   .IsRequired() 
                   .HasMaxLength(44); 

            
            builder.Property(p => p.DOB)
                   .IsRequired(); 

            
            builder.Property(p => p.Gender)
                   .IsRequired();

            builder.Property(p => p.BloodGroup)
                   .IsRequired();

           
            builder.Property(p => p.PhoneNumber)
                   .HasMaxLength(15);

            builder.Property(p => p.SeriaNumber)
                   .HasMaxLength(20); 

            builder.Property(p => p.RegistrationAddress)
                   .HasMaxLength(100); 

            builder.Property(p => p.CurrentAddress)
                   .HasMaxLength(100); 

            builder.Property(p => p.Email)
                   .HasMaxLength(100);


            builder.HasOne(p => p.Insurance)
                   .WithMany(i => i.Patients)
                   .HasForeignKey(p => p.InsuranceId)
                   .OnDelete(DeleteBehavior.Restrict);

           
            builder.HasIndex(p => p.PhoneNumber)
                   .IsUnique();

            builder.HasIndex(p => p.Email)
                   .IsUnique();
        }
    }
}

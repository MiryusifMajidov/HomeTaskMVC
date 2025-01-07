using AutoMapper;
using HospitalMApi.Model.DTOs.Patient;
using HospitalMApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMApi.Model.MappingProfile
{
    public class PatientProfile:Profile
    {
        public PatientProfile()
        {
            CreateMap<PatientCreateDto, Patient>();
            CreateMap<Patient, PatientCreateDto>();
        }
    }
}

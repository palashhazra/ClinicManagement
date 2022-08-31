using AutoMapper;
using HospitalManagement.DTOs;
using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagement.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Patient, PatientsDto>();
            Mapper.CreateMap<PatientsDto, Patient>();
        }
    }
}
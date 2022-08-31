using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagement.ViewModels
{
    public class DoctorViewModel
    {
        public Doctor Doctor { get; set; }
        public List<Patient> Patients { get; set; }
    }
}
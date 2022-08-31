using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalManagement.DTOs
{
    public class PatientsDto
    {
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Please Enter Patient Name")]
        public string PatientName { get; set; }

        [Required(ErrorMessage = "Pleaese Enter the Illness")]
        public string Dieseases { get; set; }

        [Required(ErrorMessage = "Please Enter Date of Birth")]       
        public DateTime? DateOfBirth { get; set; }

        public bool IsActive { get; set; }
    }
}
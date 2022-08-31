using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class Patient
    {
        public int PatientId { get; set; }

        [Required(ErrorMessage ="Please Enter Patient Name")]
        public string PatientName { get; set; }

        [Required(ErrorMessage ="Pleaese Enter the Illness")]
        public string Dieseases { get; set; }

        [Required(ErrorMessage ="Please Enter Date of Birth")]
        [Display(Name = "Date Of Birth")]       
        public DateTime? DateOfBirth { get; set; }

        public bool IsActive { get; set; }

        //public virtual ICollection<Appointment> Doctors { get; set; }
    }
}
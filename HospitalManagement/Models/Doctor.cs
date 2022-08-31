using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class Doctor
    {
        public int? Id { get; set; }

        [Required(ErrorMessage ="Please enter Doctor's Name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter the Department")]
        public string Department { get; set; }

        [Required(ErrorMessage ="Please select the Date of Birth")]
        [Display(Name="Date Of Birth")]
        [Minimum18YearsToBeADoctor]
        public DateTime? DOB { get; set; }

        public bool IsActive { get; set; }

        //public virtual ICollection<Appointment> Patients { get; set; }

        public Doctor()
        {
            Id = 0;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalManagement.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        public string Details { get; set; }

        public bool IsActive { get; set; }
        
        public int PatientId { get; set; } 
              
        public int DoctorId { get; set; }
         
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }

        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }
    }
}
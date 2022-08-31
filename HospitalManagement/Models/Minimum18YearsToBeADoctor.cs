using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalManagement.Models
{
    public class Minimum18YearsToBeADoctor : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var doctor = (Doctor)validationContext.ObjectInstance;
            if (doctor.DOB == null)
                return new ValidationResult("Birthdate is Required");

            var age = DateTime.Today.Year - doctor.DOB.Value.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Doctor has to be an age of 18 years or more");
        }
    }
}
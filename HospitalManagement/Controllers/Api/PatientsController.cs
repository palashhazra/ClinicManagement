using AutoMapper;
using HospitalManagement.DTOs;
using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HospitalManagement.Controllers.Api
{
    public class PatientsController : ApiController
    {
        private ApplicationDbContext _context=new ApplicationDbContext();        

        public IHttpActionResult GetPatient()
        {
            var patientDto = _context.Patients
                                .ToList()
                                .Select(Mapper.Map<Patient, PatientsDto>);
            return Ok(patientDto);
        }

        public IHttpActionResult GetPatient(int id)
        {
            var patient = _context.Patients.SingleOrDefault(x => x.PatientId == id);
            if (patient == null)
                return NotFound();

            return Ok(Mapper.Map<Patient, PatientsDto>(patient));
        }

        [HttpPost]
        public IHttpActionResult CreatePatient(PatientsDto patientsdto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var patient = Mapper.Map<PatientsDto, Patient>(patientsdto);
            _context.Patients.Add(patient);
            _context.SaveChanges();
            patientsdto.PatientId = patient.PatientId;
            return Created(new Uri(Request.RequestUri + "/" + patient.PatientId), patientsdto);
        }

        [HttpPut]
        public void UpdatePatient(int id, PatientsDto patientdto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var patientInDb = _context.Patients.SingleOrDefault(c => c.PatientId == id);
            if (patientInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(patientdto, patientInDb);

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeletePatient(int id)
        {
            var patientInDb = _context.Patients.SingleOrDefault(c => c.PatientId == id);
            if (patientInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Patients.Remove(patientInDb);
            _context.SaveChanges();
        }
    }
}

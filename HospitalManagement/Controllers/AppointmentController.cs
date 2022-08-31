using HospitalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagement.Controllers
{
    [RoutePrefix("Appointment")]
    public class AppointmentController : Controller
    {
        private ApplicationDbContext _context=new ApplicationDbContext();
        
        // GET: Appointment       
        public ActionResult Index()
        {            
            return View();
        }

        // GET: Appointment/Details/5
        [HttpGet]
        [Route("Details/{patientId}")]
        public ActionResult Details(int patientId)
        {
            var lstPatientDtls = _context.Appointments.Where(x => x.PatientId == patientId).ToList();
            if (lstPatientDtls.Count > 0)
            {
                return View(lstPatientDtls);
            }
            else
            {
                return RedirectToAction("Create/"+patientId);
            }            
        }

        // GET: Appointment/Create
        [Route("Create/{patientId}")]
        public ActionResult Create(int patientId)
        {
            var patientDetails = _context.Patients.FirstOrDefault(x => x.PatientId == patientId);
            ViewBag.doctors = _context.Doctors.ToList();
            Appointment objAppointment = new Appointment();
            objAppointment.Patient = patientDetails;
            objAppointment.AppointmentDateTime = DateTime.Now;

            return View(objAppointment);
        }

        // POST: Appointment/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Appointment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Appointment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Appointment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Appointment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

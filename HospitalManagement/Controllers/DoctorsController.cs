using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using HospitalManagement.Models;
using HospitalManagement.ViewModels;
using System.Linq;

namespace HospitalManagement.Controllers
{
    public class DoctorsController : Controller
    {
        private ApplicationDbContext _context;
        public DoctorsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Doctors
        [Route("doctors/doctordetails")]
        public ActionResult DoctorDetails(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            var objDoctor = _context.Doctors.ToList();
            //var patients = new List<Patient> { new Patient { PatientId=1, PatientName="Gaurav"},
            //                                 new Patient { PatientId=2, PatientName ="Uday"}
            //                                 };
            //var viewModel = new DoctorViewModel
            //{
            //    Doctor = objDoctor,
            //    Patients = patients
            //};
            return View(objDoctor);
        }

        //[Route("doctors/doctordetails/{name}")]
        //public ActionResult ByDoctorName(string name)
        //{
        //    var objDoctor = new Doctor { Name = name };
        //    return View(objDoctor);
        //}

        [Route("Doctors/New")]
        public ActionResult DoctorForm()
        {
            var doctor = new Doctor();
            return View(doctor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return View("DoctorForm", doctor);
            }

            if (doctor.Id == 0)
            {
                _context.Doctors.Add(doctor);
            }
            else
            {
                var dctrContxt = _context.Doctors.SingleOrDefault(x => x.Id == doctor.Id);
                if (dctrContxt != null)
                {
                    dctrContxt.Name = doctor.Name;
                    dctrContxt.DOB = doctor.DOB;
                    dctrContxt.Department = doctor.Department;
                    dctrContxt.IsActive = doctor.IsActive;
                    _context.Entry(dctrContxt).State = EntityState.Modified;
                }
            }
            _context.SaveChanges();
            return RedirectToAction("DoctorDetails", "Doctors");
        }

        public ActionResult Edit(int id)
        {
            var doctor = _context.Doctors.Where(x => x.Id == id).FirstOrDefault();
            if (doctor == null)
                return HttpNotFound();

            return View("DoctorForm", doctor);
        }
    }
}
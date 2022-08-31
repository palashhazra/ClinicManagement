using HospitalManagement.Models;
using System.Web.Mvc;
using System.Linq;

namespace HospitalManagement.Controllers
{
    public class PatientController : Controller
    {
        private ApplicationDbContext _context=new ApplicationDbContext();
        
        // GET: Patient
        [Route("Patient/Patient")]
        public ActionResult Patient()
        {
            //var patients = _context.Patients.ToList();           
            if (User.IsInRole(RoleName.CanManagePatients))
                return View("Patient");

            return View("ReadOnlyPatientList");
        }
        [Route("Patient/Patient/{id}")]
        public ActionResult Patient(int id)
        {
            var patient = _context.Patients.Where(x => x.PatientId == id).ToList();
            if (patient == null)
                return HttpNotFound();
            return View(patient);
        }
        [Authorize(Roles = RoleName.CanManagePatients)]
        public ActionResult New()
        {
            var patient = new Patient();   //to set a default value of PatientId to get rid of validation summary
            return View(patient);
        }

        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return View("New", patient);
            }
            if (patient.PatientId == 0)
            {
                _context.Patients.Add(patient);               
            }
            else
            {
                var patientContext = _context.Patients.Where(c => c.PatientId == patient.PatientId).FirstOrDefault();
                if (patientContext != null)
                {
                    patientContext.PatientId = patient.PatientId;
                    patientContext.PatientName = patient.PatientName;
                    patientContext.DateOfBirth = patient.DateOfBirth;
                    patientContext.Dieseases = patient.Dieseases;
                    patientContext.IsActive = patient.IsActive;
                    _context.Entry(patientContext).State = System.Data.Entity.EntityState.Modified;                   
                }
            }
            _context.SaveChanges();

            return RedirectToAction("Patient","Patient");
        }

        public ActionResult Edit(int id)
        {
            var patient = _context.Patients.Where(x => x.PatientId == id).FirstOrDefault();
            if (patient == null)
                return HttpNotFound();
            return View("New",patient);
        }
    }
}
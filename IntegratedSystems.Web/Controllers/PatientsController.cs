using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IntegratedSystems.Domain.Domain_Models;
using IntegratedSystems.Repository;
using IntegratedSystems.Service.Interface;
using IntegratedSystems.Service.Implementation;

namespace IntegratedSystems.Web.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatients _patinetsService;
        private readonly IVactinateCentar _vactinatecentresService;

        public PatientsController(IPatients? productService, IVactinateCentar? shoppingCartService)
        {
            _patinetsService = productService;
            _vactinatecentresService = shoppingCartService;
        }

        // GET: Patients
        public async Task<IActionResult> Index()
        {
            return View(_patinetsService.GetAllPatient());
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var product = _patinetsService.GetDetailsForPatient(id);
            return View(product);

        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return View(patient);
            }
            _patinetsService.CreateNewPatient(patient);

            return RedirectToAction(nameof(Index));
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var product = _patinetsService.GetDetailsForPatient(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    
        // POST: Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Embg,FirstName,LastName,PhoneNumber,Email,Id")] Patient patient)
        {
        if (id != patient.Id)
        {
                return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                    _patinetsService.UpdeteExistingPatient(patient);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(patient);
    }

        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _patinetsService.GetDetailsForPatient(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var product = _patinetsService.GetDetailsForPatient(id);
            if (product != null)
            {
                _patinetsService.DeletePatient(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(Guid id)
        {
            return true;
      //      return _context.Patients.Any(e => e.Id == id);
        }
    }
}

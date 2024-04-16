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
using IntegratedSystems.Domain.DTO;
using System.Security.Claims;
using IntegratedSystems.Domain;

namespace IntegratedSystems.Web.Controllers
{
    public class VaccinationCentersController : Controller
    {
        private readonly IPatients _patinetsService;
        private readonly IVactinateCentar _vactinatecentresService;
        public VaccinationCentersController(IPatients? productService, IVactinateCentar? shoppingCartService)
        {
            _patinetsService = productService;
            _vactinatecentresService = shoppingCartService;
        }
        public async Task<IActionResult> AddPacienttoCentar(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var centar = _vactinatecentresService.GetDetailsForVactinateCentre(id);
            var vacctinate = new VaccinationDTO();
            vacctinate.VaccinationCenter = centar.Id;
            vacctinate.PacientintinCentar = _patinetsService.GetAllPatient();
            if (vacctinate.PacientintinCentar.Count() > centar.MaxCapacity)
            {
                return Content("<h1>Error: Maximum capacity exceeded</h1>", "text/html");
            }
            return View(vacctinate);
            
        }
        [HttpPost]
        public async Task<IActionResult> AddToCartConfirmed(VaccinationDTO model)
        {

            _vactinatecentresService.addPacienttoCentre(model);
            return View("Index", _vactinatecentresService.GetAllVactinateCentre());
        }

        // GET: VaccinationCenters
        public async Task<IActionResult> Index()
        {
            return View(_vactinatecentresService.GetAllVactinateCentre());
        }

        // GET: VaccinationCenters/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            //id na centarot go imam treba da gi najdam site vacctinate so toa id
            var vaccinationCenter = _vactinatecentresService.GetDetailsForVactinateCentre(id);
            return View(vaccinationCenter);
        }

        // GET: VaccinationCenters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VaccinationCenters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Address,MaxCapacity,Id")] VaccinationCenter vaccinationCenter)
        {
            if (!ModelState.IsValid)
            {
                return View(vaccinationCenter);
            }
            _vactinatecentresService.CreateNewVactinateCentre(vaccinationCenter);
            return RedirectToAction(nameof(Index));
        }

        // GET: VaccinationCenters/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _vactinatecentresService.GetDetailsForVactinateCentre(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: VaccinationCenters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Address,MaxCapacity,Id")] VaccinationCenter vaccinationCenter)
        {
            if (id != vaccinationCenter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _vactinatecentresService.UpdeteExistingPatient(vaccinationCenter);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vaccinationCenter);
        }

        // GET: VaccinationCenters/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _vactinatecentresService.GetDetailsForVactinateCentre(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: VaccinationCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var product = _vactinatecentresService.GetDetailsForVactinateCentre(id);
            if (product != null)
            {
                _vactinatecentresService.DeletePatient(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool VaccinationCenterExists(Guid id)
        {
            return true;
           // return _context.VaccinationCenters.Any(e => e.Id == id);
        }
    }
}

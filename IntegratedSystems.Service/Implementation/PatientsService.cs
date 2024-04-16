using IntegratedSystems.Domain.Domain_Models;
using IntegratedSystems.Repository.Interface;
using IntegratedSystems.Service.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedSystems.Service.Implementation
{
    public class PatientsService : IPatients
    {
        private readonly IRepository<Patient> _patientRepository;
        private readonly IRepository<Vaccine> _patientinCentar;
        // private readonly IUserRepository _userRepository;
        private readonly ILogger<PatientsService> _logger;

        public PatientsService(IRepository<Patient> patientRepository, ILogger<PatientsService> logger, IRepository<Vaccine> patinetsinVactinateCentre)
        {
            _patientRepository = patientRepository;
            _patientinCentar = patinetsinVactinateCentre;
            _logger = logger;
        }

        public void CreateNewPatient(Patient p)
        {
            _patientRepository.Insert(p);
        }

        public void DeletePatient(Guid id)
        {
            var patinet = _patientRepository.Get(id);
            _patientRepository.Delete(patinet);
        }

        public List<Patient> GetAllPatient()
        {
            return _patientRepository.GetAll().ToList();
        }

        public Patient GetDetailsForPatient(Guid? id)
        {
            return _patientRepository.Get(id);
        }

        public void UpdeteExistingPatient(Patient p)
        {
            _patientRepository.Update(p);
        }
    }
}

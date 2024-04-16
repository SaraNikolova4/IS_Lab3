using IntegratedSystems.Domain.Domain_Models;
using IntegratedSystems.Domain.DTO;
using IntegratedSystems.Repository.Interface;
using IntegratedSystems.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedSystems.Service.Implementation
{
    public class VaccintationCentreService : IVactinateCentar
    {

        private readonly IRepository<VaccinationCenter> _vactionationcentreRepository;
        private readonly IRepository<Vaccine> _vaccinetrepositroy;
        private readonly IRepository<Patient> _PatientsRepository;

        public VaccintationCentreService(IRepository<VaccinationCenter> shoppingCartRepository, IRepository<Vaccine> productInShoppingCartRepository, IRepository<Patient> patientsRepository)
        {
            _vactionationcentreRepository = shoppingCartRepository;
            _vaccinetrepositroy = productInShoppingCartRepository;
            _PatientsRepository = patientsRepository;
        }

        public void CreateNewVactinateCentre(VaccinationCenter p)
        {
            _vactionationcentreRepository.Insert(p);
        }

        public void DeletePatient(Guid id)
        {
            var patinet = _vactionationcentreRepository.Get(id);
            _vactionationcentreRepository.Delete(patinet);
        }

        public List<VaccinationCenter> GetAllVactinateCentre()
        {
            return _vactionationcentreRepository.GetAll().ToList();
        }

        public VaccinationCenter GetDetailsForVactinateCentre(Guid? id)
        {
            return _vactionationcentreRepository.Get(id);
        }

        public void UpdeteExistingPatient(VaccinationCenter p)
        {
            _vactionationcentreRepository.Update(p);
        }
        public  bool addPacienttoCentre(VaccinationDTO p)
        {
            var vaccine = new Vaccine();
            vaccine.Manufacturer = p.Manufacturer;
            vaccine.Certificate = Guid.NewGuid();
            vaccine.VaccinationCenter = p.VaccinationCenter;
            var vcentar = _vactionationcentreRepository.Get(p.VaccinationCenter);
            vaccine.Center = vcentar;
            vaccine.PatientId = p.PatientId;
            var pacineto = _PatientsRepository.Get(p.PatientId);
            vaccine.PatientFor = pacineto;
            _vaccinetrepositroy.Insert(vaccine);
            return true;
        }
       
    }
}
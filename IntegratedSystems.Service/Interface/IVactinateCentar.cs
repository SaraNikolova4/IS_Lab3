using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegratedSystems.Domain.Domain_Models;
using IntegratedSystems.Domain.DTO;

namespace IntegratedSystems.Service.Interface
{
    public interface IVactinateCentar
    {
        List<VaccinationCenter> GetAllVactinateCentre();
        VaccinationCenter GetDetailsForVactinateCentre(Guid? id);
        void CreateNewVactinateCentre(VaccinationCenter p);
        void UpdeteExistingPatient(VaccinationCenter p);
        void DeletePatient(Guid id);
        bool addPacienttoCentre(VaccinationDTO p);
    }
}

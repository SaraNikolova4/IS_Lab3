using IntegratedSystems.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedSystems.Service.Interface
{
    public interface IPatients
    {
        List<Patient> GetAllPatient();
        Patient GetDetailsForPatient(Guid? id);
        void CreateNewPatient(Patient p);
        void UpdeteExistingPatient(Patient p);
        void DeletePatient(Guid id);
    }
}

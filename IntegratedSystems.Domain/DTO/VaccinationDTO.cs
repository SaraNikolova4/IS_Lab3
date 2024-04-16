using IntegratedSystems.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedSystems.Domain.DTO
{
    public class VaccinationDTO
    {
        public Guid VaccinationCenter { get; set; }

        public string? Manufacturer { get; set; }
        public Guid? Certificate { get; set; }
        public DateTime DateTaken { get; set; }
        public Guid PatientId { get; set; }
        public virtual Patient? PatientFor { get; set; }
       
        public virtual VaccinationCenter? Center { get; set; }

        public List<Patient>? PacientintinCentar{ get; set; }
        public int number_of_pacientint { get; set; }

    }
}

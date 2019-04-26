using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWorkAdoNet
{
   public class Street : Entity
    {
        public string NameStreet { get; set; }
        

        public Guid CityId { get; set; }
        public City City { get; set; }
    }
}

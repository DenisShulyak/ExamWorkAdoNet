using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWorkAdoNet
{
  public  class Country : Entity
    {
        public string NameCountry { get; set; }


      public  ICollection<City> Cities { get; set; }
      
    }
}

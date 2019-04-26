using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWorkAdoNet
{
  public  class City : Entity
    {
        public string NameCity { get; set; }

        public Guid CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<Street> Streets { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Domain.Entities
{
    public  class Address
    {
        public int Id { get; set; }
        public string Country { get; set; } = string.Empty;

        //public ICollection<Developer> Developers { get; set; }


        //  public ICollection<Developer> ?Developers { get; set; }
        /// <summary>
        /// OR  below options
        /// </summary>
        public ICollection<Developer> Developer { get; set; } = new List<Developer>();
    }
}

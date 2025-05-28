using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Application.Common.Exceptions
{
    public  class DomainException:Exception
    {
        public DomainException(string messege) : base(messege) { }
       
    }
}

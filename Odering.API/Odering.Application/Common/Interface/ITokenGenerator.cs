using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Common.Interface
{
    public  interface ITokenGenerator
    {
        //public string GenerateToken(string userName, string password);
        //public string GenerateJWTToken((string userId, string userName, IList<string> roles) userDetails);
        public string GenerateJWTToken((string userId, string userName, IList<string> roles) userDetails);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_API_Entity.Services
{
    public interface IAuthService
    {
        string GenerateToken(IList<string> roles);
    }
}

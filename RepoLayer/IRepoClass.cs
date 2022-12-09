using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer;

namespace RepoLayer
{
    public interface IRepoClass
    {
        Employee SignUpRequest(Employee e);
        object LoginRequest(string username, string password);
        Employee ReimbursementRequest(Employee e);
        
    }
}
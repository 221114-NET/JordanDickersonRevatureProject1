using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer;

namespace RepoLayer
{
    public interface IRepoClassLogInRequest
    {
        public Employee LogInRequest(string userEmail, string userPassword);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepoLayer;
using ModelsLayer;

namespace BusinessLayer
{
    public class BusinessClassLogInRequest : IBusinessClassLogInRequest
    {
        private readonly IRepoClassLogInRequest iRepoClassLogInRequest;
        BusinessClassLogInRequest(IRepoClassLogInRequest iRepoClassLogInRequest)
        {
            this.iRepoClassLogInRequest = iRepoClassLogInRequest;
        }
        public Employee LogInRequest(string userEmail, string userPassword)
        {
            return iRepoClassLogInRequest.LogInRequest(userEmail, userPassword);
        }
    }
}
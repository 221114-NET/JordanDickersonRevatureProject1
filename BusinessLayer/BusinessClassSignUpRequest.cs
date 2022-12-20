using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer;
using RepoLayer;

namespace BusinessLayer
{
    public class BusinessClassSignUpRequest : IBusinessClassSignUpRequest
    {
        private readonly IRepoClassSignUpRequest iRepoSignUpRequest;

        public BusinessClassSignUpRequest(IRepoClassSignUpRequest iRepoSignUpRequest)
        {
            this.iRepoSignUpRequest = iRepoSignUpRequest;
        }
        
        public Employee SignUpRequest(Employee e)
        {
            return iRepoSignUpRequest.SignUpRequest(e);
        }
    }
}
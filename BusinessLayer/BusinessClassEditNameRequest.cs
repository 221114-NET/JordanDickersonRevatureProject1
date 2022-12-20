using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepoLayer;

namespace BusinessLayer
{
    public class BusinessClassEditNameRequest : IBusinessClassEditNameRequest
    {
        private readonly IRepoClassEditNameRequest iRepo;

        public BusinessClassEditNameRequest(IRepoClassEditNameRequest iRepo)
        {
            this.iRepo = iRepo;
        }
        
    }
}
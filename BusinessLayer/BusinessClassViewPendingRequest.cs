using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepoLayer;

namespace BusinessLayer
{
    public class BusinessClassViewPendingRequest : IBusinessClassViewPendingRequest
    {
        private readonly IRepoClassViewPendingRequest iRepo;
        public BusinessClassViewPendingRequest(IRepoClassViewPendingRequest iRepo)
        {
            this.iRepo = iRepo;
        }
    }
}
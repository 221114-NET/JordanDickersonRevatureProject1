using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepoLayer;
using ModelsLayer;

namespace BusinessLayer
{
    public class BusinessClassViewPendingRequest : IBusinessClassViewPendingRequest
    {
        private readonly IRepoClassViewPendingRequest iRepo;
        public BusinessClassViewPendingRequest(IRepoClassViewPendingRequest iRepo)
        {
            this.iRepo = iRepo;
        }

        public List<ReimbursementTicket> ViewPendingRequest()
        {
            return iRepo.ViewPendingRequest();
        }
    }
}
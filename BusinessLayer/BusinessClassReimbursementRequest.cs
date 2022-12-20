using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepoLayer;
using ModelsLayer;

namespace BusinessLayer
{
    public class BusinessClassReimbursementRequest : IBusinessClassReimbursementRequest
    {
        private readonly IRepoClassReimbursementRequest iRepoClassReimbursementRequest;

        public BusinessClassReimbursementRequest(IRepoClassReimbursementRequest iRepo)
        {
            iRepoClassReimbursementRequest = iRepo;
        }
        public ReimbursementTicket ReimbursementRequest(ReimbursementTicket ticket, int employeeId)
        {
            return iRepoClassReimbursementRequest.ReimbursementRequest(ticket, employeeId);
        }
    }
}
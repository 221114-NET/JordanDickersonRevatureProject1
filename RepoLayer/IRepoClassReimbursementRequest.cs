using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer;

namespace RepoLayer
{
    public interface IRepoClassReimbursementRequest
    {
        public ReimbursementTicket ReimbursementRequest(ReimbursementTicket ticket, int employeeId);
    }
}
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
        List <Employee> LoginRequest(Employee e);
        ReimbursementTicket ReimbursementRequest(ReimbursementTicket ticket, Employee e);
        List<ReimbursementTicket> ViewPendingRequest();
        string UpdatePendingRequest(List<ReimbursementTicket> tickets);
        List<ReimbursementTicket> ViewAllTickets(Employee e);
        Employee EditNameRequest(Employee e);
    }
}
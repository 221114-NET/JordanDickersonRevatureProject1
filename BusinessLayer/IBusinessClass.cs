using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer;
namespace BusinessLayer
{
    public interface IBusinessClass
    {
        Employee SignUpRequest(Employee e);
        List<Employee> LoginRequest();
        ReimbursementTicket ReimbursementRequest(Employee e);
        List<ReimbursementTicket> ViewPendingRequest();
        string UpdatePendingRequest(List<ReimbursementTicket> tickets);
        List<ReimbursementTicket> ViewAllTickets(Employee e);
    }
}
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
        public ReimbursementTicket ReimbursementRequest(Employee e);
        public List<ReimbursementTicket> ViewPendingRequest();
    }
}
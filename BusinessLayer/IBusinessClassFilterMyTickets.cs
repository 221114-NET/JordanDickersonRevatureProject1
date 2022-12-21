using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer;

namespace BusinessLayer
{
    public interface IBusinessClassFilterMyTickets
    {
        public List<ReimbursementTicket> FilterMyTickets(string email, string status);
    }
}
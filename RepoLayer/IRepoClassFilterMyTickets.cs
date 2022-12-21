using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer;

namespace RepoLayer
{
    public interface IRepoClassFilterMyTickets
    {
       public List<ReimbursementTicket> FilterMyTickets(string email, string status);
    }
}
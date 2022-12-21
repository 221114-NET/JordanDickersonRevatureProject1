using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer;

namespace RepoLayer
{
    public interface IRepoClassViewAllMyTickets
    {
        public List<ReimbursementTicket> ViewAllMyTickets(string email);
    }
}
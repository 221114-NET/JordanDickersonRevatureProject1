using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepoLayer;
using ModelsLayer;

namespace BusinessLayer
{
    public class BusinessClassFilterMyTickets : IBusinessClassFilterMyTickets
    {
        private readonly IRepoClassFilterMyTickets iRepo;

        public BusinessClassFilterMyTickets(IRepoClassFilterMyTickets iRepo)
        {
            this.iRepo = iRepo;
        }

        public List<ReimbursementTicket> FilterMyTickets(string email, string status)
        {
            return iRepo.FilterMyTickets(email,status);
        }
        
    }
}
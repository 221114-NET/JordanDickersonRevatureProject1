using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepoLayer;
using ModelsLayer;

namespace BusinessLayer
{
    public class BussinessClassViewAllMyTickets : IBussinessClassViewAllMyTickets
    {
        private readonly IRepoClassViewAllMyTickets iRepo;
        public BussinessClassViewAllMyTickets(IRepoClassViewAllMyTickets iRepo)
        {
            this.iRepo = iRepo;
        }

        public List<ReimbursementTicket> ViewAllMyTickets(string email)
        {
            return iRepo.ViewAllMyTickets(email);
        }
        
    }
}
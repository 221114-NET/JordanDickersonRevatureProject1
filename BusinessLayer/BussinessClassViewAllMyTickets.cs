using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepoLayer;

namespace BusinessLayer
{
    public class BussinessClassViewAllMyTickets : IBussinessClassViewAllMyTickets
    {
        private readonly IRepoClassViewAllMyTickets iRepo;
        public BussinessClassViewAllMyTickets(IRepoClassViewAllMyTickets iRepo)
        {
            this.iRepo = iRepo;
        }
        
    }
}
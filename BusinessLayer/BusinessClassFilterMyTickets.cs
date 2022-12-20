using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepoLayer;

namespace BusinessLayer
{
    public class BusinessClassFilterMyTickets : IBusinessClassFilterMyTickets
    {
        private readonly IRepoClassFilterMyTickets iRepo;

        public BusinessClassFilterMyTickets(IRepoClassFilterMyTickets iRepo)
        {
            this.iRepo = iRepo;
        }
        
    }
}
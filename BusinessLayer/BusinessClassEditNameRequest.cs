using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepoLayer;

namespace BusinessLayer
{
    public class BusinessClassEditNameRequest : IBusinessClassEditNameRequest
    {
        private readonly IRepoClassEditNameRequest iRepo;

        public BusinessClassEditNameRequest(IRepoClassEditNameRequest iRepo)
        {
            this.iRepo = iRepo;
        }

        public string EditNameRequest(string email, string? firstName, string? lastName)
        {
            return iRepo.EditNameRequest(email, firstName,lastName);
        }
        
    }
}
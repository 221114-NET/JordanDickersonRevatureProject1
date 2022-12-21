using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoLayer
{
    public interface IRepoClassEditNameRequest
    {
        public string EditNameRequest(string email, string? firstName, string? lastName);
    }
}
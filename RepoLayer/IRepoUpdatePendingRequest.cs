using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoLayer
{
    public interface IRepoUpdatePendingRequest
    {
        public string UpdatePendingRequest(string status,int ticketId);
    }
}
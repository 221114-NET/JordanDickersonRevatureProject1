using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepoLayer;

namespace BusinessLayer
{
    public class BussinessUpdatePendingRequest : IBussinessUpdatePendingRequest
    {
        readonly IRepoUpdatePendingRequest iRepoUpdatePendingRequest;
        public BussinessUpdatePendingRequest(IRepoUpdatePendingRequest iRepo)
        {
            iRepoUpdatePendingRequest = iRepo;
        }

         public string UpdatePendingRequest(string status,int ticketId)
         {
            return iRepoUpdatePendingRequest.UpdatePendingRequest(status,ticketId);
         }
    }
}
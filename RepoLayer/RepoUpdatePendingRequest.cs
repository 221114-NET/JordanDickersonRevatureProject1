using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace RepoLayer
{
    public class RepoUpdatePendingRequest : IRepoUpdatePendingRequest
    {
        private readonly IMyLogger iLog; // dependency injection

        public RepoUpdatePendingRequest(IMyLogger iLog){
            this.iLog = iLog;
        }

        public string UpdatePendingRequest(string description,string status)
        {
            SqlConnection conn = new SqlConnection("");

            conn.Open();
            
            SqlCommand command = new SqlCommand($"Update Reimbursement_Tickets Set Status = @Status, Where Description = @Description", conn);
            command.Parameters.AddWithValue("@Status", status);
            command.Parameters.AddWithValue("@Description", description);
            
            conn.Close();
            return "";
        }
    }
}
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

        public string UpdatePendingRequest(string status,int ticketId)
        {
            SqlConnection conn = new SqlConnection("");

            conn.Open();
            
            SqlCommand command = new SqlCommand($"UPDATE Reimbursement_Tickets SET Status = @Status Where TicketId = @TicketId", conn);

            command.Parameters.AddWithValue("@TicketId", ticketId);
            command.Parameters.AddWithValue("@Status", status);

            int rowsAffected = command.ExecuteNonQuery();

            if(rowsAffected == 1)
            {
                conn.Close();
                iLog.LogStuff("UpdatePendingRequest");
                return "Pending request updated.";
            }
            else
            {
                conn.Close();
                return "Nothing was updated.";
            }
        }
    }
}
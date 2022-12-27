using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ModelsLayer;

namespace RepoLayer
{
    public class RepoClassViewPendingRequest : IRepoClassViewPendingRequest
    {
        private readonly IMyLogger iLog; // dependency injection

        public RepoClassViewPendingRequest(IMyLogger iLog){
            this.iLog = iLog;
        }

        
        public List<ReimbursementTicket> ViewPendingRequest()
        {
            SqlConnection conn = new SqlConnection("");

            List<ReimbursementTicket> tickets = new List<ReimbursementTicket>();
            SqlCommand command = new SqlCommand($"Select * From Reimbursement_Tickets Where Status = @Status", conn);

            conn.Open();

            command.Parameters.AddWithValue("@Status", "Pending");

            SqlDataReader resultSet = command.ExecuteReader(); // return record/s in a different format
            
            iLog.LogStuff(tickets);
            while(resultSet.Read()) // this method goes through each row of the result set
            {
                // a mapper just re formats the result set
                ReimbursementTicket ticket = Mapper.DataBaseToTickets(resultSet);
                tickets.Add(ticket);
            }
            Console.WriteLine($"Number of tickets returned {tickets.Count}");

            foreach(ReimbursementTicket ticket in tickets)
            {
                Console.WriteLine($"\n{ticket.Request}");
            }
            conn.Close();
            return tickets;
        }
    }
}
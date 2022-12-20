using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ModelsLayer;

namespace RepoLayer
{
    public class RepoClassViewAllMyTickets : IRepoClassViewAllMyTickets
    {
        private readonly IMyLogger iLog; // dependency injection

        public RepoClassViewAllMyTickets(IMyLogger iLog){
            this.iLog = iLog;
        }

        
        public List<ReimbursementTicket> ViewAllMyTickets()
        {
            SqlConnection conn = new SqlConnection("");

            List<ReimbursementTicket> tickets = new List<ReimbursementTicket>();
            SqlCommand command = new SqlCommand($"Select * From Reimbursement_Tickets Where EmployeeId = @EmployeeId", conn);

            conn.Open();

            command.Parameters.AddWithValue("@EmployeeId", e.EmployeeId);

            SqlDataReader resultSet = command.ExecuteReader(); // return record/s in a different format
            
            iLog.LogStuff(tickets);
            while(resultSet.Read()) // this method goes through each row of the result set
            {
                // a mapper just re formats the result set
                ReimbursementTicket ticket = Mapper.DataBaseToTickets(resultSet);
                tickets.Add(ticket);
            }
            Console.WriteLine($"Number of tickets returned {tickets.Count}");
            conn.Close();
            return tickets;
        }
    }
}
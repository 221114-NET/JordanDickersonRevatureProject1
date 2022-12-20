using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ModelsLayer;

namespace RepoLayer
{
    public class RepoClass : IRepoClass
    {
        private readonly IMyLogger iLog; // dependency injection

        public RepoClass(IMyLogger iLog){
            this.iLog = iLog;
        }

        // add ADO.NET to push the data to the DB
        SqlConnection conn = new SqlConnection("");
        
        
        

        public ReimbursementTicket ReimbursementRequest( ReimbursementTicket ticket ,Employee e)
        {
            
            SqlCommand command = new SqlCommand($"insert into Reimbursement_Tickets (Type, Description, DollarAmount, Status, EmployeeId)"
            + "VALUES (@Type, @Description, @DollarAmount, @Status, @EmployeeId)",conn);

            conn.Open();

            command.Parameters.AddWithValue("@Type", ticket.Type);
            command.Parameters.AddWithValue("@Description", ticket.Description);
            command.Parameters.AddWithValue("@DollarAmount", ticket.DollarAmount);
            command.Parameters.AddWithValue("@Status", ticket.Status);
            command.Parameters.AddWithValue("@EmployeeId", 11); //e.EmployeeId

            int rowsAffected = command.ExecuteNonQuery();

            
            if(rowsAffected == 1)
            {
                iLog.LogStuff(ticket);
                Console.WriteLine("Your reimbursement request was sent, check your status later.");
                Console.WriteLine($"Summary\n{ticket.Request}");
            }
            else
            {
                Console.WriteLine("Your reimbursement request was unsuccessful, try again");
                ticket = null!;
            }
            
            conn.Close();
            return ticket;
        }

        public List<ReimbursementTicket> ViewPendingRequest()
        {
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
            conn.Close();
            return tickets;
        }

        public string UpdatePendingRequest(List<ReimbursementTicket> tickets)
        {
            conn.Open();
            // loops through each ticket in the tickets list
            foreach(ReimbursementTicket ticket in tickets)
            {
                do{
                    Console.WriteLine(ticket.Request);
                    Console.WriteLine("Does the request meet the compaines rules? Type Yes or No");
                    ticket.Status = Console.ReadLine()!.ToLower().Replace(" ","");
                }while(!ticket.Status.Equals("yes") && !ticket.Status.Equals("no"));
                
                if(ticket.Status.Equals("yes"))
                {
                    ticket.Status = "Approved";
                }
                else
                {
                    ticket.Status = "Rejected";
                }
                SqlCommand command = new SqlCommand($"Update Reimbursement_Tickets Set Status = @Status, Where Description = @Description", conn);
                command.Parameters.AddWithValue("@Status", ticket.Status);
                command.Parameters.AddWithValue("@Description", ticket.Description);
            }
            conn.Close();
            return "There are no more tickets to update.";
        }

        public List<ReimbursementTicket> ViewAllTickets(Employee e)
        {
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


        public List<ReimbursementTicket> FilterTickets( string t, Employee e)
        {
            List<ReimbursementTicket> tickets = new List<ReimbursementTicket>();
            SqlCommand command = new SqlCommand($"Select * From Reimbursement_Tickets Where Status = @Status AND EmployeeId = @EmployeeId", conn);

            conn.Open();
            
            command.Parameters.AddWithValue("@Status", t);
            command.Parameters.AddWithValue("@EmployeeId", e.EmployeeId);

            SqlDataReader resultSet = command.ExecuteReader(); // return record/s in a different format
            
            iLog.LogStuff(tickets);
            while(resultSet.Read()) // this method goes through each row of the result set
            {
                // a mapper just re formats the result set
                ReimbursementTicket ticket = Mapper.DataBaseToTickets(resultSet);
                tickets.Add(ticket);
            }
            
            conn.Close();
            return tickets;
        }

        public Employee EditNameRequest(Employee e)
        {
            SqlCommand command = new SqlCommand($"UPDATE Employees SET FirstName = @FirstName, LastName = @LastName Where EmployeeId = @EmployeeId", conn);

            command.Parameters.AddWithValue("@FirstName", e.FirstName);
            command.Parameters.AddWithValue("@LastName", e.LastName);
            command.Parameters.AddWithValue("@EmployeeId", e.EmployeeId);
            conn.Open();
            
            conn.Close();
            return e;
        }
    }
}
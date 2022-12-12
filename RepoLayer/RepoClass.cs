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
        SqlConnection conn = new SqlConnection();
        
        public Employee SignUpRequest(Employee e)
        {
            
            SqlCommand command = new SqlCommand($"insert into Employees(Email, Password, Position, FirstName, LastName)"
            + $"SELECT * from (SELECT @Email as Email,"
            + $" @Password as Password,"
            + $" @Position as Position,"
            + $" @FirstName as FirstName,"
            + $" @LastName as LastName) as new_value"
            + $" WHERE NOT EXISTS("
            + $" SELECT Email FROM Employees WHERE"
            + $" Email = @Email);", conn);

            // open connection
            conn.Open();

            // prevent sql injection
            command.Parameters.AddWithValue("@Email", e.Email);
            command.Parameters.AddWithValue("@Password", e.Password);
            command.Parameters.AddWithValue("@Position", e.Position);
            command.Parameters.AddWithValue("@FirstName", e.FirstName);
            command.Parameters.AddWithValue("@LastName", e.LastName);
            int rowsAffected = command.ExecuteNonQuery();

            
            if(rowsAffected == 1)
            {
                iLog.LogStuff(e);
            }
            else
            {
                Console.WriteLine("Another employee already uses this email, sign up using a different email.");
                e = null!;
            }
           
            conn.Close();
            return e;
        }
        public List<Employee> LoginRequest(Employee e)
        {
            List<Employee> employees = new List<Employee>();
            SqlCommand command = new SqlCommand($"Select EmployeeId, Position, FirstName, LastName From Employees Where Email = @Email AND Password = @Password", conn);

            conn.Open();

            command.Parameters.AddWithValue("@Email", e.Email);
            command.Parameters.AddWithValue("@Password", e.Password);

            SqlDataReader resultSet = command.ExecuteReader(); // return record/s in a different format
            
            iLog.LogStuff(e);
            while(resultSet.Read()) // this method goes through each row of the result set
            {
                // a mapper just re formats the result set
                Employee employee = Mapper.DataBaseToEmployee(resultSet);
                employees.Add(employee);
            }
            
            conn.Close();
            return employees;
        }

        public ReimbursementTicket ReimbursementRequest( ReimbursementTicket ticket ,Employee e)
        {
            
            SqlCommand command = new SqlCommand($"insert into Reimbursement_Tickets (Type, Description, DollarAmount, Status, EmployeeId)"
            + "VALUES (@Type, @Description, @DollarAmount, @Status, @EmployeeId)",conn);

            conn.Open();

            command.Parameters.AddWithValue("@Type", ticket.Type);
            command.Parameters.AddWithValue("@Description", ticket.Description);
            command.Parameters.AddWithValue("@DollarAmount", ticket.DollarAmount);
            command.Parameters.AddWithValue("@Status", ticket.Status);
            command.Parameters.AddWithValue("@EmployeeId", 9); //e.EmployeeId

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
            /*if (File.Exists("SerializedPostList.json"))
            {
                string oldPlist = File.ReadAllText("SerializedPostList.json");

                List<string> PostList = JsonSerializer.Deserialize<List<string>>(oldPlist)!;
                PostList.Add(e.ReimbursementRequest());

                string serializedPostList = JsonSerializer.Serialize(PostList);
                File.WriteAllText("SerializedPostList.json", serializedPostList);

                iLog.LogStuff(e);
                return e;
            }
            else
            {
                List<string> PostList = new List<string>();
                PostList.Add(e.ReimbursementRequest());

                string serializedPostList = JsonSerializer.Serialize(PostList);

                File.WriteAllText("SerializedPostList.json", serializedPostList);

                iLog.LogStuff(e);
                return e;
            }*/
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
                    Console.WriteLine("Does the request meet the compaines rules? Type Yes or No");
                    ticket.Status = Console.ReadLine()!.ToLower().Replace(" ","");
                }while(!ticket.Status.Equals("yes") && !ticket.Status.Equals("no"));
                
                if(ticket.Status.Equals("yes"))
                {
                    ticket.Status = "Approved";
                }
                else
                {
                    ticket.Status = "Denied";
                }
                SqlCommand command = new SqlCommand($"Update Reimbursement_Tickets Set Status = @Status, Where Description = @Description", conn);
                command.Parameters.AddWithValue("@Status", ticket.Status);
                command.Parameters.AddWithValue("@Description", ticket.Description);
            }
            conn.Close();
            return "There are no more tickets to update.";
        }
    }
}
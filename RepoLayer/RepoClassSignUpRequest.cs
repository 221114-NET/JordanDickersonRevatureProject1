using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ModelsLayer;

namespace RepoLayer
{
    public class RepoClassSignUpRequest : IRepoClassSignUpRequest
    {

        private readonly IMyLogger iLog; // dependency injection

        public RepoClassSignUpRequest(IMyLogger iLog){
            this.iLog = iLog;
        }
        
        public Employee SignUpRequest(Employee e)
        {
            SqlConnection conn = new SqlConnection("");
            
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
    }
}
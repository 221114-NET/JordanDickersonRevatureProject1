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

        public Employee SignUpRequest(Employee e)
        {
            // add ADO.NET to push the data to the DB
            SqlConnection conn = new SqlConnection();
          
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
            //iLog.LogStuff(e);
            /* returns the employee object to the business layer
             then from the business layer the object goes to the apilayer*/
            //return e; 
        }
        public object LoginRequest(object o)
        {
            iLog.LogStuff(o);
            return o;
        }

        public string ReimbursementRequest(Employee e)
        {
            iLog.LogStuff(e);
            return e.Request!;
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
    }
}
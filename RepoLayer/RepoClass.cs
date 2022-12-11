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
            while(resultSet.Read()) // this method does the conversion that allows me to put the recond/s in a string 
            {
                // a mapper just re formats the result set coming back
                Employee employee = Mapper.DataBaseToEmployee(resultSet);
                employees.Add(employee);
            }
            
            conn.Close();
            return employees;
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
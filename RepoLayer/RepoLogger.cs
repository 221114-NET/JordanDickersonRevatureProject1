using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ModelsLayer;

namespace RepoLayer
{
    public class RepoLogger : IRepoClass
    {
        public object RepoLogin(string username, string password)
        {
            /*IDictionary<string, string> loginList = new Dictionary<string, string>();
            loginList.Add(username, password);
            loginList.Add("chickenFinger","password");

            string serializedLoginList = JsonSerializer.Serialize(loginList);
            File.WriteAllText("SerializedLoginList.json", serializedLoginList);
            File.ReadAllText(serializedLoginList);*/
            return "";
        }

        public Employee ReimbursementRequest(Employee e)
        {
            if (File.Exists("SerializedPostList.json"))
            {
                string oldPlist = File.ReadAllText("SerializedPostList.json");

                List<Employee> PostList = JsonSerializer.Deserialize<List<Employee>>(oldPlist)!;
                PostList.Add(e);

                string serializedPostList = JsonSerializer.Serialize(PostList);
                File.WriteAllText("SerializedPostList.json", serializedPostList);

                return e;
            }
            else
            {
                List<Employee> PostList = new List<Employee>();
                PostList.Add(e);

                string serializedPostList = JsonSerializer.Serialize(PostList);

                File.WriteAllText("SerializedPostList.json", serializedPostList);

                return e;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ModelsLayer;

namespace RepoLayer
{
    public class RepoLogger
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
            IList<Employee> PostList = new List<Employee>();
            PostList.Add(e);

            string serializedPostList = JsonSerializer.Serialize(PostList);
            File.WriteAllText("SerializedPostList.json", serializedPostList);
            File.ReadAllText(serializedPostList);

            return e;
        }
    }
}
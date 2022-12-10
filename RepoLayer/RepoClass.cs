using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
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
            iLog.LogStuff(e);
            /* returns the employee object to the business layer
             then from the business layer the object goes to the apilayer*/
            return e; 
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
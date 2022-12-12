using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;
using BusinessLayer;

namespace apilayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    
    public class RequestController : ControllerBase
    {

        List<ReimbursementTicket> tickets = new List<ReimbursementTicket>();
       private readonly IBusinessClass iBus; // dependency injection

       public RequestController(IBusinessClass iBus) // constructor for di
       { 
            this.iBus = iBus;
       }

       [HttpPost("SignUpRequest")] 
       public ActionResult<Employee> SignUpRequest(Employee e)
       {
            if(e != null)
            {
                iBus.SignUpRequest(e);
                return Created($"https://localhost:5255/api/employee/getemployee/{e.EmployeeId}", e);
            }
            else{
                return iBus.SignUpRequest(e!);
            }
       }

        [HttpGet("LogInRequest")]
        public ActionResult<List<Employee>> LoginRequest()
        {
            // returns a list of string type because we don't need the email and password of the employee

            List<Employee> employeeList = iBus.LoginRequest();

            if(employeeList.Count == 0)
            {
                Console.WriteLine("Invalid Email and Password combination.");
                //Problem("");
            }
            else
            {
                Console.WriteLine($"Welcome back {employeeList[0].FirstName} {employeeList[0].LastName}.");
                //Ok("Successfull");
            }

            return employeeList;
        }

        [HttpPost("ReimbursementRequest")]
        public ActionResult<ReimbursementTicket> ReimbursementRequest()
        {
            ReimbursementTicket request = iBus.ReimbursementRequest();
            if(request == null)
            {
                Console.WriteLine("You must be an Employee");
            }
            return request!;  
        }

        [HttpGet("ViewPendingRequest")]
        public ActionResult<List<ReimbursementTicket>> ViewPendingRequest()
        {
            tickets = iBus.ViewPendingRequest();

            UpdatePendingRequest(tickets);

            return tickets!;
        }

        [HttpPatch("UpdatePendingRequest")]
        public ActionResult<string> UpdatePendingRequest(List<ReimbursementTicket> tickets)
        {
            return iBus.UpdatePendingRequest(tickets);
        }

        [HttpGet("ViewAllTickets")]
        public ActionResult<List<ReimbursementTicket>> ViewAllTickets()
        {
            List<ReimbursementTicket> tickets = iBus.ViewAllTickets();

            if(tickets.Count == 0)
            {
                Console.WriteLine($"You don't have any tickets to view");
                //Problem("");
            }
            else if(tickets == null)
            {
                Console.WriteLine("You must be an Employee");
            }
            else
            {
                Console.WriteLine($"There's a total of {tickets.Count} tickets.");
                foreach(ReimbursementTicket ticket in tickets)
                {
                    Console.WriteLine(ticket.Request);
                }
                //Ok("Successfull");
            }
            return tickets!;
        }

        [HttpGet("FilterTickets")]
        public ActionResult<List<ReimbursementTicket>> FilterTickets()
        {
            List<ReimbursementTicket> tickets = iBus.FilterTickets();

            if(tickets.Count == 0)
            {
                Console.WriteLine($"You don't have any tickets to view");
                //Problem("");
            }
            else if(tickets == null)
            {
                Console.WriteLine("You must be an Employee");
            }
            else
            {
                Console.WriteLine($"{tickets.Count} tickets returned.");
                foreach(ReimbursementTicket ticket in tickets)
                {
                    Console.WriteLine(ticket.Request);
                }
                //Ok("Successfull");
            }
            return tickets!;
        }

        [HttpPatch("EditNameRequest")]
        public ActionResult<Employee> EditNameRequest()
        {
            Employee e = iBus.EditNameRequest();
            if(e == null)
            {
                Console.WriteLine("You must be an Employee");
            }
            else{
                Console.WriteLine($"{e.FirstName} and {e.LastName} has be updated.");
            }
            return e!;
        }

    }
}
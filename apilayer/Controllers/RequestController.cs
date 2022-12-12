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

       //BusinessClass business = new BusinessClass();
       private readonly IBusinessClass iBus; // dependency injection

       public RequestController(IBusinessClass iBus) // constructor for di
       { 
            this.iBus = iBus;
       }

       [HttpPost("SignUpRequest")] 
       public ActionResult<Employee> SignUpRequest(Employee e)
       {
            /* Employee e
            if(ModelState.IsValid)
            {
                Employee e1 = this.iBus.SignUpRequest(e);
            }
            else
            {
                return NotFound("that modelbinding did not work");
            }*/
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
        public ActionResult<ReimbursementTicket> ReimbursementRequest( Employee e)
        {
            return iBus.ReimbursementRequest(e);
        }

        [HttpGet("ViewPendingRequest")]
        public ActionResult<List<ReimbursementTicket>> ViewPendingRequest()
        {
            List<ReimbursementTicket> tickets = iBus.ViewPendingRequest();

            if(tickets.Count == 0)
            {
                Console.WriteLine($"There's a total of {tickets.Count} tickets.");
                //Problem("");
            }
            else
            {
                Console.WriteLine($"There's a total of {tickets.Count} tickets.");
                //Ok("Successfull");
            }
            return tickets;
        }

        [HttpPut("UpdatePendingRequest")]
        public ActionResult<string> UpdatePendingRequest(List<ReimbursementTicket> tickets)
        {
            return iBus.UpdatePendingRequest(tickets);
        }

        [HttpGet("ViewAllTickets")]
        public ActionResult<List<ReimbursementTicket>> ViewAllTickets(Employee e)
        {
            List<ReimbursementTicket> tickets = iBus.ViewAllTickets(e);

            if(tickets.Count == 0)
            {
                Console.WriteLine($"You don't have any tickets to view");
                //Problem("");
            }
            else
            {
                Console.WriteLine($"There's a total of {tickets.Count} tickets.");
                //Ok("Successfull");
            }
            return tickets;
        }

    }
}
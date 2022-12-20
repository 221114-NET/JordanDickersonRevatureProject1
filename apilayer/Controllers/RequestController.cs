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
       private readonly IBusinessClass iBus; // dependency injection\
       private readonly IBusinessClassSignUpRequest iBusinessClassSignUpRequest;
       private readonly IBusinessClassLogInRequest iBusinessClassLogInRequest;
       private readonly IBusinessClassReimbursementRequest iBusinessClassReimbursementRequest;
       private readonly IBussinessUpdatePendingRequest iBusinessUpdatePendingRequest;
       private readonly IBusinessClassViewPendingRequest iBusinessClassViewPendingRequest;     
       private readonly IBussinessClassViewAllMyTickets iBusinessClassViewAllMyTickets; 
       private readonly IBusinessClassFilterMyTickets iBusinessClassFilterMyTickets;
       private readonly IBusinessClassEditNameRequest iBusinessClassEditNameRequest; 
        // constructor for di
       public RequestController(IBusinessClassSignUpRequest iBusinessClassSignUpRequest,
            IBusinessClassLogInRequest iBusinessClassLogInRequest, IBusinessClassReimbursementRequest iBusinessClassReimbursementRequest,
            IBussinessUpdatePendingRequest iBusinessUpdatePendingRequest, IBusinessClassViewPendingRequest iBusinessClassViewPendingRequest
            ,IBussinessClassViewAllMyTickets iBusinessClassViewAllMyTickets, IBusinessClassFilterMyTickets iBusinessClassFilterMyTickets
            ,IBusinessClassEditNameRequest iBusinessClassEditNameRequest
            ,IBusinessClass iBus) 
       {
            this.iBusinessClassSignUpRequest = iBusinessClassSignUpRequest;
            this.iBusinessClassLogInRequest = iBusinessClassLogInRequest;
            this.iBusinessClassReimbursementRequest = iBusinessClassReimbursementRequest; 
            this.iBusinessUpdatePendingRequest = iBusinessUpdatePendingRequest;
            this.iBusinessClassViewPendingRequest = iBusinessClassViewPendingRequest;
            this.iBusinessClassViewAllMyTickets = iBusinessClassViewAllMyTickets;
            this.iBusinessClassFilterMyTickets = iBusinessClassFilterMyTickets;
            this.iBusinessClassEditNameRequest = iBusinessClassEditNameRequest;
            this.iBus = iBus;
       }



       [HttpPost("SignUpRequest")]
       public ActionResult<Employee> SignUpRequest(Employee e)
       {
            iBusinessClassSignUpRequest.SignUpRequest(e);
            return Created($"https://localhost:5255/api/employee/getemployee/{e.EmployeeId}", e);    
       }



        [HttpGet("LogInRequest")]
        public ActionResult<Employee> LogInRequest()
        {
            string userEmail = "jjj@yahoo.com";
            string userPassword = "jjj";
            return iBusinessClassLogInRequest.LogInRequest(userEmail, userPassword);

            /*if(employeeList.Count == 0)
            {
                Console.WriteLine("Invalid Email and Password combination.");
                //Problem("");
            }
            else
            {
                Console.WriteLine($"Welcome back.");
                //Ok("Successfull");
            }

            return employeeList;*/
        }



        [HttpPost("ReimbursementRequest")]
        public ActionResult<ReimbursementTicket> ReimbursementRequest(ReimbursementTicket ticket)
        {
            int employeeId = 11;
            return iBusinessClassReimbursementRequest.ReimbursementRequest(ticket, employeeId); 
        }


        [HttpPatch("UpdatePendingRequest")]
        public ActionResult<string> UpdatePendingRequest(List<ReimbursementTicket> tickets)
        {
            return iBus.UpdatePendingRequest(tickets);
        }



        [HttpGet("ViewPendingRequest")]
        public ActionResult<List<ReimbursementTicket>> ViewPendingRequest()
        {
            tickets = iBus.ViewPendingRequest();

            UpdatePendingRequest(tickets);

            return tickets!;
        }

        

        [HttpGet("ViewAllMyTickets")]
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




        [HttpGet("FilterMyTickets")]
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
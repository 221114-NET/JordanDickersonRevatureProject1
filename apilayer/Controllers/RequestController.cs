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
            ,IBusinessClassEditNameRequest iBusinessClassEditNameRequest) 
       {
            this.iBusinessClassSignUpRequest = iBusinessClassSignUpRequest;
            this.iBusinessClassLogInRequest = iBusinessClassLogInRequest;
            this.iBusinessClassReimbursementRequest = iBusinessClassReimbursementRequest; 
            this.iBusinessUpdatePendingRequest = iBusinessUpdatePendingRequest;
            this.iBusinessClassViewPendingRequest = iBusinessClassViewPendingRequest;
            this.iBusinessClassViewAllMyTickets = iBusinessClassViewAllMyTickets;
            this.iBusinessClassFilterMyTickets = iBusinessClassFilterMyTickets;
            this.iBusinessClassEditNameRequest = iBusinessClassEditNameRequest;
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
            string userEmail = "jordan@gmail.com";
            string userPassword = "password";
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
            int employeeId = 15;
            return iBusinessClassReimbursementRequest.ReimbursementRequest(ticket, employeeId); 
        }


        [HttpPatch("UpdatePendingRequest")]
        public ActionResult<string> UpdatePendingRequest(DTOUpdatePendingRequest dtoUpdatePendingRequest)
        {
            string status = dtoUpdatePendingRequest.Status!;
            int ticketId = dtoUpdatePendingRequest.TicketId!;
            //int ticketId = 1;
            return iBusinessUpdatePendingRequest.UpdatePendingRequest(status, ticketId);
        }



        [HttpGet("ViewPendingRequest")]
        public ActionResult<List<ReimbursementTicket>> ViewPendingRequest()
        {
            return iBusinessClassViewPendingRequest.ViewPendingRequest();
        }

        

        [HttpGet("ViewAllMyTickets")]
        public ActionResult<List<ReimbursementTicket>> ViewAllTickets()
        {
            /*List<ReimbursementTicket> tickets = iBus.ViewAllTickets();

            if(tickets.Count == 0)
            {
                Console.WriteLine($"You don't have any tickets to view");
                //Problem("");
            }
            else
            {
                Console.WriteLine($"There's a total of {tickets.Count} tickets.");
                foreach(ReimbursementTicket ticket in tickets)
                {
                    Console.WriteLine(ticket.Request);
                }
                //Ok("Successfull");
            }*/
            string email = "jd@yahoo.com";
            return iBusinessClassViewAllMyTickets.ViewAllMyTickets(email);
        }




        [HttpGet("FilterMyTickets")]
        public ActionResult<List<ReimbursementTicket>> FilterTickets()
        {
            /*List<ReimbursementTicket> tickets = iBus.FilterTickets();

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
            }*/
            string email = "jd@yahoo.com";
            string status = "Approved";
            return iBusinessClassFilterMyTickets.FilterMyTickets(email,status);
        }



        [HttpPatch("EditNameRequest")]
        public ActionResult<string> EditNameRequest(DTOEditNameRequest dTOEditNameRequest)
        {
            /*Employee e = iBus.EditNameRequest();
            if(e == null)
            {
                Console.WriteLine("You must be an Employee");
            }
            else{
                Console.WriteLine($"{e.FirstName} and {e.LastName} has be updated.");
            }*/
            string email = "jd@yahoo.com";
            string firstName = dTOEditNameRequest.FirstName!;
            string lastName = dTOEditNameRequest.LastName!;
            return iBusinessClassEditNameRequest.EditNameRequest(email,firstName, lastName);
        }

    }
}
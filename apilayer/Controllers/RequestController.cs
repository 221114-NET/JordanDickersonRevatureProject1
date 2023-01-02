using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;
using BusinessLayer;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace apilayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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


       [EnableCors("FormPolicy")]
       [HttpPost("SignUpRequest")]
       public ActionResult<Employee> SignUpRequest(Employee e)
       {
            iBusinessClassSignUpRequest.SignUpRequest(e);
            return Created($"https://localhost:5255/api/employee/getemployee/{e.EmployeeId}", e);    
       }


        [EnableCors("FormPolicy")]
        [HttpPost("LogInRequest")]
        public ActionResult<DTOToken> LogInRequest(DTOLogInRequest dTOLogInRequest)
        {
            return new DTOToken(iBusinessClassLogInRequest.LogInRequest(dTOLogInRequest.Email!, dTOLogInRequest.Password!));
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Employee")]
        [HttpPost("ReimbursementRequest")]
        public ActionResult<ReimbursementTicket> ReimbursementRequest(ReimbursementTicket ticket)
        {
            string claimSid = ($"{this.User.FindFirst(ClaimTypes.Sid)!.Value}");
            int employeeId = Int32.Parse(claimSid);
            return iBusinessClassReimbursementRequest.ReimbursementRequest(ticket, employeeId); 
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Finance Manager")]
        [HttpPatch("UpdatePendingRequest")]
        public ActionResult<string> UpdatePendingRequest(DTOUpdatePendingRequest dtoUpdatePendingRequest)
        {
            string status = dtoUpdatePendingRequest.Status!;
            int ticketId = dtoUpdatePendingRequest.TicketId!;
            //int ticketId = 1;
            return iBusinessUpdatePendingRequest.UpdatePendingRequest(status, ticketId);
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Finance Manager")]
        [HttpGet("ViewPendingRequest")]
        public ActionResult<List<ReimbursementTicket>> ViewPendingRequest()
        {
            return iBusinessClassViewPendingRequest.ViewPendingRequest();
        }

        
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Employee")]
        [HttpGet("ViewAllMyTickets")]
        public ActionResult<List<ReimbursementTicket>> ViewAllTickets()
        {
            string email = ($"{this.User.FindFirst(ClaimTypes.Email)!.Value}");
            return iBusinessClassViewAllMyTickets.ViewAllMyTickets(email);
        }



        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Employee")]
        [HttpGet("FilterMyTickets")]
        public ActionResult<List<ReimbursementTicket>> FilterTickets()
        {
            string email = ($"{this.User.FindFirst(ClaimTypes.Email)!.Value}");
            string status = "Approved";
            return iBusinessClassFilterMyTickets.FilterMyTickets(email,status);
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPatch("EditNameRequest")]
        public ActionResult<string> EditNameRequest(DTOEditNameRequest dTOEditNameRequest)
        {
            string email = ($"{this.User.FindFirst(ClaimTypes.Email)!.Value}");
            string firstName = dTOEditNameRequest.FirstName!;
            string lastName = dTOEditNameRequest.LastName!;
            return iBusinessClassEditNameRequest.EditNameRequest(email,firstName, lastName);
        }

    }
}
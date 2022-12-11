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

       [HttpPost("sign-up-request")] 
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

            return iBus.SignUpRequest(e);
            //return Created($"https://localhost:5255/api/employee/getemployee/{e.EmployeeId}", e);
       }

       /* [HttpPost("sign-up-request")]  // employees sign up using this action method
        public object SignUpRequest()
        {
            return iBus.SignUpRequest();
        }*/

        [HttpGet("log-in-request")]
        public object LoginRequest()
        {
            return iBus.LoginRequest();
        }

        [HttpPost("reimbursement-request")]
        public string ReimbursementRequest()
        {
            return iBus.ReimbursementRequest();
        }

        [HttpGet("view-pending-request")]
        public string ViewPendingRequest()
        {
            return "view request";
        }

        /*[HttpGet]
        public string ViewUpdatedStatus(Employee e)
        {
            return "viewstatus";
        }*/

    }
}
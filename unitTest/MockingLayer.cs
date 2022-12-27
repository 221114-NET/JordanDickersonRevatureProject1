using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepoLayer;
using ModelsLayer;
using System.Text.RegularExpressions;

namespace unitTest
{
    public class MockingLayer 
    {
        List<Employee> employees = new List<Employee>();
        List<ReimbursementTicket> tickets = new List<ReimbursementTicket>();

        public Employee SignUpRequest(Employee e)
        {
            foreach( Employee employee in employees)
            {
                if(employee.Email!.Equals(e.Email))
                {
                    Console.WriteLine("Sorry Email already exist, try signing up using another email");
                    e = null!;
                }
                else
                {
                    employees.Add(e);
                    Console.WriteLine($"{e.FirstName} {e.LastName} has successfully signed up");
                }
            }
            return e;
        }


        public List <Employee> LoginRequest(Employee e)
        {    
            foreach( Employee employee in employees)
            {
                if(employee.Email!.Equals(e.Email) && employee.Password!.Equals(e.Password))
                {
                    Console.WriteLine($"Welcome {e.FirstName} {e.LastName}");
                }
                else
                {
                    Console.WriteLine($"Invalid Email and Password combination.");
                }
            }
            return employees;
        }


        public ReimbursementTicket ReimbursementRequest(ReimbursementTicket ticket, Employee e)
        {
            do{
            Console.WriteLine("What type of reimbursement ticket are you submitting?");
            Console.WriteLine("Pick from the following types (Travel, Food or Rental)?");
            ticket.Type = Console.ReadLine()!.ToUpper().Replace(" ","");
            }while(!ticket.Type.Equals("TRAVEL") && !ticket.Type.Equals("FOOD") && !ticket.Type.Equals("RENTAL"));
            
            Regex hasLetter = new Regex("^\\d+$");

            // continue looping until Amount only contains numbers
            do{
                Console.WriteLine("How much should you be reimbursed for? (digits only)");
                ticket.DollarAmount = Console.ReadLine()!.Replace(" ","");
            }while(!hasLetter.IsMatch(ticket.DollarAmount)); // returns true when DollarAmount only contains numbers
            

            Console.WriteLine("Explain why you should be reimbursed?");
            ticket.Description = Console.ReadLine()!;

            ticket.Status = "Pending";

            ticket.Request = $"Ticket Type: {ticket.Type} \nAmount: {ticket.DollarAmount} \nDescription: {ticket.Description} \nStatus: {ticket.Status}";
            tickets.Add(ticket);
            return ticket;
        }


        public List<ReimbursementTicket> ViewPendingRequest()
        {
            foreach( ReimbursementTicket ticket in tickets)
            {
                if(ticket.Status!.Equals("Pending"))
                    Console.WriteLine(ticket.Request);
            }
            return tickets;
        }


        public string UpdatePendingRequest(List<ReimbursementTicket> tickets)
        {
           foreach( ReimbursementTicket ticket in tickets)
            {
                if(ticket.Status!.Equals("Pending"))
                    Console.WriteLine("Does the request meet the compaines rules?");
                    ticket.Status = Console.ReadLine()!;
            }
            return "All the pending request are updated!";
        }


        public List<ReimbursementTicket> ViewAllTickets(Employee e)
        {
            Console.WriteLine($"There's a total of {tickets.Count} tickets");
            foreach( ReimbursementTicket ticket in tickets)
            {
                Console.WriteLine(ticket.Request);
            }
            return tickets;
        }

        public List<ReimbursementTicket> FilterTickets( string t ,Employee e)
        {
            do{
                Console.WriteLine("How do you want to filter your reimbursement ticket/s?");
                Console.WriteLine("Enter (1)Pending, (2)Approved, or (3)Rejected");
                t = Console.ReadLine()!;
            }while(!t!.Equals("1") && !t.Equals("2") && !t.Equals("3"));

            foreach( ReimbursementTicket ticket in tickets)
            {
                if(ticket.Status!.Equals(t))
                Console.WriteLine(ticket.Request);
            }
            return tickets;
        }


        public Employee EditNameRequest(Employee e)
        {
            Console.WriteLine("Enter your email");
            e.Email = Console.ReadLine()!.Replace(" ","");

            Console.WriteLine("Enter your password");
            e.Password = Console.ReadLine()!.Replace(" ","");

            foreach( Employee employee in employees)
            {
                if(employee.Email!.Equals(e.Email) && employee.Password!.Equals(e.Password))
                {
                    Console.WriteLine("Change your first name");
                    e.FirstName = Console.ReadLine()!.Replace(" ","");

                    Console.WriteLine("Change your last name");
                    e.LastName = Console.ReadLine()!.Replace(" ","");
                    Console.WriteLine($"First name changed to {e.FirstName} and last name changed to {e.LastName}");
                }
                else
                {
                    Console.WriteLine($"Invalid Email and Password combination.");
                }
            }
            return e;
        }
    }
}
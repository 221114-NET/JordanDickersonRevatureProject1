namespace BusinessLayer;

using System;
using ModelsLayer;
using RepoLayer;
public class BusinessClass : IBusinessClass
{
    private readonly IRepoClass iRepo;

    public BusinessClass(IRepoClass iRepo){ // constructor for di
        this.iRepo = iRepo;
    }
    
    public List<Employee> LoginRequest()
    {
        Employee e = new Employee();

         Console.WriteLine("What is your email?");
        e.Email = Console.ReadLine()!;

        Console.WriteLine("Create a password.");
        e.Password = Console.ReadLine()!;

        return iRepo.LoginRequest(e);
    }




    public ReimbursementTicket ReimbursementRequest()
    {
        //Employee e = new Employee(1, "Finance Manager","","");
        Employee e = new Employee(11,"Employee","4","life");
        if(e.Position!.Equals("Employee"))
        {
            ReimbursementTicket ticket = new ReimbursementTicket();
            ticket.ReimbursementRequest();
            return iRepo.ReimbursementRequest(ticket, e);
        }
        else
        {
            ReimbursementTicket invalid = null!;
            return invalid;
        }  
    }



    public List<ReimbursementTicket> ViewPendingRequest()
    {
        Employee e = new Employee(1, "Finance Manager");
        //Employee e = new Employee(9,"Employee","a","aa");

        if(e.Position!.Equals("Finance Manager"))
            return iRepo.ViewPendingRequest();
        else
        {
            Console.WriteLine("You must be a Finance Manager to view all pending request");
            List<ReimbursementTicket> list = new List<ReimbursementTicket>();
            return list;
        }     
    }



    public string UpdatePendingRequest(List<ReimbursementTicket> tickets)
    {
        Employee e = new Employee(1, "Finance Manager");
       // Employee e = new Employee(9,"Employee");

        if(e.Position!.Equals("Finance Manager"))
        {
            return iRepo.UpdatePendingRequest(tickets);
        }
        else
        {
            Console.WriteLine("You must be a Finance Manager");
           return "You must be a Finance Manager";
        }
        
    }



    public List<ReimbursementTicket> ViewAllTickets()
    {
        //Employee e = new Employee(1, "Finance Manager","","");
        Employee e = new Employee(9,"Employee","a","aa");
        if(e.Position!.Equals("Employee"))
        {
            return iRepo.ViewAllTickets(e);
        }
        else
        {
            Console.WriteLine("You must be an employee to view this request");
            List<ReimbursementTicket> invaild = new List<ReimbursementTicket>();
            return invaild;
        }
    }



    public List<ReimbursementTicket> FilterTickets()
    {
        ReimbursementTicket t1 = new ReimbursementTicket();
        string t = t1.Status!;

        //Employee e = new Employee(1, "Finance Manager","","");
        Employee e = new Employee(9,"Employee","a","aa");

        if(e.Position!.Equals("Employee"))
        {
            do{
                Console.WriteLine("How do you want to filter your reimbursement ticket/s?");
                Console.WriteLine("Enter (1)Pending, (2)Approved, or (3)Rejected");
                t = Console.ReadLine()!;
            }while(!t!.Equals("1") && !t.Equals("2") && !t.Equals("3"));

            if(t.Equals("1"))
            {
                t = "Pending";
            }
            else if(t.Equals("2"))
            {
                t = "Approved";
            }
            else if(t.Equals("3"))
            {
                t = "Rejected";
            }
        
            return iRepo.FilterTickets(t,e);
        }
        else
        {
            List<ReimbursementTicket> invaild = null!;
            return invaild;
        }
    }



    public Employee EditNameRequest()
    {
        //Employee e = new Employee(1, "Finance Manager","","");
        Employee e = new Employee(9,"Employee");

        if(e.Position!.Equals("Employee")){
    
            Console.WriteLine("Update your first name");
            e.FirstName = Console.ReadLine()!;

            Console.WriteLine("Update your last name");
            e.LastName = Console.ReadLine()!;

            return iRepo.EditNameRequest(e);
        }
        else
        {
            e = null!;
            return e;
        }
        
    }
}   

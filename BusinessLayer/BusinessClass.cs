namespace BusinessLayer;

using System;
using ModelsLayer;
using RepoLayer;
public class BusinessClass : IBusinessClass
{
    // dependency injection used with Ilogin interface
    //private readonly Ilogin? loginInjection;
    //RepoLogger repo = new RepoLogger();
    private readonly IRepoClass iRepo; // dependency injection

    public BusinessClass(IRepoClass iRepo){ // constructor for di
        this.iRepo = iRepo;
    }

    public Employee SignUpRequest(Employee e) // client enters the email and password to sign up
    {
        //Employee e = new Employee();
        Console.WriteLine("What is your email?");
        e.Email = Console.ReadLine()!;

        Console.WriteLine("Create a password.");
        e.Password = Console.ReadLine()!;

        Console.WriteLine("Enter your first name.");
        e.FirstName = Console.ReadLine()!;

        Console.WriteLine("Enter your last name.");
        e.LastName = Console.ReadLine()!;

        return iRepo.SignUpRequest(e);
    }
    
    public List<Employee> LoginRequest()
    {
        Object o = new Object(); // creating a reference of the object class to reference one of my objects;
        
        // while positions does not equal Employee or Manager keep the client in a loop
        /*string position;
        do{
            Console.WriteLine("Are you an Employee or Manager? Enter Employee or Manager");
            position = Console.ReadLine()!.ToUpper().Replace(" ","");
        }while(!position.Equals("EMPLOYEE") && !position.Equals("MANAGER"));*/


        //if(position.Equals("EMPLOYEE"))
        //{
            Employee e = new Employee();

            Console.WriteLine("What is your email?");
            e.Email = Console.ReadLine()!;

            Console.WriteLine("Create a password.");
            e.Password = Console.ReadLine()!;

            //o = e;
            
        //}
        /*else if(position.Equals("MANAGER"))
        {
            FinanceManager f = new FinanceManager();

            Console.WriteLine("What is your email?");
            f.Email = Console.ReadLine()!;

            Console.WriteLine("Create a password.");
            f.Password = Console.ReadLine()!;

            o = f;
        }*/

        return iRepo.LoginRequest(e);
    }

    public ReimbursementTicket ReimbursementRequest(Employee e)
    {
        ReimbursementTicket ticket = new ReimbursementTicket();
        ticket.ReimbursementRequest();
        return iRepo.ReimbursementRequest(ticket, e);
    }

    public List<ReimbursementTicket> ViewPendingRequest()
    {
        return iRepo.ViewPendingRequest();
    }

    public string UpdatePendingRequest(List<ReimbursementTicket> tickets)
    {
        return iRepo.UpdatePendingRequest(tickets);
    }
}   

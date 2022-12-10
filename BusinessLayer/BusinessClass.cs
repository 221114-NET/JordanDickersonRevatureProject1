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

    public object SignUpRequest() // client enters the email and password to sign up
    {
        Employee e = new Employee();
        Console.WriteLine("What is your email?");
        e.email = Console.ReadLine()!;

        Console.WriteLine("Create a password.");
        e.password = Console.ReadLine()!;

        return iRepo.SignUpRequest(e);
    }
    
    public object LoginRequest()
    {
        Object o = new Object(); // creating a reference of the object class to reference one of my objects;
        
        // while positions does not equal Employee or Manager keep the client in a loop
        string position;
        do{
            Console.WriteLine("Are you an Employee or Manager? Enter Employee or Manager");
            position = Console.ReadLine()!.ToUpper().Replace(" ","");
        }while(!position.Equals("EMPLOYEE") && !position.Equals("MANAGER"));


        if(position.Equals("EMPLOYEE"))
        {
            Employee e = new Employee();

            Console.WriteLine("What is your email?");
            e.email = Console.ReadLine()!;

            Console.WriteLine("Create a password.");
            e.password = Console.ReadLine()!;

            o = e;
            
        }
        else if(position.Equals("MANAGER"))
        {
            FinanceManager f = new FinanceManager();

            Console.WriteLine("What is your email?");
            f.email = Console.ReadLine()!;

            Console.WriteLine("Create a password.");
            f.password = Console.ReadLine()!;

            o = f;
        }

        return iRepo.LoginRequest(o);
    }

    public Employee ReimbursementRequest()
    {
        Employee e = new Employee();
        return iRepo.ReimbursementRequest(e);

    }
}   

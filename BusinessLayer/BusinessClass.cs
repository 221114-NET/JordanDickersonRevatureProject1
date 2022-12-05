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
    
    public object BusinessLoginRequest()
    {
        //object something = loginInjection?.login(username,password);

        //Employee employee1 = new Employee("jdog","chickengood");
        //object eLoggerLogin = repo.RepoLogin(employee1.username, employee1.password);


        //RepoClass repo = new RepoClass();
        //repo.RepoLogin(something);
        return "";
    }

    public Employee ReimbursementRequest()
    {
        Employee e = new Employee("jdog","password");
        return iRepo.ReimbursementRequest(e);
    }
}   

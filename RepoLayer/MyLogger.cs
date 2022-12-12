using ModelsLayer;
namespace RepoLayer;

public interface IMyLogger
{
    void LogStuff(object o);
}

public class MyLogger : IMyLogger
{
    public void LogStuff(object o)
    {
        Console.WriteLine($"{o} just happened!");
    }

    public void LogStuff(List<ReimbursementTicket> tickets)
    {
        Console.WriteLine($"{tickets} just happened!");
    }
}

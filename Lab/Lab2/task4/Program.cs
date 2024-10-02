namespace Name
{
    class Program
    {
        public static void Main(){
            SingletonService singletonService = new();

            Client client = new(singletonService);

            client.Execute();
        }
    }
    public class SingletonService{
    public void DoSomething()
    {
        Console.WriteLine("Doing something...");
    }
}

public class Client{
    private readonly SingletonService _singletonService;

    public Client(SingletonService singletonService)
    {
        _singletonService = singletonService;
    }

    public void Execute(){
        _singletonService.DoSomething();
    }
}


}
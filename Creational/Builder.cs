public class Computer
{
    private string myRam;
    private string myGraphicsCard;
    private string myProcessor;

    public void SetRam(string ram)
    {
        myRam = ram;
    }

    public void SetGraphicsCard(string graphicsCard)
    {
        myGraphicsCard = graphicsCard;
    }

    public void SetProcessor(string processor)
    {
        myProcessor = processor;
    }

    public void DisplayConfiguration()
    {
        Console.WriteLine($"Ram : {myRam}, Graphics Card : {myGraphicsCard}, Processor : {myProcessor}");
    }
}

public interface IBuilder
{
    void BuildRam();
    void BuildGraphicsCard();
    void BuildProcessor();
    Computer GetComputer();
}

public class GamingPCBuilder : IBuilder
{
    private Computer myComputer;

    public GamingPCBuilder() 
    {
        myComputer = new Computer();
    }
    public void BuildGraphicsCard()
    {
        myComputer.SetGraphicsCard("NVDIA 4GB");
    }

    public void BuildProcessor()
    {
        myComputer.SetProcessor("Intel Core i7 15th Gen");
    }

    public void BuildRam()
    {
        myComputer.SetRam("16GB");
    }

    public Computer GetComputer()
    {
        return myComputer;
    }
}

public class NonGamingPCBuilder: IBuilder
{
    private Computer myComputer;

    public void BuildGraphicsCard()
    {
        myComputer.SetGraphicsCard("Intel Graphics");
    }

    public void BuildProcessor()
    {
        myComputer.SetProcessor("Intel Core i5 15th Gen");
    }

    public void BuildRam()
    {
        myComputer.SetRam("8GB");
    }

    public Computer GetComputer()
    {
        return myComputer;
    }
}

public class ComputerDirector
{
    public void Construct(IBuilder builder)
    {
        builder.BuildRam();
        builder.BuildGraphicsCard();
        builder.BuildProcessor();
    }
}

public class ComputerClient
{
    public void ConstructComputer()
    {
        GamingPCBuilder gamingPCBuilder = new GamingPCBuilder();
        ComputerDirector computerDirector = new ComputerDirector();
        computerDirector.Construct(gamingPCBuilder);

        var computer = gamingPCBuilder.GetComputer();
        computer.DisplayConfiguration();

        NonGamingPCBuilder nonGamingPCBuilder = new NonGamingPCBuilder();
        computerDirector = new ComputerDirector();
        computerDirector.Construct(nonGamingPCBuilder);

        computer = nonGamingPCBuilder.GetComputer();
        computer.DisplayConfiguration();
    }
}
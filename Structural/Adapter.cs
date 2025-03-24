public interface IPrinter
{
    void Print();
}

public class LegacyPrinter
{
    public void Print()
    {
        Console.WriteLine("Legacy Printer");
    }
}

public class PrinterAdapter : IPrinter
{
    private LegacyPrinter myLegacyPrinter;

    public PrinterAdapter()
    {
        myLegacyPrinter = new LegacyPrinter();
    }
    public void Print()
    {
        myLegacyPrinter.Print();
    }
}

internal class AdapterPattern
{
    public void Main()
    {
        PrinterAdapter myPrinter = new PrinterAdapter();
        myPrinter.Print();
    }
}
public interface ICoffee
{
    double GetPrice();
    string GetDescription();
}

public class PlainCoffee : ICoffee
{
    public double GetPrice()
    {
        return 10.0;
    }

    public string GetDescription()
    {
        return "Coffee";
    }
}

public abstract class CoffeeDecorator : ICoffee
{
    private readonly ICoffee myCoffeeDecorator;

    public CoffeeDecorator(ICoffee coffeeDecorator)
    {
        myCoffeeDecorator = coffeeDecorator;
    }

    public virtual string GetDescription()
    {
        return myCoffeeDecorator.GetDescription();
    }

    public virtual double GetPrice()
    {
        return myCoffeeDecorator.GetPrice();
    }
}

public class MilkDecorator : CoffeeDecorator
{
    private readonly ICoffee milkDecorator;

    public MilkDecorator(ICoffee coffeeDecorator) : base(coffeeDecorator)
    {
        milkDecorator = coffeeDecorator;
    }

    public override string GetDescription()
    {
        return "Milk " + milkDecorator.GetDescription();
    }

    public override double GetPrice()
    {
        return milkDecorator.GetPrice() + 10.0;
    }
}

public class SugarDecorator : CoffeeDecorator
{
    private readonly ICoffee sugarDecorator;

    public SugarDecorator(ICoffee coffeeDecorator) : base(coffeeDecorator)
    {
        sugarDecorator = coffeeDecorator;
    }
    public override string GetDescription()
    {
        return "Sugar " + sugarDecorator.GetDescription();
    }

    public override double GetPrice()
    {
        return sugarDecorator.GetPrice() + 10.0;
    }
}

internal class DecoratorClient
{
    public void Client()
    {
        var plainCoffee = new PlainCoffee();
        Console.WriteLine($"{plainCoffee.GetPrice()} {plainCoffee.GetDescription()}");

        var milkCoffee = new MilkDecorator(new PlainCoffee()); 
        Console.WriteLine($"{milkCoffee.GetPrice()} {milkCoffee.GetDescription()}");

        var sugarCoffee = new SugarDecorator(new MilkDecorator(new PlainCoffee()));
        Console.WriteLine($"{sugarCoffee.GetPrice()} {sugarCoffee.GetDescription()}");
    }
}
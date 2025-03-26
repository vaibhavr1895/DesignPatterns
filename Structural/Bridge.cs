public abstract class AbstractVehicle
{
    protected IWorkshop myWorkshop1;
    protected IWorkshop myWorkshop2;
    protected AbstractVehicle(IWorkshop myWorkshop1, IWorkshop myWorkshop2)
    {
        this.myWorkshop1 = myWorkshop1;
        this.myWorkshop2 = myWorkshop2;
    }
 
    public abstract void Manufacture();
}

public class Car : AbstractVehicle
{
    public Car(IWorkshop workshop1, IWorkshop workshop2): base(workshop1, workshop2)
    {

    }
    public override void Manufacture()
    {
        myWorkshop1.Work();
        myWorkshop2.Work();
    }
}

public class Bus : AbstractVehicle
{
    public Bus(IWorkshop workshop1, IWorkshop workshop2) : base(workshop1, workshop2)
    {

    }

    public override void Manufacture()
    {
        myWorkshop1.Work();
        myWorkshop2.Work();
    }
}

public interface IWorkshop
{
    void Work();
}

public class Produce : IWorkshop
{
    public void Work()
    {
        Console.WriteLine("Produce Workshop");
    }
}

public class Assemble : IWorkshop
{
    public void Work()
    {
        Console.WriteLine("Assembly Workshop");
    }
}

internal class BridgePattern
{
    public void Main()
    {
        var car = new Car(new Produce(), new Assemble());
        var bus = new Bus(new Produce(), new Assemble());

        car.Manufacture();
        bus.Manufacture();
    }
}
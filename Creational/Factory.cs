public abstract class Vehicle
{
    public abstract void PrintVehicle();
}

public class TwoWheeler : Vehicle
{
    public override void PrintVehicle()
    {
        Console.WriteLine("TwoWheeler");
    }
}

public class FourWheeler : Vehicle
{
    public override void PrintVehicle()
    {
        Console.WriteLine("FourWheeler");
    }
}

public interface IVehicleFactory
{
    Vehicle CreateVehicle();
}

public class TwoWheelerFactory : IVehicleFactory
{
    public Vehicle CreateVehicle()
    {
        return new TwoWheeler();
    }
}

public class FourWheelerFactory : IVehicleFactory
{
    public Vehicle CreateVehicle()
    {
        return new FourWheeler();
    }
}

public class VehicleClient
{
    private Vehicle myVehicle;

    public VehicleClient(IVehicleFactory factory)
    {
        myVehicle = factory.CreateVehicle();
    }

    public Vehicle GetVehicle() 
    { 
        return myVehicle;
    }
}

public class FactoryPattern
{
    public void Main()
    {
        IVehicleFactory vehicleFactory = new TwoWheelerFactory();
        var vehicleClient = new VehicleClient(vehicleFactory);
        var vehicle = vehicleClient.GetVehicle();
        vehicle.PrintVehicle();

        vehicleFactory = new FourWheelerFactory();
        vehicleClient = new VehicleClient(vehicleFactory);
        vehicle = vehicleClient.GetVehicle();
        vehicle.PrintVehicle();
    }
}
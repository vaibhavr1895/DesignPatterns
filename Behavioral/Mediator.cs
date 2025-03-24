public interface IAirplane
{
    void RequestTakeoff();
    void RequestLanding();
    void NotifyAirTrafficControl(string message);
}

public class Airplane : IAirplane
{
    private AirTrafficControl myAirTrafficControl;

    public Airplane(AirTrafficControl airTrafficControl)
    {
        myAirTrafficControl = airTrafficControl;
    }

    public void NotifyAirTrafficControl(string message)
    {
        Console.WriteLine(message);
    }

    public void RequestLanding()
    {
        myAirTrafficControl.RequestLanding(this);
    }

    public void RequestTakeoff()
    {
        myAirTrafficControl.RequestTakeoff(this);
    }
}

public interface IAirTrafficControl
{
    void RequestLanding(IAirplane airplane);
    void RequestTakeoff(IAirplane airplane);
}

public class AirTrafficControl : IAirTrafficControl
{
    public void RequestLanding(IAirplane airplane)
    {
        airplane.NotifyAirTrafficControl("Request Landing");
    }

    public void RequestTakeoff(IAirplane airplane)
    {
        airplane.NotifyAirTrafficControl("Request Takeoff");
    }
}

internal class MediatorPattern
{
    public void Main()
    {
        AirTrafficControl airTrafficControl = new AirTrafficControl();

        IAirplane airplane1 = new Airplane(airTrafficControl);
        IAirplane airplane2 = new Airplane(airTrafficControl);

        airplane1.RequestTakeoff();
        airplane2.RequestLanding();
        
    }
}
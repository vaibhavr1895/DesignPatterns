public interface ISubject
{
    void AddListener(IObserver observer);
    void RemoveListener(IObserver observer);
    void NotifyListeners();
}

public interface IObserver
{
    void Update(string message);
}

public class WeatherStation : ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    private string myWeather;
    public void AddListener(IObserver observer)
    {
        observers.Add(observer);
    }

    public void NotifyListeners()
    {
        foreach (IObserver observer in observers)
        {
            observer.Update(myWeather);
        }
    }

    public void RemoveListener(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void SetWeather(string weather)
    {
        myWeather = weather;
        NotifyListeners();
    }
}

public class SmartPhoneObserver : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"Weather on my Smart Phone : {message}");
    }
}

public class TabletOberver: IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"Weather on my Tablet : {message}");
    }
}

internal class ObserverPattern
{
    public void Main()
    {
        var weatherStation = new WeatherStation();
       
        var phone = new SmartPhoneObserver();
        var tablet = new TabletOberver();

        weatherStation.AddListener(phone);
        weatherStation.AddListener(tablet);

        weatherStation.SetWeather("Sunny");
    }
}
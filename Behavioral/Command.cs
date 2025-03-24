public interface ICommand
{
    void Execute();
}

public interface IDevice
{
    void TurnOn();
    void TurnOff();
}

public class TurnOnCommand: ICommand
{
    private IDevice myDevice;
    public TurnOnCommand(IDevice device)
    {
        myDevice = device;
    }

    public void Execute()
    {
        myDevice.TurnOn();
    }
}

public class TurnOffCommand : ICommand
{
    private IDevice myDevice;
    public TurnOffCommand(IDevice device)
    {
        myDevice = device;
    }

    public void Execute()
    {
        myDevice.TurnOff();
    }
}

public class TV : IDevice
{
    public void TurnOff()
    {
        Console.WriteLine("TurnOff TV");
    }

    public void TurnOn()
    {
        Console.WriteLine("TurnOn TV");
    }
}

public class AC : IDevice
{
    public void TurnOff()
    {
        Console.WriteLine("TurnOff AC");
    }

    public void TurnOn()
    {
        Console.WriteLine("TurnOn AC");
    }
}

public class Remote
{
    private ICommand myCommand;

    public void SetCommand(ICommand command)
    {
        myCommand = command;
    }

    public void PressButton()
    {
        myCommand.Execute();
    }
}

internal class CommandPattern
{

    public void Main()
    {
        IDevice tv = new TV();
        IDevice ac = new AC();


        ICommand tvTurnOnCommand = new TurnOnCommand(tv);
        ICommand tvTurnOffCommand = new TurnOffCommand(tv);
        
        ICommand acTurnOnCommand = new TurnOnCommand(ac);
        ICommand acTurnOffCommand = new TurnOffCommand(ac);

        Remote remote = new Remote();

        remote.SetCommand(tvTurnOnCommand);
        remote.PressButton();
        
        remote.SetCommand(tvTurnOffCommand);
        remote.PressButton();
        
        remote.SetCommand(acTurnOnCommand);
        remote.PressButton();
        
        remote.SetCommand(acTurnOffCommand);
        remote.PressButton();
    }
}
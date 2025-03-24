public class VendingMachineContext
{
    private IVendingMachineState myVendingMachineState;

    public void SetState(IVendingMachineState vendingMachineState)
    {
        myVendingMachineState = vendingMachineState;
    }

    public void Request()
    {
        myVendingMachineState.HandleRequest();
    }
}

public interface IVendingMachineState
{
    void HandleRequest();
}

public class ReadyState : IVendingMachineState
{
    public void HandleRequest()
    {
        Console.WriteLine("Ready State");
    }
}

public class PaymentProcessingState : IVendingMachineState
{
    public void HandleRequest()
    {
        Console.WriteLine("Payment Processing State");
    }
}

public class ProductSelectedState : IVendingMachineState
{
    public void HandleRequest()
    {
        Console.WriteLine("Product Selected State");
    }
}

public class OutOfStockState : IVendingMachineState
{
    public void HandleRequest()
    {
        Console.WriteLine("Out of Stock State");
    }
}

internal class StatePattern
{
    public void Main()
    {
        VendingMachineContext vendingMachineContext = new VendingMachineContext();

        var readyState = new ReadyState();
        vendingMachineContext.SetState(readyState);
        vendingMachineContext.Request();

        var productSelectionState = new PaymentProcessingState();
        vendingMachineContext.SetState(productSelectionState);
        vendingMachineContext.Request();

        var paymentProcessingstate = new PaymentProcessingState();
        vendingMachineContext.SetState(paymentProcessingstate);
        vendingMachineContext.Request();

        vendingMachineContext.SetState(new OutOfStockState());  
        vendingMachineContext.Request();
    }
}
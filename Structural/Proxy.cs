public interface IImage
{
    void Display();
}

public class RealImage : IImage
{
    private readonly string myFilename;

    public RealImage(string filename) 
    {
        myFilename = filename;
    }
    public void Display()
    {
        Console.WriteLine($"Real Image {myFilename}");
    }
}

public class ProxyImage : IImage
{
    private readonly string myFilename;
    private IImage myRealImage;

    public ProxyImage(string filename)
    {
        myFilename = filename;
    }

    public void Display()
    {
        if(myRealImage == null)
        {
            myRealImage = new RealImage(myFilename);
        }
        myRealImage.Display();
    }


}


internal class Proxy
{
    public void Client()
    {
        var proxy = new ProxyImage("Dummy");
        proxy.Display();
    }
}
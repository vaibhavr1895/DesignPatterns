public class Document
{
    private string myContent;
    public Document(string content)
    {
        myContent = content;
    }

    public void Write(string text)
    {
        myContent += text;
    }

    public string GetContent()
    {
        return myContent;
    }

    public DocumentMemento CreateMemento()
    {
        var memento = new DocumentMemento(myContent);
        return memento;
    }

    public void RestoreFromMemento(DocumentMemento documentMemento)
    {
        myContent = documentMemento.GetSavedContent();
    }
}

public class DocumentMemento
{
    private string myContent;
    public DocumentMemento(string content)
    {
        myContent = content;
    }

    public string GetSavedContent()
    {
        return myContent;
    }
}

public class DocumentHistory
{
    private Stack<DocumentMemento> myHistory = new Stack<DocumentMemento>();

    public void AddMemento(DocumentMemento memento)
    {
        myHistory.Push(memento);
    }

    public DocumentMemento GetMemento()
    {
        return myHistory.Pop();
    }
}

internal class MementoPattern
{
    public void Main()
    {
        Document document = new Document("");
        document.Write("Hello ");
        document.Write("World !!");

        DocumentHistory history = new DocumentHistory();
        history.AddMemento(document.CreateMemento());

        document.Write("I am in Bangalore.");

        document.RestoreFromMemento(history.GetMemento());

        Console.WriteLine(document.GetContent());
    }
}
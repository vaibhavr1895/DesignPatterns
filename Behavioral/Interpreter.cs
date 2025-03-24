public class Context
{
    
}

public interface IExpression
{
    int Interpret(Context context);
}

public class NumberExpression: IExpression
{
    private int myNumber;

    public NumberExpression(int number)
    {
        myNumber = number;
    }

    public int Interpret(Context context)
    {
        return myNumber;
    }
}

public class AdditionExpression : IExpression
{
    private IExpression myLeftExpression;
    private IExpression myRightExpression;

    public AdditionExpression(IExpression leftExpression, IExpression rightExpression)
    {
        this.myLeftExpression = leftExpression;
        this.myRightExpression = rightExpression;
    }

    public int Interpret(Context context)
    {
        return myLeftExpression.Interpret(context) + myRightExpression.Interpret(context);
    }
}

public class MultiplicationExpression : IExpression
{
    private IExpression myLeftExpression;
    private IExpression myRightExpression;

    public MultiplicationExpression(IExpression leftExpression, IExpression rightExpression)
    {
        this.myLeftExpression = leftExpression;
        this.myRightExpression = rightExpression;
    }

    public int Interpret(Context context)
    {
        return myLeftExpression.Interpret(context) * myRightExpression.Interpret(context);
    }
}

public class Interpreter
{
    private Context myContext;

    public Interpreter(Context context)
    {
        myContext = context;
    }

    public int Interpret(string expression)
    {
        IExpression expressionTree = BuildExpressionTree(expression);

        return expressionTree.Interpret(myContext);
    }

    public IExpression BuildExpressionTree(string expression)
    {
        return new AdditionExpression(new NumberExpression(2), new MultiplicationExpression(new NumberExpression(3), new NumberExpression(4));
    }
}


internal class InterpreterPattern
{
    public void Main()
    {
        string expression = "2 + 3 * 4";

        Context context = new Context();
        Interpreter interpreter = new Interpreter(context);

        int result = interpreter.Interpret(expression);
    }
}
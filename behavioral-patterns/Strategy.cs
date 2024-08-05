
// Extention interface for classes that need to be passed as strategies
public interface IStrategy{
    // Two integer operation for every class that extends IStrategy
    // NOTE: every class that extends IStrategy MUST implement this function otherwise the code won't compile
    public int StrategyOperation(int a, int b); 
}


// Classes that implement strategies logic on their own manner
public class Addition : IStrategy{
    public int StrategyOperation(int a, int b){
        return a+b;
    }
}

public class Substitution : IStrategy{
    public int StrategyOperation(int a, int b){
        return a-b;
    }
}

public class Multiplication : IStrategy{
    public int StrategyOperation(int a, int b){
        return a * b;
    }
} 

// Context class that will change strategy depending on the situation
public class Context{
    private IStrategy strategy;

    // A constructor with default strategy
    public Context(IStrategy strategy){
        this.strategy = strategy;
    }

    // Setting private startegy via method
    public void SetStrategy(IStrategy strategy){
        this.strategy = strategy;
    }

    // Context strategy logic invokation
    public void Calculate(){
        Console.WriteLine(strategy.StrategyOperation(4,2)); // hardcoded for demonstration
    }
}



class Program(){
    public static void Main(string[] args){
        
        //Context object with deafuly Addition strategy 
        Context context = new Context(new Addition());
        context.Calculate(); // calculates 4 + 2, prints: 6
        
        context.SetStrategy(new Substitution());
        context.Calculate(); // calculates 4 - 2, prints: 2 

        context.SetStrategy(new Multiplication());
        context.Calculate(); // calculates 4 * 2, prints: 8

    }
}


// Simply adapts one functionality to another without breaking Single Responsibility & Open/Closed principles

public class JSON{
    public virtual void PrintContents(){
        Console.WriteLine("Json contents");
    }
}

public interface ITarget;

public class CSV : ITarget;

public class JSONAdapter : JSON{
    ITarget target;
    public JSONAdapter(ITarget target) { 
        this.target = target; 
    }

    public override void PrintContents()
    {
        // target to json
        base.PrintContents();
    }


}



class Program(){

    public static void Main(string[] args){
        CSV csv = new CSV();
        JSONAdapter adapter = new JSONAdapter(csv);
        adapter.PrintContents(); // Prints: Json contents
    }
}

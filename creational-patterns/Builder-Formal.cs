// Builder Design Pattern suits for work with COMPOSITE products.
// It allows to build different complex objects STEP BY STEP. 
// And at any moment and step we can get the result product out of builders.
// NOTE: If a final product can be done in one step then consider to use Factory Design Pattern.
public interface IBuilder{
    public void Method1();
    public void Method2();

    public T GetProduct<T>() where T: class;
}

public class Product1{
    public bool isMethod1Invoked = false;
    public bool isMethod2Invoked = false;
}

public class Product2{
    public bool isMethod1Invoked = false;
    public bool isMethod2Invoked = false;
}

public class ConcreteBuilder1: IBuilder{
    public Product1 _product1 = new Product1();
    public void Method1(){
        Console.WriteLine("Builder1: Method1");
        _product1.isMethod1Invoked = true;
    }
    public void Method2(){
        Console.WriteLine("Builder1: Method2");
        _product1.isMethod2Invoked = true;
    }

    public Product1 GetProduct<Product1>() where Product1: class{
        if(_product1 != null){
            return _product1 as Product1;
        }
        throw new Exception("Null product1");
    }

}

public class ConcreteBuilder2 : IBuilder{
    public Product2 _product2 = new Product2();
    public void Method1(){
        Console.WriteLine("Builder2: Method1");
        _product2.isMethod1Invoked = true;
    }
    public void Method2(){
        Console.WriteLine("Builder2: Method2");
        _product2.isMethod2Invoked = true;
    }

    public Product2 GetProduct<Product2>() where Product2: class{
        if(_product2 != null){
            return _product2 as Product2;
        }
        throw new Exception("Null product2");
    }
}

public class Director{
    private IBuilder _builder;

    public Director(IBuilder builder){
        _builder = builder;
    }

    public void SetBuilder(IBuilder builder){
        _builder = builder;
    }

    public void InvokeBuilderMethod1(){
        _builder.Method1();
    }

    public void InvokeBuilderMethod2(){
        _builder.Method2();
    }

}


class Program(){
    public static void Main(string[] args){
        ConcreteBuilder1 builder1 = new ConcreteBuilder1();

        Director director = new Director(builder1);

        director.InvokeBuilderMethod1(); // Prints: Builder1 Method1
        Product1 aquiredProduct1 = builder1.GetProduct<Product1>();

        Console.WriteLine($"product1: isMethod1Invoked: {aquiredProduct1.isMethod1Invoked}, isMethod2Invoked {aquiredProduct1.isMethod2Invoked}");
        // ^ Prints: product1: isMethod1Invoked: True, isMethod2Invoked False

        ConcreteBuilder2 builder2 = new ConcreteBuilder2();

        // Setting new builder
        director.SetBuilder(builder2);
        director.InvokeBuilderMethod2(); // Prints: Builder2 Method2

        Product2 aquiredProduct2 = builder2.GetProduct<Product2>();
        Console.WriteLine($"product2: isMethod1Invoked: {aquiredProduct2.isMethod1Invoked}, isMethod2Invoked {aquiredProduct2.isMethod2Invoked}");
        // ^ Prints: product2: isMethod1Invoked: True, isMethod2Invoked False


    }
}

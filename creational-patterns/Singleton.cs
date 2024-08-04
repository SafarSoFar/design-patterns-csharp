
//---------------------------------------NOT THREAD-SAFE---------------------------------------------------------------------

// Using sealed keyword to prevent inheritance from Singleton
// because inheritance can violate the singleton principle
public sealed class Singleton{
    public int val = 0; // a demonstrative field
    private static Singleton instance;
    public static Singleton Instance{
        get{
            if(instance == null){
                instance = new Singleton();
            }
            return instance;
        }
        private set{} // to prevent creating through the class constructor 
    }

    
}
//---------------------------------------------------------------------------------------------------

public sealed class ThreadSafeSingleton{
    public int val = 0;
}

class Program(){
    public static void Main(string[] args){

//-------------------NOT THREAD-SAFE-----------------------------------------------------------------

        //SingletonClass.Instance = new SingletonClass(); - doens't compile due to inaccessibility

        Console.WriteLine(Singleton.Instance.val); // 0
        Singleton.Instance.val = 15; 
        Console.WriteLine(Singleton.Instance.val); // 15

//--------------------------------------------------------------------------------------------------
    }
}

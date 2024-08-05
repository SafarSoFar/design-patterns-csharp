
//---------------------------------------NOT THREAD-SAFE---------------------------------------------------------------------

// Using sealed keyword to prevent inheritance from Singleton
// because inheritance can violate the singleton principle
public sealed class Singleton{
    public int val = 0; // a demonstrative field
    private static Singleton instance; //private field
    public static Singleton Instance{ // instance property
        get{
            // Lazy initialization. Initialization when the instance is required for the first time
            if(instance == null){
                instance = new Singleton();
            }
            return instance;
        }
        private set{} // to prevent creating through the class constructor 
    }

    
}
//------------------------------------THREAD SAFE------------------------------------

//By using lock we can ensure that different threads cannot read/write at the same time 
public sealed class ThreadSafeSingleton{
    public int val = 0; // a demonstrative field
    private static ThreadSafeSingleton instance; // private field
    public static readonly object padlock = new object(); // lock object
    public static ThreadSafeSingleton Instance{ // instance property
        get{    
            lock(padlock){

                // Lazy initialization. Initialization when the instance is required for the first time
                if(instance == null){
                    instance = new ThreadSafeSingleton();
                }
                return instance;    

            }
        }
        private set{} // to prevent creating through the class constructor 
    }
}
//----------------------------------THREAD-SAFE------------------------------------------

class Program(){
    public static void Main(string[] args){

//-------------------NOT THREAD-SAFE----------------------------------------------------------------

        //SingletonClass.Instance = new SingletonClass(); - doens't compile due to inaccessibility

        Console.WriteLine(Singleton.Instance.val); // 0
        Singleton.Instance.val = 15; 
        Console.WriteLine(Singleton.Instance.val); // 15

//--------------------------------------------------------------------------------------------------
//------------------THREAD-SAFE---------------------------------------------------------------------
        
        //ThreadSafeSingleton.Instance = new ThreadSafeSingleton(); - doesn't compile due to inaccessibility

        Console.WriteLine(ThreadSafeSingleton.Instance.val); // 0
        ThreadSafeSingleton.Instance.val = 15;
        Console.WriteLine(ThreadSafeSingleton.Instance.val); // 15
        
//--------------------------------------------------------------------------------------------------
    }
}

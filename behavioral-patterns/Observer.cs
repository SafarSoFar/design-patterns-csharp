
// Common interface for subscriptions
public interface ISubscriber{
    public void Update(string notificatonMessage);
}

// Business logic
public class NewsMagazine{
    private List<ISubscriber> _subscribers;

    public NewsMagazine(){
        _subscribers = new List<ISubscriber>();
    }

    public void AddSubscriber(ISubscriber subscriber){
        
        // Check to prevent from double subscription 
        if(!_subscribers.Contains(subscriber)){
            _subscribers.Add(subscriber);
        }
    }

    public void RemoveSubscriber(ISubscriber subscriber){
        
        // Check to prevent error from deleting non-exiting subscriber 
        if(_subscribers.Contains(subscriber)){
            _subscribers.Remove(subscriber);
        }
    }

    public void CreateNewsArticle(string articleName){
        Console.WriteLine($"Creating a new article: {articleName}...");

        // After creating article we invoke 'event' that notifies all subscribers
        NotifySubscribers(articleName);
    }

    // Event to notify all subscribers
    public void NotifySubscribers(string articleName){
        foreach(ISubscriber subscriber in _subscribers){
            subscriber.Update(articleName);
        }
    }
}

// Concrete class that implements subscription interface
public class NewsMagazineReader : ISubscriber{
    string _name;
    public NewsMagazineReader(string name){
        this._name = name;
    }

    public void Update(string notificatonMessage){
        Console.WriteLine($"{_name}, a new article '{notificatonMessage}' just came out!");
    }
}


class Program(){
    public static void Main(string[] args){
        
        NewsMagazine newsMagazine = new NewsMagazine();
        
        // Creating concrete subscribers objects to keep references for unsubscription
        NewsMagazineReader bobReader = new NewsMagazineReader("Bob");
        NewsMagazineReader aliceReader = new NewsMagazineReader("Alice");
        NewsMagazineReader johnDoeReader = new NewsMagazineReader("John Doe");

        newsMagazine.AddSubscriber(bobReader); 
        newsMagazine.AddSubscriber(aliceReader); 
        newsMagazine.AddSubscriber(johnDoeReader); 

        // Creates an important news article and simultaniously notifies subscribers 
        newsMagazine.CreateNewsArticle("Funny cats pictures");

        // Console Print:

        // Creating a new article: Funny cats pictures

        // Bob, a new article 'Funny cats pictures' just came out!
        // Alice, a new article 'Funny cats pictures' just came out!
        // John Doe, a new article 'Funny cats pictures' just came out!

        newsMagazine.RemoveSubscriber(johnDoeReader);

        newsMagazine.CreateNewsArticle("Funny dogs pictures");

        // Console Print:
        
        // Creating a new article: Funny dogs pictures

        // Bob, a new article 'Funny dogs pictures' just came out!
        // Alice, a new article 'Funny dogs pictures' just came out!


    }
}

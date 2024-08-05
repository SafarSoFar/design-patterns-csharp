
public interface ISubscriber{
    public void Notify(string notificatonMessage);
}


public class NewsMagazine{
    private List<ISubscriber> subscribers;

    public NewsMagazine(){
        subscribers = new List<ISubscriber>();
    }

    public void AddSubscriber(ISubscriber subscriber){
        subscribers.Add(subscriber);
    }

    public void CreateNewsArticle(string articleName){
        // creating news article
        // ..
        NotifySubscribers(articleName);
    }

    public void NotifySubscribers(string articleName){
        foreach(ISubscriber subscriber in subscribers){
            subscriber.Notify(articleName);
        }
    }
}

public class NewsMagazineReader : ISubscriber{
    string name;
    public NewsMagazineReader(string name){
        this.name = name;
    }

    public void Notify(string notificatonMessage){
        Console.WriteLine($"{name}, a new article '{notificatonMessage}' just came out!");
    }
}


class Program(){
    public static void Main(string[] args){
        
        NewsMagazine newsMagazine = new NewsMagazine();

        newsMagazine.AddSubscriber(new NewsMagazineReader("Bob")); // Bob, a new article 'Funny cat pictures' just came out!
        newsMagazine.AddSubscriber(new NewsMagazineReader("Alice")); // Alice, a new article 'Funny cat pictures' just came out!
        newsMagazine.AddSubscriber(new NewsMagazineReader("John Doe")); // John Doe, a new article 'Funny cat pictures' just came out!

        // Creates an important news article and simultaniously notifies subscribers 
        newsMagazine.CreateNewsArticle("Funny cat pictures");

    }
}

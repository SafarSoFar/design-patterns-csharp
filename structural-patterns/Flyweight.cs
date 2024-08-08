
// Flyweight Design Pattern allows to store common objects memory to decrease usage of RAM 


using System.Diagnostics;


public enum EnemyType{
    Zombie,
    Vampire,
}

public abstract class IEnemy{
    protected int _xPos;
    protected int _yPos;

    public void SetCoordinates(int xPos, int yPos){
        _xPos = xPos;
        _yPos = yPos;
    }
    //void Attack(int damage)
}

public class Zombie : IEnemy{
    List<int> ints = new List<int>();
    public Zombie(){
        for(int i = 0; i < 10000; i++){
            ints.Add(i);
        }
    }
}

public class Vampire : IEnemy{
    List<int> ints = new List<int>();
    public Vampire(){
        for(int i = 0; i < 10000; i++){
            ints.Add(i);
        }
    }
}

public class FlyweightFactory(){
    Dictionary<EnemyType, IEnemy> _enemiesMap = new Dictionary<EnemyType, IEnemy>();

    public IEnemy GetEnemy(EnemyType enemyType){
        IEnemy enemy;
        if(_enemiesMap.ContainsKey(enemyType)){
            enemy = _enemiesMap[enemyType];
        }
        else{
            if(enemyType == EnemyType.Zombie){
                enemy = new Zombie();
                _enemiesMap.Add(EnemyType.Zombie, enemy);
            }
            else{
                enemy = new Vampire();
                _enemiesMap.Add(EnemyType.Vampire, enemy);
            }
            
        }
        return enemy;

    }
}

class Program(){
    public static void Main(string[] args){

        //------------------------NON-OPTIMIZED-MEMORY-----------------------------------------

        Random r = new Random();
        for(int i = 0; i < 500; i++){
            Zombie zombie = new Zombie();
            zombie.SetCoordinates(r.Next(0,100), r.Next(0,100));

            Vampire vampire = new Vampire();
            vampire.SetCoordinates(r.Next(0,100), r.Next(0,100));
            
        }
        Process process = Process.GetCurrentProcess();
        Console.WriteLine("Memory usage: " + process.PrivateMemorySize64); // Prints: 11636736 bytes => 11636.736 KB

        //--------------------------------------------------------------------------------------

        //-----------------------OPTIMIZED-MEMORY------------------------------------------------

        FlyweightFactory flyweightFactory = new FlyweightFactory();
        Random r = new Random();
        for(int i = 0; i < 500; i++){
            Zombie zombie = (Zombie) flyweightFactory.GetEnemy(EnemyType.Zombie);
            zombie.SetCoordinates(r.Next(0,100), r.Next(0,100));

            Vampire vampire = (Vampire) flyweightFactory.GetEnemy(EnemyType.Vampire);
            vampire.SetCoordinates(r.Next(0,100), r.Next(0,100));
            
        }
        Process process = Process.GetCurrentProcess();
        Console.WriteLine("Memory usage: " + process.PrivateMemorySize64); // Prints:  7098368 bytes => 7098.368 KB

        //---------------------------------------------------------------------------------------

        

    }
}

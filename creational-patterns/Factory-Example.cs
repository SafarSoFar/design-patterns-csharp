// Parent executable interface (abtract class, abtract method)
public abstract class Executable{
    public abstract void PrintExecutable();
}


//-----------------CONCRETE EXECUTABLE CLASSES------------------------------
public class WindowsExecutable : Executable{
    public override void PrintExecutable()
    {
        Console.WriteLine("Windows executable");
    }
}
public class LinuxExecutable : Executable{
    public override void PrintExecutable()
    {
        Console.WriteLine("Linux executable");
    }
}
//--------------------------------------------------------------------------

// Main factory interface 
public interface IExecutableFactory{
    public Executable GetExecutable();
}

//-----------------CONCRETE FACTORIES----------------------------------------
public class WindowsExecutableFactory() : IExecutableFactory{
    public Executable GetExecutable(){
        return new WindowsExecutable();
    }
}
public class LinuxExecutableFactory() : IExecutableFactory{
    public Executable GetExecutable(){
        return new LinuxExecutable();
    }
}
//----------------------------------------------------------------------------

class Program(){
    public static void Main(string[] args){
        
        WindowsExecutableFactory windowsExecutableFactory = new WindowsExecutableFactory();
        Executable windowsExecutable = windowsExecutableFactory.GetExecutable();
        windowsExecutable.PrintExecutable(); // Prints: Windows Executable

        LinuxExecutableFactory linuxExecutableFactory = new LinuxExecutableFactory();
        Executable linuxExecutable = linuxExecutableFactory.GetExecutable();
        linuxExecutable.PrintExecutable(); // Prints : Linux Executable

    }
}

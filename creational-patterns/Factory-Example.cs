// Factory pattern is some kind of a WRAPPER of products constructor, when you provide some input to a Factory
// an receive an output object depending on the input

//---------------------EXAMPLE-1---------------------------------------------------------------------------

// Simple Factory example

public abstract class Vehicle{
    public abstract Vehicle GetVehicle();
    public abstract void DriveVehicle();
}

public class Car : Vehicle{
    public override Vehicle GetVehicle(){
        return new Car();
    }
    public override void DriveVehicle(){
        Console.WriteLine("Driving the car");
    }
} 

public class Motorcycle : Vehicle{
    public override Vehicle GetVehicle()
    {
        return new Motorcycle();
    }
    public override void DriveVehicle(){
        Console.WriteLine("Driving the motorcycle");
    }
}

// Enum for more precise factory argument passing
public enum VehicleType{
    Car,
    Motorcycle
}

public class VehicleFactory(){
    public Vehicle CreateVehicle(VehicleType vehicleToCreate){
        if(vehicleToCreate==VehicleType.Car){
            return new Car();
        }
        else{
            return new Motorcycle();
        }
    }
}

//---------------------END-OF-EXAMPLE-1---------------------------------------------------------------------------

//----------------------EXAMPLE-2---------------------------------------------------------------------------

//  A bit bigger Factory Pattern example involving a few factories 

// Parent executable interface (abtract class, abtract method)
public abstract class Executable{
    public abstract void PrintExecutable();
}


//-----------------CONCRETE-EXECUTABLE-CLASSES------------------------------
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

//-----------------CONCRETE-FACTORIES----------------------------------------
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

//-----------------------END-OF-EXAMPLE-2-------------------------------------
class Program(){
    public static void Main(string[] args){

        //-----------------EXAMPLE-1-USAGE-----------------------------------------

        VehicleFactory vehicleFactory = new VehicleFactory();

        // Choosing between Car / Motorcycle
        Vehicle car = vehicleFactory.CreateVehicle(VehicleType.Car);
        car.DriveVehicle(); // Prints: Driving the car

        Vehicle motorcycle = vehicleFactory.CreateVehicle(VehicleType.Motorcycle);
        motorcycle.DriveVehicle(); // Prints: Driving the motorcycle

        //-----------------END-OF-EXAMPLE-1-USAGE---------------------------------------

        //-----------------EXAMPLE-2-USAGE----------------------------------------------

        WindowsExecutableFactory windowsExecutableFactory = new WindowsExecutableFactory();
        Executable windowsExecutable = windowsExecutableFactory.GetExecutable();
        windowsExecutable.PrintExecutable(); // Prints: Windows Executable

        LinuxExecutableFactory linuxExecutableFactory = new LinuxExecutableFactory();
        Executable linuxExecutable = linuxExecutableFactory.GetExecutable();
        linuxExecutable.PrintExecutable(); // Prints : Linux Executable

        //-----------------END-OF-EXAMPLE-2-USAGE-----------------------------------------------

    }
}

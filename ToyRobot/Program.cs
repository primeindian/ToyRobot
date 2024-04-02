using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToyRobot.Extensions;
using ToyRobot.Interfaces;

internal class Program
{
    private static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .AddApplicationServices()
            .Build();

        var commandProcessor = host.Services.GetRequiredService<IProcessCommands>();

        GiveInstructions();
        commandProcessor.StartProcess();
    }

    private static void GiveInstructions()
    {
        Console.WriteLine("Toy Robot Simulator");
        Console.WriteLine("Instructions:");
        Console.WriteLine("1. PLACE X,Y,F - Places the robot on the table at position X,Y facing F (NORTH, EAST, SOUTH, WEST)");
        Console.WriteLine("2. MOVE - Moves the robot one unit forward in the direction it is facing");
        Console.WriteLine("3. LEFT - Rotates the robot 90 degrees to the left without changing its position");
        Console.WriteLine("4. RIGHT - Rotates the robot 90 degrees to the right without changing its position");
        Console.WriteLine("5. REPORT - Reports the current position and direction of the robot");
        Console.WriteLine("6. EXIT - Exits the simulator");
        Console.WriteLine("Enter commands for the robot (type 'EXIT' to stop):");
    }
}
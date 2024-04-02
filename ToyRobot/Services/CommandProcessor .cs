using ToyRobot.Constants;
using ToyRobot.Enumerations;
using ToyRobot.Interfaces;
using ToyRobot.Models;

namespace ToyRobot.Services;

public class CommandProcessor : IProcessCommands
{
    private readonly IOperateRobot _robotOperations;

    public CommandProcessor(IOperateRobot robotOperations)
    {
        _robotOperations = robotOperations;
    }

    public void StartProcess()
    {
        string command;
        while ((command = Console.ReadLine()) != null && command.ToUpper() != "EXIT")
        {
            ProcessCommand(command);
        }
    }

    public void ProcessCommand(string command)
    {
        string[] parts = command.Split(' ');
        switch (parts[0])
        {
            case Operations.Place:
                string[] args = parts[1].Split(',');
                if (args.Length != 3) break;
                var xParse = int.TryParse(args[0], out int x);
                var yParse = int.TryParse(args[1], out int y);
                if (!xParse || !yParse) break;

                var facing = (Direction)Enum.Parse(typeof(Direction), args[2], ignoreCase: true);

                _robotOperations.Place(new Coordinate(x, y), facing);
                break;

            case Operations.Move:
                _robotOperations.Move();
                break;

            case Operations.Left:
                _robotOperations.Left();
                break;

            case Operations.Right:
                _robotOperations.Right();
                break;

            case Operations.Report:
                var robo = _robotOperations.GetReport();
                if (robo.IsPlaced)
                    Console.WriteLine($"{robo.Position.X},{robo.Position.Y},{robo.Facing}");
                break;
        }
    }
}
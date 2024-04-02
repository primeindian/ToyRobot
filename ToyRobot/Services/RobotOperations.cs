using ToyRobot.Enumerations;
using ToyRobot.Interfaces;
using ToyRobot.Models;

namespace ToyRobot.Services;

public class RobotOperations : IOperateRobot
{
    private Robot robo { get; set; }

    public RobotOperations()
    {
        robo = new Robot();
    }

    public bool Place(Coordinate coordinate, Direction facing)
    {
        if (coordinate.X >= 0 && coordinate.X < 5 && coordinate.Y >= 0 && coordinate.Y < 5)
        {
            robo.Position = coordinate;
            robo.Facing = facing;
            robo.IsPlaced = true;
            return true;
        }
        return false;
    }

    public bool Move()
    {
        if (!robo.IsPlaced) return false;

        switch (robo.Facing)
        {
            case Direction.North:
                if (robo.Position.Y < 4) robo.Position.Y++;
                return true;

            case Direction.East:
                if (robo.Position.X < 4) robo.Position.X++;
                return true;

            case Direction.South:
                if (robo.Position.Y > 0) robo.Position.Y--;
                return true;

            case Direction.West:
                if (robo.Position.X > 0) robo.Position.X--;
                return true;

            default:
                return false;
        }
    }

    public bool Left()
    {
        if (!robo.IsPlaced) return false;
        robo.Facing = (Direction)(((int)robo.Facing + 3) % 4);

        return true;
    }

    public bool Right()
    {
        if (!robo.IsPlaced) return false;
        robo.Facing = (Direction)(((int)robo.Facing + 1) % 4);

        return true;
    }

    public Robot GetReport()
    {
        return robo;
    }
}
using ToyRobot.Enumerations;

namespace ToyRobot.Models;

public class Robot
{
    public Coordinate Position { get; set; }
    public Direction Facing { get; set; }
    public bool IsPlaced { get; set; }

    public Robot()
    {
        IsPlaced = false;
    }
}
using ToyRobot.Enumerations;
using ToyRobot.Models;

namespace ToyRobot.Interfaces;

public interface IOperateRobot
{
    bool Place(Coordinate coordinate, Direction facing);

    bool Move();

    bool Left();

    bool Right();

    Robot GetReport();
}
namespace ToyRobot.Tests.Unit;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Enumerations;
using ToyRobot.Models;
using ToyRobot.Services;

[TestClass]
public class RobotOperationsTests
{
    [TestMethod]
    public void Place_ValidCoordinatesAndDirection_ShouldPlaceRobot()
    {
        var robotOperations = new RobotOperations();
        var result = robotOperations.Place(new Coordinate(2, 2), Direction.North);

        Assert.IsTrue(result);
        var robotReport = robotOperations.GetReport();
        Assert.AreEqual(2, robotReport.Position.X);
        Assert.AreEqual(2, robotReport.Position.Y);
        Assert.AreEqual(Direction.North, robotReport.Facing);
    }

    [TestMethod]
    public void Place_InvalidCoordinates_ShouldNotPlaceRobot()
    {
        var robotOperations = new RobotOperations();
        var result = robotOperations.Place(new Coordinate(5, 5), Direction.North);

        Assert.IsFalse(result);
        Assert.IsFalse(robotOperations.GetReport().IsPlaced);
    }

    [TestMethod]
    public void Move_RobotPlacedAndFacingNorth_ShouldMoveNorth()
    {
        var robotOperations = new RobotOperations();
        robotOperations.Place(new Coordinate(0, 0), Direction.North);
        var result = robotOperations.Move();

        Assert.IsTrue(result);
        var robotReport = robotOperations.GetReport();
        Assert.AreEqual(0, robotReport.Position.X);
        Assert.AreEqual(1, robotReport.Position.Y);
        Assert.AreEqual(Direction.North, robotReport.Facing);
    }

    [TestMethod]
    public void Move_RobotNotPlaced_ShouldNotMove()
    {
        var robotOperations = new RobotOperations();
        var result = robotOperations.Move();

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void Left_RobotPlaced_ShouldTurnLeft()
    {
        var robotOperations = new RobotOperations();
        robotOperations.Place(new Coordinate(0, 0), Direction.North);
        var result = robotOperations.Left();

        Assert.IsTrue(result);
        Assert.AreEqual(Direction.West, robotOperations.GetReport().Facing);
    }

    [TestMethod]
    public void Left_RobotNotPlaced_ShouldNotTurn()
    {
        var robotOperations = new RobotOperations();
        var result = robotOperations.Left();

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void Right_RobotPlaced_ShouldTurnRight()
    {
        var robotOperations = new RobotOperations();
        robotOperations.Place(new Coordinate(0, 0), Direction.North);
        var result = robotOperations.Right();

        Assert.IsTrue(result);
        Assert.AreEqual(Direction.East, robotOperations.GetReport().Facing);
    }

    [TestMethod]
    public void Right_RobotNotPlaced_ShouldNotTurn()
    {
        var robotOperations = new RobotOperations();
        var result = robotOperations.Right();

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void GetReport_RobotPlaced_ShouldReturnCorrectReport()
    {
        var robotOperations = new RobotOperations();
        robotOperations.Place(new Coordinate(1, 1), Direction.South);

        var report = robotOperations.GetReport();

        Assert.AreEqual(1, report.Position.X);
        Assert.AreEqual(1, report.Position.Y);
        Assert.AreEqual(Direction.South, report.Facing);
    }

    [TestMethod]
    public void GetReport_RobotNotPlaced_ShouldReturnNullPosition()
    {
        var robotOperations = new RobotOperations();

        var report = robotOperations.GetReport();

        Assert.IsNull(report.Position);
    }
}
namespace ToyRobot.Interfaces;

public interface IProcessCommands
{
    void StartProcess();

    void ProcessCommand(string command);
}
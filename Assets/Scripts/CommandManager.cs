using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface ICommand
{
    void Execute();
    void Undo();
}

public class MoveCommand : ICommand
{
    private Transform objectToMove;
    private Vector3 displacement;

    public MoveCommand(Transform obj, Vector3 displacement)
    {
        this.objectToMove = obj;
        this.displacement = displacement;
    }

    public void Execute() { objectToMove.position += displacement; }
    public void Undo() { objectToMove.position -= displacement; }
}



public class CommandManager : MonoBehaviour
{
    private Stack<ICommand> commandHistory = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        commandHistory.Push(command);
    }

    // Update is called once per frame
    public void UndoLastCommand()
    {
        if (commandHistory.Count > 0)
        {
            ICommand lastcommand = commandHistory.Pop();
            lastcommand.Undo();
        }
    }
}

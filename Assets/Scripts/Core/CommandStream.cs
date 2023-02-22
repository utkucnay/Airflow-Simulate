using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandStream : Singleton<CommandStream>
{
    public Queue<ICommand> CommandQueue;

    protected override void Awake()
    {
        base.Awake();
        CommandQueue = new Queue<ICommand>();
    }

    private void LateUpdate()
    {
        while (CommandQueue.Count != 0)
        {
            var command = CommandQueue.Dequeue();
            command.Execute();
        }
    }
}

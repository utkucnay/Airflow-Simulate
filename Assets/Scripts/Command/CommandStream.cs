using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;
using Unity.Collections;

// I garbaged Multi Thread Physics code. 
public class CommandStream : Singleton<CommandStream>
{
    public Queue<ICommand> CommandQueue;

    //public Queue<PhysicsCommand> physicsQueue;

    //JobHandle physicsJobHandle;


    protected override void Awake()
    {
        base.Awake();
        CommandQueue = new Queue<ICommand>();
        //physicsQueue = new Queue<PhysicsCommand>();
    }

    private void Update()
    {
        //physicsJobHandle.Complete();
    }

    private void LateUpdate()
    {
        while (CommandQueue.Count != 0)
        {
            var command = CommandQueue.Dequeue();
            command.Execute();
        }

        /*if (physicsQueue.Count == 0) return;
        PhysicsJob physicsJob = new PhysicsJob();
        PhysicsJob.physicsCommand = physicsQueue;
        physicsJobHandle = physicsJob.Schedule();*/
    }
}

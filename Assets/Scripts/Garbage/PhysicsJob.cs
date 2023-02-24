using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;


public interface ICommandG { }

// Unity hasn't Multi Thread physics systems if you want to will add install this packet: Havok physics or Unity Dot physics.
//I don't use those codes. 
public struct PhysicsCommand : ICommandG
{
    public PhysicsCommand(PhysicsMonoBehavior physicsMonoBehavior, Vector3 pos, float radius)
    {
        this.physicsMonoBehavior = physicsMonoBehavior;
        this.pos = pos;
        this.radius = radius; 
    }

    public void Execute()
    {
        Collider[] colliders = new Collider[200];
        int size =  Physics.OverlapSphereNonAlloc(pos, radius, colliders);

        for (int i = 0; i < size; i++)
        {
            physicsMonoBehavior.colliders.Add(colliders[i]);
        }
    }

    public PhysicsMonoBehavior physicsMonoBehavior;
    public Vector3 pos;
    public float radius;
}

public struct PhysicsJob : IJob
{
    public static Queue<PhysicsCommand> physicsCommand;

    public void Execute()
    {
        int count = physicsCommand.Count;

        for (int i = 0; i < count; i++)
        {
            var command = physicsCommand.Dequeue();
            command.Execute();
        }
    }
}

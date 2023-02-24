using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    public void Execute()
    {
        gObject.transform.position += moveDir * speed * Time.deltaTime;
    }

    public GameObject gObject;
    public Vector3 moveDir;
    public float speed;
}

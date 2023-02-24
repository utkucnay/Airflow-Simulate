using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosCommand : ICommand
{
    public void Execute()
    {
        gObject.transform.position = newPos;
    }

    public GameObject gObject;
    public Vector3 newPos;
}

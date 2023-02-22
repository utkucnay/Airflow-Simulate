using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCommand : ICommand
{
    public void Execute()
    {
        transform.Rotate(new Vector3(-y * speed, 0, 0), Space.Self);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + x * speed, transform.eulerAngles.z);
    }

    public Transform transform;
    public float x, y;
    public float speed;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] Vector3 moveDir = Vector3.zero;
    [SerializeField] float speed;

    private void FixedUpdate()
    {
        transform.position += moveDir * speed * Time.fixedDeltaTime;

        if (transform.position.x > GameController.instance.groundProp.groundSize.x + 2.5f)
        {
            Spawner.instance.RemoveLines(this);
        }
    }

    public void SetDirAndSpeed(Vector3 moveDir, float speed)
    {
        this.moveDir = moveDir;
        this.speed = speed;
    }
}

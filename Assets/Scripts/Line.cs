using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] Vector3 moveDir = Vector3.zero;
    [SerializeField] float speed;

    public int ID;

    public Vector3 MoveDir { get { return moveDir; } }

    TrailRenderer trailRenderer;

    private void Start()
    {
        trailRenderer= GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        if (ID < GameController.instance.spawnLineProp.spawnLineCount)
        {
            trailRenderer.enabled = true;
        }
        else
        {
            trailRenderer.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        speed = GameController.instance.spawnLineProp.windSpeed;
        trailRenderer.widthMultiplier = GameController.instance.spawnLineProp.widthLine * 2;

        transform.position += moveDir * speed * Time.fixedDeltaTime;

        if (transform.position.x > GameController.instance.groundProp.groundSize.x + 2.5f)
        {
            Spawner.instance.RemoveLines(this);
        }
    }

    public void SetDir(Vector3 moveDir)
    {
        this.moveDir = moveDir;
    }
}

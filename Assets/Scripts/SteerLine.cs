using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerLine : MonoBehaviour
{
    Line line;

    public Vector3 lineLoc;

    private void Start()
    {
        line = GetComponent<Line>();
        lineLoc = transform.position;
    }

    private void FixedUpdate()
    {
        var colliders = Physics.OverlapBox(transform.position, new Vector3(0.4f, 4f,2f));
        Vector3 velocity = Vector3.zero;

        Steer(colliders, ref velocity);
        BackToNormal(ref velocity);
        SubmitVelocity(velocity);
    }

    public void Steer(Collider[] colliders, ref Vector3 velocity)
    {
        Vector3 allObstaclePositionAverage = Vector3.zero;

        foreach (var collider in colliders)
        {
            allObstaclePositionAverage += collider.transform.position - transform.position;
            Vector3 obstacleNormal = collider.transform.up;
            Vector3 avoidanceDirection = Vector3.Cross(obstacleNormal, line.MoveDir);

            if (collider.transform.localScale.y / 2 + collider.transform.position.y - transform.position.y < .2f)
            {
                velocity += new Vector3(0, 1, 0) * Time.fixedDeltaTime * 20f;
            }
            else
            {
                velocity += new Vector3(0, 0, avoidanceDirection.normalized.z)
                    / Mathf.Sqrt(Vector3.Distance(transform.position, collider.transform.position)) * Time.fixedDeltaTime * 50f;
            }
        }

        allObstaclePositionAverage /= colliders.Length;

        velocity *= Mathf.Sign(allObstaclePositionAverage.z);
    }

    public void BackToNormal(ref Vector3 velocity)
    {
        if (transform.position.z != lineLoc.z || transform.position.y != lineLoc.y)
        {
            velocity += new Vector3(0, Mathf.Sign(lineLoc.y - transform.position.y), Mathf.Sign(lineLoc.z - transform.position.z)) * 3.4f * Time.fixedDeltaTime;
        }
    }

    public void SubmitVelocity(in Vector3 velocity)
    {
        transform.position += velocity;
    }
}

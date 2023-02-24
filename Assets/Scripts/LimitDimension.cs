using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitDimension : MonoBehaviour
{
    float minX, maxX, minY, maxY;

    private void Start()
    {
        minX = -GameController.instance.groundProp.groundSize.x;
        maxX = GameController.instance.groundProp.groundSize.x;

        minY = -GameController.instance.groundProp.groundSize.y;
        maxY = GameController.instance.groundProp.groundSize.y;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x,minX, maxX),
            Mathf.Clamp(transform.position.y, minX, maxX),
            Mathf.Clamp(transform.position.z, minY, maxY)
            );
    }
}

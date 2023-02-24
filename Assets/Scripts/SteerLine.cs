using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerLine : MonoBehaviour
{
    private void Update()
    {
        var colliders = Physics.OverlapSphere(transform.position, 2);

        if (colliders.Length != 0)
        {
            
        }
    }
}

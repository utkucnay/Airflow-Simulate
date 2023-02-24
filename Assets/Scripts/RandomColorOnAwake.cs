using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorOnAwake : MonoBehaviour
{


    private void Awake()
    {
        var mat = GetComponent<MeshRenderer>().material;
        mat.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        Destroy(this);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMonoBehavior : MonoBehaviour
{
    [HideInInspector] public List<RaycastHit> raycastHits;
    [HideInInspector] public List<Collider> colliders;
}

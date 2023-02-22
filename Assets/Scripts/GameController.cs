using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GroundProp
{
    public GameObject groundPrefab;
    public Vector2 groundSize;
    public float GrondScaleToKM { get { return 5; } }
}

[System.Serializable]
public struct SpawnProp 
{
    public GameObject spawnPrefab;
    public Vector2 height;
    public Vector2 width;
    public Vector2 length;
    public int spawnCubeCount;
}

public class GameController : Singleton<GameController>
{
    public GroundProp groundProp;

    public SpawnProp spawnProp;

    protected override void Awake()
    {
        base.Awake();
        
    }


}

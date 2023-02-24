using UnityEngine;

[System.Serializable]
public struct GroundProp
{
    public GameObject groundPrefab;
    public Vector2 groundSize;
    public float GrondScaleToKM { get { return 5; } }
}

[System.Serializable]
public struct SpawnCubeProp 
{
    public GameObject spawnCubePrefab;
    public Vector2 height;
    public Vector2 width;
    public Vector2 length;
    public int spawnCubeCount;
}

[System.Serializable]
public struct SpawnLineProp
{
    public GameObject spawnLinePrefab;
    public Vector2 widthLine;
    public int spawnLineCount;
    public Vector2Int spawnLineLimitCount;
    public float windSpeed;
}

public class GameController : Singleton<GameController>
{
    public GroundProp groundProp;

    public SpawnCubeProp spawnCubeProp;

    public SpawnLineProp spawnLineProp;

    protected override void Awake()
    {
        base.Awake();
        
    }


}

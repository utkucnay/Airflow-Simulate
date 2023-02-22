using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject CubePrefab;

    private void Start()
    {
        //Limit Spawn Prop
        float startX, startY, endX, endY;
        var groundSize = GameController.instance.groundProp.groundSize;
        float groundToKM = GameController.instance.groundProp.GrondScaleToKM;

        SpawnGround(GameController.instance.groundProp.groundPrefab, groundSize, groundToKM);

        startX = -groundSize.x;
        startY = -groundSize.y;

        endX = groundSize.x;
        endY = groundSize.y;

        SpawnCubes(startX, startY, endX, endY);
    }

    public void SpawnGround(GameObject groundPrefab, in Vector2 groundSize, in float groundToKM)
    {
        var groundGO = Instantiate(groundPrefab, Vector3.zero, Quaternion.identity);
        groundGO.transform.localScale = new Vector3(groundSize.x / groundToKM, 1, groundSize.y / groundToKM);
    } 

    public void SpawnCubes(in float startX,in float startY, in float endX, in float endY)
    {
        int spawnCount = GameController.instance.spawnProp.spawnCubeCount;
        Vector2 height = GameController.instance.spawnProp.height;
        Vector2 width = GameController.instance.spawnProp.width;
        Vector2 length = GameController.instance.spawnProp.length;
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 scale = new Vector3(Random.Range(height.x, height.y), Random.Range(length.x, length.y), Random.Range(width.x, width.y));
            var cubeGO = Instantiate(CubePrefab, new Vector3(Random.Range(startX, endX), scale.y / 2, Random.Range(startY, endY)), Quaternion.identity);
            cubeGO.transform.localScale = scale;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Singleton<Spawner>
{
    Queue<GameObject> lineQueue;
    int lineCount = 0;

    private void Start()
    {
        lineQueue = new();
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

        int spawnLineLimitCount = GameController.instance.spawnLineProp.spawnLineLimitCount.y;
        for (int i = 0; i < spawnLineLimitCount; i++)
        {
            GameObject lineGO = Instantiate(GameController.instance.spawnLineProp.spawnLinePrefab, Vector3.zero, Quaternion.identity);
            lineGO.SetActive(false);
            lineQueue.Enqueue(lineGO);
        }

        Invoke("SpawnLines", GameController.instance.spawnLineProp.nextSpawnLineTime);
    }

    public void RemoveLines(Line line)
    {
        lineQueue.Enqueue(line.gameObject);
        line.gameObject.SetActive(false);

        if (--lineCount == 0)
        {
            Invoke("SpawnLines", GameController.instance.spawnLineProp.nextSpawnLineTime);
        }
    }

    void SpawnLines()
    {
        float lineMaxCount = GameController.instance.spawnLineProp.spawnLineLimitCount.y;
        lineCount = GameController.instance.spawnLineProp.spawnLineCount;
        float offsetY = 5;
        float offsetZ = -GameController.instance.groundProp.groundSize.y;

        float offset = 1.5f;

        for (int i = 0; i < lineCount; i++)
        {
            var lineGO = lineQueue.Dequeue();
            lineGO.SetActive(true);
            lineGO.transform.position = new Vector3(-GameController.instance.groundProp.groundSize.x, offsetY, offsetZ);

            Line lineComp = lineGO.GetComponent<Line>();
            lineComp.SetDir(new Vector3(1, 0, 0));
            lineComp.ID = i;

            offsetZ += offset;

            if (offsetZ > GameController.instance.groundProp.groundSize.y)
            {
                offsetZ = -GameController.instance.groundProp.groundSize.y;
                offsetY += offset;
            }
        }

        for (int i = lineCount; i < lineMaxCount; i++)
        {
            var lineGO = lineQueue.Dequeue();
            lineGO.SetActive(true);
            lineGO.transform.position = new Vector3(-GameController.instance.groundProp.groundSize.x, offsetY, offsetZ);

            Line lineComp = lineGO.GetComponent<Line>();
            lineComp.SetDir(new Vector3(1, 0, 0));
            lineComp.ID = i;

            offsetZ += offset;

            if (offsetZ > GameController.instance.groundProp.groundSize.y)
            {
                offsetZ = -GameController.instance.groundProp.groundSize.y;
                offsetY += offset;
            }
        }
    }

    void SpawnGround(GameObject groundPrefab, in Vector2 groundSize, in float groundToKM)
    {
        var groundGO = Instantiate(groundPrefab, Vector3.zero, Quaternion.identity);
        groundGO.transform.localScale = new Vector3(groundSize.x / groundToKM, 1, groundSize.y / groundToKM);
    } 

    void SpawnCubes(in float startX, in float startY, in float endX, in float endY)
    {
        int spawnCount = GameController.instance.spawnCubeProp.spawnCubeCount;
        GameObject cubePrefab = GameController.instance.spawnCubeProp.spawnCubePrefab;
        Vector2 height = GameController.instance.spawnCubeProp.height;
        Vector2 width = GameController.instance.spawnCubeProp.width;
        Vector2 length = GameController.instance.spawnCubeProp.length;
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 scale = new Vector3(Random.Range(height.x, height.y), Random.Range(length.x, length.y), Random.Range(width.x, width.y));
            var cubeGO = Instantiate(cubePrefab, new Vector3(Random.Range(startX, endX), scale.y / 2, Random.Range(startY, endY)), Quaternion.identity);
            cubeGO.transform.localScale = scale;
        }
    }
}

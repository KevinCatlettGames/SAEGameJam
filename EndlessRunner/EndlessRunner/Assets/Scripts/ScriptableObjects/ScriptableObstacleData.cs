using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Scriptable Objects/ObstacleData", fileName = "new ObstacleData")]
public class ScriptableObstacleData : ScriptableObject
{
    [Header("GameObject")]
    public GameObject Obstacle;
    [Header("Spawn Area")]
    public float MinX;
    public float MaxX;
    public float MinY;
    public float MaxY;
    [Header("Spawn Amount")]
    public int MinAmount = 1;
    public int MaxAmount = 1;
    [Header("Spawn Weight")]
    public float SpawnWeight = 1.0f;

    public void SpawnObstacle()
    {
        int spawnAmount = Random.Range(MinAmount, MaxAmount + 1);
        for (int i = 0; i < spawnAmount; i++)
        {
            float xPos = Random.Range(MinX, MaxX);
            float yPos = Random.Range(MinY, MaxY);
            Instantiate(Obstacle, new Vector3(xPos, yPos, 0.0f), quaternion.identity);
        }
    }
}

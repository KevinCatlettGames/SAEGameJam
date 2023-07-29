using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private ScriptableObstacleData[] spawnableObstacles;
    [SerializeField] private int lastSpawnedIndex = int.MaxValue;

    [SerializeField] private float timerLength = 3.0f;
    [SerializeField] private float timerVariation = 0.75f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = timerLength;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ChooseObstacle()?.SpawnObstacle();
            timer += timerLength + Random.Range(-timerVariation, timerVariation);
        }
    }

    private ScriptableObstacleData ChooseObstacle()
    {
        ScriptableObstacleData chosenObstacle = null;
        //List<ScriptableObstacleData> viableObstacles = new List<ScriptableObstacleData>();
        
        float weightRange = 0;
        
        for (int i = 0; i < spawnableObstacles.Length; i++)
        {
            if (i == lastSpawnedIndex) continue;
            
            //viableObstacles.Add(spawnableObstacles[i]);
            weightRange += spawnableObstacles[i].SpawnWeight;
        }

        float rnd = Random.Range(0.0f, weightRange);
        float weightRangeProgress = 0;
        for (int i = 0; i < spawnableObstacles.Length; i++)
        {
            if (i == lastSpawnedIndex) continue;
            if (i == spawnableObstacles.Length-1||rnd >= weightRangeProgress && rnd <= weightRangeProgress + spawnableObstacles[i].SpawnWeight)
            {
                chosenObstacle = spawnableObstacles[i];
                lastSpawnedIndex = i;
                Debug.Log(lastSpawnedIndex);
                
                break;
            }
            
            weightRange += spawnableObstacles[i].SpawnWeight;
        }

        return chosenObstacle;
    }
}

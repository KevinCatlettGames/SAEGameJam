using UnityEngine;

public class ManaSpawner : MonoBehaviour
{
    [SerializeField] float spawnDuration;
    float initialSpawnDuration;

    float verticalSpawnOffset;
    
    [SerializeField] float offsetChangeSpeed = 0.2f;

    [SerializeField] float maxVerticalPosition;
    [SerializeField] float minVerticalPosition; 

    [SerializeField] GameObject manaObject; 
    private void Awake()
    {
        initialSpawnDuration = spawnDuration;
    }
    
    private void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        spawnDuration -= Time.deltaTime;
        if (spawnDuration <= 0)
        {
            // spawn
            spawnDuration = initialSpawnDuration;
            GameObject newObject = Instantiate(manaObject, new Vector2(transform.position.x, transform.position.y + verticalSpawnOffset), Quaternion.identity);
            newObject.transform.parent = gameObject.transform;
            verticalSpawnOffset = Mathf.Lerp(minVerticalPosition, maxVerticalPosition, Mathf.PerlinNoise(Time.time * offsetChangeSpeed, 0));
        }
    }
}

using UnityEngine;

public class ManaSpawner : MonoBehaviour
{
    [SerializeField] float spawnDuration;
    float initialSpawnDuation;

    float verticalSpawnOffset = 0;

    [SerializeField] float incrementAmount = 0.1f;

    bool goUp;

    [SerializeField] float maxVerticalPosition;
    [SerializeField] float minVerticalPosition; 

    [SerializeField] GameObject manaObject; 
    private void Awake()
    {
        initialSpawnDuation = spawnDuration;
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
            spawnDuration = initialSpawnDuation;
            Instantiate(manaObject, new Vector2(transform.position.x, transform.position.y + verticalSpawnOffset), Quaternion.identity);

            if (goUp)
            {
                verticalSpawnOffset += incrementAmount;

                if (verticalSpawnOffset > maxVerticalPosition)
                {
                    goUp = false;
                }
            }
            else
            {
                verticalSpawnOffset -= incrementAmount;

                if (verticalSpawnOffset < minVerticalPosition)
                {
                    goUp = true;
                }
            }         
        }
    }
}

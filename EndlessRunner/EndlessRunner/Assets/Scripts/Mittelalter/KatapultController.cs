using UnityEngine;

public class KatapultController : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPosition; 
    public float horizontsalSpawnPosition;
    bool fired;
    public Animator anim; 
    private void Update()
    {
        if(transform.position.x < horizontsalSpawnPosition)
        {
            fired = true;
            anim.SetTrigger("Schießen");

        }
    }

    public void SpawnSchuss()
    {
        Instantiate(bullet, bulletPosition.position, Quaternion.identity);
    }
}

using UnityEngine;

/// <summary>
/// The snapping dino plays a snapping animation and activates appropriate colliders depending on the current frame.
/// The snapping animation is started after a random time, <see cref="minMaxIdleTime"/>.
/// </summary>
public class SnappingDinoController : MonoBehaviour
{   
    [SerializeField] Animator animator;
    [SerializeField] Vector2 minMaxIdleTime = new Vector2(3, 5);

    float idleTime;  

    private void Awake()
    {
        InitializeIdleTime();
    }
    private void Update()
    {
        idleTime -= Time.deltaTime;
        if(idleTime <= 0)
        {
            animator.SetTrigger("Snap");
            InitializeIdleTime();
        }
    }
    private void InitializeIdleTime()
    {
        idleTime = Random.Range(minMaxIdleTime.x, minMaxIdleTime.y);
    }
}

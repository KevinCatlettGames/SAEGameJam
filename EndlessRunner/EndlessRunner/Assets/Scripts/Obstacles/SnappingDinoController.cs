using UnityEngine;

/// <summary>
/// The snapping dino plays a snapping animation and activates appropriate colliders depending on the current frame.
/// The snapping animation is started after a random time, <see cref="minMaxIdleTime"/>.
/// </summary>
public class SnappingDinoController : MonoBehaviour, IObstacle
{   
    [SerializeField] Animator animator;
    bool snapped; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !snapped)
        {
            snapped = true;
            animator.SetTrigger("Snap");
        }
    }
}

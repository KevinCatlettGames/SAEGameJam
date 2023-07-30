using UnityEngine;

/// <summary>
/// Loops back to <see cref="positionToMoveTo"/> once <see cref="positionToMoveFrom"/> is reached. 
/// </summary>
public class PositionLooping : MonoBehaviour
{  
    [SerializeField] float positionToMoveTo;
    [SerializeField] float positionToMoveFrom;

    private void Update()
    {
        Reposition();
    }
    private void Reposition()
    {
        if (transform.position.x <= positionToMoveFrom)
        {
            transform.position = new Vector3(positionToMoveTo, transform.position.y, transform.position.z);
        }
    }
}

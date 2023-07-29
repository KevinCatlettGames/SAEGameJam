using UnityEngine;

public class PortalArtHandler : MonoBehaviour
{
    PlayerArtHandler playerArtHandler;

    public GameObject twoDArt;
    public GameObject threeDArt;
    private void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player"))
        {
            playerArtHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerArtHandler>();
            if(playerArtHandler.activeObject == playerArtHandler.spriteObject)
            {
                threeDArt.SetActive(false);
            }
            else if (playerArtHandler.activeObject == playerArtHandler.modelObject)
            {
                twoDArt.SetActive(false);
            }
        }
    }
}

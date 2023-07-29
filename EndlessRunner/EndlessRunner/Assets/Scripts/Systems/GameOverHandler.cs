using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    public void LoadScene(int buildindex)
    {
        SceneManager.LoadScene(buildindex);
    }
}

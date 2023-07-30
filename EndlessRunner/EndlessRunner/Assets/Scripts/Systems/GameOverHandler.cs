using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverHandler : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    public AudioSource audioS;
    public AudioClip audioC;

    private void OnEnable()
    {
        audioS.PlayOneShot(audioC);
    }

    public void LoadScene(int buildindex)
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerArtHandler>().DoReset();
        GameManager.Instance.RestartGame();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        gameObject.SetActive(false);
        Destroy(CanvasManager.Instance.gameObject);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }

    public void LoadManaCollectText(int amount)
    {
        text.text = "Your Score: " + amount.ToString();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMana>().ResetScore();
        Time.timeScale = 0;
    }
}

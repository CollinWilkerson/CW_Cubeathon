using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 1f;

    public GameObject completeUI;

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }
    }

    public void win()
    {
        Debug.Log("Win");
        completeUI.SetActive(true);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

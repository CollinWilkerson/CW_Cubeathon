using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Invoker invoker;
    bool gameHasEnded = false;

    public float restartDelay = 1f;

    public GameObject completeUI;

    private void Start()
    {
        invoker = FindAnyObjectByType<Invoker>();
    }

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Invoke("Restart", restartDelay); //calls restart after restart delay, like a one time coroutine
        }
    }

    public void win()
    {
        Debug.Log("Win");
        completeUI.SetActive(true);
    }

    private void Replay()
    {
        
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

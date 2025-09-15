using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    [SerializeField] GameObject[] cameras;
    public float restartDelay = 1f;

    public GameObject completeUI;


    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Invoke("Replay", restartDelay); //calls restart after restart delay, like a one time coroutine
        }
    }

    public void win()
    {
        Debug.Log("Win");
        completeUI.SetActive(true);
    }

    private void Replay()
    {
        foreach (GameObject go in cameras)
        {
            go.SetActive(false);
        }
        cameras[0].SetActive(true);
        HomingTarget.Restart();
        FindAnyObjectByType<playerBehavior>().ResetPosition();
        FindAnyObjectByType<InputHandeler>().StartReplay();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

using UnityEngine;

public class MsgBehavior : MonoBehaviour
{
    [SerializeField] private GameObject message;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FindAnyObjectByType<UIBehavior>().passed500.AddListener(SpawnMessage);
    }

    public void SpawnMessage()
    {
        message.SetActive(true);
    }
}

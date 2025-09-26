using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class UIBehavior : MonoBehaviour
{
    private GameObject Player;
    public UnityEvent passed500;
    public TMP_Text scoreText;
    private void Start()
    {
        if (passed500 == null)
            passed500 = new UnityEvent();

        Player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = Player.transform.position.z.ToString("0");
        if(Player.transform.position.z > 500)
        {
            passed500.Invoke();
        }
    }
}

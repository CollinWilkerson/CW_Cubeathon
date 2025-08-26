using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIBehavior : MonoBehaviour
{
    private GameObject Player;
    public TMP_Text scoreText;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = Player.transform.position.z.ToString("0");
    }
}

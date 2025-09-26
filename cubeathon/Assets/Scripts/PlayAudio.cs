using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    AudioSource yipee;
    [SerializeField] AudioClip thing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        yipee = gameObject.GetComponent<AudioSource>();
        InputHandeler.OnLMB += pleyone;
    }

    // Update is called once per frame
    private void pleyone()
    {
        yipee.PlayOneShot(thing);
    }
}

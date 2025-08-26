using UnityEngine;
using Unity.Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] GameObject activeCamera;
    [SerializeField] GameObject newCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            activeCamera.SetActive(false);
            newCamera.SetActive(true);
        }
    }
}

using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.SceneManagement;

public class NextLvlScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rb; 
    [SerializeField] private UnityEvent OnTriggerEnterEvent;
    [SerializeField] private UnityEvent OnTriggerExitEvent;
    public AudioSource audioSource;
    public GameObject PausePanel;

    void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody == rb) 
        {
            OnTriggerEnterEvent.Invoke();
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
                Debug.Log("12322341243");
            }
            // SceneManager.LoadScene(2);
            PausePanel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody == rb)
        {
            OnTriggerExitEvent.Invoke();
            Debug.Log("OKE");
        }
    }
}

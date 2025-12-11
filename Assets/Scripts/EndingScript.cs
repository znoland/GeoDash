using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour
{
    public string sceneToLoad = "WinScene"; 
    private bool activated = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (activated) return;

        if (other.CompareTag("Player") || other.CompareTag("PlanePlayer"))
        {
            activated = true;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}

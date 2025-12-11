using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string levelScene = "StereoMadness";   

    public void RestartLevel()
    {
        SceneManager.LoadScene(levelScene);
    }
}

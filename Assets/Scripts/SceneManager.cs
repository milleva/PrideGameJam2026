using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void LoadScroogeDate()
    {
        Debug.Log("Loading Scrooge Date Scene...");
        UnityEngine.SceneManagement.SceneManager.LoadScene("ScroogeDate");
    }
}

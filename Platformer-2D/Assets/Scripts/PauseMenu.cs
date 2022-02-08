using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    void Start()
    {
        // Set Time in Game to 0
        Time.timeScale = 0f;
    }
    public static void Resume()
    {
        // Set Time to normal again and close Pause Menu
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("PauseMenu"), UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        Time.timeScale = 1f;
    }
}

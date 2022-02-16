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

    public void SaveGame()
    {
        if(PlayerPrefs.GetInt("player") == 0)
            GameObject.Find("Player").GetComponent<PlayerHealth>().SaveGame(); 
        if(PlayerPrefs.GetInt("player") == 1)
            GameObject.Find("Archer").GetComponent<PlayerHealth>().SaveGame();
    }
}

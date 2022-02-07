using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerPauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    // Update is called once per frame
    void Update()
    {
        // Check if Escape Button got pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape gets recocniced");
            // Look if game is not yet paused and start Pause Menu
            if (!gameIsPaused)
            {
                SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive);
                //SceneManager.SetActiveScene(SceneManager.GetSceneByName("PauseMenu"));
            }
            // If Pause Menu is started and user presses Escape again, close Pause Menu
            if (gameIsPaused)
            {
                PauseMenu.Resume();
            }
            gameIsPaused = !gameIsPaused;
        }
    }
}

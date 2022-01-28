using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private bool isArcher;
    private GameObject archer;
    private GameObject swordsman;
    private GameObject playerSpawn;

    public void SetPlayer(bool isArcherButton)
    {
        isArcher = isArcherButton;
    }
    public void PlayGame()
    {
        swordsman = Resources.Load("Prefabs/Player") as GameObject;
        archer = Resources.Load("Prefabs/Archer") as GameObject;
        if (isArcher)
            Instantiate(archer, new Vector3(3, 2, 0), Quaternion.identity);
        else
            Instantiate(swordsman, new Vector3(2, 1, 0), new Quaternion());
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        playerSpawn = GameObject.Find("PlayerSpawnPoint");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

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
            Instantiate(archer, playerSpawn.transform.position, playerSpawn.transform.rotation);
        else
            Instantiate(swordsman, playerSpawn.transform.position, playerSpawn.transform.rotation);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

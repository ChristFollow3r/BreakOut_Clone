using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Menu_Script : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene"); // It loads the scene called "GameScene"
    }

    public void ExitGame()
    {
        Application.Quit(); // It quits the application
    }
}

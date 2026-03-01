using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Menu_Script : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

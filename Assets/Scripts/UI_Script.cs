using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Script : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI lives;

    private int currentLives = 3;
    private int currentScore = 0;
    private int scoreAddition = 5;

    private void LateUpdate()
    {
        if (currentLives <= 0) SceneManager.LoadScene("Menu");
    }

    public void AddPoints() 
    {
        currentScore += scoreAddition;
        score.text = currentScore.ToString();
    }
    public void AddLives()
    {
        currentLives += 1;
        lives.text = currentLives.ToString();
    }
    public void SubtractLives()
    {
        currentLives -= 1;
        lives.text = currentLives.ToString();
        
    }
    

}

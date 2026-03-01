using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Script : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI lives;

    private GameObject[] balls;
    private GameObject thing;

    private int currentLives = 3;
    private int currentScore = 0;
    private int scoreAddition = 5;

    private void Start()
    {
        thing = GameObject.Find("Thing");
    }

    private void LateUpdate()
    {
        if (currentLives <= 0 && balls.Length == 0) { // Super dirty solution. I have no fucking clue how to fix the lives counter problem.
            SceneManager.LoadScene("Menu"); // Load the menu scene if the player dies
            thing.GetComponent<thingMovement>().actions.Disable(); // And I disable the input system actions so it doesn't give errors about memory leaks
        }
    }

    private void Update()
    {
        balls = GameObject.FindGameObjectsWithTag("Ball");
    }

    public void AddPoints() // This adds points and displays it in the respective UI text
    {
        currentScore += scoreAddition;
        score.text = currentScore.ToString();
    }
    public void AddLives() // This adds lives and displays it in the respective UI text
    {
        currentLives += 1;
        lives.text = currentLives.ToString();
    }
    public void SubtractLives() // This subtracts lives and displays it in the respective UI text
    {
        currentLives -= 1;
        lives.text = currentLives.ToString();
        
    }
    

}

using System.Collections;
using TMPro;
using UnityEngine;

public class UI_Script : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI lives;

    public bool canAdd = false;
    public bool canSubtract = false;

    private int currentLives = 3;
    private int currentScore = 0;
    private int scoreAddition = 5;

    public void Update()
    {
        if (canAdd) StartCoroutine(CRAddPoints());
        if (canSubtract) StartCoroutine(CRSubtractLives());
    }
    public IEnumerator CRAddPoints()
    {
        canAdd = false;
        currentScore += scoreAddition;
        score.text = currentScore.ToString();
        yield return null;
    }
    public IEnumerator CRSubtractLives()
    {
        canSubtract = false;
        currentLives -= 1;
        lives.text = currentLives.ToString();
        yield return null;
    }
    

}

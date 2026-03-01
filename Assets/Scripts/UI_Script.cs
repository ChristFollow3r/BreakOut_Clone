using System.Collections;
using TMPro;
using UnityEngine;

public class UI_Script : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI score;

    public bool canAdd = false;

    private int currentScore = 0;
    private int scoreAddition = 5;

    public void Update()
    {
        if (canAdd) StartCoroutine(CRAddPoints());
    }
    public IEnumerator CRAddPoints()
    {
        canAdd = false;
        currentScore += scoreAddition;
        score.text = currentScore.ToString();
        yield return null;
    }

}

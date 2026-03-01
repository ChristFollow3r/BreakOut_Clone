using UnityEngine;

public class duplicateAllBalls : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    //private GameObject ballManager; // I'm not using this?
    private GameObject UIManager;
    private GameObject[] balls;

    private void Start()
    {
        //ballManager = GameObject.Find("BallManager");
        UIManager = GameObject.Find("UIManager");
        Debug.Log("One spawned");
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Thing"))
        {
            balls = GameObject.FindGameObjectsWithTag("Ball");
            foreach (GameObject x in balls)
            {
                GameObject newBall = Instantiate(ball, new Vector3(Random.Range(-5, 5), Random.Range(-1, -4), 0), Quaternion.identity);
                newBall.GetComponent<ballMovement>().isFromUpgrade = true; // This is crucial so that when this balls die then don't spawn new balls
                UIManager.GetComponent<UI_Script>().AddPoints();
                UIManager.GetComponent<UI_Script>().AddLives();
                Debug.Log("Found a ball");
            }
            Destroy(gameObject);
        }

    }
}

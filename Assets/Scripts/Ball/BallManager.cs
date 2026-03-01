using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    private GameObject UIManager;

    private Vector3 spawnVector;
    private Vector3 spawnRandomVector;

    public bool upgrade = false;
    public bool canSpawn = false;

    private void Start()
    {
        spawnVector = new Vector3(0f, -2f, 0f);
        UIManager = GameObject.Find("UIManager");
    }
    void Update()
    {
        spawnRandomVector = new Vector3(Random.Range(-5,5), -2f, 0f);

        if (canSpawn == true)
        {
            Instantiate(ball, spawnVector, Quaternion.identity);
            Debug.Log("Ball spawned");
            canSpawn = false;
        }
    }

    public void SpawnOneBallHopefully()
    {
        GameObject upgradBall = Instantiate(ball, spawnRandomVector, Quaternion.identity);
        UIManager.GetComponent<UI_Script>().AddLives();
        upgradBall.GetComponent<ballMovement>().isFromUpgrade = true;
    }
}

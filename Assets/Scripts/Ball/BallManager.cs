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
        UIManager = GameObject.Find("UIManager"); // The gameobject in the scene that controlls the game UI
    }
    void Update()
    {
        spawnRandomVector = new Vector3(Random.Range(-5,5), -2f, 0f);

        if (canSpawn == true)
        {
            Instantiate(ball, spawnVector, Quaternion.identity); // Every ball that doesn't come from an upgrade spawns exacly at (0,-2,0)
            Debug.Log("Ball spawned");
            canSpawn = false; // reset so it doesn't keep spawnging balls
        }
    }

    public void SpawnOneBallHopefully() // Reminesence of a nightmare
    {
        GameObject upgradBall = Instantiate(ball, spawnRandomVector, Quaternion.identity); // Spawn balls in a random x position wiht a fixedy position
        UIManager.GetComponent<UI_Script>().AddLives(); // In theory every new ball adds a live to the counter (it doesn't).
        upgradBall.GetComponent<ballMovement>().isFromUpgrade = true; // This is super important so instantited balls don't instantiate balls when they are destroyed
    }
}

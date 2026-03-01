using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] private GameObject ball;

    private Vector3 spawnVector;
    private Vector3 spawnRandomVector;

    public bool upgrade = false;
    public bool canSpawn = false;

    private void Start()
    {
        spawnVector = new Vector3(0f, -2f, 0f);
        spawnRandomVector = new Vector3(Random.Range(-5,5), -2f, 0f);
    }
    void Update()
    {
        if (upgrade == true)
        {
            Instantiate(ball, spawnRandomVector, Quaternion.identity);
            upgrade = false;
        }
        if (canSpawn == true)
        {
            Instantiate(ball, spawnVector, Quaternion.identity);
            Debug.Log("Ball spawned");
            canSpawn = false;
        }
    }
}

using UnityEngine;

public class duplicateAllBalls : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    private GameObject UIManager;
    private GameObject[] balls; // An array of gameobjects

    private void Start()
    {
        UIManager = GameObject.Find("UIManager");
        Debug.Log("One spawned");
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision) // If the upgrades collide with the thing
    {
        if (collision.gameObject.CompareTag("Thing"))
        {
            balls = null; // Before filling the array I set it to null (just in case it keps adding balls over and over). I had a similar problem and thought of this
            balls = GameObject.FindGameObjectsWithTag("Ball"); // I don't think it was the fix but it won't hurt to add it
            foreach (GameObject x in balls) 
            {
                GameObject newBall = Instantiate(ball, new Vector3(Random.Range(-5, 5), Random.Range(-1, -4), 0), Quaternion.identity); // Insantiates the new ball in a random position
                newBall.GetComponent<ballMovement>().isFromUpgrade = true; // This is crucial so that when this balls die then don't spawn new balls
                UIManager.GetComponent<UI_Script>().AddPoints();
                UIManager.GetComponent<UI_Script>().AddLives();
                Debug.Log("Found a ball");
            }
            Destroy(gameObject); // I destroy this game object so it doesn't keep adding balls
        }

    }
}

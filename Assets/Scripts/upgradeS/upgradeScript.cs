using UnityEngine;

public class upgradeScript : MonoBehaviour
{
    private GameObject ballManager;
    private GameObject UIManager;
    private int chance;

    private void Start()
    {
        ballManager = GameObject.Find("BallManager");
        UIManager = GameObject.Find("UIManager");
        Debug.Log("One spawned");
        chance = Random.Range(1, 101);
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Thing"))
        {
            if (chance >= 70) ballManager.GetComponent<BallManager>().SpawnOneBallHopefully(); // This is very weird.
            Debug.Log("Entered");                                     // I'm probably not instantiating the ball here because
            UIManager.GetComponent<UI_Script>().AddPoints();          // of some serious trauma the ball spawning mechanic has caused me.
            Destroy(gameObject); // This way I dont spawn more than one ball ---> Reminesence of the trauma (+1h to find bug)
        }
        
    }
}

using UnityEngine;

public class upgradeScript : MonoBehaviour
{
    private GameObject ballManager;
    private int chance;

    private void Start()
    {
        ballManager = GameObject.Find("BallManager");
        Debug.Log("One spawned");
        chance = Random.Range(1, 101);
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Thing"))
        {
            if (chance >= 70) ballManager.GetComponent<BallManager>().SpawnOneBallHopefully();
            Debug.Log("Entered");
            Destroy(gameObject); // This way I dont spawn more than one ball
        }
        
    }
}

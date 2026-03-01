using UnityEngine;

public class upgradeScript : MonoBehaviour
{
    private BallManager ballManager;
    private int chance;

    private void Start()
    {
        chance = Random.Range(1, 101);
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Thing"))
        {
            if (chance >= 70) ballManager.GetComponent<BallManager>().upgrade = true;
            Destroy(gameObject); // This way I dont spawn more than one ball
        }
        
    }
}

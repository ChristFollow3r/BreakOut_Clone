using UnityEngine;

public class shotgunUpgrade : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    private GameObject thing;
    //private GameObject ballManager;
    private GameObject UIManager;

    private void Start()
    {
        //ballManager = GameObject.Find("BallManager");
        UIManager = GameObject.Find("UIManager");
        thing = GameObject.Find("Thing");
        Debug.Log("One spawned");
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Thing"))
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject newBall = Instantiate(ball, new Vector3(thing.transform.position.x, thing.transform.position.y + 0.3f, 0), Quaternion.identity); // + 0.3 so it doesnt spawn right where the thing is
                newBall.GetComponent<ballMovement>().isFromUpgrade = true; // This is crucial so that when this balls die then don't spawn new balls
                UIManager.GetComponent<UI_Script>().AddPoints();
                UIManager.GetComponent<UI_Script>().AddLives();
            }

            Destroy(gameObject);
        }

    }
}

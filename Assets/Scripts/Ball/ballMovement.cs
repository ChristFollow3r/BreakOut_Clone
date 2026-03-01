using UnityEngine;

public class ballMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private GameObject thing;
    private GameObject UIManager;
    private GameObject BallManager;

    private float ballSpeed = 1.3f;
    private float sizeDecrese = 0.2f;

    private Vector3 newScale;

    private bool layer2 = false;
    private bool layer3 = false;
    private bool layer4 = false;
    private bool layer5 = false;

    public bool isFromUpgrade = false; // This. Holy moly...

    private void Awake()
    {
        float num1 = Random.Range(3, 5);
        float num2 = Random.Range(3, 5);

        thing = GameObject.Find("Thing");
        UIManager = GameObject.Find("UIManager");
        BallManager = GameObject.Find("BallManager");

        newScale = new Vector3(sizeDecrese, 0, 0);

        if (!isFromUpgrade) rb.linearVelocity = new Vector2(num1, num2);


    }

    private void Update()
    {
        if (rb.transform.position.y < -7f)
        {
            UIManager.GetComponent<UI_Script>().SubtractLives();
            if (!isFromUpgrade)
            {
                BallManager.GetComponent<BallManager>().canSpawn = true;
            }
            Destroy(gameObject); // This should destroy the ball and the script and everything
        }

        if (!isFromUpgrade)
        {
            layer2 = true;
            layer3 = true;
            layer4 = true;
            layer5 = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float currentBallSpeed = rb.linearVelocity.magnitude;

        if (collision.CompareTag("Right")) rb.linearVelocity *= new Vector2 (-1, 1); // I can see this is repeated code but I tried to change it and it gave me errors
        else if (collision.CompareTag("Left")) rb.linearVelocity *= new Vector2 (-1, 1); // So it'll stay like this...
        else if (collision.CompareTag("Top")) rb.linearVelocity *= new Vector2 (1, -1);
        else if (collision.CompareTag("Middle")) rb.linearVelocity = new Vector2 (0, currentBallSpeed);
        else if (collision.CompareTag("tRight")) rb.linearVelocity = new Vector2 (1, currentBallSpeed);
        else if (collision.CompareTag("tLeft")) rb.linearVelocity = new Vector2 (-1, currentBallSpeed);

        if (collision.gameObject.GetComponent<brickLife>())
        {
            collision.gameObject.GetComponent<brickLife>().lives--; // This is triggering multiple times. It's a know bug. I'm not going to fix it.
            collision.gameObject.GetComponent<brickLife>().ThisIsDrivingMeNuts();
            //Debug.Log(collision.gameObject.GetComponent<brickLife>().lives--);
        }

        if (collision.gameObject.GetComponent<ballMovement>() == null) return;

        if (collision.gameObject.layer == 7 && layer2) // Some serious trauma
        {
            rb.linearVelocity *= ballSpeed;
            thing.transform.localScale = newScale;
            layer2 = false;
        }

        else if (collision.gameObject.layer == 8 && layer3)
        {
            rb.linearVelocity *= ballSpeed;
            thing.transform.localScale -= newScale;
            //newScale -= new Vector3(sizeDecrese, 0, 0);
            layer3 = false;
        }
        else if (collision.gameObject.layer == 9 && layer4)
        {
            rb.linearVelocity *= ballSpeed;
            //newScale.x -= sizeDecrese;
            thing.transform.localScale -= newScale;
            layer4 = false;
        }
        else if (collision.gameObject.layer == 10 && layer5)
        {
            rb.linearVelocity *= ballSpeed;
            thing.transform.localScale -= newScale;
            layer5 = false;
        }
    }
}

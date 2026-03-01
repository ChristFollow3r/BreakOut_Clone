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

    private bool layer2 = true;
    private bool layer3 = true;
    private bool layer4 = true;
    private bool layer5 = true;

    private void Awake()
    {
        float num1 = Random.Range(3, 5);
        float num2 = Random.Range(3, 5);

        thing = GameObject.Find("Thing");
        UIManager = GameObject.Find("UIManager");
        BallManager = GameObject.Find("BallManager");

        newScale = thing.transform.localScale;
        newScale -= new Vector3(sizeDecrese,0,0);

        rb.linearVelocity = new Vector2(num1, num2);
    }

    private void Update()
    {
        if (rb.transform.position.y < -7f)
        {
            UIManager.GetComponent<UI_Script>().SubtractLives();
            BallManager.GetComponent<BallManager>().canSpawn = true;
            thing.transform.localScale = new Vector3(1.5f, 0.2f, 0f);
            Destroy(gameObject); // This should desttroy the script 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float currentBallSpeed = rb.linearVelocity.magnitude;
        if (collision.CompareTag("Right")) rb.linearVelocity *= new Vector2 (-1, 1); // I can see this is repeated code but I tried to change it and it gave me errors
        else if (collision.CompareTag("Left")) rb.linearVelocity *= new Vector2 (-1, 1); // So it'll stay like this...
        else if (collision.CompareTag("Top")) rb.linearVelocity *= new Vector2 (1, -1);
        else if (collision.CompareTag("Thing")) rb.linearVelocity *= new Vector2 (1, -1);
        else if (collision.CompareTag("Middle")) rb.linearVelocity = new Vector2 (0, currentBallSpeed); // To do: Decrease raycast length and collider size
        else if (collision.CompareTag("tRight")) rb.linearVelocity = new Vector2 (1, currentBallSpeed);
        else if (collision.CompareTag("tLeft")) rb.linearVelocity = new Vector2 (-1, currentBallSpeed);

        if (collision.gameObject.GetComponent<brickLife>())
        {
            collision.gameObject.GetComponent<brickLife>().lives--; // This is triggering multiple times. It's a know bug. I'm not going to fix it.
            collision.gameObject.GetComponent<brickLife>().ThisIsDrivingMeNuts();
            Debug.Log(collision.gameObject.GetComponent<brickLife>().lives--);
        }

        if (collision.gameObject.layer == 7 && layer2)
        {
            rb.linearVelocity *= ballSpeed;
            thing.transform.localScale = newScale;
            newScale -= new Vector3(sizeDecrese, 0, 0);
            layer2 = false;
        }

        else if (collision.gameObject.layer == 8 && layer3)
        {
            rb.linearVelocity *= ballSpeed;
            thing.transform.localScale = newScale;
            newScale -= new Vector3(sizeDecrese, 0, 0);
            layer3 = false;
        }
        else if (collision.gameObject.layer == 9 && layer4)
        {
            rb.linearVelocity *= ballSpeed;
            newScale.x -= sizeDecrese;
            thing.transform.localScale = newScale;
            newScale -= new Vector3(sizeDecrese, 0, 0);
            layer4 = false;
        }
        else if (collision.gameObject.layer == 10 && layer5)
        {
            rb.linearVelocity *= ballSpeed;
            thing.transform.localScale = newScale;
            newScale -= new Vector3(sizeDecrese, 0, 0);
            layer5 = false;
        }
    }
}

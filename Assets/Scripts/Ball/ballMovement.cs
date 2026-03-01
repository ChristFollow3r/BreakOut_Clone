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

    private bool layer2 = false; // This were set up to false in an attempt to fix the platform not shrinking in size
    private bool layer3 = false; // It didn't work though
    private bool layer4 = false;
    private bool layer5 = false;

    public bool isFromUpgrade = false; // This. Holy moly...

    private void Awake()
    {
        float num1 = Random.Range(3, 5); // Random speed for the new balls
        float num2 = Random.Range(3, 5); 

        thing = GameObject.Find("Thing");
        UIManager = GameObject.Find("UIManager");
        BallManager = GameObject.Find("BallManager");

        newScale = new Vector3(sizeDecrese, 0, 0); // Maybe the size thing works but it's beeing reset everytime this script is being called idk

        if (!isFromUpgrade) rb.linearVelocity = new Vector2(num1, num2);


    }

    private void Update()
    {
        if (rb.transform.position.y < -7f) // Destroy the balls that go below a certain threshold
        {
            UIManager.GetComponent<UI_Script>().SubtractLives(); // Subtracts lives from the live counter

            if (!isFromUpgrade) // If the ball isn't instantiated from an upgrade sets canSpawn to true
            {
                BallManager.GetComponent<BallManager>().canSpawn = true;
            }
            Destroy(gameObject); // This should destroy the ball and the script and everything
        }

        if (!isFromUpgrade) // This was an attempt to fix the thing size issue. Didn't work.
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
        else if (collision.CompareTag("Middle")) rb.linearVelocity = new Vector2 (0, currentBallSpeed); // This three here are for the thing
        else if (collision.CompareTag("tRight")) rb.linearVelocity = new Vector2 (1, currentBallSpeed); // If it hits the middle goes up, left left, right right.
        else if (collision.CompareTag("tLeft")) rb.linearVelocity = new Vector2 (-1, currentBallSpeed); // I got it though trial and error

        if (collision.gameObject.GetComponent<brickLife>())
        {
            collision.gameObject.GetComponent<brickLife>().lives--; // This is triggering multiple times. It's a know bug. I'm not going to fix it.
            // (UPDATE) I think the brick lives system works properly now but im not totally sure (and it got fixed by error).
            collision.gameObject.GetComponent<brickLife>().ThisIsDrivingMeNuts(); // MY bad setting up a bad name for the function. Dont really know what it does here
            //Debug.Log(collision.gameObject.GetComponent<brickLife>().lives--);     I'll just explain it where it's defined
        }

        if (collision.gameObject.GetComponent<ballMovement>() == null) return; // This came from asking IA cause I was getting error of null reference
        // Aparently I was checking for scripts within the balls that were already destroyed (while the ball was still alive) and it threw a shit ton of null reference errors

        if (collision.gameObject.layer == 7 && layer2) // This might as well don't be here cause I think rn it's not working at all
        {                                              // This was my system for making the thing smaller and the balls go faster upon reaching each brick level
            rb.linearVelocity *= ballSpeed;            // It worked (You can go to previous commits to check it ou), but when I started instantiating new balls
            thing.transform.localScale = newScale;     // everything went south
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

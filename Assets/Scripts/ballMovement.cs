using UnityEngine;

public class ballMovement : MonoBehaviour
{
    [SerializeField] private GameObject thing;
    [SerializeField] private Rigidbody2D ball;

    private float ballSpeed = 1.3f;
    private float sizeDecrese = 0.2f;
    private Vector3 newScale;

    private bool layer2 = true;
    private bool layer3 = true;
    private bool layer4 = true;
    private bool layer5 = true;

    private void Start()
    {
        float num1 = Random.Range(3, 5);
        float num2 = Random.Range(3, 5);
        newScale = thing.transform.localScale;
        newScale -= new Vector3(sizeDecrese,0,0);

        ball.linearVelocity = new Vector2(num1, num2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Right")) ball.linearVelocity *= new Vector2 (-1, 1);
        else if (collision.CompareTag("Left")) ball.linearVelocity *= new Vector2(-1, 1);
        else if (collision.CompareTag("Top")) ball.linearVelocity *= new Vector2(1, -1);
        else if (collision.CompareTag("Thing")) ball.linearVelocity *= new Vector2(1, -1);

        if (collision.gameObject.GetComponent<brickLife>())
        {
            collision.gameObject.GetComponent<brickLife>().lives--;
            Debug.Log("Hit");
        }

        if (collision.gameObject.layer == 7 && layer2)
        {
            ball.linearVelocity *= ballSpeed;
            thing.GetComponent<thingMovement>().thingSpeed += 1.2f;
            thing.transform.localScale = newScale;
            newScale -= new Vector3(sizeDecrese, 0, 0);
            layer2 = false;
        }

        else if (collision.gameObject.layer == 8 && layer3)
        {
            ball.linearVelocity *= ballSpeed;
            thing.GetComponent<thingMovement>().thingSpeed += 1.2f;
            thing.transform.localScale = newScale;
            newScale -= new Vector3(sizeDecrese, 0, 0);
            layer3 = false;
        }
        else if (collision.gameObject.layer == 9 && layer4)
        {
            ball.linearVelocity *= ballSpeed;
            thing.GetComponent<thingMovement>().thingSpeed += 1.2f;
            newScale.x -= sizeDecrese;
            thing.transform.localScale = newScale;
            newScale -= new Vector3(sizeDecrese, 0, 0);
            layer4 = false;
        }
        else if (collision.gameObject.layer == 10 && layer5)
        {
            ball.linearVelocity *= ballSpeed;
            thing.GetComponent<thingMovement>().thingSpeed += 1.2f;
            thing.transform.localScale = newScale;
            newScale -= new Vector3(sizeDecrese, 0, 0);
            layer5 = false;
        }
    }
}

using UnityEngine;

public class ballMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D ball;
    private float ballSpeed = 5f;

    private void Start()
    {
        float num1 = Random.Range(1, 4);
        float num2 = Random.Range(1, 4);

        ball.linearVelocity = new Vector2(num1, num2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Right")) ball.linearVelocity *= new Vector2 (-1, 1);
        else if (collision.CompareTag("Left")) ball.linearVelocity *= new Vector2(-1, 1);
        else if (collision.CompareTag("Top")) ball.linearVelocity *= new Vector2(1, -1);
        else if (collision.CompareTag("Thing")) ball.linearVelocity *= new Vector2(1, -1);
    }
}

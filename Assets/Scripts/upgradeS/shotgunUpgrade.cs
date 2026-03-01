using System.Runtime.CompilerServices;
using UnityEngine;

public class shotgunUpgrade : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    private GameObject thing;
    private GameObject UIManager;

    private void Start()
    {
        UIManager = GameObject.Find("UIManager");
        thing = GameObject.Find("Thing");
        Debug.Log("One spawned");
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision) // It sapwns three balls 0.1f above the thing towards random directions
    {
        if (collision.gameObject.CompareTag("Thing"))
        {
            bool direction = true;

            for (int i = 0; i < 3; i++)
            {
                int num1 = Random.Range(4, 6);
                int num2 = Random.Range(4, 6);
                float num3 = Random.Range(0f, 1.5f);

                GameObject newBall = Instantiate(ball, new Vector3(thing.transform.position.x +  num3, thing.transform.position.y + 0.1f, 0), Quaternion.identity); // + 0.3 so it doesnt spawn right where the thing is
                newBall.GetComponent<ballMovement>().isFromUpgrade = true; // This is crucial so that when this balls die then don't spawn new balls
                num1 = direction == true ? num1 : -num1; // Without this the three bals go towards the same direction and I don't know what else I can do to prevent it
                direction = !direction;
                newBall.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(num1, num2);
                UIManager.GetComponent<UI_Script>().AddPoints();
                UIManager.GetComponent<UI_Script>().AddLives(); // IT'S ADDING LIVES!!!
            }

            Destroy(gameObject); // No more balls please
        }

    }
}

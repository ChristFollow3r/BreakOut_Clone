using UnityEngine;
using UnityEngine.Windows;

public class thingMovement : MonoBehaviour
{
    [SerializeField] private GameObject thing;

    private Collider2D collider;
    private InputSystem_Actions actions;

    private Vector2 movement;

    private float thingSpeed = 14f;
    private float thingSize;

    private Vector2 safePosition;
    private void Start()
    {
        // This gets the collider2D component atached to the same object that has this script atached to
        collider = GetComponent<Collider2D>();
        // I dont know how to explain this but it's pretty self explanatory
        actions = new InputSystem_Actions();
        // This enables it
        actions.Player.Enable();
    }

    private void Update()
    {
        safePosition = thing.transform.position;
        ThingMovement();
        CheckCollision();
    }

    private void ThingMovement()
    {
        // Reads the value of the input
        movement = actions.Player.Move.ReadValue<Vector2>();
        Debug.Log(movement);

        // Moves the thing
        if (movement.x > 0) thing.transform.position += new Vector3(movement.x * thingSpeed * Time.deltaTime, 0);
        else if (movement.x < 0) thing.transform.position += new Vector3(movement.x * thingSpeed * Time.deltaTime, 0);

    }

    private void CheckCollision()
    {
        RaycastHit2D lHit = Physics2D.Raycast(thing.transform.position, Vector2.left, 0.5f);
        RaycastHit2D rHit = Physics2D.Raycast(thing.transform.position, Vector2.right, 0.5f);

        if (lHit) thing.transform.position = safePosition;
        if (rHit) thing.transform.position = safePosition;
    }

    
}

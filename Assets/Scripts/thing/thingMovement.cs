using UnityEngine;

public class thingMovement : MonoBehaviour // I genually don't know how to call thins thing in english so throughout he program it'll be called "THING"
{
    [SerializeField] private GameObject thing;

    public InputSystem_Actions actions;

    private Vector2 movement;

    public float thingSpeed = 14f;
    public float thingSize;

    private Vector2 safePosition;
    private void Start()
    {
        // I dont know how to explain this but it's pretty self explanatory
        actions = new InputSystem_Actions(); // It's from the new input system (apparently not the best way to use it, but it works just fine)
        actions.Player.Enable(); // This enables it
    }

    private void Update()
    {
        safePosition = thing.transform.position; // Stores a safe position to use whenever the raycast hits.
        ThingMovement();
        CheckCollision();
    }

    private void ThingMovement()
    {
        // Reads the value of the input
        movement = actions.Player.Move.ReadValue<Vector2>();
        //Debug.Log(movement);

        // Moves the thing
        if (movement.x > 0) thing.transform.position += new Vector3(movement.x * thingSpeed * Time.deltaTime, 0);
        else if (movement.x < 0) thing.transform.position += new Vector3(movement.x * thingSpeed * Time.deltaTime, 0);

    }

    private void CheckCollision()
    {
        float rayLength = thing.transform.localScale.x / 2;
        RaycastHit2D lHit = Physics2D.Raycast(thing.transform.position, Vector2.left, rayLength); // This shoots a ray towards the left of the thing
        RaycastHit2D rHit = Physics2D.Raycast(thing.transform.position, Vector2.right, rayLength); // This shoots a ray towards the right of the thing

        // This basically acts as a collider. The only difference is that this wont allow the thing to clip through the wall.

        if (lHit) thing.transform.position = safePosition; // If it hits it inmediatly teleports it to the last position it didn't hit
        if (rHit) thing.transform.position = safePosition;
    }

    
}

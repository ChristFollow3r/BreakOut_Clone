using UnityEngine;
using UnityEngine.Windows;

public class thingMovement : MonoBehaviour
{
    [SerializeField] private GameObject thing;
    /// <summary>
    /// This is a collider
    /// </summary>
    private Collider2D collider;
    /// <summary>
    /// This is a reference to the input system action map or something like that
    /// </summary>
    private InputSystem_Actions actions;
    /// <summary>
    /// This is a vector 2
    /// </summary>
    private Vector2 movement;
    /// <summary>
    /// This is a decimal number
    /// </summary>
    private float thingSpeed = 7f;
    /// <summary>
    /// This is also a decimal number
    /// </summary>
    private float thingSize;
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
        ThingMovement();
    }

    private void ThingMovement()
    {
        movement = actions.Player.Move.ReadValue<Vector2>();
        Debug.Log(movement);

        if (movement.x > 0) thing.transform.position += new Vector3(movement.x * thingSpeed * Time.deltaTime, 0);
        else if (movement.x < 0) thing.transform.position += new Vector3(movement.x * thingSpeed * Time.deltaTime, 0);

    }

    
}

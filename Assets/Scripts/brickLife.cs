using UnityEngine;

public class brickLife : MonoBehaviour
{
    [SerializeField] public int lives;
    private SpriteRenderer sprite;
    private BoxCollider2D colldier;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        colldier = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (lives <= 0)
        {
            Destroy(sprite);
            Destroy(colldier);
        }
    }
}

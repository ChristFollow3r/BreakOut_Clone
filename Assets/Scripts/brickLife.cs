using UnityEngine;

public class brickLife : MonoBehaviour
{
    [SerializeField] public int lives;
    [SerializeField] private GameObject UIManager;

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
            UIManager.GetComponent<UI_Script>().canAdd = true;
            Destroy(this); // I destroy the script so my counter's dont go nuts
        }
    }

}

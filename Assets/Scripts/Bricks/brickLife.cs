using UnityEngine;

public class brickLife : MonoBehaviour
{
    [SerializeField] public int lives;
    [SerializeField] private GameObject UIManager; // This works on all the prefabs cause I manually added it on all the prefabs :V
    // I could just do GameObject.Find() but it already works so I'm not touching it.
    [SerializeField] private GameObject sBallUpgrade;
    [SerializeField] private GameObject plentyBallsUpgrade;
    [SerializeField] private GameObject shotgunUpgrade;

    private SpriteRenderer sprite;
    private BoxCollider2D colldier;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        colldier = GetComponent<BoxCollider2D>();
    }
    
    public void ThisIsDrivingMeNuts()
    {
        if (lives <= 0)
        {
            int chance = Random.Range(1, 101);

            if (chance <= 10) Instantiate(sBallUpgrade, transform.position, Quaternion.identity);
            else if (chance > 10 && chance <= 20) Instantiate(shotgunUpgrade, transform.position, Quaternion.identity);
            else if (chance > 20 && chance <= 30) Instantiate(plentyBallsUpgrade, transform.position, Quaternion.identity);

            Destroy(sprite);
            Destroy(colldier);
            Destroy(gameObject);
            UIManager.GetComponent<UI_Script>().AddPoints();
        }
    }

}

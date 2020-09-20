using UnityEngine;

public class Block : MonoBehaviour
{
    public void Start()
    {
        GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponentInParent<ScoreManager>().AddScore();
        GetComponentInParent<BlockSetGenerator>().PlayBlockDestroyedSound();
        Destroy(gameObject);
    }
}

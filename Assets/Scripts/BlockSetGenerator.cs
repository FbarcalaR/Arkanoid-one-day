using UnityEngine;

public class BlockSetGenerator : MonoBehaviour
{
    public GameObject blockPrefab;
    public int blocksWide = 7;
    public int blocksTall = 4;
    public AudioSource audioOnDestroy;

    public void Start()
    {
        float sizeX = blockPrefab.GetComponent<SpriteRenderer>().size.x;
        float sizeY = blockPrefab.GetComponent<SpriteRenderer>().size.y;

        for (int i = 0; i < blocksWide; i++)
        {
            for (int j = 0; j < blocksTall; j++)
            {
                Vector3 instantiatePosition = new Vector3(sizeX * i, sizeY * j, 0f) + transform.position;
                var newBlock = Instantiate(blockPrefab, instantiatePosition, Quaternion.identity);
                newBlock.transform.SetParent(gameObject.transform);
            }
        }
    }

    public void PlayBlockDestroyedSound()
    {
        audioOnDestroy.Play();
    }
}

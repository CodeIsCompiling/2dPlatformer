using UnityEngine;

public class Coin : MonoBehaviour
{
    public Collectables collectables;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collectables.CoinsCollected++;
        Destroy(gameObject);
    }
}

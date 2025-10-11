using UnityEngine;

namespace Collectables
{
    public class Coin : MonoBehaviour
    {
        public Collectable collectable;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            collectable.CoinsCollected++;
            Destroy(gameObject);
        }
    }
}

using Player_2;
using UnityEngine;

namespace Collectables
{
    public class DoubleJumpBooster : MonoBehaviour
    {
        public int jumpBoost;
        private void OnTriggerEnter2D(Collider2D other)
        {
            Player2Mover player2Mover = other.gameObject.GetComponent<Player2Mover>();
            if (player2Mover.maxJumps < jumpBoost)
            {
                player2Mover.maxJumps = jumpBoost;
            }
            Destroy(gameObject);
        }
    }
}
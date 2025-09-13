using UnityEngine;

namespace Player_2
{
    public class Player2Mover : MonoBehaviour
    {
        public Rigidbody2D rb;
        public int speed = 10;
        public float groundCheckDistance = 0.1f;
        public LayerMask groundLayer;
        private void FixedUpdate()
        {
            float moveInputX = 0f;
        
            if (Input.GetKey(KeyCode.A))
            {
                transform.localScale = new Vector3(-1, 1, 1);
                moveInputX = -1;
            }
        
            if (Input.GetKey(KeyCode.D))
            {
                transform.localScale = new Vector3(1, 1, 1);
                moveInputX = 1;
            }
            
            RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(0.65f, 2.05f, 0), Vector2.right, groundCheckDistance, groundLayer);

            if (hit.collider != null && Input.GetKey(KeyCode.W))
            {
                rb.linearVelocityY = 10;
            }
            rb.linearVelocityX = moveInputX * speed;
        }
        
    }
}

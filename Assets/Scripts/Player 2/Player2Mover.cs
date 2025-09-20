using System;
using UnityEngine;

namespace Player_2
{
    public class Player2Mover : MonoBehaviour
    {
        public Rigidbody2D rb;
        public int speed = 10;
        public float groundCheckDistance = 0.1f;
        public LayerMask groundLayer;
        public Transform groundCheck;
        public Vector2 groundCheckSize;
        [SerializeField] private Vector3 halfExtents = new Vector3(0.5f, 0.5f, 0.5f);
        
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

            RaycastHit2D hit = Physics2D.BoxCast(groundCheck.position, groundCheckSize, 0f, Vector2.down, groundCheckDistance, groundLayer);
            
            if (hit.collider != null && Input.GetKey(KeyCode.W))
            {
                rb.linearVelocityY = 10;
            }
            rb.linearVelocityX = moveInputX * speed;
            
        }

        /*private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

      
            Vector3 dir = transform.forward;


            Vector3 start = transform.position;
            Vector3 end = start + dir * groundCheckDistance;


            Gizmos.DrawLine(start, end);


            Gizmos.DrawWireCube(start, halfExtents * 2);


            Gizmos.DrawWireCube(end, halfExtents * 2);
        }*/
    }
}

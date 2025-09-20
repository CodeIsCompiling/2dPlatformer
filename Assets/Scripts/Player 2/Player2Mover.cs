using System;
using UnityEngine;

namespace Player_2
{
    
    public class Player2Mover : MonoBehaviour
    {
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Grounded = Animator.StringToHash("Grounded");
        public Rigidbody2D rb;
        public int speed = 10;
        public float groundCheckDistance = 0.1f;
        public LayerMask groundLayer;
        public Transform groundCheck;
        public Vector2 groundCheckSize;
        public Animator animator;
        public Collider2D collider2d;
        [SerializeField] private Vector3 halfExtents = new Vector3(0.5f, 0.5f, 0.5f);

        void OnDestroy()
        {
            SetBounce(0f);
        }

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
            bool isGrounded = hit.collider != null;
            if (isGrounded && Input.GetKey(KeyCode.W))
            {
                rb.linearVelocityY = 10;
            }
            rb.linearVelocityX = moveInputX * speed;
            animator.SetFloat(Speed,  MathF.Abs(moveInputX));
            animator.SetBool(Grounded, isGrounded);
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
        public void SetBounce(float bounce)
        {
            collider2d.sharedMaterial.bounciness = bounce;
        }
    }
}

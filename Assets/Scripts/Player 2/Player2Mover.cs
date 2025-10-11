using System;
using DG.Tweening;
using Player;
using Unity.VisualScripting;
using UnityEngine;

namespace Player_2
{
    
    public class Player2Mover : MonoBehaviour
    {
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Grounded = Animator.StringToHash("Grounded");
        private static readonly int Dashing = Animator.StringToHash("Dashing");
        public Rigidbody2D rb;
        public float speed = 10;
        public float groundCheckDistance = 0.1f;
        public LayerMask groundLayer;
        public Transform groundCheck;
        public Vector2 groundCheckSize;
        public Animator animator;
        public Collider2D collider2d;
        public int maxDashes = 100;
        public int dashesLeft;
        public int directionFaced = 1;
        public float dashSpeed = 0.2f;
        public WallChecker  wallChecker;
        public GroundChecker  groundChecker;
        public bool isGrounded;
        public bool isDashing;
        public bool jumpInAir = true;
        public int maxJumps = 2;
        public int currentJumps = 0;
        private Tweener _dashTweener;
        private float moveInputX = 0f;
        [SerializeField] private Vector3 halfExtents = new Vector3(0.5f, 0.5f, 0.5f);

        private void OnEnable()
        {
            wallChecker.OnWallTouched += WallTouched;
            groundChecker.OnGroundTouched += GroundTouched;
        }

        private void OnDisable()
        {
            wallChecker.OnWallTouched -= WallTouched;
            groundChecker.OnGroundTouched -= GroundTouched;
        }
        
        private void WallTouched(bool isTouched)
        {
            if (isTouched)
            {
                _dashTweener?.Kill();
                isDashing = false;
            }
        }
        
        //Ground touched
        private void GroundTouched(bool isTouched)
        {
            if (isTouched)
            {
                currentJumps = 0;
            }
            isGrounded = isTouched;
        }
        // Makes you not bouncy
        void OnDestroy()
        {
            SetBounce(0f);
        }
        
        // Every Frame Update
        private void FixedUpdate()
        {
            //Moving
            rb.linearVelocityX = moveInputX * speed;
            
        }

        private void Update()
        {
            // Dashing
            if (isGrounded)
            {
                dashesLeft = maxDashes;
            }
            bool canDash = (dashesLeft > 0);
            
            if (canDash && Input.GetKeyDown(KeyCode.F) && !wallChecker.isTouchingWall)
            {
                Dash();
            }
            
            // Jumping
            if (currentJumps < maxJumps && Input.GetKeyDown(KeyCode.W))
            {
                rb.linearVelocityY = 10;
                currentJumps++;
                isGrounded = false;
            }
            
            //Moving
            moveInputX = 0;
            if (Input.GetKey(KeyCode.A))
            {
                if (!isDashing)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    directionFaced = -1;
                }
                moveInputX = -1;
            }
        
            if (Input.GetKey(KeyCode.D))
            {
                if (!isDashing)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    directionFaced = 1;
                }
                moveInputX = 1;
            }
            
            // Animations
            animator.SetFloat(Speed,  MathF.Abs(moveInputX));
            animator.SetBool(Grounded, isGrounded);
            animator.SetBool(Dashing, isDashing);
        }

        // Set Bouncyness
        public void SetBounce(float bounce)
        {
            collider2d.sharedMaterial.bounciness = bounce;
        }
        
        //Dash
        private void Dash()
        {
            rb.linearVelocityY = 0;
            isDashing = true;
            _dashTweener = rb.DOMoveX(13 * directionFaced + rb.transform.position.x, dashSpeed).SetEase(Ease.Linear).OnComplete(OnDashComplete);
            dashesLeft--;
        }

        private void OnDashComplete()
        {
            isDashing = false;
            _dashTweener = null;
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
//Make Dash Work
//Add ui
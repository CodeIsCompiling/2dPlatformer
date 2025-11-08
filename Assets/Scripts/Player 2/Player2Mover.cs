using System;
using DG.Tweening;
using UnityEngine;

namespace Player_2
{
    
    public class Player2Mover : MonoBehaviour
    {
        public Rigidbody2D rb;
        public float speed = 10;
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
        public int maxJumps = 2;
        public int currentJumps;
        public float acceleration;
        public bool isTouchingWall;
        public bool canWallJump;
        public bool canWallCling;
        public Player2 player2;
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Grounded = Animator.StringToHash("Grounded");
        private static readonly int Dashing = Animator.StringToHash("Dashing");
        private Tweener _dashTweener;
        private float _moveInputX;

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
            isTouchingWall = isTouched;
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
            float targetVelocityX = _moveInputX * speed;
            float smoothedVelocityX = Mathf.Lerp(rb.linearVelocityX, targetVelocityX, acceleration * Time.fixedDeltaTime);
            rb.linearVelocityX = smoothedVelocityX;

        }

        private void Update()
        {
            
            // Dashing
            if (isGrounded)
            {
                dashesLeft = maxDashes;
            }
            bool canDash = (dashesLeft > 0);
            
            if (canDash && Input.GetKeyDown(KeyCode.Mouse0) && !wallChecker.isTouchingWall)
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
            
            // Wall Jumping
            if (canWallJump)
            {
                if (isTouchingWall && Input.GetKeyDown(KeyCode.W))
                {
                    rb.linearVelocityY = 1 * speed;
                    rb.linearVelocityX = 1 * speed * -directionFaced;
                    dashesLeft = maxDashes;
                    currentJumps = 0;
                }
            }
            
            // Wall Cling
            if (!canWallCling)
            {
                if (isTouchingWall && !isGrounded)
                {
                    rb.linearVelocityX = 0.2f * speed * -directionFaced;;
                }
            }
            
            //Moving
            _moveInputX = 0;
            if (Input.GetKey(KeyCode.A))
            {
                if (!isDashing && !isTouchingWall)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    directionFaced = -1;
                }
                _moveInputX = -1;
            }
        
            if (Input.GetKey(KeyCode.D))
            {
                if (!isDashing)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    directionFaced = 1;
                }
                _moveInputX = 1;
            }
            
            // Animations
            animator.SetFloat(Speed,  MathF.Abs(_moveInputX));
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
            isDashing = true;
            DashParticles dashParticles = player2.DashParticlesPool.Get();
            dashParticles.gameObject.transform.localScale = transform.localScale;
            dashParticles.transform.position = transform.position + new Vector3(-1 * transform.localScale.x, -1.25f, 0);
            //_dashTweener = rb.DOMoveX(7 * directionFaced + rb.transform.position.x, dashSpeed).SetEase(Ease.Linear).OnComplete(OnDashComplete);
            rb.AddForceX(100 * directionFaced * speed);
            DOVirtual.DelayedCall(dashSpeed, OnDashComplete);
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
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerMover : MonoBehaviour
    {
        public Rigidbody2D rb;
        public int speed = 10;
        public float moveInputY = 0f;
        public float gravity = 100f;
        private void FixedUpdate()
        {
            Vector2 moveVector = new Vector3(0, 0, 0);
            float moveInputX = 0f;
            
            //transform.Translate(Vector3.down * Time.deltaTime);
            //if (Input.GetKey(KeyCode.W))
            {
                //moveVector += Vector2.up * speed;
                //rb.linearVelocity = Vector2.up * Time.deltaTime;
                
            }

            //if (Input.GetKey(KeyCode.S))
            {
                //moveVector += Vector2.down * speed;
            }

            if (Input.GetKey(KeyCode.A))
            {
                //moveVector += Vector2.left * speed;
                transform.localScale = new Vector3(-1, 1, 1);
                moveInputX = -1;
            }

            if (Input.GetKey(KeyCode.D))
            {
                //moveVector += Vector2.right * speed;
                transform.localScale = new Vector3(1, 1, 1);
                moveInputX = 1;
            }
            //moveVector *= Time.fixedDeltaTime;
            //rb.MovePosition(rb.position + moveVector);
            
            
            rb.linearVelocityX = moveInputX * speed;
            rb.linearVelocityY += moveInputY;
            
            moveInputY /= gravity;
            
        }
        public void Bounce(float BounceAmount)
        {
            rb.linearVelocityY = 0;
            moveInputY =  BounceAmount;
        }
        
    }
}
// FINISH MOVEMENT AND ADD MAP
// TILEMAP VIDEO
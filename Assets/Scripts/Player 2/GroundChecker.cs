using System;
using UnityEngine;

namespace Player_2
{
    public class GroundChecker : MonoBehaviour
    {
        public bool isTouchingGround = false;
        public event Action<bool> OnGroundTouched;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            isTouchingGround = true;
            OnGroundTouched?.Invoke(isTouchingGround);
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            isTouchingGround = false;
            OnGroundTouched?.Invoke(isTouchingGround);
        }

    }
}

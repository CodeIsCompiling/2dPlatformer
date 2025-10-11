using System;
using UnityEngine;

namespace Player_2
{
    public class WallChecker : MonoBehaviour
    {
        public bool isTouchingWall = false;
        public event Action<bool> OnWallTouched;

        private void OnTriggerEnter2D(Collider2D other)
        {
            isTouchingWall = true;
            OnWallTouched?.Invoke(isTouchingWall);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            isTouchingWall = false;
            OnWallTouched?.Invoke(isTouchingWall);
        }
        
    }
}

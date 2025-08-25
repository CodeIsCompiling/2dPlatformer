using System;
using UnityEngine;

namespace Shooter
{
    public class Projectile : MonoBehaviour
    {
        private Vector3 _moveDirection;
        private float _speed;
        // Update is called once per frame
        void FixedUpdate()
        {
            transform.position += _moveDirection * (Time.fixedDeltaTime * _speed);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(gameObject);
        }
        
        public void SetDirection(Vector3 dir)
        {
            _moveDirection = dir;
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }
    }
}

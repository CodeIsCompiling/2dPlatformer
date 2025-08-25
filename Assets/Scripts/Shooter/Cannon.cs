using UnityEngine;

namespace Shooter
{
    public class Cannon : MonoBehaviour
    {
        private float _time;
        [Range(0.05f, 10f)]public float speed = 1f;
        [Range(0.01f, 10)]public float spawnInterval;
        public Vector3 moveDirection;
        public Projectile projectilePrefab;
        // Update is called once per frame
        void Update()
        {
            _time += Time.deltaTime;
            if (_time >= spawnInterval)
            {
                _time -= spawnInterval;
                SpawnFireball();
            }
        }
        
        
        void SpawnFireball()
        {
            Projectile instance = Instantiate(projectilePrefab,  transform.position, Quaternion.identity);
            instance.SetDirection(moveDirection);
            instance.SetSpeed(speed);
        }
    }
}

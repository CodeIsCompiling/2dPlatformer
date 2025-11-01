using UnityEngine;
using UnityEngine.Pool;

namespace Player_2
{
    public class DashParticles : MonoBehaviour
    {
        private ObjectPool<DashParticles> _dashParticlesPool;
        

        public void SetPool(ObjectPool<DashParticles> pool)
        {
            _dashParticlesPool = pool;
        }
        public void ReturnToPool()
        {
            _dashParticlesPool.Release(this);
        }
    }
}

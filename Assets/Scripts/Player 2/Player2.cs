using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;

namespace Player_2
{
    public class Player2 : MonoBehaviour
    {
        [SerializeField] private DashParticles dashParticlePrefab;
        public ObjectPool<DashParticles> DashParticlesPool;
        [FormerlySerializedAs("PoolParent")] public Transform poolParent;
        private void Awake()
        {
            DashParticlesPool = new ObjectPool<DashParticles>(
                createFunc:CreateParticles, actionOnGet:OnGet, actionOnRelease:OnRelease, actionOnDestroy:OnDestroyed, defaultCapacity:16);
        }
        
        private void OnDestroyed(DashParticles obj)
        {
            
        }

        private void OnRelease(DashParticles obj)
        {
            obj.gameObject.SetActive(false);
        }

        private void OnGet(DashParticles obj)
        {
            obj.gameObject.SetActive(true);
        }

        private DashParticles CreateParticles()
        {
            DashParticles dashParticles = Instantiate(dashParticlePrefab, poolParent);
            dashParticles.SetPool(DashParticlesPool);
            return dashParticles;
        }
    }
}

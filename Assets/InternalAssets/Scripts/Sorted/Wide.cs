using UnityEngine;

namespace InternalAssets.Scripts
{
    public class Wide : MonoBehaviour, IPoolable
    {
        private WideObjectPool _pool;

        public void Initialize(WideObjectPool pool)
        {
            _pool = pool;
        }

        public void SetInPool()
        {
            _pool.Delete(gameObject);
        }
    }
}
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class WideObjectPool : ObjectPool<Wide>
    {
        [SerializeField] private GameObject _wide;

        private void Awake()
        {
            Clear();
        }

        public GameObject Create(Vector3 position, Quaternion rotation)
        {
            return base.Create(_wide, position, rotation);
        }
    }
}
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class Mover : MonoBehaviour
    {
        private const float speed = 6.255f;

        private bool _active = true;

        private void Update()
        {
            if (_active)
            {
                transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
            }
        }

        public void SetActive()
        {
            _active = true;
        }

        public void SetInactive()
        {
            _active = false;
        }
    }
}
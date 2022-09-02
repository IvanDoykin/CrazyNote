using UnityEngine;

namespace InternalAssets.Scripts
{
    public class Mover : MonoBehaviour
    {
        private const float speed = 6.255f;
        private void Update()
        {
            transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
        }
    }
}
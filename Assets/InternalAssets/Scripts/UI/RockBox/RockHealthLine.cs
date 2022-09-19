using UnityEngine;

namespace InternalAssets.Scripts
{
    public class RockHealthLine : MonoBehaviour
    {
        private const float minDegree = -35f;
        private const float maxDegree = 35f;

        public void RotateToDegree(float degree)
        {
            transform.eulerAngles = new Vector3(0f, 0f, degree);
        }
    }
}
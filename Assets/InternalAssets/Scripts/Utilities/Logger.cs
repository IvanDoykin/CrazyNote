using UnityEngine;
using UnityEngine.Serialization;

namespace InternalAssets.Scripts
{
    public class Logger : MonoBehaviour
    {
        [SerializeField] private bool _isActive;

        private void Awake()
        {
#if UNITY_EDITOR
            Debug.unityLogger.logEnabled = _isActive;
#else
        Debug.unityLogger.logEnabled = false;
#endif
        }
    }
}
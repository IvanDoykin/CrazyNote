using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : MonoBehaviour
{
    [SerializeField] private bool isActive;

    private void Awake()
    {
#if UNITY_EDITOR
        Debug.unityLogger.logEnabled = isActive;
#else
        Debug.unityLogger.logEnabled = false;
#endif
    }
}

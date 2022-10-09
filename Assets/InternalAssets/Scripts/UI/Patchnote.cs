using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InternalAssets.Scripts
{
    public class Patchnote : MonoBehaviour
    {
        private void Start()
        {
#if UNITY_EDITOR
            gameObject.SetActive(false);
#else
            gameObject.SetActive(true);
#endif
        }
    }
}
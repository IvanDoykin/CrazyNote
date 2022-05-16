using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public class GuitarAnimator : MonoBehaviour
    {
        private Material _material;

        private void Start()
        {
            _material = GetComponent<MeshRenderer>().material;
        }
        private void Update()
        {
            if (_material != null)
            {
                _material.SetTextureOffset("_MainTex", _material.GetTextureOffset("_MainTex") + new Vector2(0f, 0.667f * Time.deltaTime));
            }
        }
    }
}
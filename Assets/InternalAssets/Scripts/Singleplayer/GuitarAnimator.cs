using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public class GuitarAnimator : MonoBehaviour
    {
        private const string textureProperty = "_MainTex";
        private Material _material;

        private void Start()
        {
            _material = GetComponent<MeshRenderer>().material;
            _material.SetTextureOffset(textureProperty, new Vector2(0f, -0.5f));
        }

        private void Update()
        {
            if (_material != null)
            {
                _material.SetTextureOffset(textureProperty, _material.GetTextureOffset(textureProperty) + new Vector2(0f, 0.45f * Time.deltaTime));
            }
        }
    }
}
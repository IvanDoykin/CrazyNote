using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Singleplayer
{
    public class GuitarAnimator : MonoBehaviour
    {
        private Material _material;
        private float _clock = 0f;
        private bool kek = true;

        private void Start()
        {
            _material = GetComponent<MeshRenderer>().material;
            _material.SetTextureOffset("_MainTex", new Vector2(0f, -0.5f));
        }
        private void Update()
        {
            _clock += Time.deltaTime;
            if (_material != null)
            {
                _material.SetTextureOffset("_MainTex", _material.GetTextureOffset("_MainTex") + new Vector2(0f, 0.45f * Time.deltaTime));

                if (_material.GetTextureOffset("_MainTex").y >= 0.5f && kek)
                {
                    kek = false;
                    Debug.Log("clock = " + _clock);
                }
            }
        }
    }
}